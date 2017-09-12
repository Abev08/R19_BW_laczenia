using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace R19_BW_laczenia
{
    public partial class MainWindow : Form
    {
        // Listy prefiksów, baz i sufiksów każdego typu przedmiotów
        List<string> PrefHelm = new List<string>();
        List<string> BazaHelm = new List<string>();
        List<string> SufHelm = new List<string>();

        List<string> PrefZbroja = new List<string>();
        List<string> BazaZbroja = new List<string>();
        List<string> SufZbroja = new List<string>();

        List<string> PrefSpodnie = new List<string>();
        List<string> BazaSpodnie = new List<string>();
        List<string> SufSpodnie = new List<string>();

        List<string> PrefPierscien = new List<string>();
        List<string> BazaPierscien = new List<string>();
        List<string> SufPierscien = new List<string>();

        List<string> PrefAmulet = new List<string>();
        List<string> BazaAmulet = new List<string>();
        List<string> SufAmulet = new List<string>();

        List<string> PrefBiala1h = new List<string>();
        List<string> BazaBiala1h = new List<string>();
        List<string> SufBiala1h = new List<string>();

        List<string> PrefBiala2h = new List<string>();
        List<string> BazaBiala2h = new List<string>();
        List<string> SufBiala2h = new List<string>();

        List<string> PrefPalan1h = new List<string>();
        List<string> BazaPalna1h = new List<string>();
        List<string> SufPalna1h = new List<string>();

        List<string> PrefPalna2h = new List<string>();
        List<string> BazaPalna2h = new List<string>();
        List<string> SufPalna2h = new List<string>();

        List<string> PrefDystans = new List<string>();
        List<string> BazaDystans = new List<string>();
        List<string> SufDystans = new List<string>();

        // Zmienne do łączenia
        int[] component1 = new int[4];
        int[] component2 = new int[4];
        int[] result = new int[4];
        bool added = false;
        List<int[]> HistoriaPrzedmiotow = new List<int[]>();
        List<string> HistoriaLaczen = new List<string>();

        // Utworzenie obiektu tabeli łączeń (nowego Form'a)
        TableWindow Tabela;

        public MainWindow()
        {
            InitializeComponent();

            // Zmiana ikony Form'a
            this.Icon = Properties.Resources.Icon;

            // Załaduj bazy przedmiotów do list
            BazaHelmow(PrefHelm, BazaHelm, SufHelm);
            BazaZbroi(PrefZbroja, BazaZbroja, SufZbroja);
            BazaSpodni(PrefSpodnie, BazaSpodnie, SufSpodnie);
            BazaPierścieni(PrefPierscien, BazaPierscien, SufPierscien);
            BazaAmuletow(PrefAmulet, BazaAmulet, SufAmulet);
            BazaBialych1h(PrefBiala1h, BazaBiala1h, SufBiala1h);
            BazaBialych2h(PrefBiala2h, BazaBiala2h, SufBiala2h);
            BazaPalnych1h(PrefPalan1h, BazaPalna1h, SufPalna1h);
            BazaPalnych2h(PrefPalna2h, BazaPalna2h, SufPalna2h);
            BazaDystansow(PrefDystans, BazaDystans, SufDystans);

            // Dodaj "puste okno" do historii łączeń
            HistoriaLaczen.Add("");

            // Zmienne do zmian wyglądu
            Color bckColorTab = Color.Black; // Zmiana koloru tła z Transparent (przeźroczysty) niweluje migotanie przy TabControl
            Color bckColorRTB = Color.Gainsboro; // Kolor tła RichTextBox'a
            ImageLayout imgLayoutTab = ImageLayout.Tile;   // Wybór typu obrazu tła tab'u - kafelka
            Image bckPictureTab = Properties.Resources.Background_black;    // Obraz tła tab'u

            // Dodawanie prefiksów, baz i sufiksów do comboBox'ów
            // Hełm
            TabHelm.BackColor = bckColorTab;
            TabHelm.BackgroundImageLayout = imgLayoutTab;
            TabHelm.BackgroundImage = bckPictureTab;
            helmWynik.BackColor = bckColorRTB;
            helmWynik.ReadOnly = true;  // Ustawienie flagi Read Only
            helmWynik.ContextMenuStrip = contextMenuStrip1; // Dodanie menu prawego przycisku myszy
            foreach (string s in PrefHelm)
            {
                cbHelmPref.Items.Add(s);
                cbHelmPref_sh1.Items.Add(s);
                cbHelmPref_sh2.Items.Add(s);
                cbHelmPref_sh3.Items.Add(s);
            }
            cbHelmPref.SelectedIndex = 0;
            foreach (string s in BazaHelm)
            {
                cbHelmBaza.Items.Add(s);
                cbHelmBaza_sh1.Items.Add(s);
                cbHelmBaza_sh2.Items.Add(s);
                cbHelmBaza_sh3.Items.Add(s);
            }
            cbHelmBaza.SelectedIndex = 0;
            foreach (string s in SufHelm)
            {
                cbHelmSuf.Items.Add(s);
                cbHelmSuf_sh1.Items.Add(s);
                cbHelmSuf_sh2.Items.Add(s);
                cbHelmSuf_sh3.Items.Add(s);
            }
            cbHelmSuf.SelectedIndex = 0;

            // Zbroja
            TabZbroja.BackColor = bckColorTab;
            TabZbroja.BackgroundImageLayout = imgLayoutTab;
            TabZbroja.BackgroundImage = bckPictureTab;
            zbrojaWynik.BackColor = bckColorRTB;
            zbrojaWynik.ReadOnly = true;    // Ustawienie flagi Read Only
            zbrojaWynik.ContextMenuStrip = contextMenuStrip1;   // Dodanie menu prawego przycisku myszy
            foreach (string s in PrefZbroja)
            {
                cbZbrojaPref.Items.Add(s);
                cbZbrojaPref_sh1.Items.Add(s);
                cbZbrojaPref_sh2.Items.Add(s);
                cbZbrojaPref_sh3.Items.Add(s);
            }
            cbZbrojaPref.SelectedIndex = 0;
            foreach (string s in BazaZbroja)
            {
                cbZbrojaBaza.Items.Add(s);
                cbZbrojaBaza_sh1.Items.Add(s);
                cbZbrojaBaza_sh2.Items.Add(s);
                cbZbrojaBaza_sh3.Items.Add(s);
            }
            cbZbrojaBaza.SelectedIndex = 0;
            foreach (string s in SufZbroja)
            {
                cbZbrojaSuf.Items.Add(s);
                cbZbrojaSuf_sh1.Items.Add(s);
                cbZbrojaSuf_sh2.Items.Add(s);
                cbZbrojaSuf_sh3.Items.Add(s);
            }
            cbZbrojaSuf.SelectedIndex = 0;

            // Spodnie
            TabSpodnie.BackColor = bckColorTab;
            TabSpodnie.BackgroundImageLayout = imgLayoutTab;
            TabSpodnie.BackgroundImage = bckPictureTab;
            spodnieWynik.BackColor = bckColorRTB;
            spodnieWynik.ReadOnly = true;   // Ustawienie flagi Read Only
            spodnieWynik.ContextMenuStrip = contextMenuStrip1;  // Dodanie menu prawego przycisku myszy
            foreach (string s in PrefSpodnie)
            {
                cbSpodniePref.Items.Add(s);
                cbSpodniePref_sh1.Items.Add(s);
                cbSpodniePref_sh2.Items.Add(s);
                cbSpodniePref_sh3.Items.Add(s);
            }
            cbSpodniePref.SelectedIndex = 0;
            foreach (string s in BazaSpodnie)
            {
                cbSpodnieBaza.Items.Add(s);
                cbSpodnieBaza_sh1.Items.Add(s);
                cbSpodnieBaza_sh2.Items.Add(s);
                cbSpodnieBaza_sh3.Items.Add(s);
            }
            cbSpodnieBaza.SelectedIndex = 0;
            foreach (string s in SufSpodnie)
            {
                cbSpodnieSuf.Items.Add(s);
                cbSpodnieSuf_sh1.Items.Add(s);
                cbSpodnieSuf_sh2.Items.Add(s);
                cbSpodnieSuf_sh3.Items.Add(s);
            }
            cbSpodnieSuf.SelectedIndex = 0;

            // Pierścień
            TabPierscien.BackColor = bckColorTab;
            TabPierscien.BackgroundImageLayout = imgLayoutTab;
            TabPierscien.BackgroundImage = bckPictureTab;
            pierscienWynik.BackColor = bckColorRTB;
            pierscienWynik.ReadOnly = true;  // Ustawienie flagi Read Only
            pierscienWynik.ContextMenuStrip = contextMenuStrip1; // Dodanie menu prawego przycisku myszy
            foreach (string s in PrefPierscien)
            {
                cbPierscienPref.Items.Add(s);
                cbPierscienPref_sh1.Items.Add(s);
                cbPierscienPref_sh2.Items.Add(s);
                cbPierscienPref_sh3.Items.Add(s);
            }
            cbPierscienPref.SelectedIndex = 0;
            foreach (string s in BazaPierscien)
            {
                cbPierscienBaza.Items.Add(s);
                cbPierscienBaza_sh1.Items.Add(s);
                cbPierscienBaza_sh2.Items.Add(s);
                cbPierscienBaza_sh3.Items.Add(s);
            }
            cbPierscienBaza.SelectedIndex = 0;
            foreach (string s in SufPierscien)
            {
                cbPierscienSuf.Items.Add(s);
                cbPierscienSuf_sh1.Items.Add(s);
                cbPierscienSuf_sh2.Items.Add(s);
                cbPierscienSuf_sh3.Items.Add(s);
            }
            cbPierscienSuf.SelectedIndex = 0;

            // Amulet
            TabAmulet.BackColor = bckColorTab;
            TabAmulet.BackgroundImageLayout = imgLayoutTab;
            TabAmulet.BackgroundImage = bckPictureTab;
            amuletWynik.BackColor = bckColorRTB;
            amuletWynik.ReadOnly = true;  // Ustawienie flagi Read Only
            amuletWynik.ContextMenuStrip = contextMenuStrip1; // Dodanie menu prawego przycisku myszy
            foreach (string s in PrefAmulet)
            {
                cbAmuletPref.Items.Add(s);
                cbAmuletPref_sh1.Items.Add(s);
                cbAmuletPref_sh2.Items.Add(s);
                cbAmuletPref_sh3.Items.Add(s);
            }
            cbAmuletPref.SelectedIndex = 0;
            foreach (string s in BazaAmulet)
            {
                cbAmuletBaza.Items.Add(s);
                cbAmuletBaza_sh1.Items.Add(s);
                cbAmuletBaza_sh2.Items.Add(s);
                cbAmuletBaza_sh3.Items.Add(s);
            }
            cbAmuletBaza.SelectedIndex = 0;
            foreach (string s in SufAmulet)
            {
                cbAmuletSuf.Items.Add(s);
                cbAmuletSuf_sh1.Items.Add(s);
                cbAmuletSuf_sh2.Items.Add(s);
                cbAmuletSuf_sh3.Items.Add(s);
            }
            cbAmuletSuf.SelectedIndex = 0;

            // Biała 1h
            TabBiala1h.BackColor = bckColorTab;
            TabBiala1h.BackgroundImageLayout = imgLayoutTab;
            TabBiala1h.BackgroundImage = bckPictureTab;
            biala1hWynik.BackColor = bckColorRTB;
            biala1hWynik.ReadOnly = true;  // Ustawienie flagi Read Only
            biala1hWynik.ContextMenuStrip = contextMenuStrip1; // Dodanie menu prawego przycisku myszy
            foreach (string s in PrefBiala1h)
            {
                cbBiala1hPref.Items.Add(s);
                cbBiala1hPref_sh1.Items.Add(s);
                cbBiala1hPref_sh2.Items.Add(s);
                cbBiala1hPref_sh3.Items.Add(s);
            }
            cbBiala1hPref.SelectedIndex = 0;
            foreach (string s in BazaBiala1h)
            {
                cbBiala1hBaza.Items.Add(s);
                cbBiala1hBaza_sh1.Items.Add(s);
                cbBiala1hBaza_sh2.Items.Add(s);
                cbBiala1hBaza_sh3.Items.Add(s);
            }
            cbBiala1hBaza.SelectedIndex = 0;
            foreach (string s in SufBiala1h)
            {
                cbBiala1hSuf.Items.Add(s);
                cbBiala1hSuf_sh1.Items.Add(s);
                cbBiala1hSuf_sh2.Items.Add(s);
                cbBiala1hSuf_sh3.Items.Add(s);
            }
            cbBiala1hSuf.SelectedIndex = 0;

            // Biała 2h
            TabBiala2h.BackColor = bckColorTab;
            TabBiala2h.BackgroundImageLayout = imgLayoutTab;
            TabBiala2h.BackgroundImage = bckPictureTab;
            biala2hWynik.BackColor = bckColorRTB;
            biala2hWynik.ReadOnly = true;  // Ustawienie flagi Read Only
            biala2hWynik.ContextMenuStrip = contextMenuStrip1; // Dodanie menu prawego przycisku myszy
            foreach (string s in PrefBiala2h)
            {
                cbBiala2hPref.Items.Add(s);
                cbBiala2hPref_sh1.Items.Add(s);
                cbBiala2hPref_sh2.Items.Add(s);
                cbBiala2hPref_sh3.Items.Add(s);
            }
            cbBiala2hPref.SelectedIndex = 0;
            foreach (string s in BazaBiala2h)
            {
                cbBiala2hBaza.Items.Add(s);
                cbBiala2hBaza_sh1.Items.Add(s);
                cbBiala2hBaza_sh2.Items.Add(s);
                cbBiala2hBaza_sh3.Items.Add(s);
            }
            cbBiala2hBaza.SelectedIndex = 0;
            foreach (string s in SufBiala2h)
            {
                cbBiala2hSuf.Items.Add(s);
                cbBiala2hSuf_sh1.Items.Add(s);
                cbBiala2hSuf_sh2.Items.Add(s);
                cbBiala2hSuf_sh3.Items.Add(s);
            }
            cbBiala2hSuf.SelectedIndex = 0;

            // Palna 1h
            TabPalna1h.BackColor = bckColorTab;
            TabPalna1h.BackgroundImageLayout = imgLayoutTab;
            TabPalna1h.BackgroundImage = bckPictureTab;
            palna1hWynik.BackColor = bckColorRTB;
            palna1hWynik.ReadOnly = true;  // Ustawienie flagi Read Only
            palna1hWynik.ContextMenuStrip = contextMenuStrip1; // Dodanie menu prawego przycisku myszy
            foreach (string s in PrefPalan1h)
            {
                cbPalna1hPref.Items.Add(s);
                cbPalna1hPref_sh1.Items.Add(s);
                cbPalna1hPref_sh2.Items.Add(s);
                cbPalna1hPref_sh3.Items.Add(s);
            }
            cbPalna1hPref.SelectedIndex = 0;
            foreach (string s in BazaPalna1h)
            {
                cbPalna1hBaza.Items.Add(s);
                cbPalna1hBaza_sh1.Items.Add(s);
                cbPalna1hBaza_sh2.Items.Add(s);
                cbPalna1hBaza_sh3.Items.Add(s);
            }
            cbPalna1hBaza.SelectedIndex = 0;
            foreach (string s in SufPalna1h)
            {
                cbPalna1hSuf.Items.Add(s);
                cbPalna1hSuf_sh1.Items.Add(s);
                cbPalna1hSuf_sh2.Items.Add(s);
                cbPalna1hSuf_sh3.Items.Add(s);
            }
            cbPalna1hSuf.SelectedIndex = 0;

            // Palna 2h
            TabPalna2h.BackColor = bckColorTab;
            TabPalna2h.BackgroundImageLayout = imgLayoutTab;
            TabPalna2h.BackgroundImage = bckPictureTab;
            palna2hWynik.BackColor = bckColorRTB;
            palna2hWynik.ReadOnly = true;  // Ustawienie flagi Read Only
            palna2hWynik.ContextMenuStrip = contextMenuStrip1; // Dodanie menu prawego przycisku myszy
            foreach (string s in PrefPalna2h)
            {
                cbPalna2hPref.Items.Add(s);
                cbPalna2hPref_sh1.Items.Add(s);
                cbPalna2hPref_sh2.Items.Add(s);
                cbPalna2hPref_sh3.Items.Add(s);
            }
            cbPalna2hPref.SelectedIndex = 0;
            foreach (string s in BazaPalna2h)
            {
                cbPalna2hBaza.Items.Add(s);
                cbPalna2hBaza_sh1.Items.Add(s);
                cbPalna2hBaza_sh2.Items.Add(s);
                cbPalna2hBaza_sh3.Items.Add(s);
            }
            cbPalna2hBaza.SelectedIndex = 0;
            foreach (string s in SufPalna2h)
            {
                cbPalna2hSuf.Items.Add(s);
                cbPalna2hSuf_sh1.Items.Add(s);
                cbPalna2hSuf_sh2.Items.Add(s);
                cbPalna2hSuf_sh3.Items.Add(s);
            }
            cbPalna2hSuf.SelectedIndex = 0;

            // Dystans
            TabDystans.BackColor = bckColorTab;
            TabDystans.BackgroundImageLayout = imgLayoutTab;
            TabDystans.BackgroundImage = bckPictureTab;
            dystansWynik.BackColor = bckColorRTB;
            dystansWynik.ReadOnly = true;  // Ustawienie flagi Read Only
            dystansWynik.ContextMenuStrip = contextMenuStrip1; // Dodanie menu prawego przycisku myszy
            foreach (string s in PrefDystans)
            {
                cbDystansPref.Items.Add(s);
                cbDystansPref_sh1.Items.Add(s);
                cbDystansPref_sh2.Items.Add(s);
                cbDystansPref_sh3.Items.Add(s);
            }
            cbDystansPref.SelectedIndex = 0;
            foreach (string s in BazaDystans)
            {
                cbDystansBaza.Items.Add(s);
                cbDystansBaza_sh1.Items.Add(s);
                cbDystansBaza_sh2.Items.Add(s);
                cbDystansBaza_sh3.Items.Add(s);
            }
            cbDystansBaza.SelectedIndex = 0;
            foreach (string s in SufDystans)
            {
                cbDystansSuf.Items.Add(s);
                cbDystansSuf_sh1.Items.Add(s);
                cbDystansSuf_sh2.Items.Add(s);
                cbDystansSuf_sh3.Items.Add(s);
            }
            cbDystansSuf.SelectedIndex = 0;

            // Analizator raportu
            TabAnalizator.BackColor = bckColorTab;
            TabAnalizator.BackgroundImageLayout = imgLayoutTab;
            TabAnalizator.BackgroundImage = bckPictureTab;
            AnalizatorRaportuTekst.BackColor = bckColorRTB;
            AnalizatorRaportuTekst.ReadOnly = false;
            AnalizatorRaportuTekst.ContextMenuStrip = contextMenuStrip1;    // Dodanie menu prawego przycisku myszy
            ARzw0zw1.Text = Convert.ToString("Zwykły -> Zwykły (+1): 0/0");
            ARzw1zw2.Text = Convert.ToString("Zwykły (+1) -> Zwykły (+2): 0/0");
            ARzw2zw3.Text = Convert.ToString("Zwykły (+2) -> Zwykły (+3): 0/0");
            ARzw3zw4.Text = Convert.ToString("Zwykły (+3) -> Zwykły (+4): 0/0");
            ARzw4zw5.Text = Convert.ToString("Zwykły (+4) -> Zwykły (+5): 0/0");
            ARzw5db0.Text = Convert.ToString("Zwykły (+5) -> Dobry: 0/0");
            ARdb0db1.Text = Convert.ToString("Dobry -> Dobry (+1): 0/0");
            ARdb1db2.Text = Convert.ToString("Dobry (+1) -> Dobry (+2): 0/0");
            ARdb2db3.Text = Convert.ToString("Dobry (+2) -> Dobry (+3): 0/0");
            ARdb3db4.Text = Convert.ToString("Dobry (+3) -> Dobry (+4): 0/0");
            ARdb4db5.Text = Convert.ToString("Dobry (+4) -> Dobry (+5): 0/0");
            ARdb5dsk0.Text = Convert.ToString("Dobry (+5) -> Doskonały: 0/0");
            ARdsk0dsk1.Text = Convert.ToString("Doskonały -> Doskonały (+1): 0/0");
            ARdsk1dsk2.Text = Convert.ToString("Doskonały (+1) -> Doskonały (+2): 0/0");
            ARdsk2dsk3.Text = Convert.ToString("Doskonały (+2) -> Doskonały (+3): 0/0");
            ARdsk3dsk4.Text = Convert.ToString("Doskonały (+3) -> Doskonały (+4): 0/0");
            ARdsk4dsk5.Text = Convert.ToString("Doskonały (+4) -> Doskonały (+5): 0/0");

            // Wersja programu (tooltip na labelu "by Abev")
            toolTip1.SetToolTip(this.ByMe, "Wersja programu: 1.09.1\nProszę zgłaszać wszelkie błędy / sugestie :)");
        }

        private void Dodaj(ComboBox PrefCB, ComboBox BazaCB, ComboBox SufCB, RichTextBox Wynik, List<string> Pref, List<string> Baza, List<string> Suf)
        {
            // Dodaj snak sumy jeżeli dodano drugi przedmiot do łączenia
            if ((PrefCB.Text != "") || (BazaCB.Text != "") || (SufCB.Text != ""))
            {
                if (component1[3] == 1) Wynik.AppendText(" + ");
            }
            // Dodaj wybrany prefiks / bazę / sufiks do okienka z wynikiem
            if (PrefCB.Text != "")
            {
                Wynik.AppendText(PrefCB.Text);
                added = true;
            }
            if (BazaCB.Text != "")
            {
                if (PrefCB.Text != "") Wynik.AppendText(" ");
                Wynik.AppendText(BazaCB.Text);
                added = true;
            }
            if (SufCB.Text != "")
            {
                if (BazaCB.Text != "") Wynik.AppendText(" ");
                else if (PrefCB.Text != "") Wynik.AppendText(" ");
                Wynik.AppendText(SufCB.Text);
                added = true;
            }

            if (added)
            {
                added = false;

                if (component1[3] == 0)
                {
                    // Pierwszy składnik
                    component1[0] = Pref.IndexOf(PrefCB.Text);
                    component1[1] = Baza.IndexOf(BazaCB.Text);
                    component1[2] = Suf.IndexOf(SufCB.Text);
                    component1[3] = 1;
                    // Dodaj składnik do histori składników
                    HistoriaPrzedmiotow.Add(new int[] { component1[0], component1[1], component1[2], component1[3] });
                }
                else
                {
                    // Drugi składnik
                    component2[0] = Pref.IndexOf(PrefCB.Text);
                    component2[1] = Baza.IndexOf(BazaCB.Text);
                    component2[2] = Suf.IndexOf(SufCB.Text);
                    component2[3] = 1;
                    // Dodaj składnik do histori składników
                    HistoriaPrzedmiotow.Add(new int[] { component2[0], component2[1], component2[2], component2[3] });

                    // Połącz składniki
                    result = Polacz(component1[0], component1[1], component1[2], component2[0], component2[1], component2[2]);

                    // Sprawdź wyjątki przy łączeniu przy końcu tabeli łączeń
                    result[0] = SprawdzWyjatki(Pref, component1[0], component2[0], result[0]);
                    result[1] = SprawdzWyjatki(Baza, component1[1], component2[1], result[1]);
                    result[2] = SprawdzWyjatki(Suf, component1[2], component2[2], result[2]);

                    // Potraktuj wynik jako pierwszy składnik
                    component1 = new int[] { result[0], result[1], result[2], 1 };

                    // Dodaj składnik do histori składników
                    HistoriaPrzedmiotow.Add(new int[] { component1[0], component1[1], component1[2], component1[3] });
                    // Wyświetl wynik łączenia
                    Wynik.AppendText("\r= ");
                    if (result[0] != 0) Wynik.AppendText(Pref.ElementAt(result[0]));
                    if (result[0] != 0 && result[1] != 0) Wynik.AppendText(" ");
                    if (result[1] != 0) Wynik.AppendText(Baza.ElementAt(result[1]));
                    if (true)
                    {
                        if (result[1] != 0 && result[2] != 0) Wynik.AppendText(" ");
                        else if (result[0] != 0 && result[2] != 0) Wynik.AppendText(" ");
                    }
                    if (result[2] != 0) Wynik.AppendText(Suf.ElementAt(result[2]));
                }

                // Dodaj łączenie do historii łączeń 
                HistoriaLaczen.Add(Wynik.Text);
            }

            // Przesuń kursor na koniec tekstu (jeżeli dodano tekst poniżej widocznego pola, "przescrolluj na sam dół")
            Wynik.ScrollToCaret();
            // Uaktualnij "wynik łączenia aktualizowany na bierząco"
            ZmienLabel();
        }

        private int[] Polacz(int pref1, int baza1, int suf1, int pref2, int baza2, int suf2)
        {
            int[] wynik = new int[4];
            double x = 0, y = 0;

            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        x = pref1;
                        y = pref2;
                        break;
                    case 1:
                        x = baza1;
                        y = baza2;
                        break;
                    case 2:
                        x = suf1;
                        y = suf2;
                        break;
                }

                if ((int)x == 0 || (int)y == 0) wynik[i] = 0;
                else if (x == y) wynik[i] = (int)x;
                else if (true) wynik[i] = Convert.ToInt32(Math.Ceiling((x + y) / 2) + 1);
            }

            return wynik;
        }

        private void HelmDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbHelmPref, cbHelmBaza, cbHelmSuf, helmWynik, PrefHelm, BazaHelm, SufHelm);
        }

        private void ZbrojaDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbZbrojaPref, cbZbrojaBaza, cbZbrojaSuf, zbrojaWynik, PrefZbroja, BazaZbroja, SufZbroja);
        }

        private void SpodnieDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbSpodniePref, cbSpodnieBaza, cbSpodnieSuf, spodnieWynik, PrefSpodnie, BazaSpodnie, SufSpodnie);
        }

        private void PierscienDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbPierscienPref, cbPierscienBaza, cbPierscienSuf, pierscienWynik, PrefPierscien, BazaPierscien, SufPierscien);
        }

        private void AmuletDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbAmuletPref, cbAmuletBaza, cbAmuletSuf, amuletWynik, PrefAmulet, BazaAmulet, SufAmulet);
        }

        private void Biala1hDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbBiala1hPref, cbBiala1hBaza, cbBiala1hSuf, biala1hWynik, PrefBiala1h, BazaBiala1h, SufBiala1h);
        }

        private void Biala2hDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbBiala2hPref, cbBiala2hBaza, cbBiala2hSuf, biala2hWynik, PrefBiala2h, BazaBiala2h, SufBiala2h);
        }

        private void Palna1hDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbPalna1hPref, cbPalna1hBaza, cbPalna1hSuf, palna1hWynik, PrefPalan1h, BazaPalna1h, SufPalna1h);
        }

        private void Palna2hDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbPalna2hPref, cbPalna2hBaza, cbPalna2hSuf, palna2hWynik, PrefPalna2h, BazaPalna2h, SufPalna2h);
        }

        private void DystansDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbDystansPref, cbDystansBaza, cbDystansSuf, dystansWynik, PrefDystans, BazaDystans, SufDystans);
        }

        private void InicjalizacjaTabeli(TableWindow Tab, List<string> baza, string disp)
        {
            int[] resultTable = new int[4];

            if (Tab != null)
            {
                Tab.IsOpen = false;
                Tab.Dispose();
                Tab.Close();
            }

            Tabela = new TableWindow();
            Tabela.DisplayedTable = disp;
            Tabela.DataGridView.RowCount = baza.Count();
            Tabela.DataGridView.ColumnCount = baza.Count();
            Tabela.Height = 60 + (Tabela.DataGridView.RowCount * Tabela.DataGridView.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
            if (Tabela.Height < 150) Tabela.Height = 150;
            Tabela.Width = Convert.ToInt32(Tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

            for (int i = 0; i < baza.Count(); i++)
            {
                Tabela.DataGridView.Rows[i].Cells[0].Value = baza[i];
                Tabela.DataGridView.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                Tabela.DataGridView.Rows[0].Cells[i].Value = baza[i];
                Tabela.DataGridView.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;

                if (i > 0)
                {
                    Tabela.DataGridView.Rows[i].Cells[i].Style.BackColor = Color.SkyBlue;

                    for (int j = 1; j < baza.Count(); j++)
                    {
                        if ((i == (baza.Count - 1)) & (j == (baza.Count - 2))) resultTable[0] = baza.Count - 3; // wyjątki
                        else if ((i == (baza.Count - 2)) & (j == (baza.Count - 1))) resultTable[0] = baza.Count - 3;
                        else if ((i == (baza.Count - 3)) & (j == (baza.Count - 1))) resultTable[0] = baza.Count - 2;
                        else if ((i == (baza.Count - 1)) & (j == (baza.Count - 3))) resultTable[0] = baza.Count - 2;
                        else if (true) resultTable = Polacz(i, 0, 0, j, 0, 0);

                        Tabela.DataGridView.Rows[i].Cells[j].Value = baza.ElementAt(resultTable[0]);
                    }
                }
            }
            Tabela.Show();
        }

        private void prefHelmPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "PrefHelm") InicjalizacjaTabeli(Tabela, PrefHelm, "PrefHelm");
            else Tabela.BringToFront();
        }

        private void bazaHelmPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "BazaHelm") InicjalizacjaTabeli(Tabela, BazaHelm, "BazaHelm");
            else Tabela.BringToFront();
        }

        private void sufHelmPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "SufHelm") InicjalizacjaTabeli(Tabela, SufHelm, "SufHelm");
            else Tabela.BringToFront();
        }

        private void prefZbrojaPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "PrefZbroja") InicjalizacjaTabeli(Tabela, PrefZbroja, "PrefZbroja");
            else Tabela.BringToFront();
        }

        private void bazaZbrojaPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "BazaZbroja") InicjalizacjaTabeli(Tabela, BazaZbroja, "BazaZbroja");
            else Tabela.BringToFront();
        }

        private void sufZbrojaPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "SufZbroja") InicjalizacjaTabeli(Tabela, SufZbroja, "SufZbroja");
            else Tabela.BringToFront();
        }

        private void prefSpodniePanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "PrefSpodnie") InicjalizacjaTabeli(Tabela, PrefSpodnie, "PrefSpodnie");
            else Tabela.BringToFront();
        }

        private void bazaSpodniePanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "BazaSpodnie") InicjalizacjaTabeli(Tabela, BazaSpodnie, "BazaSpodnie");
            else Tabela.BringToFront();
        }

        private void sufSpodniePanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "SufSpodnie") InicjalizacjaTabeli(Tabela, SufSpodnie, "SufSpodnie");
            else Tabela.BringToFront();
        }

        private void prefPierscienPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "PrefPierscien") InicjalizacjaTabeli(Tabela, PrefPierscien, "PrefPierscien");
            else Tabela.BringToFront();
        }

        private void bazaPierscienPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "BazaPierscien") InicjalizacjaTabeli(Tabela, BazaPierscien, "BazaPierscien");
            else Tabela.BringToFront();
        }

        private void sufPierscienPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "SufPierscien") InicjalizacjaTabeli(Tabela, SufPierscien, "SufPierscien");
            else Tabela.BringToFront();
        }

        private void prefAmuletPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "PrefAmulet") InicjalizacjaTabeli(Tabela, PrefAmulet, "PrefAmulet");
            else Tabela.BringToFront();
        }

        private void bazaAmuletPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "BazaAmulet") InicjalizacjaTabeli(Tabela, BazaAmulet, "BazaAmulet");
            else Tabela.BringToFront();
        }

        private void sufAmuletPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "SufAmulet") InicjalizacjaTabeli(Tabela, SufAmulet, "SufAmulet");
            else Tabela.BringToFront();
        }

        private void prefBiala1hPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "PrefBiala1h") InicjalizacjaTabeli(Tabela, PrefBiala1h, "PrefBiala1h");
            else Tabela.BringToFront();
        }

        private void bazaBiala1hPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "BazaBiala1h") InicjalizacjaTabeli(Tabela, BazaBiala1h, "BazaBiala1h");
            else Tabela.BringToFront();
        }

        private void sufBiala1hPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "SufBiala1h") InicjalizacjaTabeli(Tabela, SufBiala1h, "SufBiala1h");
            else Tabela.BringToFront();
        }

        private void prefBiala2hPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "PrefBiala2h") InicjalizacjaTabeli(Tabela, PrefBiala2h, "PrefBiala2h");
            else Tabela.BringToFront();
        }

        private void bazaBiala2hPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "BazaBiala2h") InicjalizacjaTabeli(Tabela, BazaBiala2h, "BazaBiala2h");
            else Tabela.BringToFront();
        }

        private void sufBiala2hPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "SufBiala2h") InicjalizacjaTabeli(Tabela, SufBiala2h, "SufBiala2h");
            else Tabela.BringToFront();
        }

        private void prefPalna1hPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "PrefPalna1h") InicjalizacjaTabeli(Tabela, PrefPalan1h, "PrefPalna1h");
            else Tabela.BringToFront();
        }

        private void bazaPalna1hPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "BazaPalna1h") InicjalizacjaTabeli(Tabela, BazaPalna1h, "BazaPalna1h");
            else Tabela.BringToFront();
        }

        private void sufPalna1hPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "SufPalna1h") InicjalizacjaTabeli(Tabela, SufPalna1h, "SufPalna1h");
            else Tabela.BringToFront();
        }

        private void prefPalna2hPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "PrefPalna2h") InicjalizacjaTabeli(Tabela, PrefPalna2h, "PrefPalna2h");
            else Tabela.BringToFront();
        }

        private void bazaPalna2hPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "BazaPalna2h") InicjalizacjaTabeli(Tabela, BazaPalna2h, "BazaPalna2h");
            else Tabela.BringToFront();
        }

        private void sufPalna2hPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "SufPalna2h") InicjalizacjaTabeli(Tabela, SufPalna2h, "SufPalna2h");
            else Tabela.BringToFront();
        }

        private void prefDystansPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "PrefDystans") InicjalizacjaTabeli(Tabela, PrefDystans, "PrefDystans");
            else Tabela.BringToFront();
        }

        private void bazaDystansPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "BazaDystans") InicjalizacjaTabeli(Tabela, BazaDystans, "BazaDystans");
            else Tabela.BringToFront();
        }

        private void sufDystansPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false || Tabela.DisplayedTable != "SufDystans") InicjalizacjaTabeli(Tabela, SufDystans, "SufDystans");
            else Tabela.BringToFront();
        }

        private void GlownyTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            Czyszczenie();
        }

        private void WyczyscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Czyszczenie();
        }

        private void Czyszczenie()
        {
            // Czyszczenie składników i okienek wyników po przepłączeniu zakładki
            component1 = new int[] { 0, 0, 0, 0 };
            component2 = new int[] { 0, 0, 0, 0 };
            result = new int[] { 0, 0, 0, 0 };
            added = false;

            helmWynik.Clear();
            zbrojaWynik.Clear();
            spodnieWynik.Clear();
            pierscienWynik.Clear();
            amuletWynik.Clear();
            biala1hWynik.Clear();
            biala2hWynik.Clear();
            palna1hWynik.Clear();
            palna2hWynik.Clear();
            dystansWynik.Clear();
            AnalizatorRaportuTekst.Clear();

            // czyszczenie labeli
            PrefHelmL.Text = "";
            BazaHelmL.Text = "";
            SufHelmL.Text = "";
            PrefZbrojaL.Text = "";
            BazaZbrojaL.Text = "";
            SufZbrojaL.Text = "";
            PrefSpodnieL.Text = "";
            BazaSpodnieL.Text = "";
            SufSpodnieL.Text = "";
            PrefPierscienL.Text = "";
            BazaPierscienL.Text = "";
            SufPierscienL.Text = "";
            PrefAmuletL.Text = "";
            BazaAmuletL.Text = "";
            SufAmuletL.Text = "";
            PrefBiala1hL.Text = "";
            BazaBiala1hL.Text = "";
            SufBiala1hL.Text = "";
            PrefBiala2hL.Text = "";
            BazaBiala2hL.Text = "";
            SufBiala2hL.Text = "";
            PrefPalna1hL.Text = "";
            BazaPalna1hL.Text = "";
            SufPalna1hL.Text = "";
            PrefPalna2hL.Text = "";
            BazaPalna2hL.Text = "";
            SufPalna2hL.Text = "";
            PrefDystansL.Text = "";
            BazaDystansL.Text = "";
            SufDystansL.Text = "";

            // Czyszczenie historii
            HistoriaLaczen.Clear();
            HistoriaLaczen.Add("");
            HistoriaPrzedmiotow.Clear();
        }

        private void KopiujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kopiuj zaznaczony tekst do schowka systemowego
            switch (GlownyTab.SelectedTab.Text)
            {
                case "Hełm":
                    helmWynik.Copy();
                    break;
                case "Zbroja":
                    zbrojaWynik.Copy();
                    break;
                case "Spodnie":
                    spodnieWynik.Copy();
                    break;
                case "Pierścień":
                    pierscienWynik.Copy();
                    break;
                case "Amulet":
                    amuletWynik.Copy();
                    break;
                case "Biała 1h":
                    biala1hWynik.Copy();
                    break;
                case "Biała 2h":
                    biala2hWynik.Copy();
                    break;
                case "Palna 1h":
                    palna1hWynik.Copy();
                    break;
                case "Palna 2h":
                    palna2hWynik.Copy();
                    break;
                case "Dystans":
                    dystansWynik.Copy();
                    break;
                case "Analizator raportu":
                    AnalizatorRaportuTekst.Copy();
                    break;
            }
        }

        private void KopiujWszystkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kopiuj wszystko do schowka systemowego
            switch (GlownyTab.SelectedTab.Text)
            {
                case "Hełm":
                    helmWynik.SelectAll();
                    helmWynik.Copy();
                    break;
                case "Zbroja":
                    zbrojaWynik.SelectAll();
                    zbrojaWynik.Copy();
                    break;
                case "Spodnie":
                    spodnieWynik.SelectAll();
                    spodnieWynik.Copy();
                    break;
                case "Pierścień":
                    pierscienWynik.SelectAll();
                    pierscienWynik.Copy();
                    break;
                case "Amulet":
                    amuletWynik.SelectAll();
                    amuletWynik.Copy();
                    break;
                case "Biała 1h":
                    biala1hWynik.SelectAll();
                    biala1hWynik.Copy();
                    break;
                case "Biała 2h":
                    biala2hWynik.SelectAll();
                    biala2hWynik.Copy();
                    break;
                case "Palna 1h":
                    palna1hWynik.SelectAll();
                    palna1hWynik.Copy();
                    break;
                case "Palna 2h":
                    palna2hWynik.SelectAll();
                    palna2hWynik.Copy();
                    break;
                case "Dystans":
                    dystansWynik.SelectAll();
                    dystansWynik.Copy();
                    break;
                case "Analizator raportu":
                    AnalizatorRaportuTekst.SelectAll();
                    AnalizatorRaportuTekst.Copy();
                    break;
            }
        }

        private void ZapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Zapisz zaznaczony tekst do pliku, domyślnie format .txt
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text Files (*.txt)|*.txt|All Files|*.*";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (Stream a = File.Open(saveFile.FileName, FileMode.Create))
                using (StreamWriter aa = new StreamWriter(a))
                {
                    switch (GlownyTab.SelectedTab.Text)
                    {
                        case "Hełm":
                            aa.Write(helmWynik.Text);
                            break;
                        case "Zbroja":
                            aa.Write(zbrojaWynik.Text);
                            break;
                        case "Spodnie":
                            aa.Write(spodnieWynik.Text);
                            break;
                        case "Pierścień":
                            aa.Write(pierscienWynik.Text);
                            break;
                        case "Amulet":
                            aa.Write(amuletWynik.Text);
                            break;
                        case "Biała 1h":
                            aa.Write(biala1hWynik.Text);
                            break;
                        case "Biała 2h":
                            aa.Write(biala2hWynik.Text);
                            break;
                        case "Palna 1h":
                            aa.Write(palna1hWynik.Text);
                            break;
                        case "Palna 2h":
                            aa.Write(palna2hWynik.Text);
                            break;
                        case "Dystans":
                            aa.Write(dystansWynik.Text);
                            break;
                        case "Analizator raportu":
                            aa.Write(AnalizatorRaportuTekst.Text);
                            break;
                    }
                }
            }
        }

        private void AnalizatorRaportuOblicz_Click(object sender, EventArgs e)
        {
            // Przeprowadź analizę raportu
            // Zmienne do przechowywania całkowitej ilości ulepszeń i ilości udanych ulepszeń
            int zw0zw1 = 0, zw0zw1c = 0;
            int zw1zw2 = 0, zw1zw2c = 0;
            int zw2zw3 = 0, zw2zw3c = 0;
            int zw3zw4 = 0, zw3zw4c = 0;
            int zw4zw5 = 0, zw4zw5c = 0;
            int zw5db0 = 0, zw5db0c = 0;
            int db0db1 = 0, db0db1c = 0;
            int db1db2 = 0, db1db2c = 0;
            int db2db3 = 0, db2db3c = 0;
            int db3db4 = 0, db3db4c = 0;
            int db4db5 = 0, db4db5c = 0;
            int db5dsk0 = 0, db5dsk0c = 0;
            int dsk0dsk1 = 0, dsk0dsk1c = 0;
            int dsk1dsk2 = 0, dsk1dsk2c = 0;
            int dsk2dsk3 = 0, dsk2dsk3c = 0;
            int dsk3dsk4 = 0, dsk3dsk4c = 0;
            int dsk4dsk5 = 0, dsk4dsk5c = 0;
            // Podziel tekst na wiersze
            string[] ulepszenia = AnalizatorRaportuTekst.Text.Split('\n');

            // W każdym wierszu spróbuj wyszukać odpowiedni ciąg znaków (odpowiednie słowa)
            // i na ich podstawie zwiększ odpowiednie zmienne
            for (int i = 0; i < ulepszenia.Count(); i++)
            {
                if (ulepszenia[i].Contains("Ulepszono przedmiot"))
                {
                    if (ulepszenia[i].Contains("Doskonał") & ulepszenia[i].Contains("Dobr"))
                    {
                        // ulepszenie dobry -> dsk
                        db5dsk0++;
                        db5dsk0c++;
                    }
                    else if (ulepszenia[i].Contains("Doskonał"))
                    {
                        // ulepszanie dsk -> dsk
                        if (ulepszenia[i].Contains("(+4)") & ulepszenia[i].Contains("(+5)"))
                        {
                            // Doskonały (+4) -> Doskonały (+5)
                            dsk4dsk5++;
                            dsk4dsk5c++;
                        }
                        else if (ulepszenia[i].Contains("(+3)") & ulepszenia[i].Contains("(+4)"))
                        {
                            // Doskonały (+3) -> Doskonały (+4)
                            dsk3dsk4++;
                            dsk3dsk4c++;
                        }
                        else if (ulepszenia[i].Contains("(+2)") & ulepszenia[i].Contains("(+3)"))
                        {
                            // Doskonały (+2) -> Doskonały (+3)
                            dsk2dsk3++;
                            dsk2dsk3c++;
                        }
                        else if (ulepszenia[i].Contains("(+1)") & ulepszenia[i].Contains("(+2)"))
                        {
                            // Doskonały (+1) -> Doskonały (+2)
                            dsk1dsk2++;
                            dsk1dsk2c++;
                        }
                        else if (ulepszenia[i].Contains("(+1)") & !ulepszenia[i].Contains(("+2")))
                        {
                            // Doskonały -> Doskonały (+1)
                            dsk0dsk1++;
                            dsk0dsk1c++;
                        }
                    }
                    else if (ulepszenia[i].Contains("Dobr"))
                    {
                        // ulepszanie zwykły -> dobry i dobry -> dobry
                        if (ulepszenia[i].Contains("(+4)") & ulepszenia[i].Contains("(+5)"))
                        {
                            // Dobry (+4) -> Dobry (+5)
                            db4db5++;
                            db4db5c++;
                        }
                        else if (ulepszenia[i].Contains("(+3)") & ulepszenia[i].Contains("(+4)"))
                        {
                            // Dobry (+3) -> Dobry (+4)
                            db3db4++;
                            db3db4c++;
                        }
                        else if (ulepszenia[i].Contains("(+2)") & ulepszenia[i].Contains("(+3)"))
                        {
                            // Dobry (+2) -> Dobry (+3)
                            db2db3++;
                            db2db3c++;
                        }
                        else if (ulepszenia[i].Contains("(+1)") & ulepszenia[i].Contains("(+2)"))
                        {
                            // Dobry (+1) -> Dobry (+2)
                            db1db2++;
                            db1db2c++;
                        }
                        else if (ulepszenia[i].Contains("(+1)"))
                        {
                            // Dobry -> Dobry (+1)
                            db0db1++;
                            db0db1c++;
                        }
                        else if (ulepszenia[i].Contains("(+5)"))
                        {
                            // Zwykły (+5) -> Dobry
                            zw5db0++;
                            zw5db0c++;
                        }
                    }
                    else
                    {
                        // ulepszanie zwykły
                        if (ulepszenia[i].Contains("(+4)") & ulepszenia[i].Contains("(+5)"))
                        {
                            // Zwykły (+4) -> Zwykły (+5)
                            zw4zw5++;
                            zw4zw5c++;
                        }
                        else if (ulepszenia[i].Contains("(+3)") & ulepszenia[i].Contains("(+4)"))
                        {
                            // Zwykły (+3) -> Zwykły (+4)
                            zw3zw4++;
                            zw3zw4c++;
                        }
                        else if (ulepszenia[i].Contains("(+2)") & ulepszenia[i].Contains("(+3)"))
                        {
                            // Zwykły (+2) -> Zwykły (+3)
                            zw2zw3++;
                            zw2zw3c++;
                        }
                        else if (ulepszenia[i].Contains("(+1)") & ulepszenia[i].Contains("(+2)"))
                        {
                            // Zwykły (+1) -> Zwykły (+2)
                            zw1zw2++;
                            zw1zw2c++;
                        }
                        else if (ulepszenia[i].Contains("(+1)") & !ulepszenia[i].Contains("(+2)"))
                        {
                            // Zwykły -> Zwykły (+1)
                            zw0zw1++;
                            zw0zw1c++;
                        }
                    }
                }

                if (ulepszenia[i].Contains("nie został ulepszony"))
                {
                    if (ulepszenia[i].Contains("Doskonał"))
                    {
                        // Niepowodzenie ulepszenia przedmiotu doskonałego
                        if (ulepszenia[i].Contains("(+4)")) dsk4dsk5c++;
                        else if (ulepszenia[i].Contains("(+3)")) dsk3dsk4c++;
                        else if (ulepszenia[i].Contains("(+2)")) dsk2dsk3c++;
                        else if (ulepszenia[i].Contains("(+1)")) dsk1dsk2c++;
                        else if (!ulepszenia[i].Contains("(+1)")) dsk0dsk1c++;
                    }
                    else if (ulepszenia[i].Contains("Dobr"))
                    {
                        // Niepowodzenie ulepszenia przedmiotu dobrego
                        if (ulepszenia[i].Contains("(+5)")) db5dsk0c++;
                        else if (ulepszenia[i].Contains("(+4)")) db4db5c++;
                        else if (ulepszenia[i].Contains("(+3)")) db3db4c++;
                        else if (ulepszenia[i].Contains("(+2)")) db2db3c++;
                        else if (ulepszenia[i].Contains("(+1)")) db1db2c++;
                        else if (!ulepszenia[i].Contains("(+1)")) db0db1c++;
                    }
                    else if (true)
                    {
                        // Niepowodzenie ulepszenia przedmiotu zwykłego
                        if (ulepszenia[i].Contains("(+5)")) zw5db0c++;
                        else if (ulepszenia[i].Contains("(+4)")) zw4zw5c++;
                        else if (ulepszenia[i].Contains("(+3)")) zw3zw4c++;
                        else if (ulepszenia[i].Contains("(+2)")) zw2zw3c++;
                        else if (ulepszenia[i].Contains("(+1)")) zw1zw2c++;
                        else if (!ulepszenia[i].Contains("(+1)")) zw0zw1c++;
                    }
                }

                // Wyświetl przeanalizowane ulepszenia
                ARzw0zw1.Text = Convert.ToString("Zwykły -> Zwykły (+1): " + zw0zw1 + "/" + zw0zw1c);
                ARzw1zw2.Text = Convert.ToString("Zwykły (+1) -> Zwykły (+2): " + zw1zw2 + "/" + zw1zw2c);
                ARzw2zw3.Text = Convert.ToString("Zwykły (+2) -> Zwykły (+3): " + zw2zw3 + "/" + zw2zw3c);
                ARzw3zw4.Text = Convert.ToString("Zwykły (+3) -> Zwykły (+4): " + zw3zw4 + "/" + zw3zw4c);
                ARzw4zw5.Text = Convert.ToString("Zwykły (+4) -> Zwykły (+5): " + zw4zw5 + "/" + zw4zw5c);
                ARzw5db0.Text = Convert.ToString("Zwykły (+5) -> Dobry: " + zw5db0 + "/" + zw5db0c);
                ARdb0db1.Text = Convert.ToString("Dobry -> Dobry (+1): " + db0db1 + "/" + db0db1c);
                ARdb1db2.Text = Convert.ToString("Dobry (+1) -> Dobry (+2): " + db1db2 + "/" + db1db2c);
                ARdb2db3.Text = Convert.ToString("Dobry (+2) -> Dobry (+3): " + db2db3 + "/" + db2db3c);
                ARdb3db4.Text = Convert.ToString("Dobry (+3) -> Dobry (+4): " + db3db4 + "/" + db3db4c);
                ARdb4db5.Text = Convert.ToString("Dobry (+4) -> Dobry (+5): " + db4db5 + "/" + db4db5c);
                ARdb5dsk0.Text = Convert.ToString("Dobry (+5) -> Doskonały: " + db5dsk0 + "/" + db5dsk0c);
                ARdsk0dsk1.Text = Convert.ToString("Doskonały -> Doskonały (+1): " + dsk0dsk1 + "/" + dsk0dsk1c);
                ARdsk1dsk2.Text = Convert.ToString("Doskonały (+1) -> Doskonały (+2): " + dsk1dsk2 + "/" + dsk1dsk2c);
                ARdsk2dsk3.Text = Convert.ToString("Doskonały (+2) -> Doskonały (+3): " + dsk2dsk3 + "/" + dsk2dsk3c);
                ARdsk3dsk4.Text = Convert.ToString("Doskonały (+3) -> Doskonały (+4): " + dsk3dsk4 + "/" + dsk3dsk4c);
                ARdsk4dsk5.Text = Convert.ToString("Doskonały (+4) -> Doskonały (+5): " + dsk4dsk5 + "/" + dsk4dsk5c);
            }
        }

        private void AnalizatorRaportuPomoc_Click(object sender, EventArgs e)
        {
            // Szybka pomoc jak korzystać z analizatora ulepszeń
            System.Windows.Forms.MessageBox.Show("1. Skopiuj zawartość raportu z ulepszania.\n" +
                "    Możesz zaznaczyć wszystko (CTRL+A) i skopiować (CTRL+C).\n" +
                "2. Wlej skopiowaną zawartość raportu do okienka obok.\n" +
                "3. Kliknij 'Oblicz'.");
        }

        private void CB_TextChanged(object sender, EventArgs e)
        {
            // Zmiana wybranego prefiksu / bazy / sufiksu wywołuje funkcję zmiany labeli (aktualizacji "na bierząco" wyniku łączenia)
            ZmienLabel();
        }

        private void ZmienLabelObliczenia(ComboBox PrefCB, ComboBox BazaCB, ComboBox SufCB, List<string> Pref, List<string> Baza, List<string> Suf, Label PrefLab, Label BazaLab, Label SufLab)
        {
            // Funkcja do zmiany labeli - aktualizacji "na bierząco" wyniku łączenia
            int[] componentTemp = new int[3];
            int[] resultTemp = new int[3];

            componentTemp[0] = Pref.IndexOf(PrefCB.Text);
            componentTemp[1] = Baza.IndexOf(BazaCB.Text);
            componentTemp[2] = Suf.IndexOf(SufCB.Text);

            resultTemp = Polacz(component1[0], component1[1], component1[2], componentTemp[0], componentTemp[1], componentTemp[2]);

            resultTemp[0] = SprawdzWyjatki(Pref, component1[0], componentTemp[0], resultTemp[0]);
            resultTemp[1] = SprawdzWyjatki(Baza, component1[1], componentTemp[1], resultTemp[1]);
            resultTemp[2] = SprawdzWyjatki(Suf, component1[2], componentTemp[2], resultTemp[2]);

            if (PrefCB.Text != "") PrefLab.Text = Pref.ElementAt(resultTemp[0]);
            if (PrefCB.Text == "") PrefLab.Text = "";
            if (BazaCB.Text != "") BazaLab.Text = Baza.ElementAt(resultTemp[1]);
            if (BazaCB.Text == "") BazaLab.Text = "";
            if (SufCB.Text != "") SufLab.Text = Suf.ElementAt(resultTemp[2]);
            if (SufCB.Text == "") SufLab.Text = "";
        }

        private void ZmienLabel()
        {
            if (component1[3] != 0)
            {
                switch (GlownyTab.SelectedTab.Text)
                {
                    case "Hełm":
                        ZmienLabelObliczenia(cbHelmPref, cbHelmBaza, cbHelmSuf, PrefHelm, BazaHelm, SufHelm, PrefHelmL, BazaHelmL, SufHelmL);
                        break;
                    case "Zbroja":
                        ZmienLabelObliczenia(cbZbrojaPref, cbZbrojaBaza, cbZbrojaSuf, PrefZbroja, BazaZbroja, SufZbroja, PrefZbrojaL, BazaZbrojaL, SufZbrojaL);
                        break;
                    case "Spodnie":
                        ZmienLabelObliczenia(cbSpodniePref, cbSpodnieBaza, cbSpodnieSuf, PrefSpodnie, BazaSpodnie, SufSpodnie, PrefSpodnieL, BazaSpodnieL, SufSpodnieL);
                        break;
                    case "Pierścień":
                        ZmienLabelObliczenia(cbPierscienPref, cbPierscienBaza, cbPierscienSuf, PrefPierscien, BazaPierscien, SufPierscien, PrefPierscienL, BazaPierscienL, SufPierscienL);
                        break;
                    case "Amulet":
                        ZmienLabelObliczenia(cbAmuletPref, cbAmuletBaza, cbAmuletSuf, PrefAmulet, BazaAmulet, SufAmulet, PrefAmuletL, BazaAmuletL, SufAmuletL);
                        break;
                    case "Biała 1h":
                        ZmienLabelObliczenia(cbBiala1hPref, cbBiala1hBaza, cbBiala1hSuf, PrefBiala1h, BazaBiala1h, SufBiala1h, PrefBiala1hL, BazaBiala1hL, SufBiala1hL);
                        break;
                    case "Biała 2h":
                        ZmienLabelObliczenia(cbBiala2hPref, cbBiala2hBaza, cbBiala2hSuf, PrefBiala2h, BazaBiala2h, SufBiala2h, PrefBiala2hL, BazaBiala2hL, SufBiala2hL);
                        break;
                    case "Palna 1h":
                        ZmienLabelObliczenia(cbPalna1hPref, cbPalna1hBaza, cbPalna1hSuf, PrefPalan1h, BazaPalna1h, SufPalna1h, PrefPalna1hL, BazaPalna1hL, SufPalna1hL);
                        break;
                    case "Palna 2h":
                        ZmienLabelObliczenia(cbPalna2hPref, cbPalna2hBaza, cbPalna2hSuf, PrefPalna2h, BazaPalna2h, SufPalna2h, PrefPalna2hL, BazaPalna2hL, SufPalna2hL);
                        break;
                    case "Dystans":
                        ZmienLabelObliczenia(cbDystansPref, cbDystansBaza, cbDystansSuf, PrefDystans, BazaDystans, SufDystans, PrefDystansL, BazaDystansL, SufDystansL);
                        break;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Odsyłacz do mojej postaci
            System.Diagnostics.Process.Start("https://r19.bloodwars.interia.pl/showmsg.php?a=profile&uid=2755");
        }

        private int SprawdzWyjatki(List<string> B, int sk1, int sk2, int w)
        {
            // Sprawdzenie wyjątków przy łączeniach przy końcu tabeli
            if ((sk1 == (B.Count - 1)) & (sk2 == (B.Count - 2))) w = B.Count - 3;
            if ((sk1 == (B.Count - 2)) & (sk2 == (B.Count - 1))) w = B.Count - 3;
            if ((sk1 == (B.Count - 3)) & (sk2 == (B.Count - 1))) w = B.Count - 2;
            if ((sk1 == (B.Count - 1)) & (sk2 == (B.Count - 3))) w = B.Count - 2;
            return w;
        }

        private void Cofnij(RichTextBox R)
        {
            if (HistoriaLaczen.Count > 1)
            {
                // Usuń ostatnie łączenie i zaktualizuj tekst
                HistoriaLaczen.RemoveAt(HistoriaLaczen.Count - 1);
                R.Text = HistoriaLaczen[HistoriaLaczen.Count - 1];

                // Usuń drugi składnik i wynik łączenia
                if (HistoriaPrzedmiotow.Count > 1) HistoriaPrzedmiotow.RemoveAt(HistoriaPrzedmiotow.Count - 1);
                if (HistoriaPrzedmiotow.Count > 1) HistoriaPrzedmiotow.RemoveAt(HistoriaPrzedmiotow.Count - 1);

                component1 = HistoriaPrzedmiotow[HistoriaPrzedmiotow.Count - 1];
                component2 = new int[] { 0, 0, 0, 0 };

                if (HistoriaLaczen.Count == 1) Czyszczenie();
            }

            if (R.Text.Length > 1) R.Select(R.Text.Length - 1, 0);
            R.ScrollToCaret();
            ZmienLabel();
        }

        private void HelmCofnij_Click(object sender, EventArgs e)
        {
            Cofnij(helmWynik);
        }

        private void ZbrojaCofnij_Click(object sender, EventArgs e)
        {
            Cofnij(zbrojaWynik);
        }

        private void SpodnieCofnij_Click(object sender, EventArgs e)
        {
            Cofnij(spodnieWynik);
        }

        private void PierscienCofnij_Click(object sender, EventArgs e)
        {
            Cofnij(pierscienWynik);
        }

        private void AmuletCofnij_Click(object sender, EventArgs e)
        {
            Cofnij(amuletWynik);
        }

        private void Biala1hCofnij_Click(object sender, EventArgs e)
        {
            Cofnij(biala1hWynik);
        }

        private void Biala2hCofnij_Click(object sender, EventArgs e)
        {
            Cofnij(biala2hWynik);
        }

        private void Palna1hCofnij_Click(object sender, EventArgs e)
        {
            Cofnij(palna1hWynik);
        }

        private void Palna2hCofnij_Click(object sender, EventArgs e)
        {
            Cofnij(palna2hWynik);
        }

        private void DystansCofnij_Click(object sender, EventArgs e)
        {
            Cofnij(dystansWynik);
        }

        private void BazaHelmow(List<string> pref, List<string> baza, List<string> suf)
        {
            // Prefiksy hełmu w uporządkowanej kolejności
            pref.Add("");
            pref.Add("Utwardzany");
            pref.Add("Wzmocniony");
            pref.Add("Pomocny");
            pref.Add("Ozdobny");
            pref.Add("Elegancki");
            pref.Add("Rogaty");
            pref.Add("Złośliwy");
            pref.Add("Leniwy");
            pref.Add("Śmiercionośny");
            pref.Add("Bojowy");
            pref.Add("Magnetyczny");
            pref.Add("Krwawy");
            pref.Add("Kunsztowny");
            pref.Add("Kuloodporny");
            pref.Add("Szamański");
            pref.Add("Tygrysi");
            pref.Add("Szturmowy");
            pref.Add("Runiczny");
            pref.Add("Rytualny");

            // Bazy hełmu w uporządkowanej kolejności
            baza.Add("");
            baza.Add("Czapka");
            baza.Add("Kask");
            baza.Add("Hełm");
            baza.Add("Maska");
            baza.Add("Obręcz");
            baza.Add("Kominiarka");
            baza.Add("Kapelusz");
            baza.Add("Opaska");
            baza.Add("Bandana");
            baza.Add("Korona");

            // Sufiksy hełmu w uporządkowanej kolejności
            suf.Add("");
            suf.Add("Podróżnika");
            suf.Add("Przezorności");
            suf.Add("Wytrzymałości");
            suf.Add("Pasterza");
            suf.Add("Narkomana");
            suf.Add("Ochrony");
            suf.Add("Zmysłów");
            suf.Add("Wieszcza");
            suf.Add("Kary");
            suf.Add("Gladiatora");
            suf.Add("Krwi");
            suf.Add("Skorupy żółwia");
            suf.Add("Słońca");
            suf.Add("Adrenaliny");
            suf.Add("Prekognicji");
            suf.Add("Smoczej łuski");
            suf.Add("Mocy");
            suf.Add("Magii");
        }

        private void BazaZbroi(List<string> pref, List<string> baza, List<string> suf)
        {
            // Prefiksy zbroi w uporządkowanej kolejności
            pref.Add("");
            pref.Add("Wzmocniony");
            pref.Add("Ćwiekowany");
            pref.Add("Władczy");
            pref.Add("Lekki");
            pref.Add("Łuskowy");
            pref.Add("Bojowy");
            pref.Add("Płytowy");
            pref.Add("Giętki");
            pref.Add("Krwawy");
            pref.Add("Łowiecki");
            pref.Add("Szamański");
            pref.Add("Kuloodporny");
            pref.Add("Tygrysi");
            pref.Add("Elfi");
            pref.Add("Runiczny");
            pref.Add("Śmiercionośny");

            // Bazy zbroi w uporządkowanej kolejności
            baza.Add("");
            baza.Add("Koszulka");
            baza.Add("Kurtka");
            baza.Add("Marynarka");
            baza.Add("Kamizelka");
            baza.Add("Gorset");
            baza.Add("Peleryna");
            baza.Add("Smoking");
            baza.Add("Kolczuga");
            baza.Add("Zbroja warstwowa");
            baza.Add("Pełna zbroja");

            // Sufiksy zbroi w uporządkowanej kolejności
            suf.Add("");
            suf.Add("Adepta");
            suf.Add("Strażnika");
            suf.Add("Złodzieja");
            suf.Add("Siłacza");
            suf.Add("Naromana");
            suf.Add("Szermierza");
            suf.Add("Zabójcy");
            suf.Add("Gwardzisty");
            suf.Add("Kobry");
            suf.Add("Skorupy żółwia");
            suf.Add("Uników");
            suf.Add("Grabieżcy");
            suf.Add("Mistrza");
            suf.Add("Adrenaliny");
            suf.Add("Centuriona");
            suf.Add("Odporności");
            suf.Add("Kaliguli");
            suf.Add("Śiewcy śmierci");
            suf.Add("Szybkości");
            suf.Add("Orchidei");
        }

        private void BazaSpodni(List<string> pref, List<string> baza, List<string> suf)
        {
            // Prefiksy spodni w uporządkowanej kolejności
            pref.Add("");
            pref.Add("Krótkie");
            pref.Add("Pikowane");
            pref.Add("Lekkie");
            pref.Add("Wzmocnione");
            pref.Add("Aksamitne");
            pref.Add("Ćwiekowane");
            pref.Add("Kuloodporne");
            pref.Add("Giętkie");
            pref.Add("Kolcze");
            pref.Add("Szamańskie");
            pref.Add("Krwawe");
            pref.Add("Elfie");
            pref.Add("Tygrysie");
            pref.Add("Pancerne");
            pref.Add("Runiczne");
            pref.Add("Kompozytowe");
            pref.Add("Śmiercionośne");

            // Bazy spodni w uporządkowanej kolejności
            baza.Add("");
            baza.Add("Szorty");
            baza.Add("Spodnie");
            baza.Add("Spódnica");
            baza.Add("Kilt");

            // Sufiksy spodni w uporządkowanej kolejności
            suf.Add("");
            suf.Add("Rzezimieszka");
            suf.Add("Przemytnika");
            suf.Add("Narkomana");
            suf.Add("Siłacza");
            suf.Add("Cichych ruchów");
            suf.Add("Uników");
            suf.Add("Skrytości");
            suf.Add("Słońca");
            suf.Add("Handlarza bronią");
            suf.Add("Pasterza");
            suf.Add("Łowcy cieni");
            suf.Add("Węża");
            suf.Add("Inków");
            suf.Add("Tropiciela");
            suf.Add("Nocy");
        }

        private void BazaPierścieni(List<string> pref, List<string> baza, List<string> suf)
        {
            // Prefiksy pierścieni w uporządkowanej kolejności
            pref.Add("");
            pref.Add("Miedziany");
            pref.Add("Srebrny");
            pref.Add("Szmaragdowy");
            pref.Add("Złoty");
            pref.Add("Platynowy");
            pref.Add("Rubinowy");
            pref.Add("Dystyngowany");
            pref.Add("Przebiegły");
            pref.Add("Kardynalski");
            pref.Add("Elastyczny");
            pref.Add("Nekromancki");
            pref.Add("Gwiezdny");
            pref.Add("Niedźwiedzi");
            pref.Add("Twardy");
            pref.Add("Zwierzęcy");
            pref.Add("Tańczący");
            pref.Add("Archaiczny");
            pref.Add("Hipnotyczny");
            pref.Add("Diamentowy");
            pref.Add("Mściwy");
            pref.Add("Spaczony");
            pref.Add("Plastikowy");
            pref.Add("Zdradziecki");
            pref.Add("Tytanowy");
            pref.Add("Słoneczny");
            pref.Add("Pajęczy");
            pref.Add("Jastrzębi");
            pref.Add("Czarny");

            // Bazy pierścieni w uporządkowanej kolejności
            baza.Add("");
            baza.Add("Pierścień");
            baza.Add("Sygnet");
            baza.Add("Bransoleta");

            // Sufiksy pierścieni w uporządkowanej kolejności
            suf.Add("");
            suf.Add("Występku");
            suf.Add("Urody");
            suf.Add("Władzy");
            suf.Add("Siły");
            suf.Add("Geniuszu");
            suf.Add("Mądrości");
            suf.Add("Twardej skóry");
            suf.Add("Wilkołaka");
            suf.Add("Sztuki");
            suf.Add("Celności");
            suf.Add("Młodości");
            suf.Add("Lisa");
            suf.Add("Szczęścia");
            suf.Add("Krwi");
            suf.Add("Nietoperza");
            suf.Add("Koncentracji");
            suf.Add("Lewitacji");
            suf.Add("Przebiegłości");
            suf.Add("Szaleńca");
            suf.Add("Łatwości");
        }

        private void BazaAmuletow(List<string> pref, List<string> baza, List<string> suf)
        {
            // Prefiksy amuletów w uporządkowanej kolejności
            pref.Add("");
            pref.Add("Miedziany");
            pref.Add("Srebrny");
            pref.Add("Szmaragdowy");
            pref.Add("Złoty");
            pref.Add("Platynowy");
            pref.Add("Rubinowy");
            pref.Add("Dystyngowany");
            pref.Add("Przebiegły");
            pref.Add("Kardynalski");
            pref.Add("Elastyczny");
            pref.Add("Nekromancki");
            pref.Add("Gwiezdny");
            pref.Add("Niedźwiedzi");
            pref.Add("Twardy");
            pref.Add("Diamentowy");
            pref.Add("Mściwy");
            pref.Add("Archaiczny");
            pref.Add("Tańczący");
            pref.Add("Hipnotyczny");
            pref.Add("Zwierzęcy");
            pref.Add("Spaczony");
            pref.Add("Plastikowy");
            pref.Add("Zdradziecki");
            pref.Add("Tytanowy");
            pref.Add("Słoneczny");
            pref.Add("Pajęczy");
            pref.Add("Jastrzębi");
            pref.Add("Czarny");

            // Bazy amuletów w uporządkowanej kolejności
            baza.Add("");
            baza.Add("Naszyjnik");
            baza.Add("Amulet");
            baza.Add("Łańcuch");
            baza.Add("Apaszka");
            baza.Add("Krawat");

            // Sufiksy amuletów w uporządkowanej kolejności
            suf.Add("");
            suf.Add("Występku");
            suf.Add("Urody");
            suf.Add("Władzy");
            suf.Add("Geniuszu");
            suf.Add("Siły");
            suf.Add("Mądrości");
            suf.Add("Twardej skóry");
            suf.Add("Pielgrzyma");
            suf.Add("Wilkołaka");
            suf.Add("Celności");
            suf.Add("Sztuki");
            suf.Add("Młodości");
            suf.Add("Szczęścia");
            suf.Add("Krwi");
            suf.Add("Zdolności");
            suf.Add("Koncentracji");
            suf.Add("Lewitacji");
            suf.Add("Przebiegłości");
            suf.Add("Szaleńca");
            suf.Add("Łatwości");
        }

        private void BazaBialych1h(List<string> pref, List<string> baza, List<string> suf)
        {
            // Prefiksy białej 1h w uporządkowanej kolejności
            pref.Add("");
            pref.Add("Ostry");
            pref.Add("Zębaty");
            pref.Add("Kościany");
            pref.Add("Wzmacniający");
            pref.Add("Kryształowy");
            pref.Add("Mistyczny");
            pref.Add("Lekki");
            pref.Add("Okrutny");
            pref.Add("Przyjacielski");
            pref.Add("Kąsający");
            pref.Add("Opiekuńczy");
            pref.Add("Świecący");
            pref.Add("Jadowity");
            pref.Add("Zabójczy");
            pref.Add("Zatruty");
            pref.Add("Przeklęty");
            pref.Add("Zwinny");
            pref.Add("Antyczny");
            pref.Add("Szybki");
            pref.Add("Demoniczny");

            // Bazy białej 1h w uporządkowanej kolejności
            baza.Add("");
            baza.Add("Pałka");
            baza.Add("Nóż");
            baza.Add("Sztylet");
            baza.Add("Kastet");
            baza.Add("Miecz");
            baza.Add("Rapier");
            baza.Add("Kama");
            baza.Add("Topór");
            baza.Add("Wakizashi");
            baza.Add("Pięść niebios");

            // Sufiksy białej 1h w uporządkowanej kolejności
            suf.Add("");
            suf.Add("Dowódcy");
            suf.Add("Sekty");
            suf.Add("Bólu");
            suf.Add("Władzy");
            suf.Add("Zwinności");
            suf.Add("Mocy");
            suf.Add("Zarazy");
            suf.Add("Odwagi");
            suf.Add("Trafienia");
            suf.Add("Przodków");
            suf.Add("Zdobywcy");
            suf.Add("Kontuzji");
            suf.Add("Męstwa");
            suf.Add("Precyzji");
            suf.Add("Krwi");
            suf.Add("Zemsty");
            suf.Add("Podkowy");
            suf.Add("Drakuli");
            suf.Add("Biegłości");
            suf.Add("Klanu");
            suf.Add("Imperatora");
            suf.Add("Samobójcy");
        }

        private void BazaBialych2h(List<string> pref, List<string> baza, List<string> suf)
        {
            // Prefiksy białej 2h w uporządkowanej kolejności
            pref.Add("");
            pref.Add("Kosztowny");
            pref.Add("Ostry");
            pref.Add("Kryształowy");
            pref.Add("Zębaty");
            pref.Add("Szeroki");
            pref.Add("Okrutny");
            pref.Add("Mistyczny");
            pref.Add("Wzmacniający");
            pref.Add("Kąsający");
            pref.Add("Lekki");
            pref.Add("Ciężki");
            pref.Add("Zatruty");
            pref.Add("Napromieniowany");
            pref.Add("Świecący");
            pref.Add("Opiekuńczy");
            pref.Add("Jadowity");
            pref.Add("Zabójczy");
            pref.Add("Przeklęty");
            pref.Add("Zwinny");
            pref.Add("Antyczny");
            pref.Add("Demoniczny");

            // Bazy białej 2h w uporządkowanej kolejności
            baza.Add("");
            baza.Add("Maczuga");
            baza.Add("Łom");
            baza.Add("Miecz dwuręczny");
            baza.Add("Topór dwuręczny");
            baza.Add("Korbacz");
            baza.Add("Kosa");
            baza.Add("Pika");
            baza.Add("Halabarda");
            baza.Add("Katana");
            baza.Add("Piła łancuchowa");

            // Sufiksy białej 2h w uporządkowanej kolejności
            suf.Add("");
            suf.Add("Zdrady");
            suf.Add("Podstępu");
            suf.Add("Bólu");
            suf.Add("Hazardzisty");
            suf.Add("Ołowiu");
            suf.Add("Mocy");
            suf.Add("Inkwizytora");
            suf.Add("Krwiopijcy");
            suf.Add("Zdobywcy");
            suf.Add("Władzy");
            suf.Add("Zemsty");
            suf.Add("Zarazy");
            suf.Add("Podkowy");
            suf.Add("Autokraty");
            suf.Add("Krwi");
            suf.Add("Bazyliszka");
            suf.Add("Samobójcy");
            suf.Add("Drakuli");
        }

        private void BazaPalnych1h(List<string> pref, List<string> baza, List<string> suf)
        {
            // Prefiksy palnych 1h w uporządkowanej kolejności
            pref.Add("");

            // Bazy palnych 1h w uporządkowanej kolejności
            baza.Add("");
            baza.Add("Glock");
            baza.Add("Beretta");
            baza.Add("Uzi");
            baza.Add("Magnum");
            baza.Add("Desert Eagle");
            baza.Add("Mp5k");
            baza.Add("Skorpion");

            // Sufiksy palnych 1h w uporządkowanej kolejności
            suf.Add("");
        }

        private void BazaPalnych2h(List<string> pref, List<string> baza, List<string> suf)
        {
            // Prefiksy palnych 2h w uporządkowanej kolejności
            pref.Add("");

            // Bazy palnych 2h w uporządkowanej kolejności
            baza.Add("");
            baza.Add("Karabin myśliwski");
            baza.Add("Półautomat snajperski");
            baza.Add("Karabin snajperski");
            baza.Add("AK-47");
            baza.Add("Fn-Fal");
            baza.Add("Strzelba");
            baza.Add("Miotacz płomieni");

            // Sufiksy palnych 2h w uporządkowanej kolejności
            suf.Add("");
        }

        private void BazaDystansow(List<string> pref, List<string> baza, List<string> suf)
        {
            // Prefiksy dystansu w uporządkowanej kolejności
            pref.Add("");

            // Bazy dystansu w uporządkowanej kolejności
            baza.Add("");
            baza.Add("Krótki łuk");
            baza.Add("Łuk");
            baza.Add("Shuriken");
            baza.Add("Długi łuk");
            baza.Add("Kusza");
            baza.Add("Nóż do rzucania");
            baza.Add("Łuk refleksyjny");
            baza.Add("Oszczep");
            baza.Add("Pilum");
            baza.Add("Toporek do rzucania");
            baza.Add("Ciężka kusza");

            // Sufiksy dystansu w uporządkowanej kolejności
            suf.Add("");
            suf.Add("Dalekiego zasięgu");
            suf.Add("Doskonałości");
            suf.Add("Precyzji");
            suf.Add("Zemsty");
            suf.Add("Reakcji");
            suf.Add("Driady");
            suf.Add("Szybkostrzelności");
            suf.Add("Wilka");
        }
    }
}