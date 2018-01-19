using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace R19_BW_laczenia
{
    public partial class EditWindow : Form
    {
        public EditWindow(List<Item> _items, ItemType _itemType, MainWindow _mw)
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            // Zmiana wyglądu okienka
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = ImageLayout.Tile;
            this.BackgroundImage = Properties.Resources.Background_black;

            // Przypisz parametry do zmiennych globalnych
            LoadedItems = _items;
            LoadedItemsType = _itemType;
            mw = _mw;
            
            // Dodaj prefy, bazy i sufy typu załadowanych przedmiotów
            foreach (string s in LoadedItemsType.prefy) cbEditPref.Items.Add(s);
            foreach (string s in LoadedItemsType.bazy) cbEditBaza.Items.Add(s);
            foreach (string s in LoadedItemsType.sufy) cbEditSuf.Items.Add(s);

            // Wybierz pierwszy pref, bazę i suf
            cbEditPref.SelectedIndex = 0;
            cbEditBaza.SelectedIndex = 0;
            cbEditSuf.SelectedIndex = 0;

            // Dodaj załadowane przedmioty do comboBox'a
            foreach (Item i in LoadedItems) cbEditLoadedItems.Items.Add(UsunSpacje(i, LoadedItemsType));
            // Wybierz pierwszy przedmiot z listy załadowanych przedmiotów
            if (LoadedItems.Count > 0) cbEditLoadedItems.SelectedIndex = 0;
        }
        
        // Zmienne globalne listy przedmiotów i typu przedmiotów
        List<Item> LoadedItems;
        ItemType LoadedItemsType;

        // Obiekt okna głównego
        MainWindow mw;

        private void CbEditLoadedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Zaktualizuj pref, bazę i suf wybranego przedmiotu
            cbEditPref.SelectedIndex = LoadedItems[cbEditLoadedItems.SelectedIndex].pref;
            cbEditBaza.SelectedIndex = LoadedItems[cbEditLoadedItems.SelectedIndex].baza;
            cbEditSuf.SelectedIndex = LoadedItems[cbEditLoadedItems.SelectedIndex].suf;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            /// Podmiana prefiksu / bazy / sufiksu wybranego przedmiotu z listy załadowanych przedmiotów
            // Jeżeli nie ma przedmiotu do podmiany to wyjdź z funkcji
            if (LoadedItems.Count == 0) return;
            
            // Zapamiętaj indeks wybranego przedmiotu
            int index = cbEditLoadedItems.SelectedIndex;
            
            // Podmień wybrany przedmiot na przedmiot z wybranymi prefem, bazą i sufem
            LoadedItems[index].pref = cbEditPref.SelectedIndex;
            LoadedItems[index].baza = cbEditBaza.SelectedIndex;
            LoadedItems[index].suf = cbEditSuf.SelectedIndex;

            // Wyczyść listę załadowanych przedmiotów
            cbEditLoadedItems.Items.Clear();

            // Dodaj listę załadowanych przedmiotów
            foreach (Item i in LoadedItems) cbEditLoadedItems.Items.Add(UsunSpacje(i, LoadedItemsType));
            // Wybierz edytowany przedmiot
            cbEditLoadedItems.SelectedIndex = index;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            /// Dodanie nowego przedmiotu do listy załadowanych przedmiotów
            // Jeżeli nie wybrano prefiksu, bazy i sufiksu wyjdź z funkcji
            if (cbEditPref.SelectedIndex + cbEditBaza.SelectedIndex + cbEditSuf.SelectedIndex < 1) return;

            // Dodaj nowy przedmiot do listy załadowanych przedmiotów
            LoadedItems.Add(new Item(cbEditPref.SelectedIndex, cbEditBaza.SelectedIndex, cbEditSuf.SelectedIndex));

            // Wyczyść listę załadowanych przedmiotów
            cbEditLoadedItems.Items.Clear();

            // Dodaj listę załadowanych przedmiotów
            foreach (Item i in LoadedItems) cbEditLoadedItems.Items.Add(UsunSpacje(i, LoadedItemsType));
            // Wybierz nowo dodany przedmiot
            cbEditLoadedItems.SelectedIndex = LoadedItems.Count - 1;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            /// Usuń wybrany przedmiot z listy załadowanych przedmiotów
            // Jeżeli nie ma żadnych załadowanych przedmiotów to wyjdź z funkcji
            if (LoadedItems.Count == 0) return;

            // Usuń przedmiot
            LoadedItems.RemoveAt(cbEditLoadedItems.SelectedIndex);

            // Wyczyść listę załadowanych przedmiotów
            cbEditLoadedItems.Items.Clear();

            // Dodaj listę załadowanych przedmiotów
            foreach (Item i in LoadedItems) cbEditLoadedItems.Items.Add(UsunSpacje(i, LoadedItemsType));
            // Wybierz pierwszy przedmiot z listy
            if (LoadedItems.Count > 0) cbEditLoadedItems.SelectedIndex = 0;
        }

        private static string UsunSpacje(Item i, ItemType TypPrzedmiotu)
        {
            // Funkcja zwracająca prefiks, bazę i sufiks przedmiotu w postaci stringa bez niepotrzebnych spacji
            string s = "";
            if (i.pref != 0) s += TypPrzedmiotu.prefy.ElementAt(i.pref);
            if (i.pref != 0 && i.baza != 0) s += " ";
            if (i.baza != 0) s += TypPrzedmiotu.bazy.ElementAt(i.baza);
            if ((i.pref != 0 || i.baza != 0) && i.suf != 0) s += " ";
            if (i.suf != 0) s += TypPrzedmiotu.sufy.ElementAt(i.suf);
            return s;
        }

        private void EditWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Wywołaj funkcję UpdateLoadedItems okna głównego przekazując listę zaktualizowanych przedmiotów
            mw.UpdateLoadedItems(LoadedItems, LoadedItemsType);

            // Zamknij okno po kliknięciu "X" w prawym górnym rogu okna
            this.Dispose();
            this.Close();
        }
    }
}