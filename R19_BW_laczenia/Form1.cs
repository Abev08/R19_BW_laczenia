using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R19_BW_laczenia
{
    public partial class Form1 : Form
    {
        public Form2 tabela;

        // Listy prefiksów, baz i sufiksów każdego typu przedmiotów
        List<string> prefHelm = new List<string>();
        List<string> bazaHelm = new List<string>();
        List<string> sufHelm = new List<string>();

        List<string> prefZbroja = new List<string>();
        List<string> bazaZbroja = new List<string>();
        List<string> sufZbroja = new List<string>();

        List<string> prefSpodnie = new List<string>();
        List<string> bazaSpodnie = new List<string>();
        List<string> sufSpodnie = new List<string>();

        List<string> prefPierscien = new List<string>();
        List<string> bazaPierscien = new List<string>();
        List<string> sufPierscien = new List<string>();

        List<string> prefAmulet = new List<string>();
        List<string> bazaAmulet = new List<string>();
        List<string> sufAmulet = new List<string>();

        List<string> prefBiala1h = new List<string>();
        List<string> bazaBiala1h = new List<string>();
        List<string> sufBiala1h = new List<string>();

        List<string> prefBiala2h = new List<string>();
        List<string> bazaBiala2h = new List<string>();
        List<string> sufBiala2h = new List<string>();

        List<string> prefPalna1h = new List<string>();
        List<string> bazaPalna1h = new List<string>();
        List<string> sufPalna1h = new List<string>();

        List<string> prefPalna2h = new List<string>();
        List<string> bazaPalna2h = new List<string>();
        List<string> sufPalna2h = new List<string>();

        List<string> prefDystans = new List<string>();
        List<string> bazaDystans = new List<string>();
        List<string> sufDystans = new List<string>();

        // Zmienne do łączenia
        int[] skladnik1 = new int[4];
        int[] skladnik2 = new int[4];
        int[] wynikLaczenia = new int[4];
        int[] wynikTab = new int[4];
        bool dodano = false;

        // Zmienna do analizatora raportów
        string[] ulepszenia;

        public Form1()
        {
            InitializeComponent();
            // Załaduj bazy przedmiotów
            bazaHelmow();
            bazaZbroi();
            bazaSpodni();
            bazaPierścieni();
            bazaAmuletow();
            bazaBialych1h();
            bazaBialych2h();
            bazaPalnych1h();
            bazaPalnych2h();
            bazaDystansow();

            // Dodawanie prefiksów, baz i sufiksów do comboBox'ów
            // Hełm
            helmWynik.ReadOnly = true;
            helmWynik.ContextMenuStrip = contextMenuStrip1;
            foreach (string s in prefHelm)
            {
                cbHelmPref.Items.Add(s);
                cbHelmPref_sh1.Items.Add(s);
                cbHelmPref_sh2.Items.Add(s);
                cbHelmPref_sh3.Items.Add(s);
            }
            cbHelmPref.SelectedIndex = 0;
            foreach (string s in bazaHelm)
            {
                cbHelmBaza.Items.Add(s);
                cbHelmBaza_sh1.Items.Add(s);
                cbHelmBaza_sh2.Items.Add(s);
                cbHelmBaza_sh3.Items.Add(s);
            }
            cbHelmBaza.SelectedIndex = 0;
            foreach (string s in sufHelm)
            {
                cbHelmSuf.Items.Add(s);
                cbHelmSuf_sh1.Items.Add(s);
                cbHelmSuf_sh2.Items.Add(s);
                cbHelmSuf_sh3.Items.Add(s);
            }
            cbHelmSuf.SelectedIndex = 0;

            // Zbroja
            zbrojaWynik.ReadOnly = true;
            zbrojaWynik.ContextMenuStrip = contextMenuStrip1;
            foreach (string s in prefZbroja)
            {
                cbZbrojaPref.Items.Add(s);
                cbZbrojaPref_sh1.Items.Add(s);
                cbZbrojaPref_sh2.Items.Add(s);
                cbZbrojaPref_sh3.Items.Add(s);
            }
            cbZbrojaPref.SelectedIndex = 0;
            foreach (string s in bazaZbroja)
            {
                cbZbrojaBaza.Items.Add(s);
                cbZbrojaBaza_sh1.Items.Add(s);
                cbZbrojaBaza_sh2.Items.Add(s);
                cbZbrojaBaza_sh3.Items.Add(s);
            }
            cbZbrojaBaza.SelectedIndex = 0;
            foreach (string s in sufZbroja)
            {
                cbZbrojaSuf.Items.Add(s);
                cbZbrojaSuf_sh1.Items.Add(s);
                cbZbrojaSuf_sh2.Items.Add(s);
                cbZbrojaSuf_sh3.Items.Add(s);
            }
            cbZbrojaSuf.SelectedIndex = 0;

            // Spodnie
            spodnieWynik.ReadOnly = true;
            spodnieWynik.ContextMenuStrip = contextMenuStrip1;
            foreach (string s in prefSpodnie)
            {
                cbSpodniePref.Items.Add(s);
                cbSpodniePref_sh1.Items.Add(s);
                cbSpodniePref_sh2.Items.Add(s);
                cbSpodniePref_sh3.Items.Add(s);
            }
            cbSpodniePref.SelectedIndex = 0;
            foreach (string s in bazaSpodnie)
            {
                cbSpodnieBaza.Items.Add(s);
                cbSpodnieBaza_sh1.Items.Add(s);
                cbSpodnieBaza_sh2.Items.Add(s);
                cbSpodnieBaza_sh3.Items.Add(s);
            }
            cbSpodnieBaza.SelectedIndex = 0;
            foreach (string s in sufSpodnie)
            {
                cbSpodnieSuf.Items.Add(s);
                cbSpodnieSuf_sh1.Items.Add(s);
                cbSpodnieSuf_sh2.Items.Add(s);
                cbSpodnieSuf_sh3.Items.Add(s);
            }
            cbSpodnieSuf.SelectedIndex = 0;

            // Pierścień
            pierscienWynik.ReadOnly = true;
            pierscienWynik.ContextMenuStrip = contextMenuStrip1;
            foreach (string s in prefPierscien)
            {
                cbPierscienPref.Items.Add(s);
                cbPierscienPref_sh1.Items.Add(s);
                cbPierscienPref_sh2.Items.Add(s);
                cbPierscienPref_sh3.Items.Add(s);
            }
            cbPierscienPref.SelectedIndex = 0;
            foreach (string s in bazaPierscien)
            {
                cbPierscienBaza.Items.Add(s);
                cbPierscienBaza_sh1.Items.Add(s);
                cbPierscienBaza_sh2.Items.Add(s);
                cbPierscienBaza_sh3.Items.Add(s);
            }
            cbPierscienBaza.SelectedIndex = 0;
            foreach (string s in sufPierscien)
            {
                cbPierscienSuf.Items.Add(s);
                cbPierscienSuf_sh1.Items.Add(s);
                cbPierscienSuf_sh2.Items.Add(s);
                cbPierscienSuf_sh3.Items.Add(s);
            }
            cbPierscienSuf.SelectedIndex = 0;

            // Amulet
            amuletWynik.ReadOnly = true;
            amuletWynik.ContextMenuStrip = contextMenuStrip1;
            foreach (string s in prefAmulet)
            {
                cbAmuletPref.Items.Add(s);
                cbAmuletPref_sh1.Items.Add(s);
                cbAmuletPref_sh2.Items.Add(s);
                cbAmuletPref_sh3.Items.Add(s);
            }
            cbAmuletPref.SelectedIndex = 0;
            foreach (string s in bazaAmulet)
            {
                cbAmuletBaza.Items.Add(s);
                cbAmuletBaza_sh1.Items.Add(s);
                cbAmuletBaza_sh2.Items.Add(s);
                cbAmuletBaza_sh3.Items.Add(s);
            }
            cbAmuletBaza.SelectedIndex = 0;
            foreach (string s in sufAmulet)
            {
                cbAmuletSuf.Items.Add(s);
                cbAmuletSuf_sh1.Items.Add(s);
                cbAmuletSuf_sh2.Items.Add(s);
                cbAmuletSuf_sh3.Items.Add(s);
            }
            cbAmuletSuf.SelectedIndex = 0;

            // Biała 1h
            biala1hWynik.ReadOnly = true;
            biala1hWynik.ContextMenuStrip = contextMenuStrip1;
            foreach (string s in prefBiala1h)
            {
                cbBiala1hPref.Items.Add(s);
                cbBiala1hPref_sh1.Items.Add(s);
                cbBiala1hPref_sh2.Items.Add(s);
                cbBiala1hPref_sh3.Items.Add(s);
            }
            cbBiala1hPref.SelectedIndex = 0;
            foreach (string s in bazaBiala1h)
            {
                cbBiala1hBaza.Items.Add(s);
                cbBiala1hBaza_sh1.Items.Add(s);
                cbBiala1hBaza_sh2.Items.Add(s);
                cbBiala1hBaza_sh3.Items.Add(s);
            }
            cbBiala1hBaza.SelectedIndex = 0;
            foreach (string s in sufBiala1h)
            {
                cbBiala1hSuf.Items.Add(s);
                cbBiala1hSuf_sh1.Items.Add(s);
                cbBiala1hSuf_sh2.Items.Add(s);
                cbBiala1hSuf_sh3.Items.Add(s);
            }
            cbBiala1hSuf.SelectedIndex = 0;

            // Biała 2h
            biala2hWynik.ReadOnly = true;
            biala2hWynik.ContextMenuStrip = contextMenuStrip1;
            foreach (string s in prefBiala2h)
            {
                cbBiala2hPref.Items.Add(s);
                cbBiala2hPref_sh1.Items.Add(s);
                cbBiala2hPref_sh2.Items.Add(s);
                cbBiala2hPref_sh3.Items.Add(s);
            }
            cbBiala2hPref.SelectedIndex = 0;
            foreach (string s in bazaBiala2h)
            {
                cbBiala2hBaza.Items.Add(s);
                cbBiala2hBaza_sh1.Items.Add(s);
                cbBiala2hBaza_sh2.Items.Add(s);
                cbBiala2hBaza_sh3.Items.Add(s);
            }
            cbBiala2hBaza.SelectedIndex = 0;
            foreach (string s in sufBiala2h)
            {
                cbBiala2hSuf.Items.Add(s);
                cbBiala2hSuf_sh1.Items.Add(s);
                cbBiala2hSuf_sh2.Items.Add(s);
                cbBiala2hSuf_sh3.Items.Add(s);
            }
            cbBiala2hSuf.SelectedIndex = 0;

            // Palna 1h
            palna1hWynik.ReadOnly = true;
            palna1hWynik.ContextMenuStrip = contextMenuStrip1;
            foreach (string s in prefPalna1h)
            {
                cbPalna1hPref.Items.Add(s);
                cbPalna1hPref_sh1.Items.Add(s);
                cbPalna1hPref_sh2.Items.Add(s);
                cbPalna1hPref_sh3.Items.Add(s);
            }
            cbPalna1hPref.SelectedIndex = 0;
            foreach (string s in bazaPalna1h)
            {
                cbPalna1hBaza.Items.Add(s);
                cbPalna1hBaza_sh1.Items.Add(s);
                cbPalna1hBaza_sh2.Items.Add(s);
                cbPalna1hBaza_sh3.Items.Add(s);
            }
            cbPalna1hBaza.SelectedIndex = 0;
            foreach (string s in sufPalna1h)
            {
                cbPalna1hSuf.Items.Add(s);
                cbPalna1hSuf_sh1.Items.Add(s);
                cbPalna1hSuf_sh2.Items.Add(s);
                cbPalna1hSuf_sh3.Items.Add(s);
            }
            cbPalna1hSuf.SelectedIndex = 0;

            // Palna 2h
            palna2hWynik.ReadOnly = true;
            palna2hWynik.ContextMenuStrip = contextMenuStrip1;
            foreach (string s in prefPalna2h)
            {
                cbPalna2hPref.Items.Add(s);
                cbPalna2hPref_sh1.Items.Add(s);
                cbPalna2hPref_sh2.Items.Add(s);
                cbPalna2hPref_sh3.Items.Add(s);
            }
            cbPalna2hPref.SelectedIndex = 0;
            foreach (string s in bazaPalna2h)
            {
                cbPalna2hBaza.Items.Add(s);
                cbPalna2hBaza_sh1.Items.Add(s);
                cbPalna2hBaza_sh2.Items.Add(s);
                cbPalna2hBaza_sh3.Items.Add(s);
            }
            cbPalna2hBaza.SelectedIndex = 0;
            foreach (string s in sufPalna2h)
            {
                cbPalna2hSuf.Items.Add(s);
                cbPalna2hSuf_sh1.Items.Add(s);
                cbPalna2hSuf_sh2.Items.Add(s);
                cbPalna2hSuf_sh3.Items.Add(s);
            }
            cbPalna2hSuf.SelectedIndex = 0;

            // Dystans
            dystansWynik.ReadOnly = true;
            dystansWynik.ContextMenuStrip = contextMenuStrip1;
            foreach (string s in prefDystans)
            {
                cbDystansPref.Items.Add(s);
                cbDystansPref_sh1.Items.Add(s);
                cbDystansPref_sh2.Items.Add(s);
                cbDystansPref_sh3.Items.Add(s);
            }
            cbDystansPref.SelectedIndex = 0;
            foreach (string s in bazaDystans)
            {
                cbDystansBaza.Items.Add(s);
                cbDystansBaza_sh1.Items.Add(s);
                cbDystansBaza_sh2.Items.Add(s);
                cbDystansBaza_sh3.Items.Add(s);
            }
            cbDystansBaza.SelectedIndex = 0;
            foreach (string s in sufDystans)
            {
                cbDystansSuf.Items.Add(s);
                cbDystansSuf_sh1.Items.Add(s);
                cbDystansSuf_sh2.Items.Add(s);
                cbDystansSuf_sh3.Items.Add(s);
            }
            cbDystansSuf.SelectedIndex = 0;

            // Analizator raportu
            AnalizatorRaportuTekst.ReadOnly = false;
            AnalizatorRaportuTekst.ContextMenuStrip = contextMenuStrip1;
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

            // Wersja programu
            toolTip1.SetToolTip(this.label1, "Wersja programu: 1.07");
        }

        private void Dodaj(ComboBox PrefCB, ComboBox BazaCB, ComboBox SufCB, RichTextBox Wynik, List<string> Pref, List<string> Baza, List<string> Suf)
        {
            if ((PrefCB.Text != "") | (BazaCB.Text != "") | (SufCB.Text != ""))
            {
                if (skladnik1[3] == 1) Wynik.AppendText(" + ");
            }
            if (PrefCB.Text != "")
            {
                Wynik.AppendText(PrefCB.Text);
                dodano = true;
            }
            if (BazaCB.Text != "")
            {
                Wynik.AppendText(" " + BazaCB.Text);
                dodano = true;
            }
            if (SufCB.Text != "")
            {
                Wynik.AppendText(" " + SufCB.Text);
                dodano = true;
            }

            if (dodano)
            {
                dodano = false;

                if (skladnik1[3] == 0)
                {
                    skladnik1[0] = Pref.IndexOf(PrefCB.Text);
                    skladnik1[1] = Baza.IndexOf(BazaCB.Text);
                    skladnik1[2] = Suf.IndexOf(SufCB.Text);
                    skladnik1[3] = 1;
                }
                else
                {
                    skladnik2[0] = Pref.IndexOf(PrefCB.Text);
                    skladnik2[1] = Baza.IndexOf(BazaCB.Text);
                    skladnik2[2] = Suf.IndexOf(SufCB.Text);
                    skladnik2[3] = 1;

                    wynikLaczenia = polacz(skladnik1[0], skladnik1[1], skladnik1[2], skladnik2[0], skladnik2[1], skladnik2[2]);

                    wynikLaczenia[0] = SprawdzWyjatki(Pref, skladnik1[0], skladnik2[0], wynikLaczenia[0]);
                    wynikLaczenia[1] = SprawdzWyjatki(Baza, skladnik1[1], skladnik2[1], wynikLaczenia[1]);
                    wynikLaczenia[2] = SprawdzWyjatki(Suf, skladnik1[2], skladnik2[2], wynikLaczenia[2]);

                    for (int i = 0; i < 4; i++)
                    {
                        skladnik1[i] = wynikLaczenia[i];
                    }
                    skladnik1[3] = 1;
                    Wynik.AppendText("\r= " + Pref.ElementAt(wynikLaczenia[0]) + " " + Baza.ElementAt(wynikLaczenia[1]) + " " + Suf.ElementAt(wynikLaczenia[2]));
                }
            }

            Wynik.ScrollToCaret();
            ZmienLabel();
        }

        private void helmDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbHelmPref, cbHelmBaza, cbHelmSuf, helmWynik, prefHelm, bazaHelm, sufHelm);
        }

        private void zbrojaDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbZbrojaPref, cbZbrojaBaza, cbZbrojaSuf, zbrojaWynik, prefZbroja, bazaZbroja, sufZbroja);
        }

        private void spodnieDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbSpodniePref, cbSpodnieBaza, cbSpodnieSuf, spodnieWynik, prefSpodnie, bazaSpodnie, sufSpodnie);
        }

        private void pierscienDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbPierscienPref, cbPierscienBaza, cbPierscienSuf, pierscienWynik, prefPierscien, bazaPierscien, sufPierscien);
        }

        private void amuletDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbAmuletPref, cbAmuletBaza, cbAmuletSuf, amuletWynik, prefAmulet, bazaAmulet, sufAmulet);
        }

        private void biala1hDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbBiala1hPref, cbBiala1hBaza, cbBiala1hSuf, biala1hWynik, prefBiala1h, bazaBiala1h, sufBiala1h);
        }

        private void biala2hDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbBiala2hPref, cbBiala2hBaza, cbBiala2hSuf, biala2hWynik, prefBiala2h, bazaBiala2h, sufBiala2h);
        }

        private void palna1hDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbPalna1hPref, cbPalna1hBaza, cbPalna1hSuf, palna1hWynik, prefPalna1h, bazaPalna1h, sufPalna1h);
        }

        private void palna2hDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbPalna2hPref, cbPalna2hBaza, cbPalna2hSuf, palna2hWynik, prefPalna2h, bazaPalna2h, sufPalna2h);
        }

        private void dystansDodaj_Click(object sender, EventArgs e)
        {
            Dodaj(cbDystansPref, cbDystansBaza, cbDystansSuf, dystansWynik, prefDystans, bazaDystans, sufDystans);
        }

        public int[] polacz(int pref1, int baza1, int suf1, int pref2, int baza2, int suf2)
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

                if ((Convert.ToInt32(x) == 0) | (Convert.ToInt32(y) == 0)) wynik[i] = 0;
                else if (x == y) wynik[i] = Convert.ToInt32(x);
                else if (true) wynik[i] = Convert.ToInt32(Math.Ceiling((x + y) / 2) + 1);
            }

            return wynik;
        }

        public void bazaHelmow()
        {
            // Prefiksy hełmu w uporządkowanej kolejności
            prefHelm.Add("");
            prefHelm.Add("Utwardzany");
            prefHelm.Add("Wzmocniony");
            prefHelm.Add("Pomocny");
            prefHelm.Add("Ozdobny");
            prefHelm.Add("Elegancki");
            prefHelm.Add("Rogaty");
            prefHelm.Add("Złośliwy");
            prefHelm.Add("Leniwy");
            prefHelm.Add("Śmiercionośny");
            prefHelm.Add("Bojowy");
            prefHelm.Add("Magnetyczny");
            prefHelm.Add("Krwawy");
            prefHelm.Add("Kunsztowny");
            prefHelm.Add("Kuloodporny");
            prefHelm.Add("Szamański");
            prefHelm.Add("Tygrysi");
            prefHelm.Add("Szturmowy");
            prefHelm.Add("Runiczny");
            prefHelm.Add("Rytualny");

            // Bazy hełmu w uporządkowanej kolejności
            bazaHelm.Add("");
            bazaHelm.Add("Czapka");
            bazaHelm.Add("Kask");
            bazaHelm.Add("Hełm");
            bazaHelm.Add("Maska");
            bazaHelm.Add("Obręcz");
            bazaHelm.Add("Kominiarka");
            bazaHelm.Add("Kapelusz");
            bazaHelm.Add("Opaska");
            bazaHelm.Add("Bandana");
            bazaHelm.Add("Korona");

            // Sufiksy hełmu w uporządkowanej kolejności
            sufHelm.Add("");
            sufHelm.Add("Podróżnika");
            sufHelm.Add("Przezorności");
            sufHelm.Add("Wytrzymałości");
            sufHelm.Add("Pasterza");
            sufHelm.Add("Narkomana");
            sufHelm.Add("Ochrony");
            sufHelm.Add("Zmysłów");
            sufHelm.Add("Wieszcza");
            sufHelm.Add("Kary");
            sufHelm.Add("Gladiatora");
            sufHelm.Add("Krwi");
            sufHelm.Add("Skorupy żółwia");
            sufHelm.Add("Słońca");
            sufHelm.Add("Adrenaliny");
            sufHelm.Add("Prekognicji");
            sufHelm.Add("Smoczej łuski");
            sufHelm.Add("Mocy");
            sufHelm.Add("Magii");
        }

        public void bazaZbroi()
        {
            // Prefiksy zbroi w uporządkowanej kolejności
            prefZbroja.Add("");
            prefZbroja.Add("Wzmocniony");
            prefZbroja.Add("Ćwiekowany");
            prefZbroja.Add("Władczy");
            prefZbroja.Add("Lekki");
            prefZbroja.Add("Łuskowy");
            prefZbroja.Add("Bojowy");
            prefZbroja.Add("Płytowy");
            prefZbroja.Add("Giętki");
            prefZbroja.Add("Krwawy");
            prefZbroja.Add("Łowiecki");
            prefZbroja.Add("Szamański");
            prefZbroja.Add("Kuloodporny");
            prefZbroja.Add("Tygrysi");
            prefZbroja.Add("Elfi");
            prefZbroja.Add("Runiczny");
            prefZbroja.Add("Śmiercionośny");

            // Bazy zbroi w uporządkowanej kolejności
            bazaZbroja.Add("");
            bazaZbroja.Add("Koszulka");
            bazaZbroja.Add("Kurtka");
            bazaZbroja.Add("Marynarka");
            bazaZbroja.Add("Kamizelka");
            bazaZbroja.Add("Gorset");
            bazaZbroja.Add("Peleryna");
            bazaZbroja.Add("Smoking");
            bazaZbroja.Add("Kolczuga");
            bazaZbroja.Add("Zbroja warstwowa");
            bazaZbroja.Add("Pełna zbroja");

            // Sufiksy zbroi w uporządkowanej kolejności
            sufZbroja.Add("");
            sufZbroja.Add("Adepta");
            sufZbroja.Add("Strażnika");
            sufZbroja.Add("Złodzieja");
            sufZbroja.Add("Siłacza");
            sufZbroja.Add("Naromana");
            sufZbroja.Add("Szermierza");
            sufZbroja.Add("Zabójcy");
            sufZbroja.Add("Gwardzisty");
            sufZbroja.Add("Kobry");
            sufZbroja.Add("Skorupy żółwia");
            sufZbroja.Add("Uników");
            sufZbroja.Add("Grabieżcy");
            sufZbroja.Add("Mistrza");
            sufZbroja.Add("Adrenaliny");
            sufZbroja.Add("Centuriona");
            sufZbroja.Add("Odporności");
            sufZbroja.Add("Kaliguli");
            sufZbroja.Add("Śiewcy śmierci");
            sufZbroja.Add("Szybkości");
            sufZbroja.Add("Orchidei");
        }

        public void bazaSpodni()
        {
            // Prefiksy spodni w uporządkowanej kolejności
            prefSpodnie.Add("");
            prefSpodnie.Add("Krótkie");
            prefSpodnie.Add("Pikowane");
            prefSpodnie.Add("Lekkie");
            prefSpodnie.Add("Wzmocnione");
            prefSpodnie.Add("Aksamitne");
            prefSpodnie.Add("Ćwiekowane");
            prefSpodnie.Add("Kuloodporne");
            prefSpodnie.Add("Giętkie");
            prefSpodnie.Add("Kolcze");
            prefSpodnie.Add("Szamańskie");
            prefSpodnie.Add("Krwawe");
            prefSpodnie.Add("Elfie");
            prefSpodnie.Add("Tygrysie");
            prefSpodnie.Add("Pancerne");
            prefSpodnie.Add("Runiczne");
            prefSpodnie.Add("Kompozytowe");
            prefSpodnie.Add("Śmiercionośne");

            // Bazy spodni w uporządkowanej kolejności
            bazaSpodnie.Add("");
            bazaSpodnie.Add("Szorty");
            bazaSpodnie.Add("Spodnie");
            bazaSpodnie.Add("Spódnica");
            bazaSpodnie.Add("Kilt");

            // Sufiksy spodni w uporządkowanej kolejności
            sufSpodnie.Add("");
            sufSpodnie.Add("Rzezimieszka");
            sufSpodnie.Add("Przemytnika");
            sufSpodnie.Add("Narkomana");
            sufSpodnie.Add("Siłacza");
            sufSpodnie.Add("Cichych ruchów");
            sufSpodnie.Add("Uników");
            sufSpodnie.Add("Skrytości");
            sufSpodnie.Add("Słońca");
            sufSpodnie.Add("Handlarza bronią");
            sufSpodnie.Add("Pasterza");
            sufSpodnie.Add("Łowcy cieni");
            sufSpodnie.Add("Węża");
            sufSpodnie.Add("Inków");
            sufSpodnie.Add("Tropiciela");
            sufSpodnie.Add("Nocy");
        }

        public void bazaPierścieni()
        {
            // Prefiksy pierścieni w uporządkowanej kolejności
            prefPierscien.Add("");
            prefPierscien.Add("Miedziany");
            prefPierscien.Add("Srebrny");
            prefPierscien.Add("Szmaragdowy");
            prefPierscien.Add("Złoty");
            prefPierscien.Add("Platynowy");
            prefPierscien.Add("Rubinowy");
            prefPierscien.Add("Dystyngowany");
            prefPierscien.Add("Przebiegły");
            prefPierscien.Add("Kardynalski");
            prefPierscien.Add("Elastyczny");
            prefPierscien.Add("Nekromancki");
            prefPierscien.Add("Gwiezdny");
            prefPierscien.Add("Niedźwiedzi");
            prefPierscien.Add("Twardy");
            prefPierscien.Add("Zwierzęcy");
            prefPierscien.Add("Tańczący");
            prefPierscien.Add("Archaiczny");
            prefPierscien.Add("Hipnotyczny");
            prefPierscien.Add("Diamentowy");
            prefPierscien.Add("Mściwy");
            prefPierscien.Add("Spaczony");
            prefPierscien.Add("Plastikowy");
            prefPierscien.Add("Zdradziecki");
            prefPierscien.Add("Tytanowy");
            prefPierscien.Add("Słoneczny");
            prefPierscien.Add("Pajęczy");
            prefPierscien.Add("Jastrzębi");
            prefPierscien.Add("Czarny");

            // Bazy pierścieni w uporządkowanej kolejności
            bazaPierscien.Add("");
            bazaPierscien.Add("Pierścień");
            bazaPierscien.Add("Sygnet");
            bazaPierscien.Add("Bransoleta");

            // Sufiksy pierścieni w uporządkowanej kolejności
            sufPierscien.Add("");
            sufPierscien.Add("Występku");
            sufPierscien.Add("Urody");
            sufPierscien.Add("Władzy");
            sufPierscien.Add("Siły");
            sufPierscien.Add("Geniuszu");
            sufPierscien.Add("Mądrości");
            sufPierscien.Add("Twardej skóry");
            sufPierscien.Add("Wilkołaka");
            sufPierscien.Add("Sztuki");
            sufPierscien.Add("Celności");
            sufPierscien.Add("Młodości");
            sufPierscien.Add("Lisa");
            sufPierscien.Add("Szczęścia");
            sufPierscien.Add("Krwi");
            sufPierscien.Add("Nietoperza");
            sufPierscien.Add("Koncentracji");
            sufPierscien.Add("Lewitacji");
            sufPierscien.Add("Przebiegłości");
            sufPierscien.Add("Szaleńca");
            sufPierscien.Add("Łatwości");
        }

        public void bazaAmuletow()
        {
            // Prefiksy amuletów w uporządkowanej kolejności
            prefAmulet.Add("");
            prefAmulet.Add("Miedziany");
            prefAmulet.Add("Srebrny");
            prefAmulet.Add("Szmaragdowy");
            prefAmulet.Add("Złoty");
            prefAmulet.Add("Platynowy");
            prefAmulet.Add("Rubinowy");
            prefAmulet.Add("Dystyngowany");
            prefAmulet.Add("Przebiegły");
            prefAmulet.Add("Kardynalski");
            prefAmulet.Add("Elastyczny");
            prefAmulet.Add("Nekromancki");
            prefAmulet.Add("Gwiezdny");
            prefAmulet.Add("Niedźwiedzi");
            prefAmulet.Add("Twardy");
            prefAmulet.Add("Diamentowy");
            prefAmulet.Add("Mściwy");
            prefAmulet.Add("Archaiczny");
            prefAmulet.Add("Tańczący");
            prefAmulet.Add("Hipnotyczny");
            prefAmulet.Add("Zwierzęcy");
            prefAmulet.Add("Spaczony");
            prefAmulet.Add("Plastikowy");
            prefAmulet.Add("Zdradziecki");
            prefAmulet.Add("Tytanowy");
            prefAmulet.Add("Słoneczny");
            prefAmulet.Add("Pajęczy");
            prefAmulet.Add("Jastrzębi");
            prefAmulet.Add("Czarny");

            // Bazy amuletów w uporządkowanej kolejności
            bazaAmulet.Add("");
            bazaAmulet.Add("Naszyjnik");
            bazaAmulet.Add("Amulet");
            bazaAmulet.Add("Apaszka");
            bazaAmulet.Add("Krawat");
            bazaAmulet.Add("Łańcuch");

            // Sufiksy amuletów w uporządkowanej kolejności
            sufAmulet.Add("");
            sufAmulet.Add("Występku");
            sufAmulet.Add("Urody");
            sufAmulet.Add("Władzy");
            sufAmulet.Add("Geniuszu");
            sufAmulet.Add("Siły");
            sufAmulet.Add("Mądrości");
            sufAmulet.Add("Twardej skóry");
            sufAmulet.Add("Pielgrzyma");
            sufAmulet.Add("Wilkołaka");
            sufAmulet.Add("Celności");
            sufAmulet.Add("Sztuki");
            sufAmulet.Add("Młodości");
            sufAmulet.Add("Szczęścia");
            sufAmulet.Add("Krwi");
            sufAmulet.Add("Zdolności");
            sufAmulet.Add("Koncentracji");
            sufAmulet.Add("Lewitacji");
            sufAmulet.Add("Przebiegłości");
            sufAmulet.Add("Szaleńca");
            sufAmulet.Add("Łatwości");
        }

        public void bazaBialych1h()
        {
            // Prefiksy białej 1h w uporządkowanej kolejności
            prefBiala1h.Add("");
            prefBiala1h.Add("Ostry");
            prefBiala1h.Add("Zębaty");
            prefBiala1h.Add("Kościany");
            prefBiala1h.Add("Wzmacniający");
            prefBiala1h.Add("Kryształowy");
            prefBiala1h.Add("Mistyczny");
            prefBiala1h.Add("Lekki");
            prefBiala1h.Add("Okrutny");
            prefBiala1h.Add("Przyjacielski");
            prefBiala1h.Add("Kąsający");
            prefBiala1h.Add("Opiekuńczy");
            prefBiala1h.Add("Świecący");
            prefBiala1h.Add("Jadowity");
            prefBiala1h.Add("Zabójczy");
            prefBiala1h.Add("Zatruty");
            prefBiala1h.Add("Przeklęty");
            prefBiala1h.Add("Zwinny");
            prefBiala1h.Add("Antyczny");
            prefBiala1h.Add("Szybki");
            prefBiala1h.Add("Demoniczny");

            // Bazy białej 1h w uporządkowanej kolejności
            bazaBiala1h.Add("");
            bazaBiala1h.Add("Pałka");
            bazaBiala1h.Add("Nóż");
            bazaBiala1h.Add("Sztylet");
            bazaBiala1h.Add("Kastet");
            bazaBiala1h.Add("Miecz");
            bazaBiala1h.Add("Rapier");
            bazaBiala1h.Add("Kama");
            bazaBiala1h.Add("Topór");
            bazaBiala1h.Add("Wakizashi");
            bazaBiala1h.Add("Pięść niebios");

            // Sufiksy białej 1h w uporządkowanej kolejności
            sufBiala1h.Add("");
            sufBiala1h.Add("Dowódcy");
            sufBiala1h.Add("Sekty");
            sufBiala1h.Add("Bólu");
            sufBiala1h.Add("Władzy");
            sufBiala1h.Add("Zwinności");
            sufBiala1h.Add("Mocy");
            sufBiala1h.Add("Zarazy");
            sufBiala1h.Add("Odwagi");
            sufBiala1h.Add("Trafienia");
            sufBiala1h.Add("Przodków");
            sufBiala1h.Add("Zdobywcy");
            sufBiala1h.Add("Kontuzji");
            sufBiala1h.Add("Męstwa");
            sufBiala1h.Add("Precyzji");
            sufBiala1h.Add("Krwi");
            sufBiala1h.Add("Zemsty");
            sufBiala1h.Add("Podkowy");
            sufBiala1h.Add("Drakuli");
            sufBiala1h.Add("Biegłości");
            sufBiala1h.Add("Klanu");
            sufBiala1h.Add("Imperatora");
            sufBiala1h.Add("Samobójcy");
        }

        public void bazaBialych2h()
        {
            // Prefiksy białej 2h w uporządkowanej kolejności
            prefBiala2h.Add("");
            prefBiala2h.Add("Kosztowny");
            prefBiala2h.Add("Ostry");
            prefBiala2h.Add("Kryształowy");
            prefBiala2h.Add("Zębaty");
            prefBiala2h.Add("Szeroki");
            prefBiala2h.Add("Okrutny");
            prefBiala2h.Add("Mistyczny");
            prefBiala2h.Add("Wzmacniający");
            prefBiala2h.Add("Kąsający");
            prefBiala2h.Add("Lekki");
            prefBiala2h.Add("Ciężki");
            prefBiala2h.Add("Zatruty");
            prefBiala2h.Add("Napromieniowany");
            prefBiala2h.Add("Świecący");
            prefBiala2h.Add("Opiekuńczy");
            prefBiala2h.Add("Jadowity");
            prefBiala2h.Add("Zabójczy");
            prefBiala2h.Add("Przeklęty");
            prefBiala2h.Add("Zwinny");
            prefBiala2h.Add("Antyczny");
            prefBiala2h.Add("Demoniczny");

            // Bazy białej 2h w uporządkowanej kolejności
            bazaBiala2h.Add("");
            bazaBiala2h.Add("Maczuga");
            bazaBiala2h.Add("Łom");
            bazaBiala2h.Add("Miecz dwuręczny");
            bazaBiala2h.Add("Topór dwuręczny");
            bazaBiala2h.Add("Korbacz");
            bazaBiala2h.Add("Kosa");
            bazaBiala2h.Add("Pika");
            bazaBiala2h.Add("Halabarda");
            bazaBiala2h.Add("Katana");
            bazaBiala2h.Add("Piła łancuchowa");

            // Sufiksy białej 2h w uporządkowanej kolejności
            sufBiala2h.Add("");
            sufBiala2h.Add("Zdrady");
            sufBiala2h.Add("Podstępu");
            sufBiala2h.Add("Bólu");
            sufBiala2h.Add("Hazardzisty");
            sufBiala2h.Add("Ołowiu");
            sufBiala2h.Add("Mocy");
            sufBiala2h.Add("Inkwizytora");
            sufBiala2h.Add("Krwiopijcy");
            sufBiala2h.Add("Zdobywcy");
            sufBiala2h.Add("Władzy");
            sufBiala2h.Add("Zemsty");
            sufBiala2h.Add("Zarazy");
            sufBiala2h.Add("Podkowy");
            sufBiala2h.Add("Autokraty");
            sufBiala2h.Add("Krwi");
            sufBiala2h.Add("Bazyliszka");
            sufBiala2h.Add("Samobójcy");
            sufBiala2h.Add("Drakuli");
        }

        public void bazaPalnych1h()
        {
            // Prefiksy palnych 1h w uporządkowanej kolejności
            prefPalna1h.Add("");

            // Bazy palnych 1h w uporządkowanej kolejności
            bazaPalna1h.Add("");
            bazaPalna1h.Add("Glock");
            bazaPalna1h.Add("Beretta");
            bazaPalna1h.Add("Uzi");
            bazaPalna1h.Add("Magnum");
            bazaPalna1h.Add("Desert Eagle");
            bazaPalna1h.Add("Mp5k");
            bazaPalna1h.Add("Skorpion");

            // Sufiksy palnych 1h w uporządkowanej kolejności
            sufPalna1h.Add("");
        }

        public void bazaPalnych2h()
        {
            // Prefiksy palnych 2h w uporządkowanej kolejności
            prefPalna2h.Add("");

            // Bazy palnych 2h w uporządkowanej kolejności
            bazaPalna2h.Add("");
            bazaPalna2h.Add("Karabin myśliwski");
            bazaPalna2h.Add("Półautomat snajperski");
            bazaPalna2h.Add("Karabin snajperski");
            bazaPalna2h.Add("AK-47");
            bazaPalna2h.Add("Fn-Fal");
            bazaPalna2h.Add("Strzelba");
            bazaPalna2h.Add("Miotacz płomieni");

            // Sufiksy palnych 2h w uporządkowanej kolejności
            sufPalna2h.Add("");
        }

        public void bazaDystansow()
        {
            // Prefiksy dystansu w uporządkowanej kolejności
            prefDystans.Add("");

            // Bazy dystansu w uporządkowanej kolejności
            bazaDystans.Add("");
            bazaDystans.Add("Krótki łuk");
            bazaDystans.Add("Łuk");
            bazaDystans.Add("Shuriken");
            bazaDystans.Add("Długi łuk");
            bazaDystans.Add("Kusza");
            bazaDystans.Add("Nóż do rzucania");
            bazaDystans.Add("Łuk refleksyjny");
            bazaDystans.Add("Oszczep");
            bazaDystans.Add("Pilum");
            bazaDystans.Add("Toporek do rzucania");
            bazaDystans.Add("Ciężka kusza");

            // Sufiksy dystansu w uporządkowanej kolejności
            sufDystans.Add("");
            sufDystans.Add("Dalekiego zasięgu");
            sufDystans.Add("Doskonałości");
            sufDystans.Add("Precyzji");
            sufDystans.Add("Zemsty");
            sufDystans.Add("Reakcji");
            sufDystans.Add("Driady");
            sufDystans.Add("Szybkostrzelności");
            sufDystans.Add("Wilka");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Czyszczenie();
        }

        private void Czyszczenie()
        {
            // Czyszczenie składników i okienek wyników po przepłączeniu zakładki
            skladnik1 = new int[4] { 0, 0, 0, 0 };
            skladnik2 = new int[4] { 0, 0, 0, 0 };
            wynikLaczenia = new int[4] { 0, 0, 0, 0 };
            dodano = false;

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
        }

        private void InicjalizacjaTabeli(Form2 tab, List<string> baza, string disp)
        {
            if (tab != null)
            {
                tab.IsOpen = false;
                tab.Dispose();
                tab.Close();
            }

            tabela = new Form2();
            tabela.DisplayedTable = disp;
            tabela.dataGridView1.RowCount = baza.Count();
            tabela.dataGridView1.ColumnCount = baza.Count();
            tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
            if (tabela.Height < 150) tabela.Height = 150;
            tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

            for (int i = 0; i < baza.Count(); i++)
            {
                tabela.dataGridView1.Rows[i].Cells[0].Value = baza[i];
                tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                tabela.dataGridView1.Rows[0].Cells[i].Value = baza[i];
                tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;

                if (i > 0)
                {
                    tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.SkyBlue;

                    for (int j = 1; j < baza.Count(); j++)
                    {
                        if ((i == (baza.Count - 1)) & (j == (baza.Count - 2))) wynikTab[0] = baza.Count - 3; // wyjątki
                        else if ((i == (baza.Count - 2)) & (j == (baza.Count - 1))) wynikTab[0] = baza.Count - 3;
                        else if ((i == (baza.Count - 3)) & (j == (baza.Count - 1))) wynikTab[0] = baza.Count - 2;
                        else if ((i == (baza.Count - 1)) & (j == (baza.Count - 3))) wynikTab[0] = baza.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = baza.ElementAt(wynikTab[0]);
                    }
                }
            }
            tabela.Show();
        }

        private void prefHelmPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefHelm") InicjalizacjaTabeli(tabela, prefHelm, "PrefHelm");
            else tabela.BringToFront();
        }

        private void bazaHelmPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaHelm") InicjalizacjaTabeli(tabela, bazaHelm, "BazaHelm");
            else tabela.BringToFront();
        }

        private void sufHelmPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufHelm") InicjalizacjaTabeli(tabela, sufHelm, "SufHelm");
            else tabela.BringToFront();
        }

        private void prefZbrojaPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefZbroja") InicjalizacjaTabeli(tabela, prefZbroja, "PrefZbroja");
            else tabela.BringToFront();
        }

        private void bazaZbrojaPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaZbroja") InicjalizacjaTabeli(tabela, bazaZbroja, "BazaZbroja");
            else tabela.BringToFront();
        }

        private void sufZbrojaPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufZbroja") InicjalizacjaTabeli(tabela, sufZbroja, "SufZbroja");
            else tabela.BringToFront();
        }

        private void prefSpodniePanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefSpodnie") InicjalizacjaTabeli(tabela, prefSpodnie, "PrefSpodnie");
            else tabela.BringToFront();
        }

        private void bazaSpodniePanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaSpodnie") InicjalizacjaTabeli(tabela, bazaSpodnie, "BazaSpodnie");
            else tabela.BringToFront();
        }

        private void sufSpodniePanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufSpodnie") InicjalizacjaTabeli(tabela, sufSpodnie, "SufSpodnie");
            else tabela.BringToFront();
        }

        private void prefPierscienPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefPierscien") InicjalizacjaTabeli(tabela, prefPierscien, "PrefPierscien");
            else tabela.BringToFront();
        }

        private void bazaPierscienPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaPierscien") InicjalizacjaTabeli(tabela, bazaPierscien, "BazaPierscien");
            else tabela.BringToFront();
        }

        private void sufPierscienPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufPierscien") InicjalizacjaTabeli(tabela, sufPierscien, "SufPierscien");
            else tabela.BringToFront();
        }

        private void prefAmuletPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefAmulet") InicjalizacjaTabeli(tabela, prefAmulet, "PrefAmulet");
            else tabela.BringToFront();
        }

        private void bazaAmuletPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaAmulet") InicjalizacjaTabeli(tabela, bazaAmulet, "BazaAmulet");
            else tabela.BringToFront();
        }

        private void sufAmuletPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufAmulet") InicjalizacjaTabeli(tabela, sufAmulet, "SufAmulet");
            else tabela.BringToFront();
        }

        private void prefBiala1hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefBiala1h") InicjalizacjaTabeli(tabela, prefBiala1h, "PrefBiala1h");
            else tabela.BringToFront();
        }

        private void bazaBiala1hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaBiala1h") InicjalizacjaTabeli(tabela, bazaBiala1h, "BazaBiala1h");
            else tabela.BringToFront();
        }

        private void sufBiala1hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufBiala1h") InicjalizacjaTabeli(tabela, sufBiala1h, "SufBiala1h");
            else tabela.BringToFront();
        }

        private void prefBiala2hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefBiala2h") InicjalizacjaTabeli(tabela, prefBiala2h, "PrefBiala2h");
            else tabela.BringToFront();
        }

        private void bazaBiala2hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaBiala2h") InicjalizacjaTabeli(tabela, bazaBiala2h, "BazaBiala2h");
            else tabela.BringToFront();
        }

        private void sufBiala2hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufBiala2h") InicjalizacjaTabeli(tabela, sufBiala2h, "SufBiala2h");
            else tabela.BringToFront();
        }

        private void prefPalna1hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefPalna1h") InicjalizacjaTabeli(tabela, prefPalna1h, "PrefPalna1h");
            else tabela.BringToFront();
        }

        private void bazaPalna1hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaPalna1h") InicjalizacjaTabeli(tabela, bazaPalna1h, "BazaPalna1h");
            else tabela.BringToFront();
        }

        private void sufPalna1hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufPalna1h") InicjalizacjaTabeli(tabela, sufPalna1h, "SufPalna1h");
            else tabela.BringToFront();
        }

        private void prefPalna2hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefPalna2h") InicjalizacjaTabeli(tabela, prefPalna2h, "PrefPalna2h");
            else tabela.BringToFront();
        }

        private void bazaPalna2hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaPalna2h") InicjalizacjaTabeli(tabela, bazaPalna2h, "BazaPalna2h");
            else tabela.BringToFront();
        }

        private void sufPalna2hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufPalna2h") InicjalizacjaTabeli(tabela, sufPalna2h, "SufPalna2h");
            else tabela.BringToFront();
        }

        private void prefDystansPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefDystans") InicjalizacjaTabeli(tabela, prefDystans, "PrefDystans");
            else tabela.BringToFront();
        }

        private void bazaDystansPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaDystans") InicjalizacjaTabeli(tabela, bazaDystans, "BazaDystans");
            else tabela.BringToFront();
        }

        private void sufDystansPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufDystans") InicjalizacjaTabeli(tabela, sufDystans, "SufDystans");
            else tabela.BringToFront();
        }

        private void kopiujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedTab.Text)
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

        private void kopiujWszystkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedTab.Text)
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

        private void wyczyśćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Czyszczenie();
        }

        private void AnalizatorRaportuOblicz_Click(object sender, EventArgs e)
        {
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

            ulepszenia = AnalizatorRaportuTekst.Text.Split('\n');

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
            System.Windows.Forms.MessageBox.Show("1. Skopiuj zawartość raportu z ulepszania.\n" +
                "    Możesz zaznaczyć wszystko (CTRL+A) i skopiować (CTRL+C).\n" +
                "2. Wlej skopiowaną zawartość raportu do okienka obok.\n" +
                "3. Kliknij 'Oblicz'.");
        }

        private void CB_TextChanged(object sender, EventArgs e)
        {
            ZmienLabel();
        }

        private void ZmienLabelObliczenia(ComboBox PrefCB, ComboBox BazaCB, ComboBox SufCB, List<string> Pref, List<string> Baza, List<string> Suf, Label PrefLab, Label BazaLab, Label SufLab)
        {
            int[] TempSkladnik = new int[3];
            int[] TempWynik = new int[3];

            TempSkladnik[0] = Pref.IndexOf(PrefCB.Text);
            TempSkladnik[1] = Baza.IndexOf(BazaCB.Text);
            TempSkladnik[2] = Suf.IndexOf(SufCB.Text);

            TempWynik = polacz(skladnik1[0], skladnik1[1], skladnik1[2], TempSkladnik[0], TempSkladnik[1], TempSkladnik[2]);

            TempWynik[0] = SprawdzWyjatki(Pref, skladnik1[0], TempSkladnik[0], TempWynik[0]);
            TempWynik[1] = SprawdzWyjatki(Baza, skladnik1[1], TempSkladnik[1], TempWynik[1]);
            TempWynik[2] = SprawdzWyjatki(Suf, skladnik1[2], TempSkladnik[2], TempWynik[2]);

            if (PrefCB.Text != "") PrefLab.Text = Pref.ElementAt(TempWynik[0]);
            if (PrefCB.Text == "") PrefLab.Text = "";
            if (BazaCB.Text != "") BazaLab.Text = Baza.ElementAt(TempWynik[1]);
            if (BazaCB.Text == "") BazaLab.Text = "";
            if (SufCB.Text != "") SufLab.Text = Suf.ElementAt(TempWynik[2]);
            if (SufCB.Text == "") SufLab.Text = "";
        }

        private void ZmienLabel()
        {
            if (skladnik1[3] != 0)
            {
                switch (tabControl1.SelectedTab.Text)
                {
                    case "Hełm":
                        ZmienLabelObliczenia(cbHelmPref, cbHelmBaza, cbHelmSuf, prefHelm, bazaHelm, sufHelm, PrefHelmL, BazaHelmL, SufHelmL);
                        break;
                    case "Zbroja":
                        ZmienLabelObliczenia(cbZbrojaPref, cbZbrojaBaza, cbZbrojaSuf, prefZbroja, bazaZbroja, sufZbroja, PrefZbrojaL, BazaZbrojaL, SufZbrojaL);
                        break;
                    case "Spodnie":
                        ZmienLabelObliczenia(cbSpodniePref, cbSpodnieBaza, cbSpodnieSuf, prefSpodnie, bazaSpodnie, sufSpodnie, PrefSpodnieL, BazaSpodnieL, SufSpodnieL);
                        break;
                    case "Pierścień":
                        ZmienLabelObliczenia(cbPierscienPref, cbPierscienBaza, cbPierscienSuf, prefPierscien, bazaPierscien, sufPierscien, PrefPierscienL, BazaPierscienL, SufPierscienL);
                        break;
                    case "Amulet":
                        ZmienLabelObliczenia(cbAmuletPref, cbAmuletBaza, cbAmuletSuf, prefAmulet, bazaAmulet, sufAmulet, PrefAmuletL, BazaAmuletL, SufAmuletL);
                        break;
                    case "Biała 1h":
                        ZmienLabelObliczenia(cbBiala1hPref, cbBiala1hBaza, cbBiala1hSuf, prefBiala1h, bazaBiala1h, sufBiala1h, PrefBiala1hL, BazaBiala1hL, SufBiala1hL);
                        break;
                    case "Biała 2h":
                        ZmienLabelObliczenia(cbBiala2hPref, cbBiala2hBaza, cbBiala2hSuf, prefBiala2h, bazaBiala2h, sufBiala2h, PrefBiala2hL, BazaBiala2hL, SufBiala2hL);
                        break;
                    case "Palna 1h":
                        ZmienLabelObliczenia(cbPalna1hPref, cbPalna1hBaza, cbPalna1hSuf, prefPalna1h, bazaPalna1h, sufPalna1h, PrefPalna1hL, BazaPalna1hL, SufPalna1hL);
                        break;
                    case "Palna 2h":
                        ZmienLabelObliczenia(cbPalna2hPref, cbPalna2hBaza, cbPalna2hSuf, prefPalna2h, bazaPalna2h, sufPalna2h, PrefPalna2hL, BazaPalna2hL, SufPalna2hL);
                        break;
                    case "Dystans":
                        ZmienLabelObliczenia(cbDystansPref, cbDystansBaza, cbDystansSuf, prefDystans, bazaDystans, sufDystans, PrefDystansL, BazaDystansL, SufDystansL);
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
    }
}