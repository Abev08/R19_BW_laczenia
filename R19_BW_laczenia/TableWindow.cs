using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace R19_BW_laczenia
{
    public partial class TableWindow : Form
    {
        public TableWindow()
        {
            InitializeComponent();

            // Zmiana ikony okienka
            this.Icon = Properties.Resources.Table_icon;

            IsOpen = true;
            tabTabela.Font = new Font("Segoe UI", 10);
            dgvFont = new Font("Segoe UI", fontSize);
        }

        public bool IsOpen = false;
        List<DataGridView> dgvList = new List<DataGridView>();
        Single fontSize = 9;
        Font dgvFont;

        public void AddTab(string name, List<string> baza)
        {
            // Sprawdź czy istnieje już tab o zadanej nazwie
            int temp = 0;
            foreach (TabPage TP in tabTabela.TabPages)
            {
                if (TP.Text == name)
                {
                    // Jeżeli istnieje to przełącz focus na niego
                    tabTabela.SelectedIndex = temp;
                    return;
                }
                temp++;
            }

            // Utwórz nowy tab i dodaj go do tabcontrol
            TabPage newTab = new TabPage(name);
            tabTabela.TabPages.Add(newTab);

            // Uwtórz nowy DataGridView
            dgvList.Add(new DataGridView());
            dgvList[dgvList.Count - 1].RowCount = baza.Count;
            dgvList[dgvList.Count - 1].ColumnCount = baza.Count;

            // Zapełnij go
            int wynik = 0;
            for (int i = 0; i < baza.Count; i++)
            {
                dgvList[dgvList.Count - 1].Rows[i].Cells[0].Value = baza[i];
                dgvList[dgvList.Count - 1].Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                dgvList[dgvList.Count - 1].Rows[0].Cells[i].Value = baza[i];
                dgvList[dgvList.Count - 1].Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;

                if (i > 0)
                {
                    dgvList[dgvList.Count - 1].Rows[i].Cells[i].Style.BackColor = Color.SkyBlue;

                    for (int j = 1; j < baza.Count; j++)
                    {
                        wynik = Polacz(i, j);
                        wynik = SprawdzWyjatki(baza, i, j, wynik);

                        dgvList[dgvList.Count - 1].Rows[i].Cells[j].Value = baza.ElementAt(wynik);
                    }
                }

                // Ustaw początkową wysokość wiersza na 20px
                dgvList[dgvList.Count - 1].Rows[i].Height = 20;
            }

            // Ustaw parametry DataGridView
            SetProps(dgvList[dgvList.Count - 1]);
            newTab.Controls.Add(dgvList[dgvList.Count - 1]);

            // Zmień focus taba na nowo utworzony i zaktualizuj wymiary okienka
            tabTabela.SelectedTab = newTab;
            UpdateDim();
        }

        private void SetProps(DataGridView dataGrid)
        {
            // Ustawienie właściwości kontrolki DataGridView
            dataGrid.ReadOnly = true;
            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.ColumnHeadersVisible = false;
            dataGrid.RowHeadersVisible = false;
            dataGrid.Dock = DockStyle.Fill;
            dataGrid.Font = dgvFont;
            dataGrid.DefaultCellStyle.SelectionBackColor = Color.PaleGreen;
            dataGrid.DefaultCellStyle.SelectionForeColor = Color.DarkRed;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Włączenie DoubleBuffered dla dataGridView
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(dataGrid, true, null);
            // Dodanie zdarzeń
            dataGrid.CellEnter += new DataGridViewCellEventHandler(DataGridView_CellEnter);
            dataGrid.CellLeave += new DataGridViewCellEventHandler(DataGridView_CellLeave);
        }

        private void UpdateDim()
        {
            // Uaktualnienie wymiarów okienka aby widoczne były wszystkie wiersze
            int maxRow = 0;
            int maxRowIndex = 0;

            if (dgvList.Count > 0)
            {
                for (int i = 0; i < dgvList.Count; i++)
                {
                    if (dgvList[i].RowCount > maxRow)
                    {
                        maxRow = dgvList[i].RowCount;
                        maxRowIndex = i;
                    }
                }

                this.Height = 90 + dgvList[maxRowIndex].Rows.GetRowsHeight(DataGridViewElementStates.None);  // obramowanie = 90 + wysokość wszystkich wierszy
                if (this.Height < 150) this.Height = 150;
                this.Width = Convert.ToInt32(this.Height * 1.78);   // szerokość do dopasowania do formatu 16:9
            }

            // Przenieś przyciski "+" i "-" na koniec okna
            panel1.Location = new Point(this.Width - panel1.Width - 21, 1);
        }

        private void TabPlus_Click(object sender, EventArgs e)
        {
            // Zwiększ rozmiar wyświetlanej czcionki i zaktualizuj czcionki DataGridView
            fontSize = fontSize + 1;
            dgvFont = new Font("Segoe UI", fontSize);

            foreach (DataGridView dgv in dgvList) dgv.Font = dgvFont;

            // Zaktualizuj rozmiar okna po zmianie rozmiaru czcionki
            UpdateDim();
        }

        private void TabMinus_Click(object sender, EventArgs e)
        {
            // Zwiększ rozmiar wyświetlanej czcionki i zaktualizuj czcionki DataGridView
            if (fontSize > 1) fontSize = fontSize - 1;
            dgvFont = new Font("Segoe UI", fontSize);

            foreach (DataGridView dgv in dgvList) dgv.Font = dgvFont;

            // Zaktualizuj rozmiar okna po zmianie rozmiaru czcionki
            UpdateDim();
        }

        private void TableWindow_Resize(object sender, EventArgs e)
        {
            // Po ręcznej zmianie wielkości okna zaktualizuj położenie przycisków "+" i "-"
            panel1.Location = new Point(this.Width - panel1.Width - 21, 1);
        }

        private void TabTabela_MouseUp(object sender, MouseEventArgs e)
        {
            // Zamknij kartę po kliknięciu na niej prawym przyciskiem myszy
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Middle)
            {
                for (int i = 0; i < tabTabela.TabCount; i++)
                {
                    if (tabTabela.GetTabRect(i).Contains(e.Location))
                    {
                        tabTabela.TabPages[i].Dispose();
                        dgvList.RemoveAt(i);
                        break;
                    }
                }

                if (tabTabela.TabCount > 0) UpdateDim();
            }
        }

        private int Polacz(int sk1, int sk2)
        {
            // Funkcja do łączenia przedmiotów
            int wynik = 0;
            double x = (double)sk1, y = (double)sk2;

            if ((int)x == 0 || (int)y == 0) wynik = 0;
            else if (x == y) wynik = (int)x;
            else wynik = Convert.ToInt32(Math.Ceiling((x + y) / 2d) + 1d);

            return wynik;
        }

        private int SprawdzWyjatki(List<string> B, int sk1, int sk2, int w)
        {
            // Sprawdzenie wyjątków przy łączeniach przy końcu tabeli
            if ((sk1 == (B.Count - 1)) && (sk2 == (B.Count - 2))) w = B.Count - 3;
            if ((sk1 == (B.Count - 2)) && (sk2 == (B.Count - 1))) w = B.Count - 3;
            if ((sk1 == (B.Count - 3)) && (sk2 == (B.Count - 1))) w = B.Count - 2;
            if ((sk1 == (B.Count - 1)) && (sk2 == (B.Count - 3))) w = B.Count - 2;
            return w;
        }

        private void DataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Jeżeli wybrano komórkę tabeli podświetl wiersz i kolumnę
            if ((e.RowIndex != 0) & (e.ColumnIndex != 0))
            {
                dgvList[tabTabela.SelectedIndex].Rows[e.RowIndex].Cells[0].Style.BackColor = Color.PaleGreen;
                dgvList[tabTabela.SelectedIndex].Rows[0].Cells[e.ColumnIndex].Style.BackColor = Color.PaleGreen;
            }
        }

        private void DataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Jeżeli opuszczono wybraną komórkę tabeli zresetuj podświetlenie wiersza i kolumny
            dgvList[tabTabela.SelectedIndex].Rows[e.RowIndex].Cells[0].Style.BackColor = Color.Gainsboro;
            dgvList[tabTabela.SelectedIndex].Rows[0].Cells[e.ColumnIndex].Style.BackColor = Color.Gainsboro;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Wywołane przy zamknięciu form'a
            dgvList.Clear();

            IsOpen = false;
            this.Dispose();
            this.Close();
        }
    }
}
