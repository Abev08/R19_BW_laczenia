﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace R19_BW_laczenia
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

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
            Color bckColorRTB = Color.FromArgb(20, 20, 20); // Kolor tła RichTextBox'a
            Font fontRTB = new Font("Segoe UI", 9f); // Czcionka RTB
            fontSizeAnalizRap = 8;
            fontAnalizatorRap = new Font("Segoe UI", fontSizeAnalizRap);  // Czcionka Analizatora raportu
            Color foreColorRTB = Color.FromName("ControlLightLight");   // Kolor czcionki RTB
            ImageLayout imgLayoutTab = ImageLayout.Tile;   // Wybór typu obrazu tła tab'u - kafelka
            Image bckPictureTab = Properties.Resources.Background_black;    // Obraz tła tab'u

            // Dodawanie prefiksów, baz i sufiksów do comboBox'ów
            // Hełm
            TabHelm.BackColor = bckColorTab;
            TabHelm.BackgroundImageLayout = imgLayoutTab;
            TabHelm.BackgroundImage = bckPictureTab;
            helmWynik.Font = fontRTB;
            helmWynik.ForeColor = foreColorRTB;
            helmWynik.BackColor = bckColorRTB;
            helmWynik.ReadOnly = true;  // Ustawienie flagi Read Only
            helmWynik.ContextMenuStrip = contextMenuStrip1; // Dodanie menu prawego przycisku myszy
            DodajElementyCB(PrefHelm, cbHelmPref, cbHelmPref_sh1, cbHelmPref_sh2, cbHelmPref_sh3);
            DodajElementyCB(BazaHelm, cbHelmBaza, cbHelmBaza_sh1, cbHelmBaza_sh2, cbHelmBaza_sh3);
            DodajElementyCB(SufHelm, cbHelmSuf, cbHelmSuf_sh1, cbHelmSuf_sh2, cbHelmSuf_sh3);

            // Zbroja
            TabZbroja.BackColor = bckColorTab;
            TabZbroja.BackgroundImageLayout = imgLayoutTab;
            TabZbroja.BackgroundImage = bckPictureTab;
            zbrojaWynik.Font = fontRTB;
            zbrojaWynik.ForeColor = foreColorRTB;
            zbrojaWynik.BackColor = bckColorRTB;
            zbrojaWynik.ReadOnly = true;    // Ustawienie flagi Read Only
            zbrojaWynik.ContextMenuStrip = contextMenuStrip1;   // Dodanie menu prawego przycisku myszy
            DodajElementyCB(PrefZbroja, cbZbrojaPref, cbZbrojaPref_sh1, cbZbrojaPref_sh2, cbZbrojaPref_sh3);
            DodajElementyCB(BazaZbroja, cbZbrojaBaza, cbZbrojaBaza_sh1, cbZbrojaBaza_sh2, cbZbrojaBaza_sh3);
            DodajElementyCB(SufZbroja, cbZbrojaSuf, cbZbrojaSuf_sh1, cbZbrojaSuf_sh2, cbZbrojaSuf_sh3);

            // Spodnie
            TabSpodnie.BackColor = bckColorTab;
            TabSpodnie.BackgroundImageLayout = imgLayoutTab;
            TabSpodnie.BackgroundImage = bckPictureTab;
            spodnieWynik.Font = fontRTB;
            spodnieWynik.ForeColor = foreColorRTB;
            spodnieWynik.BackColor = bckColorRTB;
            spodnieWynik.ReadOnly = true;   // Ustawienie flagi Read Only
            spodnieWynik.ContextMenuStrip = contextMenuStrip1;  // Dodanie menu prawego przycisku myszy
            DodajElementyCB(PrefSpodnie, cbSpodniePref, cbSpodniePref_sh1, cbSpodniePref_sh2, cbSpodniePref_sh3);
            DodajElementyCB(BazaSpodnie, cbSpodnieBaza, cbSpodnieBaza_sh1, cbSpodnieBaza_sh2, cbSpodnieBaza_sh3);
            DodajElementyCB(SufSpodnie, cbSpodnieSuf, cbSpodnieSuf_sh1, cbSpodnieSuf_sh2, cbSpodnieSuf_sh3);

            // Pierścień
            TabPierscien.BackColor = bckColorTab;
            TabPierscien.BackgroundImageLayout = imgLayoutTab;
            TabPierscien.BackgroundImage = bckPictureTab;
            pierscienWynik.Font = fontRTB;
            pierscienWynik.ForeColor = foreColorRTB;
            pierscienWynik.BackColor = bckColorRTB;
            pierscienWynik.ReadOnly = true;  // Ustawienie flagi Read Only
            pierscienWynik.ContextMenuStrip = contextMenuStrip1; // Dodanie menu prawego przycisku myszy
            DodajElementyCB(PrefPierscien, cbPierscienPref, cbPierscienPref_sh1, cbPierscienPref_sh2, cbPierscienPref_sh3);
            DodajElementyCB(BazaPierscien, cbPierscienBaza, cbPierscienBaza_sh1, cbPierscienBaza_sh2, cbPierscienBaza_sh3);
            DodajElementyCB(SufPierscien, cbPierscienSuf, cbPierscienSuf_sh1, cbPierscienSuf_sh2, cbPierscienSuf_sh3);

            // Amulet
            TabAmulet.BackColor = bckColorTab;
            TabAmulet.BackgroundImageLayout = imgLayoutTab;
            TabAmulet.BackgroundImage = bckPictureTab;
            amuletWynik.Font = fontRTB;
            amuletWynik.ForeColor = foreColorRTB;
            amuletWynik.BackColor = bckColorRTB;
            amuletWynik.ReadOnly = true;  // Ustawienie flagi Read Only
            amuletWynik.ContextMenuStrip = contextMenuStrip1; // Dodanie menu prawego przycisku myszy
            DodajElementyCB(PrefAmulet, cbAmuletPref, cbAmuletPref_sh1, cbAmuletPref_sh2, cbAmuletPref_sh3);
            DodajElementyCB(BazaAmulet, cbAmuletBaza, cbAmuletBaza_sh1, cbAmuletBaza_sh2, cbAmuletBaza_sh3);
            DodajElementyCB(SufAmulet, cbAmuletSuf, cbAmuletSuf_sh1, cbAmuletSuf_sh2, cbAmuletSuf_sh3);

            // Biała 1h
            TabBiala1h.BackColor = bckColorTab;
            TabBiala1h.BackgroundImageLayout = imgLayoutTab;
            TabBiala1h.BackgroundImage = bckPictureTab;
            biala1hWynik.Font = fontRTB;
            biala1hWynik.ForeColor = foreColorRTB;
            biala1hWynik.BackColor = bckColorRTB;
            biala1hWynik.ReadOnly = true;  // Ustawienie flagi Read Only
            biala1hWynik.ContextMenuStrip = contextMenuStrip1; // Dodanie menu prawego przycisku myszy
            DodajElementyCB(PrefBiala1h, cbBiala1hPref, cbBiala1hPref_sh1, cbBiala1hPref_sh2, cbBiala1hPref_sh3);
            DodajElementyCB(BazaBiala1h, cbBiala1hBaza, cbBiala1hBaza_sh1, cbBiala1hBaza_sh2, cbBiala1hBaza_sh3);
            DodajElementyCB(SufBiala1h, cbBiala1hSuf, cbBiala1hSuf_sh1, cbBiala1hSuf_sh2, cbBiala1hSuf_sh3);

            // Biała 2h
            TabBiala2h.BackColor = bckColorTab;
            TabBiala2h.BackgroundImageLayout = imgLayoutTab;
            TabBiala2h.BackgroundImage = bckPictureTab;
            biala2hWynik.Font = fontRTB;
            biala2hWynik.ForeColor = foreColorRTB;
            biala2hWynik.BackColor = bckColorRTB;
            biala2hWynik.ReadOnly = true;  // Ustawienie flagi Read Only
            biala2hWynik.ContextMenuStrip = contextMenuStrip1; // Dodanie menu prawego przycisku myszy
            DodajElementyCB(PrefBiala2h, cbBiala2hPref, cbBiala2hPref_sh1, cbBiala2hPref_sh2, cbBiala2hPref_sh3);
            DodajElementyCB(BazaBiala2h, cbBiala2hBaza, cbBiala2hBaza_sh1, cbBiala2hBaza_sh2, cbBiala2hBaza_sh3);
            DodajElementyCB(SufBiala2h, cbBiala2hSuf, cbBiala2hSuf_sh1, cbBiala2hSuf_sh2, cbBiala2hSuf_sh3);

            // Palna 1h
            TabPalna1h.BackColor = bckColorTab;
            TabPalna1h.BackgroundImageLayout = imgLayoutTab;
            TabPalna1h.BackgroundImage = bckPictureTab;
            palna1hWynik.Font = fontRTB;
            palna1hWynik.ForeColor = foreColorRTB;
            palna1hWynik.BackColor = bckColorRTB;
            palna1hWynik.ReadOnly = true;  // Ustawienie flagi Read Only
            palna1hWynik.ContextMenuStrip = contextMenuStrip1; // Dodanie menu prawego przycisku myszy
            DodajElementyCB(PrefPalan1h, cbPalna1hPref, cbPalna1hPref_sh1, cbPalna1hPref_sh2, cbPalna1hPref_sh3);
            DodajElementyCB(BazaPalna1h, cbPalna1hBaza, cbPalna1hBaza_sh1, cbPalna1hBaza_sh2, cbPalna1hBaza_sh3);
            DodajElementyCB(SufPalna1h, cbPalna1hSuf, cbPalna1hSuf_sh1, cbPalna1hSuf_sh2, cbPalna1hSuf_sh3);

            // Palna 2h
            TabPalna2h.BackColor = bckColorTab;
            TabPalna2h.BackgroundImageLayout = imgLayoutTab;
            TabPalna2h.BackgroundImage = bckPictureTab;
            palna2hWynik.Font = fontRTB;
            palna2hWynik.ForeColor = foreColorRTB;
            palna2hWynik.BackColor = bckColorRTB;
            palna2hWynik.ReadOnly = true;  // Ustawienie flagi Read Only
            palna2hWynik.ContextMenuStrip = contextMenuStrip1; // Dodanie menu prawego przycisku myszy
            DodajElementyCB(PrefPalna2h, cbPalna2hPref, cbPalna2hPref_sh1, cbPalna2hPref_sh2, cbPalna2hPref_sh3);
            DodajElementyCB(BazaPalna2h, cbPalna2hBaza, cbPalna2hBaza_sh1, cbPalna2hBaza_sh2, cbPalna2hBaza_sh3);
            DodajElementyCB(SufPalna2h, cbPalna2hSuf, cbPalna2hSuf_sh1, cbPalna2hSuf_sh2, cbPalna2hSuf_sh3);

            // Dystans
            TabDystans.BackColor = bckColorTab;
            TabDystans.BackgroundImageLayout = imgLayoutTab;
            TabDystans.BackgroundImage = bckPictureTab;
            dystansWynik.Font = fontRTB;
            dystansWynik.ForeColor = foreColorRTB;
            dystansWynik.BackColor = bckColorRTB;
            dystansWynik.ReadOnly = true;  // Ustawienie flagi Read Only
            dystansWynik.ContextMenuStrip = contextMenuStrip1; // Dodanie menu prawego przycisku myszy
            DodajElementyCB(PrefDystans, cbDystansPref, cbDystansPref_sh1, cbDystansPref_sh2, cbDystansPref_sh3);
            DodajElementyCB(BazaDystans, cbDystansBaza, cbDystansBaza_sh1, cbDystansBaza_sh2, cbDystansBaza_sh3);
            DodajElementyCB(SufDystans, cbDystansSuf, cbDystansSuf_sh1, cbDystansSuf_sh2, cbDystansSuf_sh3);

            // Analizator raportu
            TabAnalizator.BackColor = bckColorTab;
            TabAnalizator.BackgroundImageLayout = imgLayoutTab;
            TabAnalizator.BackgroundImage = bckPictureTab;
            AnalizatorRaportuTekst.Font = fontAnalizatorRap;
            AnalizatorRaportuTekst.ForeColor = foreColorRTB;
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

            // Analizator łączeń
            TabLaczenia.BackColor = bckColorTab;
            TabLaczenia.BackgroundImageLayout = imgLayoutTab;
            TabLaczenia.BackgroundImage = bckPictureTab;
            listaTypowPrzedmiotow.Items.Add("Hełm");
            listaTypowPrzedmiotow.Items.Add("Zbroja");
            listaTypowPrzedmiotow.Items.Add("Spodnie");
            listaTypowPrzedmiotow.Items.Add("Pierścień");
            listaTypowPrzedmiotow.Items.Add("Amulet");
            listaTypowPrzedmiotow.Items.Add("Biała 1h");
            listaTypowPrzedmiotow.Items.Add("Biała 2h");
            listaTypowPrzedmiotow.Items.Add("Palna 1h");
            listaTypowPrzedmiotow.Items.Add("Palna 2h");
            listaTypowPrzedmiotow.Items.Add("Dystans");
            listaTypowPrzedmiotow.SelectedIndex = 0;
            przedmiotyDoAnalizy.WordWrap = true;
            przedmiotyDoAnalizy.ContextMenuStrip = contextMenuStrip1;
            przedmiotyDoAnalizy.Font = fontRTB;
            przedmiotyDoAnalizy.ForeColor = foreColorRTB;
            przedmiotyDoAnalizy.BackColor = bckColorRTB;
            przedmiotyDoAnalizy.ReadOnly = false;
            przedmiotyDoAnalizy.Text = "Wklej tutaj listę przedmiotów do łączenia.\n";
            iloscLaczen.Minimum = 1;
            checkBoxWyswietl.Text = "Mimo wszystko\nwyświetl!";

            // Wersja programu (tooltip na labelu "by Abev")
            toolTip1.SetToolTip(this.ByMe, "Wersja programu: " + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString() +
                "\nProszę zgłaszać wszelkie znalezione błędy / sugestie :)");
        }

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
        Item component1 = new Item();
        Item component2 = new Item();
        bool added = false;
        List<Item> HistoriaPrzedmiotow = new List<Item>();
        List<string> HistoriaLaczen = new List<string>();

        // Utworzenie obiektu tabeli łączeń (nowego Form'a)
        TableWindow Tabela;

        // Obiekt okienka pomocy;
        Pomoc pomoc;

        // Zmienne do analizatora łączeń
        List<Item> przedmioty = new List<Item>();
        List<Item> wyniki = new List<Item>();
        List<int> filtrPrzedmioty = new List<int>();
        bool doOnceAnalizator = true;

        // Zmienne do analizatora raportów
        int fontSizeAnalizRap;
        Font fontAnalizatorRap;

        private void DodajElementyCB(List<string> Baza, ComboBox cb1, ComboBox cb2, ComboBox cb3, ComboBox cb4)
        {
            foreach (string s in Baza)
            {
                cb1.Items.Add(s);
                cb2.Items.Add(s);
                cb3.Items.Add(s);
                cb4.Items.Add(s);
            }
            cb1.SelectedIndex = 0;
            cb2.SelectedIndex = 0;
            cb3.SelectedIndex = 0;
            cb4.SelectedIndex = 0;
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

        private void Dodaj(ComboBox PrefCB, ComboBox BazaCB, ComboBox SufCB, RichTextBox Wynik, List<string> Pref, List<string> Baza, List<string> Suf)
        {
            Item temp = new Item(Pref.IndexOf(PrefCB.Text), Baza.IndexOf(BazaCB.Text), Suf.IndexOf(SufCB.Text));
            Item result;

            // Dodaj znak sumy jeżeli dodano drugi przedmiot do łączenia
            if (temp.Sum() > 0)
            {
                if (component1.Sum() > 0) Wynik.AppendText(" + ");

                // Dodaj wybrany prefiks / bazę / sufiks do okienka z wynikiem
                Wynik.AppendText(UsunSpacje(temp, Pref, Baza, Suf));
                added = true;
            }

            if (added)
            {
                added = false;

                if (component1.Sum() == 0)
                {
                    // Pierwszy składnik - indeks prefiksu + indeks bazy + indeks sufiksu = 0
                    component1.Set(temp);
                    // Dodaj składnik do histori składników
                    HistoriaPrzedmiotow.Add(new Item(component1));
                }
                else
                {
                    // Drugi składnik
                    component2.Set(temp);
                    // Dodaj składnik do histori składników
                    HistoriaPrzedmiotow.Add(new Item(component2));

                    // Połącz przedmioty, uwzględnij wyjątek przy łączeniu baz hełmów
                    if (Baza == BazaHelm) result = new Item(component1.Polacz(component2, Pref, Baza, Suf, true));
                    else result = new Item(component1.Polacz(component2, Pref, Baza, Suf));

                    // Potraktuj wynik jako pierwszy składnik
                    component1 = new Item(result);

                    // Dodaj składnik do histori składników
                    HistoriaPrzedmiotow.Add(new Item(result));
                    // Wyświetl wynik łączenia
                    Wynik.AppendText("\n= " + UsunSpacje(result, Pref, Baza, Suf));
                }

                // Dodaj łączenie do historii łączeń 
                HistoriaLaczen.Add(Wynik.Text);
            }

            // Przesuń kursor na koniec tekstu (jeżeli dodano tekst poniżej widocznego pola, "przescrolluj na sam dół")
            Wynik.ScrollToCaret();
            // Uaktualnij "wynik łączenia aktualizowany na bieżąco"
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

        private void Cofnij(RichTextBox RTB)
        {
            if (HistoriaLaczen.Count > 1)
            {
                // Usuń ostatnie łączenie i zaktualizuj tekst
                HistoriaLaczen.RemoveAt(HistoriaLaczen.Count - 1);
                RTB.Text = HistoriaLaczen[HistoriaLaczen.Count - 1];

                // Usuń drugi składnik i wynik łączenia
                if (HistoriaPrzedmiotow.Count > 1) HistoriaPrzedmiotow.RemoveAt(HistoriaPrzedmiotow.Count - 1);
                if (HistoriaPrzedmiotow.Count > 1) HistoriaPrzedmiotow.RemoveAt(HistoriaPrzedmiotow.Count - 1);

                component1 = HistoriaPrzedmiotow[HistoriaPrzedmiotow.Count - 1];
                component2 = new Item();

                if (HistoriaLaczen.Count == 1) Czyszczenie();
            }

            if (RTB.Text.Length > 1) RTB.Select(RTB.Text.Length - 1, 0);
            RTB.ScrollToCaret();
            ZmienLabel();
        }

        private void PrefHelmPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Hełm Pref", PrefHelm);
        }

        private void BazaHelmPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Hełm Baza", BazaHelm);
        }

        private void SufHelmPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Hełm Suf", SufHelm);
        }

        private void PrefZbrojaPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Zbroja Pref", PrefZbroja);
        }

        private void BazaZbrojaPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Zbroja Baza", BazaZbroja);
        }

        private void SufZbrojaPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Zbroja Suf", SufZbroja);
        }

        private void PrefSpodniePanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Spodnie Pref", PrefSpodnie);
        }

        private void BazaSpodniePanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Spodnie Baza", BazaSpodnie);
        }

        private void SufSpodniePanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Spodnie Suf", SufSpodnie);
        }

        private void PrefPierscienPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Pierścień Pref", PrefPierscien);
        }

        private void BazaPierscienPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Pierścień Baza", BazaPierscien);
        }

        private void SufPierscienPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Pierścień Suf", SufPierscien);
        }

        private void PrefAmuletPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Amulet Pref", PrefAmulet);
        }

        private void BazaAmuletPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Amulet Baza", BazaAmulet);
        }

        private void SufAmuletPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Amulet Suf", SufAmulet);
        }

        private void PrefBiala1hPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Biała 1h Pref", PrefBiala1h);
        }

        private void BazaBiala1hPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Biała 1h Baza", BazaBiala1h);
        }

        private void SufBiala1hPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Biała 1h Suf", SufBiala1h);
        }

        private void PrefBiala2hPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Biała 2h Pref", PrefBiala2h);
        }

        private void BazaBiala2hPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Biała 2h Baza", BazaBiala2h);
        }

        private void SufBiala2hPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Biała 2h Suf", SufBiala2h);
        }

        private void PrefPalna1hPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Palna 1h Pref", PrefPalan1h);
        }

        private void BazaPalna1hPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Palna 1h Baza", BazaPalna1h);
        }

        private void SufPalna1hPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Palna 1h Suf", SufPalna1h);
        }

        private void PrefPalna2hPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Palna 2h Pref", PrefPalna2h);
        }

        private void BazaPalna2hPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Palna 2h Baza", BazaPalna2h);
        }

        private void SufPalna2hPanelLabel_Click(object sender, EventArgs e)
        {
            if (Tabela == null || Tabela.IsOpen == false) Tabela = new TableWindow();
            InicjalizacjaTabeli("Palna 2h Suf", SufPalna2h);
        }

        private void PrefDystansPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Dystans Pref", PrefDystans);
        }

        private void BazaDystansPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Dystans Baza", BazaDystans);
        }

        private void SufDystansPanelLabel_Click(object sender, EventArgs e)
        {
            InicjalizacjaTabeli("Dystans Suf", SufDystans);
        }

        private void InicjalizacjaTabeli(string s, List<string> baza)
        {
            if (Tabela == null || Tabela.IsOpen == false) Tabela = new TableWindow();
            Tabela.AddTab(s, baza);
            Tabela.Show();
            Tabela.BringToFront();
        }

        private void AnalizatorRaportuOblicz_Click(object sender, EventArgs e)
        {
            // Przeprowadź analizę raportu
            AnalizujRaport();
        }

        private void AnalizujRaport()
        {
            // Funkcja do analizy raportu
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

            // Wyłączenie zawijania wierszy
            AnalizatorRaportuTekst.WordWrap = false;

            // Podziel tekst na wiersze
            string[] ulepszenia = AnalizatorRaportuTekst.Text.Split('\n');

            // W każdym wierszu spróbuj wyszukać odpowiedni ciąg znaków (odpowiednie słowa) i na ich podstawie zwiększ odpowiednie zmienne
            for (int i = 0; i < ulepszenia.Count(); i++)
            {
                if (ulepszenia[i].Contains("Ulepszono przedmiot"))
                {
                    // Zmiana koloru tekstu pomyślnego ulepszenia na zielony
                    AnalizatorRaportuTekst.Select(AnalizatorRaportuTekst.GetFirstCharIndexFromLine(i), AnalizatorRaportuTekst.Lines[i].Length);
                    AnalizatorRaportuTekst.SelectionColor = Color.ForestGreen;

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

                else if (ulepszenia[i].Contains("nie został ulepszony"))
                {
                    // Zmiana koloru tekstu na czerwony przy niepowodzeniu
                    AnalizatorRaportuTekst.Select(AnalizatorRaportuTekst.GetFirstCharIndexFromLine(i), AnalizatorRaportuTekst.Lines[i].Length);
                    AnalizatorRaportuTekst.SelectionColor = Color.Red;

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
                else
                {
                    // Zmiana koloru nieprzydatnego tekstu na szary
                    if (AnalizatorRaportuTekst.Text != "")
                    {
                        AnalizatorRaportuTekst.Select(AnalizatorRaportuTekst.GetFirstCharIndexFromLine(i), AnalizatorRaportuTekst.Lines[i].Length);
                        AnalizatorRaportuTekst.SelectionColor = Color.FromArgb(40, 40, 40);
                    }
                }
            }

            AnalizatorRaportuTekst.WordWrap = true;
            AnalizatorRaportuTekst.ScrollToCaret();

            // Wyświetl przeanalizowane ulepszenia
            ARzw0zw1.Text = Convert.ToString("Zwykły -> Zwykły (+1): " + zw0zw1 + "/" + zw0zw1c);
            if (zw0zw1c != 0) ARzw0zw1.Text += ", " + Math.Round(((double)zw0zw1 / (double)zw0zw1c) * 100d, 2) + "%";
            ARzw1zw2.Text = Convert.ToString("Zwykły (+1) -> Zwykły (+2): " + zw1zw2 + "/" + zw1zw2c);
            if (zw1zw2c != 0) ARzw1zw2.Text += ", " + Math.Round(((double)zw1zw2 / (double)zw1zw2c) * 100d, 2) + "%";
            ARzw2zw3.Text = Convert.ToString("Zwykły (+2) -> Zwykły (+3): " + zw2zw3 + "/" + zw2zw3c);
            if (zw2zw3c != 0) ARzw2zw3.Text += ", " + Math.Round(((double)zw2zw3 / (double)zw2zw3c) * 100d, 2) + "%";
            ARzw3zw4.Text = Convert.ToString("Zwykły (+3) -> Zwykły (+4): " + zw3zw4 + "/" + zw3zw4c);
            if (zw3zw4c != 0) ARzw3zw4.Text += ", " + Math.Round(((double)zw3zw4 / (double)zw3zw4c) * 100d, 2) + "%";
            ARzw4zw5.Text = Convert.ToString("Zwykły (+4) -> Zwykły (+5): " + zw4zw5 + "/" + zw4zw5c);
            if (zw4zw5c != 0) ARzw4zw5.Text += ", " + Math.Round(((double)zw4zw5 / (double)zw4zw5c) * 100d, 2) + "%";
            ARzw5db0.Text = Convert.ToString("Zwykły (+5) -> Dobry: " + zw5db0 + "/" + zw5db0c);
            if (zw5db0c != 0) ARzw5db0.Text += ", " + Math.Round(((double)zw5db0 / (double)zw5db0c) * 100d, 2) + "%";
            ARdb0db1.Text = Convert.ToString("Dobry -> Dobry (+1): " + db0db1 + "/" + db0db1c);
            if (db0db1c != 0) ARdb0db1.Text += ", " + Math.Round(((double)db0db1 / (double)db0db1c) * 100d, 2) + "%";
            ARdb1db2.Text = Convert.ToString("Dobry (+1) -> Dobry (+2): " + db1db2 + "/" + db1db2c);
            if (db1db2c != 0) ARdb1db2.Text += ", " + Math.Round(((double)db1db2 / (double)db1db2c) * 100d, 2) + "%";
            ARdb2db3.Text = Convert.ToString("Dobry (+2) -> Dobry (+3): " + db2db3 + "/" + db2db3c);
            if (db2db3c != 0) ARdb2db3.Text += ", " + Math.Round(((double)db2db3 / (double)db2db3c) * 100d, 2) + "%";
            ARdb3db4.Text = Convert.ToString("Dobry (+3) -> Dobry (+4): " + db3db4 + "/" + db3db4c);
            if (db3db4c != 0) ARdb3db4.Text += ", " + Math.Round(((double)db3db4 / (double)db3db4c) * 100d, 2) + "%";
            ARdb4db5.Text = Convert.ToString("Dobry (+4) -> Dobry (+5): " + db4db5 + "/" + db4db5c);
            if (db4db5c != 0) ARdb4db5.Text += ", " + Math.Round(((double)db4db5 / (double)db4db5c) * 100d, 2) + "%";
            ARdb5dsk0.Text = Convert.ToString("Dobry (+5) -> Doskonały: " + db5dsk0 + "/" + db5dsk0c);
            if (db5dsk0c != 0) ARdb5dsk0.Text += ", " + Math.Round(((double)db5dsk0 / (double)db5dsk0c) * 100d, 2) + "%";
            ARdsk0dsk1.Text = Convert.ToString("Doskonały -> Doskonały (+1): " + dsk0dsk1 + "/" + dsk0dsk1c);
            if (dsk0dsk1c != 0) ARdsk0dsk1.Text += ", " + Math.Round(((double)dsk0dsk1 / (double)dsk0dsk1c) * 100d, 2) + "%";
            ARdsk1dsk2.Text = Convert.ToString("Doskonały (+1) -> Doskonały (+2): " + dsk1dsk2 + "/" + dsk1dsk2c);
            if (dsk1dsk2c != 0) ARdsk1dsk2.Text += ", " + Math.Round(((double)dsk1dsk2 / (double)dsk1dsk2c) * 100d, 2) + "%";
            ARdsk2dsk3.Text = Convert.ToString("Doskonały (+2) -> Doskonały (+3): " + dsk2dsk3 + "/" + dsk2dsk3c);
            if (dsk2dsk3c != 0) ARdsk2dsk3.Text += ", " + Math.Round(((double)dsk2dsk3 / (double)dsk2dsk3c) * 100d, 2) + "%";
            ARdsk3dsk4.Text = Convert.ToString("Doskonały (+3) -> Doskonały (+4): " + dsk3dsk4 + "/" + dsk3dsk4c);
            if (dsk3dsk4c != 0) ARdsk3dsk4.Text += ", " + Math.Round(((double)dsk3dsk4 / (double)dsk3dsk4c) * 100d, 2) + "%";
            ARdsk4dsk5.Text = Convert.ToString("Doskonały (+4) -> Doskonały (+5): " + dsk4dsk5 + "/" + dsk4dsk5c);
            if (dsk4dsk5c != 0) ARdsk4dsk5.Text += ", " + Math.Round(((double)dsk4dsk5 / (double)dsk4dsk5c) * 100d, 2) + "%";
        }

        private void AnalizatorRaportuPomoc_Click(object sender, EventArgs e)
        {
            // Szybka pomoc jak korzystać z analizatora raportów
            pomoc = new Pomoc("Analizator raportów");
            pomoc.ShowDialog(this);
        }

        private void analizRapFontPlus_Click(object sender, EventArgs e)
        {
            // Zwiększ rozmiar czcionki analizatora raportów
            fontSizeAnalizRap++;
            fontAnalizatorRap = new Font("Segoe UI", fontSizeAnalizRap);
            AnalizatorRaportuTekst.Font = fontAnalizatorRap;
            // Po zmianie rozmiaru czcionki wymagana jest ponowna analiza w celu pokolorowania raportu
            AnalizujRaport();
        }

        private void analizRapFontMinus_Click(object sender, EventArgs e)
        {
            // Zmniejsz rozmiar czcionki analizatora raportów
            fontSizeAnalizRap--;
            fontAnalizatorRap = new Font("Segoe UI", fontSizeAnalizRap);
            AnalizatorRaportuTekst.Font = fontAnalizatorRap;
            // Po zmianie rozmiaru czcionki wymagana jest ponowna analiza w celu pokolorowania raportu
            AnalizujRaport();
        }

        private void CB_TextChanged(object sender, EventArgs e)
        {
            // Zmiana wybranego prefiksu / bazy / sufiksu wywołuje funkcję zmiany labeli (aktualizacji "na bieżąco" wyniku łączenia)
            ZmienLabel();
        }

        private void ZmienLabel()
        {
            if (component1.Sum() > 0)
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

        private void ZmienLabelObliczenia(ComboBox PrefCB, ComboBox BazaCB, ComboBox SufCB, List<string> Pref, List<string> Baza, List<string> Suf, Label PrefLab, Label BazaLab, Label SufLab)
        {
            // Funkcja do zmiany labeli - aktualizacji "na bieżąco" wyniku łączenia
            Item skladnik = new Item(Pref.IndexOf(PrefCB.Text), Baza.IndexOf(BazaCB.Text), Suf.IndexOf(SufCB.Text));
            Item wynik;
            if (Baza == BazaHelm) wynik = new Item(component1.Polacz(skladnik, Pref, Baza, Suf, true));
            else wynik = new Item(component1.Polacz(skladnik, Pref, Baza, Suf));

            if (wynik.p > 0) PrefLab.Text = Pref.ElementAt(wynik.p);
            else PrefLab.Text = "";
            if (wynik.b > 0) BazaLab.Text = Baza.ElementAt(wynik.b);
            else BazaLab.Text = "";
            if (wynik.s > 0) SufLab.Text = Suf.ElementAt(wynik.s);
            else SufLab.Text = "";
        }

        private void ZaladujPrzedmioty_Click(object sender, EventArgs e)
        {
            // Wyczyść comboBox'a z listą załadowanych przedmiotów
            zaladowanePrzedmioty.Items.Clear();
            // Wyczyść przefiltrowane przedmioty
            polaczonePrzedmioty.DataSource = null;
            // Wyczyśc ilość załadowanych połączeń
            znalezionoPolaczen.Text = " ";
            // Wyczyść pozycje filtra
            cbFiltrPref.Items.Clear();
            cbFiltrBaza.Items.Clear();
            cbFiltrSuf.Items.Clear();
            // Wyłącz okienko z ilością sprawdzanych łączeń 
            iloscLaczen.Enabled = false;
            // Wyłącz przycisk aktualizacji filtra
            filtrUpdate.Enabled = false;
            // Wyłącz listę przefiltrowanych wyników
            polaczonePrzedmioty.Enabled = false;
            // Wyłącz okienka filtra
            cbFiltrPref.Enabled = false;
            cbFiltrBaza.Enabled = false;
            cbFiltrSuf.Enabled = false;
            // Odznacz dodatkowe łączenia
            dodatkoweLaczenia.Checked = false;
            // Wyłącz checkBox "Wyświetl mimio wszystko"
            checkBoxWyswietl.Enabled = false;
            // Odznacz checkBox "Wyświetl mimio wszystko"
            checkBoxWyswietl.Checked = false;
            // Wyłącz przyciski "Edytuj przedmioty" i "Sortuj przedmioty"
            edytujPrzedmioty.Enabled = false;
            sortujPrzedmioty.Enabled = false;

            // Wyczyść listę załadowanych przedmiotów
            przedmioty.Clear();

            // Załaduj przedmioty
            switch (listaTypowPrzedmiotow.SelectedItem)
            {
                case "Hełm":
                    Zaladuj(PrefHelm, BazaHelm, SufHelm);
                    break;
                case "Zbroja":
                    Zaladuj(PrefZbroja, BazaZbroja, SufZbroja);
                    break;
                case "Spodnie":
                    Zaladuj(PrefSpodnie, BazaSpodnie, SufSpodnie);
                    break;
                case "Pierścień":
                    Zaladuj(PrefPierscien, BazaPierscien, SufPierscien);
                    break;
                case "Amulet":
                    Zaladuj(PrefAmulet, BazaAmulet, SufAmulet);
                    break;
                case "Biała 1h":
                    Zaladuj(PrefBiala1h, BazaBiala1h, SufBiala1h);
                    break;
                case "Biała 2h":
                    Zaladuj(PrefBiala2h, BazaBiala2h, SufBiala2h);
                    break;
                case "Palna 1h":
                    Zaladuj(PrefPalan1h, BazaPalna1h, SufPalna1h);
                    break;
                case "Palna 2h":
                    Zaladuj(PrefPalna2h, BazaPalna2h, SufPalna2h);
                    break;
                case "Dystans":
                    // Normalna identyfikacja nie działa :/
                    //Zaladuj(PrefDystans, BazaDystans, SufDystans);

                    zaladowanePrzedmioty.Items.Clear();
                    przedmioty.Clear();

                    przedmiotyDoAnalizy.WordWrap = false;

                    string[] linie = przedmiotyDoAnalizy.Text.Split('\n');

                    Item przedmiot = new Item();

                    foreach (string line in linie)
                    {
                        przedmiot = new Item();

                        for (int i = 0; i < PrefDystans.Count; i++)
                        {
                            if (line.Contains(PrefDystans[i])) przedmiot.p = i;
                        }
                        for (int i = 0; i < BazaDystans.Count; i++)
                        {
                            if (line.Contains(BazaDystans[i])) przedmiot.b = i;
                        }
                        for (int i = 0; i < SufDystans.Count; i++)
                        {
                            if (line.Contains(SufDystans[i])) przedmiot.s = i;
                        }


                        if (przedmiot.Sum() > 0)
                        {
                            przedmioty.Add(przedmiot);
                            zaladowanePrzedmioty.Items.Add(UsunSpacje(przedmiot, PrefDystans, BazaDystans, SufDystans));
                        }
                    }
                    przedmiotyDoAnalizy.WordWrap = true;
                    break;
            }

            // W zależności od ilości załadowanych przedmiotów wyświetl poprawną (słownie) ilość
            if (przedmioty.Count == 1) zaladowanoPrzedmiotow.Text = "Załadowano " + przedmioty.Count + " przedmiot:";
            if (przedmioty.Count > 1 && przedmioty.Count < 5) zaladowanoPrzedmiotow.Text = "Załadowano " + przedmioty.Count + " przedmioty:";
            if (przedmioty.Count >= 5 || przedmioty.Count == 0) zaladowanoPrzedmiotow.Text = "Załadowano " + przedmioty.Count + " przedmiotów:";
            // Jeżeli załadowano przynajmniej 1 przedmiot włącz przyciski "Edytuj przedmioty" i "Sortuj przedmioty"
            if (przedmioty.Count > 0)
            {
                zaladowanePrzedmioty.SelectedIndex = 0;
                edytujPrzedmioty.Enabled = true;
                sortujPrzedmioty.Enabled = true;
            }
            // Jeżeli załadowano przynajmniej 2 przedmioty włącz przyciski "Analizuj połączenia"
            // i checkBox'y dodatkoweLaczenia i mieszaneLaczenia
            if (przedmioty.Count > 1)
            {
                analizujPolaczenia.Enabled = true;
                dodatkoweLaczenia.Enabled = true;
                mieszaneLaczenia.Checked = false;
                // Jeżeli załadowano poniżej 10 przedmiotów ustaw ilość łączeń na ilość przedmiotów
                if (przedmioty.Count < 10) iloscLaczen.Value = przedmioty.Count;
                else
                {
                    // Jeżeli załadowano 10+ przedmiotów włącz okienko z wyborem ilości łączeń i ustaw wartość początkową równą 1
                    iloscLaczen.Enabled = true;
                    iloscLaczen.Value = 1;
                }
            }
            if (przedmioty.Count < 2)
            {
                // Jeżeli załadowano mniej niż 2 przedmioty wyłącz przycisk "Analizuj połączenia" oraz checkBox dodatkoweLaczenia
                // i ustaw ilość łączeń na 1
                analizujPolaczenia.Enabled = false;
                dodatkoweLaczenia.Enabled = false;
                mieszaneLaczenia.Checked = false;
                iloscLaczen.Value = 1;
            }
        }

        private void Zaladuj(List<string> pref, List<string> baza, List<string> suf)
        {
            // Funkcja ładująca przedmioty - identyfikuje przedmioty z ciągu znaków
            // Wyczyść listy załadowanych przedmiotów
            zaladowanePrzedmioty.Items.Clear();
            przedmioty.Clear();

            // Wyłącz zawijanie tekstu w okienku z tekstem
            przedmiotyDoAnalizy.WordWrap = false;

            // Podziel wklejony tekst na linie
            string[] linie = przedmiotyDoAnalizy.Text.Split('\n');

            // Identyfikowany przedmiot
            Item przedmiot;

            // Pętla dzieląca tekst z okienka na poszczególne linie
            foreach (string line in linie)
            {
                przedmiot = new Item();
                // Podziel linię tekstu na wyrazy oddzielone spacjami
                string[] wyrazy = line.Split(' ');

                // Przeszukaj poszczególne wyrazy
                for (int i = 0; i < wyrazy.Count(); i++)
                {
                    // Pomiń spacje i inne wyrazy z ilością znaków < 3
                    if (wyrazy[i].Length < 3) continue;

                    // Przytnij końcówkę wyrazu - ułatwienie identyfikacji przedmiotów
                    wyrazy[i] = wyrazy[i].Substring(0, wyrazy[i].Length - 1);

                    // Odnajdź w liście prefiksów / baz / sufiksów wyraz
                    if (pref.Any(p => p.Contains(wyrazy[i])) && przedmiot.p == 0) przedmiot.p = pref.IndexOf(pref.Find(p => p.Contains(wyrazy[i])));
                    if (baza.Any(b => b.Contains(wyrazy[i]))) przedmiot.b = baza.IndexOf(baza.Find(b => b.Contains(wyrazy[i])));
                    if (suf.Any(s => s.Contains(wyrazy[i]))) przedmiot.s = suf.IndexOf(suf.Find(s => s.Contains(wyrazy[i])));
                }

                // Jeżeli znaleziono prefiks / bazę / sufiks to dodaj przedmiot do listy przedmiotów
                if (przedmiot.Sum() > 0)
                {
                    przedmioty.Add(przedmiot);
                    zaladowanePrzedmioty.Items.Add(UsunSpacje(przedmiot, pref, baza, suf));
                }
            }

            // Włącz zawijanie tekstu w okienku z tekstem
            przedmiotyDoAnalizy.WordWrap = true;
        }

        private void AnalizujPolaczenia_Click(object sender, EventArgs e)
        {
            // Na czas analizy wyłącz przycisk "Analizuj połączenia" i zmień jego tekst na "Analizuję..."
            analizujPolaczenia.Enabled = false;
            analizujPolaczenia.Text = "Analizuję...";
            // Na czas analizy wyłącz okienko z zadeklarowaną ilością łączeń
            iloscLaczen.Enabled = false;
            // Na czas analizy wyłącz checkBox'y dodatkoweLaczenia i mieszaneLaczenia
            dodatkoweLaczenia.Enabled = false;
            mieszaneLaczenia.Enabled = false;
            // Na czas analizy wyłącz przycisk "Załaduj Przedmioty"
            zaladujPrzedmioty.Enabled = false;
            // Wyłącz przycisk "Aktualizuj filtr" i wyczyść wyświetlane wyniki łączeń
            filtrUpdate.Enabled = false;
            polaczonePrzedmioty.DataSource = null;
            // Wyłącz i odznacz checkBox "Wyświetl mimio wszystko"
            checkBoxWyswietl.Enabled = false;
            checkBoxWyswietl.Checked = false;
            // Wyczyść wyniki łączeń
            wyniki.Clear();

            // Lista z listami prefiksów, baz i sufiksów wysyłana do backgroundWorker'a
            List<List<string>> send = new List<List<string>>();
            switch (listaTypowPrzedmiotow.SelectedItem)
            {
                case "Hełm":
                    send.Add(PrefHelm);
                    send.Add(BazaHelm);
                    send.Add(SufHelm);
                    break;
                case "Zbroja":
                    send.Add(PrefZbroja);
                    send.Add(BazaZbroja);
                    send.Add(SufZbroja);
                    break;
                case "Spodnie":
                    send.Add(PrefSpodnie);
                    send.Add(BazaSpodnie);
                    send.Add(SufSpodnie);
                    break;
                case "Pierścień":
                    send.Add(PrefPierscien);
                    send.Add(BazaPierscien);
                    send.Add(SufPierscien);
                    break;
                case "Amulet":
                    send.Add(PrefAmulet);
                    send.Add(BazaAmulet);
                    send.Add(SufAmulet);
                    break;
                case "Biała 1h":
                    send.Add(PrefBiala1h);
                    send.Add(BazaBiala1h);
                    send.Add(SufBiala1h);
                    break;
                case "Biała 2h":
                    send.Add(PrefBiala2h);
                    send.Add(BazaBiala2h);
                    send.Add(SufBiala2h);
                    break;
                case "Palna 1h":
                    send.Add(PrefPalan1h);
                    send.Add(BazaPalna1h);
                    send.Add(SufPalna1h);
                    break;
                case "Palna 2h":
                    send.Add(PrefPalna2h);
                    send.Add(BazaPalna2h);
                    send.Add(SufPalna2h);
                    break;
                case "Dystans":
                    send.Add(PrefDystans);
                    send.Add(BazaDystans);
                    send.Add(SufDystans);
                    break;
            }

            // Uruchom backgroundWorker oraz wyślij do niego atrybut z listą prefiksów, baz i sufiksów
            analizatorWorker.RunWorkerAsync(send);
        }

        private void AnalizujWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // Funkcja wywoływana przez backgroundWorkera - analizujWorker
            // Potraktuj otrzymany argument jako lista list prefiksów, baz i sufiksów
            List<List<string>> arg = (List<List<string>>)e.Argument;

            // Wywołaj analizator połączeń
            AnalizujPolaczenia(arg[0], arg[1], arg[2]);

            // Po skończonej analizie zaktualizuj tekst przycisku i włącz kontrolki wyłączone na czas analizy
            this.Invoke((MethodInvoker)delegate
            {
                if (przedmioty.Count >= 10) iloscLaczen.Enabled = true;
                analizujPolaczenia.Text = "Analizuj połączenia";
                analizujPolaczenia.Enabled = true;
                dodatkoweLaczenia.Enabled = true;
                if (dodatkoweLaczenia.Checked == true) mieszaneLaczenia.Enabled = true;
                zaladujPrzedmioty.Enabled = true;
                checkBoxWyswietl.Enabled = true;
            });
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Przerwij backGroundWorker po wciśnięciu klawisza Esc
            if (keyData == Keys.Escape)
            {
                analizatorWorker.CancelAsync();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void AnalizujPolaczenia(List<string> pref, List<string> baza, List<string> suf)
        {
            // Główna funkcja analizatora połączeń sprawdzająca pierwsze połączenie
            // Lista wykorzystanych indeksów przedmiotów
            List<int> indeksy = new List<int>();
            // Zmienna do przechowywania wyniku łączenia
            Item wynik = new Item();
            // Zmienna do przechowywania ilości łączonych przedmiotów
            int iloscPrzedmiotów = przedmioty.Count;
            // Początkowa ilość łączeń = 1
            int iloscLacz = 1;
            // Maksymalna ilość łączeń odczytana z kontrolki do ustawiania ilości łączeń
            int maxIloscLaczen = (int)iloscLaczen.Value;

            for (int sk1 = 0; sk1 < iloscPrzedmiotów; sk1++)
            {
                // Wyczyść listę wykorzystanych indeksów oraz dodaj aktualnie wykorzystywany indeks
                indeksy.Clear();
                indeksy.Add(sk1);

                // Zaktualizuj procentowy postęp analizy połączeń
                this.Invoke((MethodInvoker)delegate
                {
                    znalezionoPolaczen.Text = "Znaleziono " + Math.Ceiling(((double)sk1 / ((double)iloscPrzedmiotów)) * 100d) + "% połączeń.";
                    this.Update();
                });

                // Rozpocznij drugą pętlę od następnego przedmiotu
                for (int sk2 = sk1 + 1; sk2 < iloscPrzedmiotów; sk2++)
                {
                    // Dodaj wykorzystany "indeks" przedmiotu z listy
                    indeksy.Add(sk2);

                    // Połącz składniki, dodaj historię łączenia oraz zwiększ ilość łączeń wyniku o 1, uwzględnij wyjątek przy łączeniu baz hełmów
                    if (baza == BazaHelm) wynik = new Item(przedmioty[sk1].Polacz(przedmioty[sk2], pref, baza, suf, true));
                    else wynik = new Item(przedmioty[sk1].Polacz(przedmioty[sk2], pref, baza, suf));
                    wynik.h = UsunSpacje(przedmioty[sk1], pref, baza, suf) + " + " + UsunSpacje(przedmioty[sk2], pref, baza, suf) + "\n= " + UsunSpacje(wynik, pref, baza, suf);
                    wynik.iloscLaczen += 1;
                    // Dodaj otrzymany wynik do listy wyników
                    wyniki.Add(wynik);

                    // Wywołaj pętle sprawdzające pozostałe łączenia
                    // Połączenia (((A+B)+C)+D) itd.
                    if (iloscLacz < maxIloscLaczen && analizatorWorker.CancellationPending == false) AnalizujRekFunc(indeksy, iloscPrzedmiotów, iloscLacz, maxIloscLaczen, wynik, pref, baza, suf);
                    // Połączenia dodatkowe ((A+B)+(C+D)) itd.
                    if (iloscLacz + 2 <= maxIloscLaczen && dodatkoweLaczenia.Checked == true && analizatorWorker.CancellationPending == false) AnalizujRekFunc2(indeksy, iloscPrzedmiotów, iloscLacz, maxIloscLaczen, wynik, pref, baza, suf);

                    // Usuń wykorzystany "indeks" przedmiotu z listy
                    indeksy.Remove(sk2);

                    // Jeżeli wciśnięto klawisz Esc przerwij analizowanie
                    if (analizatorWorker.CancellationPending == true)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            // Daj użytkownikowi znać, że przerwał analizę
                            znalezionoPolaczen.Text = "Przerwano analizę.";
                        });
                        return;
                    }
                }
            }

            // Po zakończonej analizie połączeń wyświetl ilość znalezionych wyników
            this.Invoke((MethodInvoker)delegate
            {
                if (wyniki.Count == 1) znalezionoPolaczen.Text = "Znaleziono " + wyniki.Count + " połączenie.";
                if (wyniki.Count > 1 && wyniki.Count < 5) znalezionoPolaczen.Text = "Znaleziono " + wyniki.Count + " połączenia.";
                if (wyniki.Count >= 5) znalezionoPolaczen.Text = "Znaleziono " + wyniki.Count + " połączeń.";
            });

            // Po zakończonej analizie połączeń zaktualizuj filtr
            this.Invoke((MethodInvoker)delegate
            {
                // Aktualizuj prefiksy, bazy i sufiksy filtru
                switch (listaTypowPrzedmiotow.SelectedItem)
                {
                    case "Hełm":
                        AktualizujPozyjcieFiltr(PrefHelm, BazaHelm, SufHelm);
                        break;
                    case "Zbroja":
                        AktualizujPozyjcieFiltr(PrefZbroja, BazaZbroja, SufZbroja);
                        break;
                    case "Spodnie":
                        AktualizujPozyjcieFiltr(PrefSpodnie, BazaSpodnie, SufSpodnie);
                        break;
                    case "Pierścień":
                        AktualizujPozyjcieFiltr(PrefPierscien, BazaPierscien, SufPierscien);
                        break;
                    case "Amulet":
                        AktualizujPozyjcieFiltr(PrefAmulet, BazaAmulet, SufAmulet);
                        break;
                    case "Biała 1h":
                        AktualizujPozyjcieFiltr(PrefBiala1h, BazaBiala1h, SufBiala1h);
                        break;
                    case "Biała 2h":
                        AktualizujPozyjcieFiltr(PrefBiala2h, BazaBiala2h, SufBiala2h);
                        break;
                    case "Palna 1h":
                        AktualizujPozyjcieFiltr(PrefPalan1h, BazaPalna1h, SufPalna1h);
                        break;
                    case "Palna 2h":
                        AktualizujPozyjcieFiltr(PrefPalna2h, BazaPalna2h, SufPalna2h);
                        break;
                    case "Dystans":
                        AktualizujPozyjcieFiltr(PrefDystans, BazaDystans, SufDystans);
                        break;
                }

                // Włącz kontrolki filtra
                filtrUpdate.Enabled = true;
                cbFiltrPref.Enabled = true;
                cbFiltrBaza.Enabled = true;
                cbFiltrSuf.Enabled = true;
            });

            // Sortowanie wyników: jakość prefiksu -> jakość bazy -> jakość sufiksu -> ilość łączeń
            wyniki = wyniki.OrderBy(x => x.p).ThenBy(y => y.b).ThenBy(z => z.s).ThenBy(l => l.iloscLaczen).ToList();
        }

        private void AnalizujRekFunc(List<int> indeksy, int iloscPrzed, int iloscLacz, int maxIloscLaczen, Item skladnik, List<string> pref, List<string> baza, List<string> suf)
        {
            // Funkcja sprawdzająca proste łączenia - ((A+B)+C)+D
            // Zmienna do przechowywania wyniku łączenia
            Item wynik = new Item();
            // Zwiększ ilość łączeń o 1
            int iloscL = iloscLacz + 1;

            // Połącz wszystkie pozostałe przedmioty
            for (int i = 0; i < iloscPrzed; i++)
            {
                // Jeżeli wcześniej wykorzystano "indeks" przedmiotu to go pomiń
                if (indeksy.Contains(i)) continue;

                // Dodaj wykorzystany "indeks" przedmiotu do listy
                indeksy.Add(i);

                // Połącz otrzymany w argumentach składnik z pozostałym przedmiotem, uwzględnij wyjątek przy łączeniu baz hełmów
                if (baza == BazaHelm) wynik = new Item(skladnik.Polacz(przedmioty[i], pref, baza, suf, true));
                else wynik = new Item(skladnik.Polacz(przedmioty[i], pref, baza, suf));
                // Dodaj jego historię łączenia - historia łącznia składnika + aktualnie sprawdzany przedmiot + wynik łączenia
                wynik.h = skladnik.h + " + " + UsunSpacje(przedmioty[i], pref, baza, suf) + "\n= " + UsunSpacje(wynik, pref, baza, suf);
                // Zwiększ ilość łączeń wyniku - ilość łączeń składnika + ilość łączeń aktualnego przedmiotu + 1
                wynik.iloscLaczen = skladnik.iloscLaczen + przedmioty[i].iloscLaczen + 1;
                // Dodaj wynik do listy wyników
                wyniki.Add(wynik);

                // Wywołaj sam siebie + ogranicznie ilości sprawdzanych łączeń
                if (iloscL < maxIloscLaczen && analizatorWorker.CancellationPending == false) AnalizujRekFunc(indeksy, iloscPrzed, iloscL, maxIloscLaczen, wynik, pref, baza, suf);
                // Jeżeli zaznaczono połączenia mieszane wywołaj funkcję dodatkowych łączeń
                if (iloscL + 2 <= maxIloscLaczen && mieszaneLaczenia.Checked == true && analizatorWorker.CancellationPending == false) AnalizujRekFunc2(indeksy, iloscPrzed, iloscL, maxIloscLaczen, wynik, pref, baza, suf);

                // Usuń wykorzystany "indeks" przedmiotu z listy
                indeksy.Remove(i);

                // Wyjdź z funkcji jeżeli przerwano analizę połączeń
                if (analizatorWorker.CancellationPending == true) return;
            }
        }

        private void AnalizujRekFunc2(List<int> indeksy, int iloscPrzed, int iloscLacz, int maxIloscLaczen, Item skladnik, List<string> pref, List<string> baza, List<string> suf)
        {
            // Funkcja sprawdzająca dodatkowe łączenia (A+B)+(C+D)
            // Zmienna do przechowywania tymczasowego składnika - wyniku łączenia dwóch przedmiotów, które zostaną połączone z otrzymanym składnikiem w argumentach funkcji
            Item skladnikTemp = new Item();
            // Zmienna do przechowywania wyniku łączenia
            Item wynik = new Item();
            // Zwiększ ilość łączeń o 2
            int iloscL = iloscLacz + 2;

            for (int i = 0; i < iloscPrzed; i++)
            {
                // Jeżeli wcześniej wykorzystano "indeks" przedmiotu to go pomiń
                if (indeksy.Contains(i)) continue;

                // Dodaj wykorzystany "indeks" przedmiotu do listy
                indeksy.Add(i);

                for (int j = 0; j < iloscPrzed; j++)
                {
                    // Jeżeli wcześniej wykorzystano "indeks" przedmiotu to go pomiń
                    if (indeksy.Contains(j)) continue;

                    // Dodaj wykorzystany "indeks" przedmiotu do listy
                    indeksy.Add(j);

                    // Połącz dwa przedmioty aby otrzymać tymczasowy składnik, uwzględnij wyjątek przy łączeniu baz hełmów
                    if (baza == BazaHelm) skladnikTemp = new Item(przedmioty[i].Polacz(przedmioty[j], pref, baza, suf, true));
                    else skladnikTemp = new Item(przedmioty[i].Polacz(przedmioty[j], pref, baza, suf));
                    // Dodaj historię łączenia tymczasowego składnika - historia łączenia przedmiotu 1 + historia łączenia przedmiotu 2
                    skladnikTemp.h = "(" + UsunSpacje(przedmioty[i], pref, baza, suf) + " + " + UsunSpacje(przedmioty[j], pref, baza, suf) + ")";
                    // Ustaw ilość łączeń tymczasowego składnika - ilość łączeń przedmiotu 1 + ilość łączeń przedmiotu 2 + 1
                    skladnikTemp.iloscLaczen = przedmioty[i].iloscLaczen + przedmioty[j].iloscLaczen + 1;

                    // Połącz tymczasowy składnik ze składnikiem otrzymanym w argumencie funkcji, uwzględnij wyjątek przy łączeniu baz hełmów
                    if (baza == BazaHelm) wynik = new Item(skladnik.Polacz(skladnikTemp, pref, baza, suf, true));
                    else wynik = new Item(skladnik.Polacz(skladnikTemp, pref, baza, suf));
                    // Dodaj historię łączenia wyniku - historia łączenia skłądnika + historia łączenia tymczasowego składnika + wynik łączenia
                    wynik.h = skladnik.h + " + " + skladnikTemp.h + "\n= " + UsunSpacje(wynik, pref, baza, suf);
                    // Ustaw ilość łączeń wyniku - ilość łączeń składnika + ilość łączeń tymczasowego składnika
                    wynik.iloscLaczen = skladnik.iloscLaczen + skladnikTemp.iloscLaczen + 1;

                    // Dodaj otrzymany wynik łączenia do listy wyników
                    wyniki.Add(wynik);

                    // Wywołaj sam siebie jeżeli ilość itemów > ilości pętli + 2
                    if (iloscL + 2 <= maxIloscLaczen && analizatorWorker.CancellationPending == false) AnalizujRekFunc2(indeksy, iloscPrzed, iloscL, maxIloscLaczen, wynik, pref, baza, suf);
                    // Jeżeli zaznaczono połączenia mieszane wywołaj funkcję domyślnych łączeń
                    if (iloscL < maxIloscLaczen && mieszaneLaczenia.Checked == true && analizatorWorker.CancellationPending == false) AnalizujRekFunc(indeksy, iloscPrzed, iloscL, maxIloscLaczen, wynik, pref, baza, suf);

                    // Usuń wykorzystany "indeks" przedmiotu z listy
                    indeksy.Remove(j);

                    // Wyjdź z funkcji jeżeli przerwano analizę połączeń
                    if (analizatorWorker.CancellationPending == true) return;
                }

                // Usuń wykorzystany "indeks" przedmiotu z listy
                indeksy.Remove(i);
            }
        }

        private void AktualizujPozyjcieFiltr(List<string> pref, List<string> baza, List<string> suf)
        {
            // Zaktualizuj pozycje filtra
            // Wyczyść aktualne pozycje filtra
            cbFiltrPref.Items.Clear();
            cbFiltrBaza.Items.Clear();
            cbFiltrSuf.Items.Clear();

            // Dodaj nowe pozycje filtra
            foreach (string p in pref) cbFiltrPref.Items.Add(p);
            foreach (string b in baza) cbFiltrBaza.Items.Add(b);
            foreach (string s in suf) cbFiltrSuf.Items.Add(s);
        }

        private void FiltrUpdate_Click(object sender, EventArgs e)
        {
            // Przefiltruj wyniki połączeń
            // Na czas filtrowania i dodawania wyników wyłącz obsługę zdarzeń
            polaczonePrzedmioty.SelectedIndexChanged -= new EventHandler(PolaczonePrzedmioty_SelectedIndexChanged);
            // Wyczyść wyświetlane przefiltorwane wyniki
            polaczonePrzedmioty.DataSource = null;

            // Wywołaj funkcję do filtrowania wyników łączeń
            switch (listaTypowPrzedmiotow.SelectedItem)
            {
                case "Hełm":
                    FiltrUpdate(PrefHelm, BazaHelm, SufHelm);
                    break;
                case "Zbroja":
                    FiltrUpdate(PrefZbroja, BazaZbroja, SufZbroja);
                    break;
                case "Spodnie":
                    FiltrUpdate(PrefSpodnie, BazaSpodnie, SufSpodnie);
                    break;
                case "Pierścień":
                    FiltrUpdate(PrefPierscien, BazaPierscien, SufPierscien);
                    break;
                case "Amulet":
                    FiltrUpdate(PrefAmulet, BazaAmulet, SufAmulet);
                    break;
                case "Biała 1h":
                    FiltrUpdate(PrefBiala1h, BazaBiala1h, SufBiala1h);
                    break;
                case "Biała 2h":
                    FiltrUpdate(PrefBiala2h, BazaBiala2h, SufBiala2h);
                    break;
                case "Palna 1h":
                    FiltrUpdate(PrefPalan1h, BazaPalna1h, SufPalna1h);
                    break;
                case "Palna 2h":
                    FiltrUpdate(PrefPalna2h, BazaPalna2h, SufPalna2h);
                    break;
                case "Dystans":
                    FiltrUpdate(PrefDystans, BazaDystans, SufDystans);
                    break;
            }

            // Po zakończonym filtorwaniu wyników włącz listę wyświetlającą wyniki oraz dodaj obsługę zdarzeń
            polaczonePrzedmioty.Enabled = true;
            polaczonePrzedmioty.SelectedIndexChanged += new EventHandler(PolaczonePrzedmioty_SelectedIndexChanged);
            polaczonePrzedmioty.SelectedIndex = -1;
        }

        private void FiltrUpdate(List<string> pref, List<string> baza, List<string> suf)
        {
            // Funkcja filtrująca wyniki łączeń oraz zmieniająca Item'y na string'i
            // Lista przechowująca przefiltrowanie wyniki łączeń w postaci string'ów
            List<string> wynikiTekst = new List<string>();
            // Zmienne do przechowywania wybranych parametrów filtra
            int filtrPref = pref.IndexOf(cbFiltrPref.Text);
            int filtrBaza = baza.IndexOf(cbFiltrBaza.Text);
            int filtrSuf = suf.IndexOf(cbFiltrSuf.Text);

            // Na czas filtrowania i dodawania wyników wyłącz przycisk "Aktualizuj filtr" oraz zmień jego tekst na "Aktualizuję..."
            filtrUpdate.Enabled = false;
            filtrUpdate.Text = "Aktualizuję...";
            this.Update();

            // Lista wiążąca przefiltorwane wyniki w postaci tekstu z listą wszystkich wyników
            // lista ta przechowuje "indeks" wyniku dodawanego do listy przefiltorwanych wyników
            // wyświetlany przedmiot = wynik . elementAt ( filtrPrzedmioty( indkes_wybranego_przefiltrowanego_wyniku ) )
            filtrPrzedmioty.Clear();

            // Przefiltruj wyniki
            for (int i = 0; i < wyniki.Count; i++)
            {
                if (filtrPref == 0 && filtrBaza == 0 && filtrSuf == 0)
                {
                    // Pref, baza i suf dowolny - pokaż wszystko
                    wynikiTekst.Add(UsunSpacje(wyniki[i], pref, baza, suf));
                    filtrPrzedmioty.Add(i);
                    continue;
                }
                else if (wyniki[i].p == filtrPref)
                {
                    // Wybrano prefiks do filtrowania
                    if (wyniki[i].b == filtrBaza)
                    {
                        // Wybrano prefiks i bazę do filtrowania
                        if (wyniki[i].s == filtrSuf)
                        {
                            // Wybrano prefiks, bazę i sufiks do filtrowania
                            wynikiTekst.Add(UsunSpacje(wyniki[i], pref, baza, suf));
                            filtrPrzedmioty.Add(i);
                            continue;
                        }
                        else if (filtrSuf == 0)
                        {
                            // Wybrano prefiks i bazę do filtrowania, dowolny sufiks
                            wynikiTekst.Add(UsunSpacje(wyniki[i], pref, baza, suf));
                            filtrPrzedmioty.Add(i);
                            continue;
                        }
                    }
                    else if (filtrBaza == 0)
                    {
                        // Wybrano prefiks do filtrowania i dowolną bazę
                        if (wyniki[i].s == filtrSuf)
                        {
                            // Wybrano prefiks i sufiks do filtrowania
                            wynikiTekst.Add(UsunSpacje(wyniki[i], pref, baza, suf));
                            filtrPrzedmioty.Add(i);
                            continue;
                        }
                        else if (filtrSuf == 0)
                        {
                            // Wybrano prefiks do filtrowania, dowolna baza i sufiks
                            wynikiTekst.Add(UsunSpacje(wyniki[i], pref, baza, suf));
                            filtrPrzedmioty.Add(i);
                            continue;
                        }
                    }
                }
                else if (filtrPref == 0)
                {
                    // Dowolny prefiks
                    if (wyniki[i].b == filtrBaza)
                    {
                        // Wybrano bazę do filtrowania, dowolny prefiks
                        if (wyniki[i].s == filtrSuf)
                        {
                            // Wybrano bazę i sufiks do filtrowania, dowolny prefiks
                            wynikiTekst.Add(UsunSpacje(wyniki[i], pref, baza, suf));
                            filtrPrzedmioty.Add(i);
                            continue;
                        }
                        else if (filtrSuf == 0)
                        {
                            // Wybrano bazę do filtrowania, dowolny prefiks i sufiks
                            wynikiTekst.Add(UsunSpacje(wyniki[i], pref, baza, suf));
                            filtrPrzedmioty.Add(i);
                            continue;
                        }
                    }
                    else if (filtrBaza == 0)
                    {
                        // Dowolny prefiks i baza
                        if (wyniki[i].s == filtrSuf)
                        {
                            // Wybrano sufiks do filtrowania, dowolny prefiks i baza
                            wynikiTekst.Add(UsunSpacje(wyniki[i], pref, baza, suf));
                            filtrPrzedmioty.Add(i);
                            continue;
                        }
                        else if (filtrSuf == 0)
                        {
                            // Dowolny prefiks, baza i sufiks
                            wynikiTekst.Add(UsunSpacje(wyniki[i], pref, baza, suf));
                            filtrPrzedmioty.Add(i);
                            continue;
                        }
                    }
                }
            }

            // Jeżeli ilość przefiltrowanych wyników jest większa niż 62 tyś. wyświetl ostrzeżenie i wyjdź z funkcji
            if (wynikiTekst.Count > 62000 && checkBoxWyswietl.Checked == false)
            {
                pomoc = new Pomoc("Wyniki łączeń", wynikiTekst.Count);
                pomoc.ShowDialog(this);

                filtrUpdate.Text = "Aktualizuj filtr";
                filtrUpdate.Enabled = true;
                return;
            }

            // Dodaj przefiltrowane wyniki do listy wyświetlanych wyników
            polaczonePrzedmioty.DataSource = wynikiTekst;
            filtrUpdate.Text = "Aktualizuj filtr";
            filtrUpdate.Enabled = true;
        }

        private void PolaczonePrzedmioty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (polaczonePrzedmioty.SelectedIndex >= 0)
            {
                // Aktualizacja historii łączeń po zmianie wybranego wyniku połączenia
                int index = filtrPrzedmioty[polaczonePrzedmioty.SelectedIndex];
                przedmiotyDoAnalizy.Text = wyniki[index].h;
            }
        }

        private void PrzedmiotyDoAnalizy_Enter(object sender, EventArgs e)
        {
            // Usuń "startowy" tekst w okienku analizatora łączeń po kliknięciu w nie
            if (doOnceAnalizator)
            {
                doOnceAnalizator = false;
                przedmiotyDoAnalizy.Text = "";
            }
        }

        private void AnalizatorLaczenPomoc_Click(object sender, EventArgs e)
        {
            // Szybka pomoc jak korzystać z analizatora łączeń
            pomoc = new Pomoc("Analizator łączeń");
            pomoc.ShowDialog(this);
        }

        private string UsunSpacje(Item i, List<string> pref, List<string> baza, List<string> suf)
        {
            // Funkcja zwracająca prefiks, bazę i sufiks przedmiotu w postaci stringa bez niepotrzebnych spacji
            string s = "";
            if (i.p != 0) s += pref.ElementAt(i.p);
            if (i.p != 0 && i.b != 0) s += " ";
            if (i.b != 0) s += baza.ElementAt(i.b);
            if ((i.p != 0 || i.b != 0) && i.s != 0) s += " ";
            if (i.s != 0) s += suf.ElementAt(i.s);
            return s;
        }

        private void EdytujPrzedmioty_Click(object sender, EventArgs e)
        {
            przedmiotyDoAnalizy.Text = "";

            switch (listaTypowPrzedmiotow.SelectedItem)
            {
                case "Hełm":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefHelm, BazaHelm, SufHelm) + '\n');
                    break;
                case "Zbroja":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefZbroja, BazaZbroja, SufZbroja) + '\n');
                    break;
                case "Spodnie":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefSpodnie, BazaSpodnie, SufSpodnie) + '\n');
                    break;
                case "Pierścień":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefPierscien, BazaPierscien, SufPierscien) + '\n');
                    break;
                case "Amulet":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefAmulet, BazaAmulet, SufAmulet) + '\n');
                    break;
                case "Biała 1h":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefBiala1h, BazaBiala1h, SufBiala1h) + '\n');
                    break;
                case "Biała 2h":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefBiala2h, BazaBiala2h, SufBiala2h) + '\n');
                    break;
                case "Palna 1h":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefPalan1h, BazaPalna1h, SufPalna1h) + '\n');
                    break;
                case "Palna 2h":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefPalna2h, BazaPalna2h, SufPalna2h) + '\n');
                    break;
                case "Dystans":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefDystans, BazaDystans, SufDystans) + '\n');
                    break;
            }
        }

        private void SortujPrzedmioty_Click(object sender, EventArgs e)
        {
            przedmiotyDoAnalizy.Text = "";
            przedmioty = przedmioty.OrderBy(y => y.p).ThenBy(z => z.b).ThenBy(k => k.s).ToList();

            switch (listaTypowPrzedmiotow.SelectedItem)
            {
                case "Hełm":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefHelm, BazaHelm, SufHelm) + '\n');
                    break;
                case "Zbroja":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefZbroja, BazaZbroja, SufZbroja) + '\n');
                    break;
                case "Spodnie":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefSpodnie, BazaSpodnie, SufSpodnie) + '\n');
                    break;
                case "Pierścień":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefPierscien, BazaPierscien, SufPierscien) + '\n');
                    break;
                case "Amulet":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefAmulet, BazaAmulet, SufAmulet) + '\n');
                    break;
                case "Biała 1h":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefBiala1h, BazaBiala1h, SufBiala1h) + '\n');
                    break;
                case "Biała 2h":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefBiala2h, BazaBiala2h, SufBiala2h) + '\n');
                    break;
                case "Palna 1h":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefPalan1h, BazaPalna1h, SufPalna1h) + '\n');
                    break;
                case "Palna 2h":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefPalna2h, BazaPalna2h, SufPalna2h) + '\n');
                    break;
                case "Dystans":
                    foreach (Item i in przedmioty) przedmiotyDoAnalizy.AppendText(UsunSpacje(i, PrefDystans, BazaDystans, SufDystans) + '\n');
                    break;
            }
        }

        private void DodatkoweLaczenia_CheckedChanged(object sender, EventArgs e)
        {
            if (dodatkoweLaczenia.Checked == true)
            {
                mieszaneLaczenia.Enabled = true;
            }

            if (dodatkoweLaczenia.Checked == false)
            {
                mieszaneLaczenia.Enabled = false;
                mieszaneLaczenia.Checked = false;
            }
        }

        private void GlownyTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            Czyszczenie();

            if (GlownyTab.SelectedTab.Text == "Analizator raportu")
            {
                wklejToolStripMenuItem.Enabled = true;
                schowekToolStripMenuItem.Enabled = false;
            }
            else if (GlownyTab.SelectedTab.Text == "Analizator łączeń")
            {
                wklejToolStripMenuItem.Enabled = true;
                schowekToolStripMenuItem.Enabled = false;
            }
            else
            {
                wklejToolStripMenuItem.Enabled = false;
                schowekToolStripMenuItem.Enabled = true;
            }
        }

        private void Czyszczenie()
        {
            // Czyszczenie składników i okienek wyników po przepłączeniu zakładki
            component1 = new Item();
            component2 = new Item();
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

        private void WklejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlownyTab.SelectedTab.Text == "Analizator raportu")
            {
                AnalizatorRaportuTekst.Paste();
                AnalizatorRaportuTekst.ScrollToCaret();
            }
            if (GlownyTab.SelectedTab.Text == "Analizator łączeń")
            {
                przedmiotyDoAnalizy.Paste();
                przedmiotyDoAnalizy.ScrollToCaret();
            }
        }

        private void KopiujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kopiuj zaznaczony tekst do schowka systemowego
            switch (GlownyTab.SelectedTab.Text)
            {
                case "Hełm":
                    if (helmWynik.SelectedText != "") Clipboard.SetText(helmWynik.SelectedText);
                    break;
                case "Zbroja":
                    if (zbrojaWynik.SelectedText != "") Clipboard.SetText(zbrojaWynik.SelectedText);
                    break;
                case "Spodnie":
                    if (spodnieWynik.SelectedText != "") Clipboard.SetText(spodnieWynik.SelectedText);
                    break;
                case "Pierścień":
                    if (pierscienWynik.SelectedText != "") Clipboard.SetText(pierscienWynik.SelectedText);
                    break;
                case "Amulet":
                    if (amuletWynik.SelectedText != "") Clipboard.SetText(amuletWynik.SelectedText);
                    break;
                case "Biała 1h":
                    if (biala1hWynik.SelectedText != "") Clipboard.SetText(biala1hWynik.SelectedText);
                    break;
                case "Biała 2h":
                    if (biala2hWynik.SelectedText != "") Clipboard.SetText(biala2hWynik.SelectedText);
                    break;
                case "Palna 1h":
                    if (palna1hWynik.SelectedText != "") Clipboard.SetText(palna1hWynik.SelectedText);
                    break;
                case "Palna 2h":
                    if (palna2hWynik.SelectedText != "") Clipboard.SetText(palna2hWynik.SelectedText);
                    break;
                case "Dystans":
                    if (dystansWynik.SelectedText != "") Clipboard.SetText(dystansWynik.SelectedText);
                    break;
                case "Analizator raportu":
                    if (AnalizatorRaportuTekst.SelectedText != "") Clipboard.SetText(AnalizatorRaportuTekst.SelectedText);
                    break;
                case "Analizator łączeń":
                    if (przedmiotyDoAnalizy.SelectedText != "") Clipboard.SetText(przedmiotyDoAnalizy.SelectedText);
                    break;
            }
        }

        private void KopiujWszystkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kopiuj wszystko do schowka systemowego
            switch (GlownyTab.SelectedTab.Text)
            {
                case "Hełm":
                    if (helmWynik.Text != "") Clipboard.SetText(helmWynik.Text);
                    break;
                case "Zbroja":
                    if (zbrojaWynik.Text != "") Clipboard.SetText(zbrojaWynik.Text);
                    break;
                case "Spodnie":
                    if (spodnieWynik.Text != "") Clipboard.SetText(spodnieWynik.Text);
                    break;
                case "Pierścień":
                    if (pierscienWynik.Text != "") Clipboard.SetText(pierscienWynik.Text);
                    break;
                case "Amulet":
                    if (amuletWynik.Text != "") Clipboard.SetText(amuletWynik.Text);
                    break;
                case "Biała 1h":
                    if (biala1hWynik.Text != "") Clipboard.SetText(biala1hWynik.Text);
                    break;
                case "Biała 2h":
                    if (biala2hWynik.Text != "") Clipboard.SetText(biala2hWynik.Text);
                    break;
                case "Palna 1h":
                    if (palna1hWynik.Text != "") Clipboard.SetText(palna1hWynik.Text);
                    break;
                case "Palna 2h":
                    if (palna2hWynik.Text != "") Clipboard.SetText(palna2hWynik.Text);
                    break;
                case "Dystans":
                    if (dystansWynik.Text != "") Clipboard.SetText(dystansWynik.Text);
                    break;
                case "Analizator raportu":
                    if (AnalizatorRaportuTekst.Text != "") Clipboard.SetText(AnalizatorRaportuTekst.Text);
                    break;
                case "Analizator łączeń":
                    if (przedmiotyDoAnalizy.Text != "") Clipboard.SetText(przedmiotyDoAnalizy.Text);
                    break;
            }
        }

        private void ZapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Zapisz tekst do pliku, domyślnie format .txt
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
                        case "Analizator łączeń":
                            aa.Write(przedmiotyDoAnalizy.Text);
                            break;
                    }
                }
            }
        }

        private void WyczyscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlownyTab.SelectedTab.Text == "Analizator łączeń") przedmiotyDoAnalizy.Clear();
            Czyszczenie();
        }

        private void SchowekPoz1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (GlownyTab.SelectedTab.Text)
            {
                case "Hełm":
                    WyslijDoSchowka(helmWynik.SelectedText, PrefHelm, BazaHelm, SufHelm, cbHelmPref_sh1, cbHelmBaza_sh1, cbHelmSuf_sh1);
                    break;
                case "Zbroja":
                    WyslijDoSchowka(zbrojaWynik.SelectedText, PrefZbroja, BazaZbroja, SufZbroja, cbZbrojaPref_sh1, cbZbrojaBaza_sh1, cbZbrojaSuf_sh1);
                    break;
                case "Spodnie":
                    WyslijDoSchowka(spodnieWynik.SelectedText, PrefSpodnie, BazaSpodnie, SufSpodnie, cbSpodniePref_sh1, cbSpodnieBaza_sh1, cbSpodnieSuf_sh1);
                    break;
                case "Pierścień":
                    WyslijDoSchowka(pierscienWynik.SelectedText, PrefPierscien, BazaPierscien, SufPierscien, cbPierscienPref_sh1, cbPierscienBaza_sh1, cbPierscienSuf_sh1);
                    break;
                case "Amulet":
                    WyslijDoSchowka(amuletWynik.SelectedText, PrefAmulet, BazaAmulet, SufAmulet, cbAmuletPref_sh1, cbAmuletBaza_sh1, cbAmuletSuf_sh1);
                    break;
                case "Biała 1h":
                    WyslijDoSchowka(biala1hWynik.SelectedText, PrefBiala1h, BazaBiala1h, SufBiala1h, cbBiala1hPref_sh1, cbBiala1hBaza_sh1, cbBiala1hSuf_sh1);
                    break;
                case "Biała 2h":
                    WyslijDoSchowka(biala2hWynik.SelectedText, PrefBiala2h, BazaBiala2h, SufBiala2h, cbBiala2hPref_sh1, cbBiala2hBaza_sh1, cbBiala2hSuf_sh1);
                    break;
                case "Palna 1h":
                    WyslijDoSchowka(palna1hWynik.SelectedText, PrefPalan1h, BazaPalna1h, SufPalna1h, cbPalna1hPref_sh1, cbPalna1hBaza_sh1, cbPalna1hSuf_sh1);
                    break;
                case "Palna 2h":
                    WyslijDoSchowka(palna2hWynik.SelectedText, PrefPalna2h, BazaPalna2h, SufPalna2h, cbPalna2hPref_sh1, cbPalna2hBaza_sh1, cbPalna2hSuf_sh1);
                    break;
                case "Dystans":
                    WyslijDoSchowka(dystansWynik.SelectedText, PrefDystans, BazaDystans, SufDystans, cbDystansPref_sh1, cbDystansBaza_sh1, cbDystansSuf_sh1);
                    break;
            }
        }

        private void SchowekPoz2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (GlownyTab.SelectedTab.Text)
            {
                case "Hełm":
                    WyslijDoSchowka(helmWynik.SelectedText, PrefHelm, BazaHelm, SufHelm, cbHelmPref_sh2, cbHelmBaza_sh2, cbHelmSuf_sh2);
                    break;
                case "Zbroja":
                    WyslijDoSchowka(zbrojaWynik.SelectedText, PrefZbroja, BazaZbroja, SufZbroja, cbZbrojaPref_sh2, cbZbrojaBaza_sh2, cbZbrojaSuf_sh2);
                    break;
                case "Spodnie":
                    WyslijDoSchowka(spodnieWynik.SelectedText, PrefSpodnie, BazaSpodnie, SufSpodnie, cbSpodniePref_sh2, cbSpodnieBaza_sh2, cbSpodnieSuf_sh2);
                    break;
                case "Pierścień":
                    WyslijDoSchowka(pierscienWynik.SelectedText, PrefPierscien, BazaPierscien, SufPierscien, cbPierscienPref_sh2, cbPierscienBaza_sh2, cbPierscienSuf_sh2);
                    break;
                case "Amulet":
                    WyslijDoSchowka(amuletWynik.SelectedText, PrefAmulet, BazaAmulet, SufAmulet, cbAmuletPref_sh2, cbAmuletBaza_sh2, cbAmuletSuf_sh2);
                    break;
                case "Biała 1h":
                    WyslijDoSchowka(biala1hWynik.SelectedText, PrefBiala1h, BazaBiala1h, SufBiala1h, cbBiala1hPref_sh2, cbBiala1hBaza_sh2, cbBiala1hSuf_sh2);
                    break;
                case "Biała 2h":
                    WyslijDoSchowka(biala2hWynik.SelectedText, PrefBiala2h, BazaBiala2h, SufBiala2h, cbBiala2hPref_sh2, cbBiala2hBaza_sh2, cbBiala2hSuf_sh2);
                    break;
                case "Palna 1h":
                    WyslijDoSchowka(palna1hWynik.SelectedText, PrefPalan1h, BazaPalna1h, SufPalna1h, cbPalna1hPref_sh2, cbPalna1hBaza_sh2, cbPalna1hSuf_sh2);
                    break;
                case "Palna 2h":
                    WyslijDoSchowka(palna2hWynik.SelectedText, PrefPalna2h, BazaPalna2h, SufPalna2h, cbPalna2hPref_sh2, cbPalna2hBaza_sh2, cbPalna2hSuf_sh2);
                    break;
                case "Dystans":
                    WyslijDoSchowka(dystansWynik.SelectedText, PrefDystans, BazaDystans, SufDystans, cbDystansPref_sh2, cbDystansBaza_sh2, cbDystansSuf_sh2);
                    break;
            }
        }

        private void SchowekPoz3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (GlownyTab.SelectedTab.Text)
            {
                case "Hełm":
                    WyslijDoSchowka(helmWynik.SelectedText, PrefHelm, BazaHelm, SufHelm, cbHelmPref_sh3, cbHelmBaza_sh3, cbHelmSuf_sh3);
                    break;
                case "Zbroja":
                    WyslijDoSchowka(zbrojaWynik.SelectedText, PrefZbroja, BazaZbroja, SufZbroja, cbZbrojaPref_sh3, cbZbrojaBaza_sh3, cbZbrojaSuf_sh3);
                    break;
                case "Spodnie":
                    WyslijDoSchowka(spodnieWynik.SelectedText, PrefSpodnie, BazaSpodnie, SufSpodnie, cbSpodniePref_sh3, cbSpodnieBaza_sh3, cbSpodnieSuf_sh3);
                    break;
                case "Pierścień":
                    WyslijDoSchowka(pierscienWynik.SelectedText, PrefPierscien, BazaPierscien, SufPierscien, cbPierscienPref_sh3, cbPierscienBaza_sh3, cbPierscienSuf_sh3);
                    break;
                case "Amulet":
                    WyslijDoSchowka(amuletWynik.SelectedText, PrefAmulet, BazaAmulet, SufAmulet, cbAmuletPref_sh3, cbAmuletBaza_sh3, cbAmuletSuf_sh3);
                    break;
                case "Biała 1h":
                    WyslijDoSchowka(biala1hWynik.SelectedText, PrefBiala1h, BazaBiala1h, SufBiala1h, cbBiala1hPref_sh3, cbBiala1hBaza_sh3, cbBiala1hSuf_sh3);
                    break;
                case "Biała 2h":
                    WyslijDoSchowka(biala2hWynik.SelectedText, PrefBiala2h, BazaBiala2h, SufBiala2h, cbBiala2hPref_sh3, cbBiala2hBaza_sh3, cbBiala2hSuf_sh3);
                    break;
                case "Palna 1h":
                    WyslijDoSchowka(palna1hWynik.SelectedText, PrefPalan1h, BazaPalna1h, SufPalna1h, cbPalna1hPref_sh3, cbPalna1hBaza_sh3, cbPalna1hSuf_sh3);
                    break;
                case "Palna 2h":
                    WyslijDoSchowka(palna2hWynik.SelectedText, PrefPalna2h, BazaPalna2h, SufPalna2h, cbPalna2hPref_sh3, cbPalna2hBaza_sh3, cbPalna2hSuf_sh3);
                    break;
                case "Dystans":
                    WyslijDoSchowka(dystansWynik.SelectedText, PrefDystans, BazaDystans, SufDystans, cbDystansPref_sh3, cbDystansBaza_sh3, cbDystansSuf_sh3);
                    break;
            }
        }

        private void WyslijDoSchowka(string tekst, List<string> pref, List<string> baza, List<string> suf, ComboBox cbPref, ComboBox cbBaza, ComboBox cbSuf)
        {
            Item przedmiot = new Item();

            for (int i = 0; i < pref.Count; i++)
            {
                if (tekst.Contains(pref[i])) przedmiot.p = i;
            }
            for (int i = 0; i < baza.Count; i++)
            {
                if (tekst.Contains(baza[i])) przedmiot.b = i;
            }
            for (int i = 0; i < suf.Count; i++)
            {
                if (tekst.Contains(suf[i])) przedmiot.s = i;
            }

            cbPref.SelectedIndex = przedmiot.p;
            cbBaza.SelectedIndex = przedmiot.b;
            cbSuf.SelectedIndex = przedmiot.s;
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
            suf.Add("Smoczej Łuski");
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
            suf.Add("Narkomana");
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
            suf.Add("Siewcy Śmierci");
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
            suf.Add("Cichych Ruchów");
            suf.Add("Uników");
            suf.Add("Skrytości");
            suf.Add("Słońca");
            suf.Add("Handlarza Bronią");
            suf.Add("Pasterza");
            suf.Add("Łowcy Cieni");
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
            suf.Add("Twardej Skóry");
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
            suf.Add("Twardej Skóry");
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
            baza.Add("Pięść Niebios");

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
            baza.Add("Piła łańcuchowa");

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

        private void Label1_Click(object sender, EventArgs e)
        {
            // Odsyłacz do mojej postaci
            System.Diagnostics.Process.Start("https://r19.bloodwars.interia.pl/showmsg.php?a=profile&uid=2755");
        }
    }
}