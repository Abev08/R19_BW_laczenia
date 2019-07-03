using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Narzędzie_Blood_Wars___R19
{
    public partial class EditWindow : Window
    {
        public EditWindow(List<Item> _items, ItemType _itemType, MainWindow _mw)
        {
            InitializeComponent();

            // Przypisz parametry do zmiennych globalnych
            LoadedItems = _items;
            LoadedItemsType = _itemType;
            mw = _mw;

            // Dodaj prefy, bazy i sufy typu załadowanych przedmiotów
            foreach (string s in LoadedItemsType.pref) cbEditPref.Items.Add(s);
            foreach (string s in LoadedItemsType.baza) cbEditBaza.Items.Add(s);
            foreach (string s in LoadedItemsType.suf) cbEditSuf.Items.Add(s);

            // Wybierz pierwszy pref, bazę i suf
            cbEditPref.SelectedIndex = 0;
            cbEditBaza.SelectedIndex = 0;
            cbEditSuf.SelectedIndex = 0;

            foreach (Item i in LoadedItems) cbEditLoadedItems.Items.Add(i.ToString(LoadedItemsType)); // Dodaj załadowane przedmioty do comboBox'a
            if (LoadedItems.Count > 0) cbEditLoadedItems.SelectedIndex = 0; // Wybierz pierwszy przedmiot z listy załadowanych przedmiotów
        }

        // Zmienne globalne listy przedmiotów i typu przedmiotów
        List<Item> LoadedItems;
        ItemType LoadedItemsType;

        MainWindow mw; // Obiekt okna głównego

        private void CbEditLoadedItems_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            /// Zaktualizuj pref, bazę i suf wybranego przedmiotu
            if (cbEditLoadedItems.SelectedIndex == -1) return;
            cbEditPref.SelectedIndex = LoadedItems[cbEditLoadedItems.SelectedIndex].pref;
            cbEditBaza.SelectedIndex = LoadedItems[cbEditLoadedItems.SelectedIndex].baza;
            cbEditSuf.SelectedIndex = LoadedItems[cbEditLoadedItems.SelectedIndex].suf;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            /// Podmiana prefiksu / bazy / sufiksu wybranego przedmiotu z listy załadowanych przedmiotów
            if (LoadedItems.Count == 0) return; // Jeżeli nie ma przedmiotu do podmiany to wyjdź z funkcji
            int index = cbEditLoadedItems.SelectedIndex; // Zapamiętaj indeks wybranego przedmiotu
            LoadedItems[index].pref = cbEditPref.SelectedIndex; // Podmień wybrany przedmiot na przedmiot z wybranymi prefem, bazą i sufem
            LoadedItems[index].baza = cbEditBaza.SelectedIndex;
            LoadedItems[index].suf = cbEditSuf.SelectedIndex;
            cbEditLoadedItems.Items.Clear(); // Wyczyść listę załadowanych przedmiotów
            foreach (Item i in LoadedItems) cbEditLoadedItems.Items.Add(i.ToString(LoadedItemsType)); // Dodaj listę załadowanych przedmiotów
            cbEditLoadedItems.SelectedIndex = index; // Wybierz edytowany przedmiot
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            /// Dodanie nowego przedmiotu do listy załadowanych przedmiotów
            if (cbEditPref.SelectedIndex + cbEditBaza.SelectedIndex + cbEditSuf.SelectedIndex < 1) return; // Jeżeli nie wybrano prefiksu, bazy i sufiksu wyjdź z funkcji
            LoadedItems.Add(new Item(cbEditPref.SelectedIndex, cbEditBaza.SelectedIndex, cbEditSuf.SelectedIndex)); // Dodaj nowy przedmiot do listy załadowanych przedmiotów
            cbEditLoadedItems.Items.Clear(); // Wyczyść listę załadowanych przedmiotów
            foreach (Item i in LoadedItems) cbEditLoadedItems.Items.Add(i.ToString(LoadedItemsType)); // Dodaj listę załadowanych przedmiotów
            cbEditLoadedItems.SelectedIndex = LoadedItems.Count - 1; // Wybierz nowo dodany przedmiot
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            /// Usuń wybrany przedmiot z listy załadowanych przedmiotów
            if (LoadedItems.Count == 0) return; // Jeżeli nie ma żadnych załadowanych przedmiotów to wyjdź z funkcji
            LoadedItems.RemoveAt(cbEditLoadedItems.SelectedIndex); // Usuń przedmiot
            cbEditLoadedItems.Items.Clear(); // Wyczyść listę załadowanych przedmiotów
            foreach (Item i in LoadedItems) cbEditLoadedItems.Items.Add(i.ToString(LoadedItemsType)); // Dodaj listę załadowanych przedmiotów
            if (LoadedItems.Count > 0) cbEditLoadedItems.SelectedIndex = 0; // Wybierz pierwszy przedmiot z listy
        }

        private void MouseEnterFocus(object sender, MouseEventArgs e)
        {
            /// Ustawia focus na kontrolce przy najechaniu na nią myszką
            if (this.IsActive == false) return;
            ((ComboBox)sender).Focus();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /// Funkcja wywoływana przy zamykaniu okienka edycji przedmiotów
            mw.UpdateLoadedItems(LoadedItems, LoadedItemsType); // Wywołaj funkcję UpdateLoadedItems okna głównego przekazując listę zaktualizowanych przedmiotów
        }
    }
}