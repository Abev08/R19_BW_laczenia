using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Narzędzie_Blood_Wars___R19
{
    public partial class TableWindow : Window
    {
        public TableWindow()
        {
            InitializeComponent();

            IsOpen = true; // Flaga czy okno tabeli jest otwarte

            Tabs = new List<TabItem>(); // Lista wyświetlanych tabeli łączeń

            // Zmiana wyglądu tabelki
            Tabela.FontFamily = new FontFamily("Segoe UI");
            Tabela.FontSize = 13d;
            Tabela.Background = Brushes.LightGray;
            // for (int i = 0; i < Tabs.Count; i++) ApplyColors(Tabs[i].Content as DataGrid);

            // Ustawienie wyglądu okienka DataGrid
            CellStyle = new Style();
            CellStyle.Setters.Add(new Setter(TextBox.TextAlignmentProperty, TextAlignment.Center));
            CellStyle.Setters.Add(new Setter(BorderThicknessProperty, new Thickness(0.5d)));
            Trigger a = new Trigger { Property = DataGridCell.IsSelectedProperty, Value = true };
            a.Setters.Add(new Setter(ForegroundProperty, Brushes.DarkRed));
            CellStyle.Triggers.Add(a);
        }

        public bool IsOpen;
        List<TabItem> Tabs;
        const double RowHeight = 20d;
        readonly Style CellStyle;

        public void AddTab(string name, List<string> baza, bool helmetException = false)
        {
            /// Funkcja dodania nowej tabeli łaczeń
            // Sprawdź czy została wcześniej dodana dana tabela
            for (int i = 0; i < Tabs.Count; i++)
            {
                if (Tabs[i].Header.ToString() == name)
                {
                    Tabela.SelectedIndex = i;
                    return;
                }
            }

            Tabela.ItemsSource = null; // Zresetuj wyświetlaną listę elementów

            // Zapełnij tabelę łącząc ze sobą itemy
            string[,] table = new string[baza.Count, baza.Count];
            for (int i = 1; i < baza.Count; i++)
            {
                table[0, i] = baza[i];
                table[i, 0] = baza[i];

                for (int j = 1; j < baza.Count; j++)
                {
                    table[j, i] = baza.ElementAt(Item.Polacz(j, i, baza, helmetException));
                }
            }

            // Dodaj nową kartę tabeli
            Tabs.Add(new TabItem { Header = name, Content = ConvertToDataGrid(table) });
            Tabs[Tabs.Count - 1].MouseRightButtonUp += TableWindow_MouseRightButtonUp;
            Tabs[Tabs.Count - 1].Loaded += TableWindow_Loaded;

            // Zaktualizuj wyświetlaną listę elementów
            Tabela.ItemsSource = Tabs;
            Tabela.SelectedIndex = Tabs.Count - 1;

            UpdateDim();
        }

        private void TableWindow_Loaded(object sender, RoutedEventArgs e)
        {
            /// Zakończono wczytywanie nowej tabeli łączeń - ustaw w niej kolory
            ApplyColors(Tabs[Tabs.Count - 1].Content as DataGrid);
            (Tabs[Tabs.Count - 1].Content as DataGrid).UpdateLayout();
        }

        private void TableWindow_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            /// Zamknij kartę z tabeli łączeń
            for (int i = 0; i < Tabs.Count; i++)
            {
                if (Tabs[i].Header == ((TabItem)sender).Header)
                {
                    Tabela.ItemsSource = null; // Zresetuj wyświetlaną listę elementów
                    Tabs.RemoveAt(i);
                    Tabela.ItemsSource = Tabs; // Zaktualizuj wyświetlaną listę elementów
                    Tabela.SelectedIndex = 0;
                }
            }

            if (Tabs.Count > 0) UpdateDim();
        }

        private DataGrid ConvertToDataGrid(string[,] ls)
        {
            /// Konwertuje dwuwymiarową tablicę elementów na DataGrid możliwy do wyświetlenia
            DataGrid dg = new DataGrid();
            DataTable dt = new DataTable();
            for (int j = 0; j < ls.GetLength(1); j++) dt.Columns.Add(new DataColumn("Col " + j.ToString()));
            for (int i = 0; i < ls.GetLength(0); i++)
            {
                DataRow newRow = dt.NewRow();
                for (int j = 0; j < ls.GetLength(1); j++) newRow["Col " + j.ToString()] = ls[i, j];
                dt.Rows.Add(newRow);
            }

            dg.ItemsSource = dt.DefaultView;
            dg.IsReadOnly = true;
            dg.HeadersVisibility = DataGridHeadersVisibility.None;
            dg.SelectionUnit = DataGridSelectionUnit.Cell;
            dg.HorizontalAlignment = HorizontalAlignment.Left;
            dg.VerticalAlignment = VerticalAlignment.Top;
            dg.SelectedCellsChanged += Dg_SelectedCellsChanged;
            dg.RowHeight = RowHeight;
            dg.CellStyle = CellStyle;
            dg.Background = Brushes.LightGray;

            return dg;
        }

        private void UpdateDim()
        {
            /// Uaktualnienie wymiarów okienka aby widoczne były wszystkie wiersze
            int maxRow = 0;
            if (Tabs.Count > 0)
            {
                for (int i = 0; i < Tabs.Count; i++)
                {
                    if (((DataGrid)Tabs[i].Content).Items.Count > maxRow) maxRow = ((DataGrid)Tabs[i].Content).Items.Count;
                }

                this.Height = 90d + (RowHeight * maxRow);  // obramowanie = 90 + wysokość wszystkich wierszy
                if (this.Height > 720d) this.Height = 720d;
                this.Width = Convert.ToInt32(this.Height * 1.78d);   // szerokość do dopasowania do formatu 16:9
            }
        }

        private void Dg_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            // Funkcja wywoływana przy zmianie zaznaczonej kontrolki
            ApplyColors(sender as DataGrid);
        }

        private void ApplyColors(DataGrid dg)
        {
            DataGridRow row;
            DataGridCell cell;
            for (int i = 0; i < dg.Items.Count; i++)
            {
                for (int j = 0; j < dg.Items.Count; j++)
                {
                    row = dg.ItemContainerGenerator.ContainerFromItem(dg.Items[i]) as DataGridRow;
                    if (row == null) return;
                    cell = dg.Columns[j].GetCellContent(row).Parent as DataGridCell;

                    if (cell.IsSelected == true)
                    {
                        // Jeżeli komórka jest wybrana to pokoloruj ją na zielono oraz pierwszą komórkę w wierszu i kolumnie również pokoloruj na zielono
                        cell.Background = Brushes.PaleGreen;
                        row = dg.ItemContainerGenerator.ContainerFromItem(dg.Items[0]) as DataGridRow;
                        cell = dg.Columns[j].GetCellContent(row).Parent as DataGridCell;
                        cell.Background = Brushes.PaleGreen;
                        row = dg.ItemContainerGenerator.ContainerFromItem(dg.Items[i]) as DataGridRow;
                        cell = dg.Columns[0].GetCellContent(row).Parent as DataGridCell;
                        cell.Background = Brushes.PaleGreen;
                    }
                    else if (i == 0 || j == 0) cell.Background = Brushes.Gainsboro; // Komórka nie jest wybrana i sprawdzano pierwszy element z wiersza lub kolumny
                    else if (i == j) cell.Background = Brushes.SkyBlue; // Komórka nie jest wybrana i sprawdzano komórkę po przekątnej
                    else cell.Background = Brushes.Transparent; // Komórka nie jest wybrana i sprawdzano pozostałe komórki
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /// Funkcja wywoływana przy zamykaniu okeinka
            IsOpen = false;
        }
    }
}