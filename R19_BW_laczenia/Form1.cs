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
        int test = 0;
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

        int[] skladnik1 = new int[4];
        int[] skladnik2 = new int[4];
        int[] wynikLaczenia = new int[4];
        int[] wynikTab = new int[4];

        bool dodano = false;

        string[] ulepszenia;

        public Form1()
        {
            InitializeComponent();
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

            // Kalkulator ulepszen
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
            toolTip1.SetToolTip(this.label1, "Wersja programu: 1.06");
        }

        private void helmDodaj_Click(object sender, EventArgs e)
        {
            if ((cbHelmPref.Text != "") | (cbHelmBaza.Text != "") | (cbHelmSuf.Text != ""))
            {
                if (skladnik1[3] == 1) helmWynik.AppendText(" + ");
            }

            if (cbHelmPref.Text != "")
            {
                helmWynik.AppendText(cbHelmPref.Text);
                dodano = true;
            }
            if (cbHelmBaza.Text != "")
            {
                helmWynik.AppendText(" " + cbHelmBaza.Text);
                dodano = true;
            }
            if (cbHelmSuf.Text != "")
            {
                helmWynik.AppendText(" " + cbHelmSuf.Text);
                dodano = true;
            }

            if (dodano)
            {
                dodano = false;

                if (skladnik1[3] == 0)
                {
                    skladnik1[0] = prefHelm.IndexOf(cbHelmPref.Text);
                    skladnik1[1] = bazaHelm.IndexOf(cbHelmBaza.Text);
                    skladnik1[2] = sufHelm.IndexOf(cbHelmSuf.Text);
                    skladnik1[3] = 1;
                }
                else
                {
                    skladnik2[0] = prefHelm.IndexOf(cbHelmPref.Text);
                    skladnik2[1] = bazaHelm.IndexOf(cbHelmBaza.Text);
                    skladnik2[2] = sufHelm.IndexOf(cbHelmSuf.Text);
                    skladnik2[3] = 1;

                    wynikLaczenia = polacz(skladnik1[0], skladnik1[1], skladnik1[2], skladnik2[0], skladnik2[1], skladnik2[2]);

                    if ((skladnik1[0] == (prefHelm.Count - 1)) & (skladnik2[0] == (prefHelm.Count - 2))) wynikLaczenia[0] = prefHelm.Count - 3; // runiczny + rytualny = szturmowy
                    if ((skladnik1[0] == (prefHelm.Count - 2)) & (skladnik2[0] == (prefHelm.Count - 1))) wynikLaczenia[0] = prefHelm.Count - 3;
                    if ((skladnik1[0] == (prefHelm.Count - 3)) & (skladnik2[0] == (prefHelm.Count - 1))) wynikLaczenia[0] = prefHelm.Count - 2; // szturmowy + rytualny = runiczny
                    if ((skladnik1[0] == (prefHelm.Count - 1)) & (skladnik2[0] == (prefHelm.Count - 3))) wynikLaczenia[0] = prefHelm.Count - 2;
                    if ((skladnik1[1] == (bazaHelm.Count - 1)) & (skladnik2[1] == (bazaHelm.Count - 2))) wynikLaczenia[1] = bazaHelm.Count - 3; // bandana + korona = opaska
                    if ((skladnik1[1] == (bazaHelm.Count - 2)) & (skladnik2[1] == (bazaHelm.Count - 1))) wynikLaczenia[1] = bazaHelm.Count - 3;
                    if ((skladnik1[1] == (bazaHelm.Count - 3)) & (skladnik2[1] == (bazaHelm.Count - 1))) wynikLaczenia[1] = bazaHelm.Count - 2; // opaska + korona = bandana
                    if ((skladnik1[1] == (bazaHelm.Count - 1)) & (skladnik2[1] == (bazaHelm.Count - 3))) wynikLaczenia[1] = bazaHelm.Count - 2;
                    if ((skladnik1[2] == (sufHelm.Count - 1)) & (skladnik2[2] == (sufHelm.Count - 2))) wynikLaczenia[2] = sufHelm.Count - 3; // magii + mocy = smoczej łuski
                    if ((skladnik1[2] == (sufHelm.Count - 2)) & (skladnik2[2] == (sufHelm.Count - 1))) wynikLaczenia[2] = sufHelm.Count - 3;
                    if ((skladnik1[2] == (sufHelm.Count - 3)) & (skladnik2[2] == (sufHelm.Count - 1))) wynikLaczenia[2] = sufHelm.Count - 2; // smoczej łuski + magii = mocy
                    if ((skladnik1[2] == (sufHelm.Count - 1)) & (skladnik2[2] == (sufHelm.Count - 3))) wynikLaczenia[2] = sufHelm.Count - 2;

                    for (int i = 0; i < 4; i++)
                    {
                        skladnik1[i] = wynikLaczenia[i];
                    }
                    skladnik1[3] = 1;
                    helmWynik.AppendText("\r= " + prefHelm.ElementAt(wynikLaczenia[0]) + " " + bazaHelm.ElementAt(wynikLaczenia[1]) + " " + sufHelm.ElementAt(wynikLaczenia[2]));
                }
            }

            helmWynik.ScrollToCaret();
        }

        private void zbrojaDodaj_Click(object sender, EventArgs e)
        {
            if ((cbZbrojaPref.Text != "") | (cbZbrojaBaza.Text != "") | (cbZbrojaSuf.Text != ""))
            {
                if (skladnik1[3] == 1) zbrojaWynik.AppendText(" + ");
            }

            if (cbZbrojaPref.Text != "")
            {
                zbrojaWynik.AppendText(cbZbrojaPref.Text);
                dodano = true;
            }
            if (cbZbrojaBaza.Text != "")
            {
                zbrojaWynik.AppendText(" " + cbZbrojaBaza.Text);
                dodano = true;
            }
            if (cbZbrojaSuf.Text != "")
            {
                zbrojaWynik.AppendText(" " + cbZbrojaSuf.Text);
                dodano = true;
            }

            if (dodano)
            {
                dodano = false;

                if (skladnik1[3] == 0)
                {
                    skladnik1[0] = prefZbroja.IndexOf(cbZbrojaPref.Text);
                    skladnik1[1] = bazaZbroja.IndexOf(cbZbrojaBaza.Text);
                    skladnik1[2] = sufZbroja.IndexOf(cbZbrojaSuf.Text);
                    skladnik1[3] = 1;
                }
                else
                {
                    skladnik2[0] = prefZbroja.IndexOf(cbZbrojaPref.Text);
                    skladnik2[1] = bazaZbroja.IndexOf(cbZbrojaBaza.Text);
                    skladnik2[2] = sufZbroja.IndexOf(cbZbrojaSuf.Text);
                    skladnik2[3] = 1;

                    wynikLaczenia = polacz(skladnik1[0], skladnik1[1], skladnik1[2], skladnik2[0], skladnik2[1], skladnik2[2]);

                    if ((skladnik1[0] == (prefZbroja.Count - 1)) & (skladnik2[0] == (prefZbroja.Count - 2))) wynikLaczenia[0] = prefZbroja.Count - 3; // runiczny + śmiercionośny = elfi
                    if ((skladnik1[0] == (prefZbroja.Count - 2)) & (skladnik2[0] == (prefZbroja.Count - 1))) wynikLaczenia[0] = prefZbroja.Count - 3;
                    if ((skladnik1[0] == (prefZbroja.Count - 3)) & (skladnik2[0] == (prefZbroja.Count - 1))) wynikLaczenia[0] = prefZbroja.Count - 2; // elfi + śmiercionośny = runiczny
                    if ((skladnik1[0] == (prefZbroja.Count - 1)) & (skladnik2[0] == (prefZbroja.Count - 3))) wynikLaczenia[0] = prefZbroja.Count - 2;
                    if ((skladnik1[1] == (bazaZbroja.Count - 1)) & (skladnik2[1] == (bazaZbroja.Count - 2))) wynikLaczenia[1] = bazaZbroja.Count - 3; // zbroja warstwowa + pełna zbroja = kolczuga
                    if ((skladnik1[1] == (bazaZbroja.Count - 2)) & (skladnik2[1] == (bazaZbroja.Count - 1))) wynikLaczenia[1] = bazaZbroja.Count - 3;
                    if ((skladnik1[1] == (bazaZbroja.Count - 3)) & (skladnik2[1] == (bazaZbroja.Count - 1))) wynikLaczenia[1] = bazaZbroja.Count - 2; // kolczuga + pełna zbroja = zbroja warstwowa
                    if ((skladnik1[1] == (bazaZbroja.Count - 1)) & (skladnik2[1] == (bazaZbroja.Count - 3))) wynikLaczenia[1] = bazaZbroja.Count - 2;
                    if ((skladnik1[2] == (sufZbroja.Count - 1)) & (skladnik2[2] == (sufZbroja.Count - 2))) wynikLaczenia[2] = sufZbroja.Count - 3; // szybkości + orchidei = siewcy śmierci
                    if ((skladnik1[2] == (sufZbroja.Count - 2)) & (skladnik2[2] == (sufZbroja.Count - 1))) wynikLaczenia[2] = sufZbroja.Count - 3;
                    if ((skladnik1[2] == (sufZbroja.Count - 3)) & (skladnik2[2] == (sufZbroja.Count - 1))) wynikLaczenia[2] = sufZbroja.Count - 2; // siewcy śmierci + orchidei = szybości
                    if ((skladnik1[2] == (sufZbroja.Count - 1)) & (skladnik2[2] == (sufZbroja.Count - 3))) wynikLaczenia[2] = sufZbroja.Count - 2;

                    for (int i = 0; i < 4; i++)
                    {
                        skladnik1[i] = wynikLaczenia[i];
                    }
                    skladnik1[3] = 1;
                    zbrojaWynik.AppendText("\r= " + prefZbroja.ElementAt(wynikLaczenia[0]) + " " + bazaZbroja.ElementAt(wynikLaczenia[1]) + " " + sufZbroja.ElementAt(wynikLaczenia[2]));
                }
            }

            zbrojaWynik.ScrollToCaret();
        }

        private void spodnieDodaj_Click(object sender, EventArgs e)
        {
            if ((cbSpodniePref.Text != "") | (cbSpodnieBaza.Text != "") | (cbSpodnieSuf.Text != ""))
            {
                if (skladnik1[3] == 1) spodnieWynik.AppendText(" + ");
            }

            if (cbSpodniePref.Text != "")
            {
                spodnieWynik.AppendText(cbSpodniePref.Text);
                dodano = true;
            }
            if (cbSpodnieBaza.Text != "")
            {
                spodnieWynik.AppendText(" " + cbSpodnieBaza.Text);
                dodano = true;
            }
            if (cbSpodnieSuf.Text != "")
            {
                spodnieWynik.AppendText(" " + cbSpodnieSuf.Text);
                dodano = true;
            }

            if (dodano)
            {
                dodano = false;

                if (skladnik1[3] == 0)
                {
                    skladnik1[0] = prefSpodnie.IndexOf(cbSpodniePref.Text);
                    skladnik1[1] = bazaSpodnie.IndexOf(cbSpodnieBaza.Text);
                    skladnik1[2] = sufSpodnie.IndexOf(cbSpodnieSuf.Text);
                    skladnik1[3] = 1;
                }
                else
                {
                    skladnik2[0] = prefSpodnie.IndexOf(cbSpodniePref.Text);
                    skladnik2[1] = bazaSpodnie.IndexOf(cbSpodnieBaza.Text);
                    skladnik2[2] = sufSpodnie.IndexOf(cbSpodnieSuf.Text);
                    skladnik2[3] = 1;

                    wynikLaczenia = polacz(skladnik1[0], skladnik1[1], skladnik1[2], skladnik2[0], skladnik2[1], skladnik2[2]);

                    if ((skladnik1[0] == (prefSpodnie.Count - 1)) & (skladnik2[0] == (prefSpodnie.Count - 2))) wynikLaczenia[0] = prefSpodnie.Count - 3; // kompozytowe + śmiercionośne = runiczne
                    if ((skladnik1[0] == (prefSpodnie.Count - 2)) & (skladnik2[0] == (prefSpodnie.Count - 1))) wynikLaczenia[0] = prefSpodnie.Count - 3;
                    if ((skladnik1[0] == (prefSpodnie.Count - 3)) & (skladnik2[0] == (prefSpodnie.Count - 1))) wynikLaczenia[0] = prefSpodnie.Count - 2; // runiczne + śmiercionośne = kompozytowe
                    if ((skladnik1[0] == (prefSpodnie.Count - 1)) & (skladnik2[0] == (prefSpodnie.Count - 3))) wynikLaczenia[0] = prefSpodnie.Count - 2;
                    if ((skladnik1[1] == (bazaSpodnie.Count - 1)) & (skladnik2[1] == (bazaSpodnie.Count - 2))) wynikLaczenia[1] = bazaSpodnie.Count - 3; // spódnica + kilt = spodnie
                    if ((skladnik1[1] == (bazaSpodnie.Count - 2)) & (skladnik2[1] == (bazaSpodnie.Count - 1))) wynikLaczenia[1] = bazaSpodnie.Count - 3;
                    if ((skladnik1[1] == (bazaSpodnie.Count - 3)) & (skladnik2[1] == (bazaSpodnie.Count - 1))) wynikLaczenia[1] = bazaSpodnie.Count - 2; // spodnie + kilt = spódnica
                    if ((skladnik1[1] == (bazaSpodnie.Count - 1)) & (skladnik2[1] == (bazaSpodnie.Count - 3))) wynikLaczenia[1] = bazaSpodnie.Count - 2;
                    if ((skladnik1[2] == (sufSpodnie.Count - 1)) & (skladnik2[2] == (sufSpodnie.Count - 2))) wynikLaczenia[2] = sufSpodnie.Count - 3; // tropiciela + mocy = inków
                    if ((skladnik1[2] == (sufSpodnie.Count - 2)) & (skladnik2[2] == (sufSpodnie.Count - 1))) wynikLaczenia[2] = sufSpodnie.Count - 3;
                    if ((skladnik1[2] == (sufSpodnie.Count - 3)) & (skladnik2[2] == (sufSpodnie.Count - 1))) wynikLaczenia[2] = sufSpodnie.Count - 2; // inków + mocy = tropiciela
                    if ((skladnik1[2] == (sufSpodnie.Count - 1)) & (skladnik2[2] == (sufSpodnie.Count - 3))) wynikLaczenia[2] = sufSpodnie.Count - 2;

                    for (int i = 0; i < 4; i++)
                    {
                        skladnik1[i] = wynikLaczenia[i];
                    }
                    skladnik1[3] = 1;
                    spodnieWynik.AppendText("\r= " + prefSpodnie.ElementAt(wynikLaczenia[0]) + " " + bazaSpodnie.ElementAt(wynikLaczenia[1]) + " " + sufSpodnie.ElementAt(wynikLaczenia[2]));
                }
            }

            spodnieWynik.ScrollToCaret();
        }

        private void pierscienDodaj_Click(object sender, EventArgs e)
        {
            if ((cbPierscienPref.Text != "") | (cbPierscienBaza.Text != "") | (cbPierscienSuf.Text != ""))
            {
                if (skladnik1[3] == 1) pierscienWynik.AppendText(" + ");
            }

            if (cbPierscienPref.Text != "")
            {
                pierscienWynik.AppendText(cbPierscienPref.Text);
                dodano = true;
            }
            if (cbPierscienBaza.Text != "")
            {
                pierscienWynik.AppendText(" " + cbPierscienBaza.Text);
                dodano = true;
            }
            if (cbPierscienSuf.Text != "")
            {
                pierscienWynik.AppendText(" " + cbPierscienSuf.Text);
                dodano = true;
            }

            if (dodano)
            {
                dodano = false;

                if (skladnik1[3] == 0)
                {
                    skladnik1[0] = prefPierscien.IndexOf(cbPierscienPref.Text);
                    skladnik1[1] = bazaPierscien.IndexOf(cbPierscienBaza.Text);
                    skladnik1[2] = sufPierscien.IndexOf(cbPierscienSuf.Text);
                    skladnik1[3] = 1;
                }
                else
                {
                    skladnik2[0] = prefPierscien.IndexOf(cbPierscienPref.Text);
                    skladnik2[1] = bazaPierscien.IndexOf(cbPierscienBaza.Text);
                    skladnik2[2] = sufPierscien.IndexOf(cbPierscienSuf.Text);
                    skladnik2[3] = 1;

                    wynikLaczenia = polacz(skladnik1[0], skladnik1[1], skladnik1[2], skladnik2[0], skladnik2[1], skladnik2[2]);

                    if ((skladnik1[0] == (prefPierscien.Count - 1)) & (skladnik2[0] == (prefPierscien.Count - 2))) wynikLaczenia[0] = prefPierscien.Count - 3; // jastrzębi + czarny = pajęczy
                    if ((skladnik1[0] == (prefPierscien.Count - 2)) & (skladnik2[0] == (prefPierscien.Count - 1))) wynikLaczenia[0] = prefPierscien.Count - 3;
                    if ((skladnik1[0] == (prefPierscien.Count - 3)) & (skladnik2[0] == (prefPierscien.Count - 1))) wynikLaczenia[0] = prefPierscien.Count - 2; // pajęczy + czarny = jastrzębi
                    if ((skladnik1[0] == (prefPierscien.Count - 1)) & (skladnik2[0] == (prefPierscien.Count - 3))) wynikLaczenia[0] = prefPierscien.Count - 2;
                    if ((skladnik1[1] == (bazaPierscien.Count - 1)) & (skladnik2[1] == (bazaPierscien.Count - 2))) wynikLaczenia[1] = bazaPierscien.Count - 3; // sygnet + bransoleta = pierścień
                    if ((skladnik1[1] == (bazaPierscien.Count - 2)) & (skladnik2[1] == (bazaPierscien.Count - 1))) wynikLaczenia[1] = bazaPierscien.Count - 3;
                    if ((skladnik1[1] == (bazaPierscien.Count - 3)) & (skladnik2[1] == (bazaPierscien.Count - 1))) wynikLaczenia[1] = bazaPierscien.Count - 2; // pierścień + bransoleta = sygnet
                    if ((skladnik1[1] == (bazaPierscien.Count - 1)) & (skladnik2[1] == (bazaPierscien.Count - 3))) wynikLaczenia[1] = bazaPierscien.Count - 2;
                    if ((skladnik1[2] == (sufPierscien.Count - 1)) & (skladnik2[2] == (sufPierscien.Count - 2))) wynikLaczenia[2] = sufPierscien.Count - 3; // szaleńca + łatwości = przebiegłości
                    if ((skladnik1[2] == (sufPierscien.Count - 2)) & (skladnik2[2] == (sufPierscien.Count - 1))) wynikLaczenia[2] = sufPierscien.Count - 3;
                    if ((skladnik1[2] == (sufPierscien.Count - 3)) & (skladnik2[2] == (sufPierscien.Count - 1))) wynikLaczenia[2] = sufPierscien.Count - 2; // przebiegłości + łatwości = szaleńca
                    if ((skladnik1[2] == (sufPierscien.Count - 1)) & (skladnik2[2] == (sufPierscien.Count - 3))) wynikLaczenia[2] = sufPierscien.Count - 2;

                    for (int i = 0; i < 4; i++)
                    {
                        skladnik1[i] = wynikLaczenia[i];
                    }
                    skladnik1[3] = 1;
                    pierscienWynik.AppendText("\r= " + prefPierscien.ElementAt(wynikLaczenia[0]) + " " + bazaPierscien.ElementAt(wynikLaczenia[1]) + " " + sufPierscien.ElementAt(wynikLaczenia[2]));
                }
            }

            pierscienWynik.ScrollToCaret();
        }

        private void amuletDodaj_Click(object sender, EventArgs e)
        {
            if ((cbAmuletPref.Text != "") | (cbAmuletBaza.Text != "") | (cbAmuletSuf.Text != ""))
            {
                if (skladnik1[3] == 1) amuletWynik.AppendText(" + ");
            }

            if (cbAmuletPref.Text != "")
            {
                amuletWynik.AppendText(cbAmuletPref.Text);
                dodano = true;
            }
            if (cbAmuletBaza.Text != "")
            {
                amuletWynik.AppendText(" " + cbAmuletBaza.Text);
                dodano = true;
            }
            if (cbAmuletSuf.Text != "")
            {
                amuletWynik.AppendText(" " + cbAmuletSuf.Text);
                dodano = true;
            }

            if (dodano)
            {
                dodano = false;

                if (skladnik1[3] == 0)
                {
                    skladnik1[0] = prefAmulet.IndexOf(cbAmuletPref.Text);
                    skladnik1[1] = bazaAmulet.IndexOf(cbAmuletBaza.Text);
                    skladnik1[2] = sufAmulet.IndexOf(cbAmuletSuf.Text);
                    skladnik1[3] = 1;
                }
                else
                {
                    skladnik2[0] = prefAmulet.IndexOf(cbAmuletPref.Text);
                    skladnik2[1] = bazaAmulet.IndexOf(cbAmuletBaza.Text);
                    skladnik2[2] = sufAmulet.IndexOf(cbAmuletSuf.Text);
                    skladnik2[3] = 1;

                    wynikLaczenia = polacz(skladnik1[0], skladnik1[1], skladnik1[2], skladnik2[0], skladnik2[1], skladnik2[2]);

                    if ((skladnik1[0] == (prefAmulet.Count - 1)) & (skladnik2[0] == (prefAmulet.Count - 2))) wynikLaczenia[0] = prefAmulet.Count - 3; // jastrzębi + czarny = pajęczy
                    if ((skladnik1[0] == (prefAmulet.Count - 2)) & (skladnik2[0] == (prefAmulet.Count - 1))) wynikLaczenia[0] = prefAmulet.Count - 3;
                    if ((skladnik1[0] == (prefAmulet.Count - 3)) & (skladnik2[0] == (prefAmulet.Count - 1))) wynikLaczenia[0] = prefAmulet.Count - 2; // pajęczy + czarny = jastrzębi
                    if ((skladnik1[0] == (prefAmulet.Count - 1)) & (skladnik2[0] == (prefAmulet.Count - 3))) wynikLaczenia[0] = prefAmulet.Count - 2;
                    if ((skladnik1[1] == (bazaAmulet.Count - 1)) & (skladnik2[1] == (bazaAmulet.Count - 2))) wynikLaczenia[1] = bazaAmulet.Count - 3; // krawat + łańcuch = apaszka
                    if ((skladnik1[1] == (bazaAmulet.Count - 2)) & (skladnik2[1] == (bazaAmulet.Count - 1))) wynikLaczenia[1] = bazaAmulet.Count - 3;
                    if ((skladnik1[1] == (bazaAmulet.Count - 3)) & (skladnik2[1] == (bazaAmulet.Count - 1))) wynikLaczenia[1] = bazaAmulet.Count - 2; // apaszka + łańcuch = krawat
                    if ((skladnik1[1] == (bazaAmulet.Count - 1)) & (skladnik2[1] == (bazaAmulet.Count - 3))) wynikLaczenia[1] = bazaAmulet.Count - 2;
                    if ((skladnik1[2] == (sufAmulet.Count - 1)) & (skladnik2[2] == (sufAmulet.Count - 2))) wynikLaczenia[2] = sufAmulet.Count - 3; // szaleńca + łatwości = przebiegłości
                    if ((skladnik1[2] == (sufAmulet.Count - 2)) & (skladnik2[2] == (sufAmulet.Count - 1))) wynikLaczenia[2] = sufAmulet.Count - 3;
                    if ((skladnik1[2] == (sufAmulet.Count - 3)) & (skladnik2[2] == (sufAmulet.Count - 1))) wynikLaczenia[2] = sufAmulet.Count - 2; // przebiegłości + łatwości = szaleńca
                    if ((skladnik1[2] == (sufAmulet.Count - 1)) & (skladnik2[2] == (sufAmulet.Count - 3))) wynikLaczenia[2] = sufAmulet.Count - 2;

                    for (int i = 0; i < 4; i++)
                    {
                        skladnik1[i] = wynikLaczenia[i];
                    }
                    skladnik1[3] = 1;
                    amuletWynik.AppendText("\r= " + prefAmulet.ElementAt(wynikLaczenia[0]) + " " + bazaAmulet.ElementAt(wynikLaczenia[1]) + " " + sufAmulet.ElementAt(wynikLaczenia[2]));
                }
            }

            amuletWynik.ScrollToCaret();
        }

        private void biala1hDodaj_Click(object sender, EventArgs e)
        {
            if ((cbBiala1hPref.Text != "") | (cbBiala1hBaza.Text != "") | (cbBiala1hSuf.Text != ""))
            {
                if (skladnik1[3] == 1) biala1hWynik.AppendText(" + ");
            }

            if (cbBiala1hPref.Text != "")
            {
                biala1hWynik.AppendText(cbBiala1hPref.Text);
                dodano = true;
            }
            if (cbBiala1hBaza.Text != "")
            {
                biala1hWynik.AppendText(" " + cbBiala1hBaza.Text);
                dodano = true;
            }
            if (cbBiala1hSuf.Text != "")
            {
                biala1hWynik.AppendText(" " + cbBiala1hSuf.Text);
                dodano = true;
            }

            if (dodano)
            {
                dodano = false;

                if (skladnik1[3] == 0)
                {
                    skladnik1[0] = prefBiala1h.IndexOf(cbBiala1hPref.Text);
                    skladnik1[1] = bazaBiala1h.IndexOf(cbBiala1hBaza.Text);
                    skladnik1[2] = sufBiala1h.IndexOf(cbBiala1hSuf.Text);
                    skladnik1[3] = 1;
                }
                else
                {
                    skladnik2[0] = prefBiala1h.IndexOf(cbBiala1hPref.Text);
                    skladnik2[1] = bazaBiala1h.IndexOf(cbBiala1hBaza.Text);
                    skladnik2[2] = sufBiala1h.IndexOf(cbBiala1hSuf.Text);
                    skladnik2[3] = 1;

                    wynikLaczenia = polacz(skladnik1[0], skladnik1[1], skladnik1[2], skladnik2[0], skladnik2[1], skladnik2[2]);

                    if ((skladnik1[0] == (prefBiala1h.Count - 1)) & (skladnik2[0] == (prefBiala1h.Count - 2))) wynikLaczenia[0] = prefBiala1h.Count - 3; // szybki + demoniczny = antyczny
                    if ((skladnik1[0] == (prefBiala1h.Count - 2)) & (skladnik2[0] == (prefBiala1h.Count - 1))) wynikLaczenia[0] = prefBiala1h.Count - 3;
                    if ((skladnik1[0] == (prefBiala1h.Count - 3)) & (skladnik2[0] == (prefBiala1h.Count - 1))) wynikLaczenia[0] = prefBiala1h.Count - 2; // antyczny + demoniczny = szybki
                    if ((skladnik1[0] == (prefBiala1h.Count - 1)) & (skladnik2[0] == (prefBiala1h.Count - 3))) wynikLaczenia[0] = prefBiala1h.Count - 2;
                    if ((skladnik1[1] == (bazaBiala1h.Count - 1)) & (skladnik2[1] == (bazaBiala1h.Count - 2))) wynikLaczenia[1] = bazaBiala1h.Count - 3; // wakizashi + pięść niebios = topór
                    if ((skladnik1[1] == (bazaBiala1h.Count - 2)) & (skladnik2[1] == (bazaBiala1h.Count - 1))) wynikLaczenia[1] = bazaBiala1h.Count - 3;
                    if ((skladnik1[1] == (bazaBiala1h.Count - 3)) & (skladnik2[1] == (bazaBiala1h.Count - 1))) wynikLaczenia[1] = bazaBiala1h.Count - 2; // topór + pięść niebios = wakizashi
                    if ((skladnik1[1] == (bazaBiala1h.Count - 1)) & (skladnik2[1] == (bazaBiala1h.Count - 3))) wynikLaczenia[1] = bazaBiala1h.Count - 2;
                    if ((skladnik1[2] == (sufBiala1h.Count - 1)) & (skladnik2[2] == (sufBiala1h.Count - 2))) wynikLaczenia[2] = sufBiala1h.Count - 3; // imperatora + samobójcy = klanu
                    if ((skladnik1[2] == (sufBiala1h.Count - 2)) & (skladnik2[2] == (sufBiala1h.Count - 1))) wynikLaczenia[2] = sufBiala1h.Count - 3;
                    if ((skladnik1[2] == (sufBiala1h.Count - 3)) & (skladnik2[2] == (sufBiala1h.Count - 1))) wynikLaczenia[2] = sufBiala1h.Count - 2; // klanu + samobójcy = imperatora
                    if ((skladnik1[2] == (sufBiala1h.Count - 1)) & (skladnik2[2] == (sufBiala1h.Count - 3))) wynikLaczenia[2] = sufBiala1h.Count - 2;

                    for (int i = 0; i < 4; i++)
                    {
                        skladnik1[i] = wynikLaczenia[i];
                    }
                    skladnik1[3] = 1;
                    biala1hWynik.AppendText("\r= " + prefBiala1h.ElementAt(wynikLaczenia[0]) + " " + bazaBiala1h.ElementAt(wynikLaczenia[1]) + " " + sufBiala1h.ElementAt(wynikLaczenia[2]));
                }
            }

            biala1hWynik.ScrollToCaret();
        }

        private void biala2hDodaj_Click(object sender, EventArgs e)
        {
            if ((cbBiala2hPref.Text != "") | (cbBiala2hBaza.Text != "") | (cbBiala2hSuf.Text != ""))
            {
                if (skladnik1[3] == 1) biala2hWynik.AppendText(" + ");
            }

            if (cbBiala2hPref.Text != "")
            {
                biala2hWynik.AppendText(cbBiala2hPref.Text);
                dodano = true;
            }
            if (cbBiala2hBaza.Text != "")
            {
                biala2hWynik.AppendText(" " + cbBiala2hBaza.Text);
                dodano = true;
            }
            if (cbBiala2hSuf.Text != "")
            {
                biala2hWynik.AppendText(" " + cbBiala2hSuf.Text);
                dodano = true;
            }

            if (dodano)
            {
                dodano = false;

                if (skladnik1[3] == 0)
                {
                    skladnik1[0] = prefBiala2h.IndexOf(cbBiala2hPref.Text);
                    skladnik1[1] = bazaBiala2h.IndexOf(cbBiala2hBaza.Text);
                    skladnik1[2] = sufBiala2h.IndexOf(cbBiala2hSuf.Text);
                    skladnik1[3] = 1;
                }
                else
                {
                    skladnik2[0] = prefBiala2h.IndexOf(cbBiala2hPref.Text);
                    skladnik2[1] = bazaBiala2h.IndexOf(cbBiala2hBaza.Text);
                    skladnik2[2] = sufBiala2h.IndexOf(cbBiala2hSuf.Text);
                    skladnik2[3] = 1;

                    wynikLaczenia = polacz(skladnik1[0], skladnik1[1], skladnik1[2], skladnik2[0], skladnik2[1], skladnik2[2]);

                    if ((skladnik1[0] == (prefBiala2h.Count - 1)) & (skladnik2[0] == (prefBiala2h.Count - 2))) wynikLaczenia[0] = prefBiala2h.Count - 3; // antyczny + demoniczny = zwinny
                    if ((skladnik1[0] == (prefBiala2h.Count - 2)) & (skladnik2[0] == (prefBiala2h.Count - 1))) wynikLaczenia[0] = prefBiala2h.Count - 3;
                    if ((skladnik1[0] == (prefBiala2h.Count - 3)) & (skladnik2[0] == (prefBiala2h.Count - 1))) wynikLaczenia[0] = prefBiala2h.Count - 2; // zwinny + demoniczny = antyczny
                    if ((skladnik1[0] == (prefBiala2h.Count - 1)) & (skladnik2[0] == (prefBiala2h.Count - 3))) wynikLaczenia[0] = prefBiala2h.Count - 2;
                    if ((skladnik1[1] == (bazaBiala2h.Count - 1)) & (skladnik2[1] == (bazaBiala2h.Count - 2))) wynikLaczenia[1] = bazaBiala2h.Count - 3; // katana + piła łańcuchowa = halabarda
                    if ((skladnik1[1] == (bazaBiala2h.Count - 2)) & (skladnik2[1] == (bazaBiala2h.Count - 1))) wynikLaczenia[1] = bazaBiala2h.Count - 3;
                    if ((skladnik1[1] == (bazaBiala2h.Count - 3)) & (skladnik2[1] == (bazaBiala2h.Count - 1))) wynikLaczenia[1] = bazaBiala2h.Count - 2; // halabarda + piła łańcuchowa = katana
                    if ((skladnik1[1] == (bazaBiala2h.Count - 1)) & (skladnik2[1] == (bazaBiala2h.Count - 3))) wynikLaczenia[1] = bazaBiala2h.Count - 2;
                    if ((skladnik1[2] == (sufBiala2h.Count - 1)) & (skladnik2[2] == (sufBiala2h.Count - 2))) wynikLaczenia[2] = sufBiala2h.Count - 3; // samobójcy + drakuli = bazyliszka
                    if ((skladnik1[2] == (sufBiala2h.Count - 2)) & (skladnik2[2] == (sufBiala2h.Count - 1))) wynikLaczenia[2] = sufBiala2h.Count - 3;
                    if ((skladnik1[2] == (sufBiala2h.Count - 3)) & (skladnik2[2] == (sufBiala2h.Count - 1))) wynikLaczenia[2] = sufBiala2h.Count - 2; // bazyliszka + drakuli = samobójcy
                    if ((skladnik1[2] == (sufBiala2h.Count - 1)) & (skladnik2[2] == (sufBiala2h.Count - 3))) wynikLaczenia[2] = sufBiala2h.Count - 2;

                    for (int i = 0; i < 4; i++)
                    {
                        skladnik1[i] = wynikLaczenia[i];
                    }
                    skladnik1[3] = 1;
                    biala2hWynik.AppendText("\r= " + prefBiala2h.ElementAt(wynikLaczenia[0]) + " " + bazaBiala2h.ElementAt(wynikLaczenia[1]) + " " + sufBiala2h.ElementAt(wynikLaczenia[2]));
                }
            }

            biala2hWynik.ScrollToCaret();
        }

        private void palna1hDodaj_Click(object sender, EventArgs e)
        {
            if ((cbPalna1hPref.Text != "") | (cbPalna1hBaza.Text != "") | (cbPalna1hSuf.Text != ""))
            {
                if (skladnik1[3] == 1) palna1hWynik.AppendText(" + ");
            }

            if (cbPalna1hPref.Text != "")
            {
                palna1hWynik.AppendText(cbPalna1hPref.Text);
                dodano = true;
            }
            if (cbPalna1hBaza.Text != "")
            {
                palna1hWynik.AppendText(" " + cbPalna1hBaza.Text);
                dodano = true;
            }
            if (cbPalna1hSuf.Text != "")
            {
                palna1hWynik.AppendText(" " + cbPalna1hSuf.Text);
                dodano = true;
            }

            if (dodano)
            {
                dodano = false;

                if (skladnik1[3] == 0)
                {
                    skladnik1[0] = prefPalna1h.IndexOf(cbPalna1hPref.Text);
                    skladnik1[1] = bazaPalna1h.IndexOf(cbPalna1hBaza.Text);
                    skladnik1[2] = sufPalna1h.IndexOf(cbPalna1hSuf.Text);
                    skladnik1[3] = 1;
                }
                else
                {
                    skladnik2[0] = prefPalna1h.IndexOf(cbPalna1hPref.Text);
                    skladnik2[1] = bazaPalna1h.IndexOf(cbPalna1hBaza.Text);
                    skladnik2[2] = sufPalna1h.IndexOf(cbPalna1hSuf.Text);
                    skladnik2[3] = 1;

                    wynikLaczenia = polacz(skladnik1[0], skladnik1[1], skladnik1[2], skladnik2[0], skladnik2[1], skladnik2[2]);

                    if ((skladnik1[0] == (prefPalna1h.Count - 1)) & (skladnik2[0] == (prefPalna1h.Count - 2))) wynikLaczenia[0] = prefPalna1h.Count - 3; // nic
                    if ((skladnik1[0] == (prefPalna1h.Count - 2)) & (skladnik2[0] == (prefPalna1h.Count - 1))) wynikLaczenia[0] = prefPalna1h.Count - 3;
                    if ((skladnik1[0] == (prefPalna1h.Count - 3)) & (skladnik2[0] == (prefPalna1h.Count - 1))) wynikLaczenia[0] = prefPalna1h.Count - 2; // nic
                    if ((skladnik1[0] == (prefPalna1h.Count - 1)) & (skladnik2[0] == (prefPalna1h.Count - 3))) wynikLaczenia[0] = prefPalna1h.Count - 2;
                    if ((skladnik1[1] == (bazaPalna1h.Count - 1)) & (skladnik2[1] == (bazaPalna1h.Count - 2))) wynikLaczenia[1] = bazaPalna1h.Count - 3; // mp5k + skorpion = desert eagle
                    if ((skladnik1[1] == (bazaPalna1h.Count - 2)) & (skladnik2[1] == (bazaPalna1h.Count - 1))) wynikLaczenia[1] = bazaPalna1h.Count - 3;
                    if ((skladnik1[1] == (bazaPalna1h.Count - 3)) & (skladnik2[1] == (bazaPalna1h.Count - 1))) wynikLaczenia[1] = bazaPalna1h.Count - 2; // desert eagle + skorpion = mp5k
                    if ((skladnik1[1] == (bazaPalna1h.Count - 1)) & (skladnik2[1] == (bazaPalna1h.Count - 3))) wynikLaczenia[1] = bazaPalna1h.Count - 2;
                    if ((skladnik1[2] == (sufPalna1h.Count - 1)) & (skladnik2[2] == (sufPalna1h.Count - 2))) wynikLaczenia[2] = sufPalna1h.Count - 3; // nic
                    if ((skladnik1[2] == (sufPalna1h.Count - 2)) & (skladnik2[2] == (sufPalna1h.Count - 1))) wynikLaczenia[2] = sufPalna1h.Count - 3;
                    if ((skladnik1[2] == (sufPalna1h.Count - 3)) & (skladnik2[2] == (sufPalna1h.Count - 1))) wynikLaczenia[2] = sufPalna1h.Count - 2; // nic
                    if ((skladnik1[2] == (sufPalna1h.Count - 1)) & (skladnik2[2] == (sufPalna1h.Count - 3))) wynikLaczenia[2] = sufPalna1h.Count - 2;

                    for (int i = 0; i < 4; i++)
                    {
                        skladnik1[i] = wynikLaczenia[i];
                    }
                    skladnik1[3] = 1;
                    palna1hWynik.AppendText("\r= " + prefPalna1h.ElementAt(wynikLaczenia[0]) + " " + bazaPalna1h.ElementAt(wynikLaczenia[1]) + " " + sufPalna1h.ElementAt(wynikLaczenia[2]));
                }
            }

            palna1hWynik.ScrollToCaret();
        }

        private void palna2hDodaj_Click(object sender, EventArgs e)
        {
            if ((cbPalna2hPref.Text != "") | (cbPalna2hBaza.Text != "") | (cbPalna2hSuf.Text != ""))
            {
                if (skladnik1[3] == 1) palna2hWynik.AppendText(" + ");
            }

            if (cbPalna2hPref.Text != "")
            {
                palna2hWynik.AppendText(cbPalna2hPref.Text);
                dodano = true;
            }
            if (cbPalna2hBaza.Text != "")
            {
                palna2hWynik.AppendText(" " + cbPalna2hBaza.Text);
                dodano = true;
            }
            if (cbPalna2hSuf.Text != "")
            {
                palna2hWynik.AppendText(" " + cbPalna2hSuf.Text);
                dodano = true;
            }

            if (dodano)
            {
                dodano = false;

                if (skladnik1[3] == 0)
                {
                    skladnik1[0] = prefPalna2h.IndexOf(cbPalna2hPref.Text);
                    skladnik1[1] = bazaPalna2h.IndexOf(cbPalna2hBaza.Text);
                    skladnik1[2] = sufPalna2h.IndexOf(cbPalna2hSuf.Text);
                    skladnik1[3] = 1;
                }
                else
                {
                    skladnik2[0] = prefPalna2h.IndexOf(cbPalna2hPref.Text);
                    skladnik2[1] = bazaPalna2h.IndexOf(cbPalna2hBaza.Text);
                    skladnik2[2] = sufPalna2h.IndexOf(cbPalna2hSuf.Text);
                    skladnik2[3] = 1;

                    wynikLaczenia = polacz(skladnik1[0], skladnik1[1], skladnik1[2], skladnik2[0], skladnik2[1], skladnik2[2]);

                    if ((skladnik1[0] == (prefPalna2h.Count - 1)) & (skladnik2[0] == (prefPalna2h.Count - 2))) wynikLaczenia[0] = prefPalna2h.Count - 3; // nic
                    if ((skladnik1[0] == (prefPalna2h.Count - 2)) & (skladnik2[0] == (prefPalna2h.Count - 1))) wynikLaczenia[0] = prefPalna2h.Count - 3;
                    if ((skladnik1[0] == (prefPalna2h.Count - 3)) & (skladnik2[0] == (prefPalna2h.Count - 1))) wynikLaczenia[0] = prefPalna2h.Count - 2; // nic
                    if ((skladnik1[0] == (prefPalna2h.Count - 1)) & (skladnik2[0] == (prefPalna2h.Count - 3))) wynikLaczenia[0] = prefPalna2h.Count - 2;
                    if ((skladnik1[1] == (bazaPalna2h.Count - 1)) & (skladnik2[1] == (bazaPalna2h.Count - 2))) wynikLaczenia[1] = bazaPalna2h.Count - 3; // toporek do rzucania + ciężka kusza = pilum
                    if ((skladnik1[1] == (bazaPalna2h.Count - 2)) & (skladnik2[1] == (bazaPalna2h.Count - 1))) wynikLaczenia[1] = bazaPalna2h.Count - 3;
                    if ((skladnik1[1] == (bazaPalna2h.Count - 3)) & (skladnik2[1] == (bazaPalna2h.Count - 1))) wynikLaczenia[1] = bazaPalna2h.Count - 2; // pilum + ciężka kusza = toporek do rzucania
                    if ((skladnik1[1] == (bazaPalna2h.Count - 1)) & (skladnik2[1] == (bazaPalna2h.Count - 3))) wynikLaczenia[1] = bazaPalna2h.Count - 2;
                    if ((skladnik1[2] == (sufPalna2h.Count - 1)) & (skladnik2[2] == (sufPalna2h.Count - 2))) wynikLaczenia[2] = sufPalna2h.Count - 3; // szybkostrzelności + wilka = driady
                    if ((skladnik1[2] == (sufPalna2h.Count - 2)) & (skladnik2[2] == (sufPalna2h.Count - 1))) wynikLaczenia[2] = sufPalna2h.Count - 3;
                    if ((skladnik1[2] == (sufPalna2h.Count - 3)) & (skladnik2[2] == (sufPalna2h.Count - 1))) wynikLaczenia[2] = sufPalna2h.Count - 2; // driady + wilka = szybkostrzelności
                    if ((skladnik1[2] == (sufPalna2h.Count - 1)) & (skladnik2[2] == (sufPalna2h.Count - 3))) wynikLaczenia[2] = sufPalna2h.Count - 2;

                    for (int i = 0; i < 4; i++)
                    {
                        skladnik1[i] = wynikLaczenia[i];
                    }
                    skladnik1[3] = 1;
                    palna2hWynik.AppendText("\r= " + prefPalna2h.ElementAt(wynikLaczenia[0]) + " " + bazaPalna2h.ElementAt(wynikLaczenia[1]) + " " + sufPalna2h.ElementAt(wynikLaczenia[2]));
                }
            }

            palna2hWynik.ScrollToCaret();
        }

        private void dystansDodaj_Click(object sender, EventArgs e)
        {
            if ((cbDystansPref.Text != "") | (cbDystansBaza.Text != "") | (cbDystansSuf.Text != ""))
            {
                if (skladnik1[3] == 1) dystansWynik.AppendText(" + ");
            }

            if (cbDystansPref.Text != "")
            {
                dystansWynik.AppendText(cbDystansPref.Text);
                dodano = true;
            }
            if (cbDystansBaza.Text != "")
            {
                dystansWynik.AppendText(" " + cbDystansBaza.Text);
                dodano = true;
            }
            if (cbDystansSuf.Text != "")
            {
                dystansWynik.AppendText(" " + cbDystansSuf.Text);
                dodano = true;
            }

            if (dodano)
            {
                dodano = false;

                if (skladnik1[3] == 0)
                {
                    skladnik1[0] = prefDystans.IndexOf(cbDystansPref.Text);
                    skladnik1[1] = bazaDystans.IndexOf(cbDystansBaza.Text);
                    skladnik1[2] = sufDystans.IndexOf(cbDystansSuf.Text);
                    skladnik1[3] = 1;
                }
                else
                {
                    skladnik2[0] = prefDystans.IndexOf(cbDystansPref.Text);
                    skladnik2[1] = bazaDystans.IndexOf(cbDystansBaza.Text);
                    skladnik2[2] = sufDystans.IndexOf(cbDystansSuf.Text);
                    skladnik2[3] = 1;

                    wynikLaczenia = polacz(skladnik1[0], skladnik1[1], skladnik1[2], skladnik2[0], skladnik2[1], skladnik2[2]);

                    if ((skladnik1[0] == (prefDystans.Count - 1)) & (skladnik2[0] == (prefDystans.Count - 2))) wynikLaczenia[0] = prefDystans.Count - 3; // nic
                    if ((skladnik1[0] == (prefDystans.Count - 2)) & (skladnik2[0] == (prefDystans.Count - 1))) wynikLaczenia[0] = prefDystans.Count - 3;
                    if ((skladnik1[0] == (prefDystans.Count - 3)) & (skladnik2[0] == (prefDystans.Count - 1))) wynikLaczenia[0] = prefDystans.Count - 2; // nic
                    if ((skladnik1[0] == (prefDystans.Count - 1)) & (skladnik2[0] == (prefDystans.Count - 3))) wynikLaczenia[0] = prefDystans.Count - 2;
                    if ((skladnik1[1] == (bazaDystans.Count - 1)) & (skladnik2[1] == (bazaDystans.Count - 2))) wynikLaczenia[1] = bazaDystans.Count - 3; // toporek do rzucania + ciężka kusza = pilum
                    if ((skladnik1[1] == (bazaDystans.Count - 2)) & (skladnik2[1] == (bazaDystans.Count - 1))) wynikLaczenia[1] = bazaDystans.Count - 3;
                    if ((skladnik1[1] == (bazaDystans.Count - 3)) & (skladnik2[1] == (bazaDystans.Count - 1))) wynikLaczenia[1] = bazaDystans.Count - 2; // pilum + ciężka kusza = toporek do rzucania
                    if ((skladnik1[1] == (bazaDystans.Count - 1)) & (skladnik2[1] == (bazaDystans.Count - 3))) wynikLaczenia[1] = bazaDystans.Count - 2;
                    if ((skladnik1[2] == (sufDystans.Count - 1)) & (skladnik2[2] == (sufDystans.Count - 2))) wynikLaczenia[2] = sufDystans.Count - 3; // szybkostrzelności + wilka = driady
                    if ((skladnik1[2] == (sufDystans.Count - 2)) & (skladnik2[2] == (sufDystans.Count - 1))) wynikLaczenia[2] = sufDystans.Count - 3;
                    if ((skladnik1[2] == (sufDystans.Count - 3)) & (skladnik2[2] == (sufDystans.Count - 1))) wynikLaczenia[2] = sufDystans.Count - 2; // driady + wilka = szybkostrzelności
                    if ((skladnik1[2] == (sufDystans.Count - 1)) & (skladnik2[2] == (sufDystans.Count - 3))) wynikLaczenia[2] = sufDystans.Count - 2;

                    for (int i = 0; i < 4; i++)
                    {
                        skladnik1[i] = wynikLaczenia[i];
                    }
                    skladnik1[3] = 1;
                    dystansWynik.AppendText("\r= " + prefDystans.ElementAt(wynikLaczenia[0]) + " " + bazaDystans.ElementAt(wynikLaczenia[1]) + " " + sufDystans.ElementAt(wynikLaczenia[2]));
                }
            }

            dystansWynik.ScrollToCaret();
        }

        public int[] polacz(int pref1, int baza1, int suf1, int pref2, int baza2, int suf2)
        {
            int[] wynik = new int[4];
            double x, y;

            // prefiks
            if (true)
            {
                x = pref1;
                y = pref2;

                if ((pref1 == 0) | (pref2 == 0)) wynik[0] = 0;
                else if (pref1 == pref2) wynik[0] = pref1;
                else if (true) wynik[0] = Convert.ToInt32(Math.Ceiling((x + y) / 2) + 1);
            }

            // baza
            if (true)
            {
                x = baza1;
                y = baza2;

                if ((baza1 == 0) | (baza2 == 0)) wynik[1] = 0;
                else if (baza1 == baza2) wynik[1] = baza1;
                else if (true) wynik[1] = Convert.ToInt32(Math.Ceiling((x + y) / 2) + 1);
            }


            // sufiks
            if (true)
            {
                x = suf1;
                y = suf2;

                if ((suf1 == 0) | (suf2 == 0)) wynik[2] = 0;
                else if (suf1 == suf2) wynik[2] = suf1;
                else if (true) wynik[2] = Convert.ToInt32(Math.Ceiling((x + y) / 2) + 1);
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

            // czyszczenie labeli
            PrefHelmL.Text = "";
        }

        private void prefHelmPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefHelm")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "PrefHelm";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = prefHelm.Count();
                tabela.dataGridView1.ColumnCount = prefHelm.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < prefHelm.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = prefHelm[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = prefHelm[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < prefHelm.Count(); i++)
                {
                    for (int j = 1; j < prefHelm.Count(); j++)
                    {
                        if ((i == (prefHelm.Count - 1)) & (j == (prefHelm.Count - 2))) wynikTab[0] = prefHelm.Count - 3; // wyjątki
                        else if ((i == (prefHelm.Count - 2)) & (j == (prefHelm.Count - 1))) wynikTab[0] = prefHelm.Count - 3;
                        else if ((i == (prefHelm.Count - 3)) & (j == (prefHelm.Count - 1))) wynikTab[0] = prefHelm.Count - 2;
                        else if ((i == (prefHelm.Count - 1)) & (j == (prefHelm.Count - 3))) wynikTab[0] = prefHelm.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = prefHelm.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < prefHelm.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void bazaHelmPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaHelm")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "BazaHelm";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = bazaHelm.Count();
                tabela.dataGridView1.ColumnCount = bazaHelm.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < bazaHelm.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = bazaHelm[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = bazaHelm[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < bazaHelm.Count(); i++)
                {
                    for (int j = 1; j < bazaHelm.Count(); j++)
                    {
                        if ((i == (bazaHelm.Count - 1)) & (j == (bazaHelm.Count - 2))) wynikTab[0] = bazaHelm.Count - 3; // wyjątki
                        else if ((i == (bazaHelm.Count - 2)) & (j == (bazaHelm.Count - 1))) wynikTab[0] = bazaHelm.Count - 3;
                        else if ((i == (bazaHelm.Count - 3)) & (j == (bazaHelm.Count - 1))) wynikTab[0] = bazaHelm.Count - 2;
                        else if ((i == (bazaHelm.Count - 1)) & (j == (bazaHelm.Count - 3))) wynikTab[0] = bazaHelm.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = bazaHelm.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < bazaHelm.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void sufHelmPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufHelm")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "SufHelm";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = sufHelm.Count();
                tabela.dataGridView1.ColumnCount = sufHelm.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < sufHelm.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = sufHelm[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = sufHelm[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < sufHelm.Count(); i++)
                {
                    for (int j = 1; j < sufHelm.Count(); j++)
                    {
                        if ((i == (sufHelm.Count - 1)) & (j == (sufHelm.Count - 2))) wynikTab[0] = sufHelm.Count - 3; // wyjątki
                        else if ((i == (sufHelm.Count - 2)) & (j == (sufHelm.Count - 1))) wynikTab[0] = sufHelm.Count - 3;
                        else if ((i == (sufHelm.Count - 3)) & (j == (sufHelm.Count - 1))) wynikTab[0] = sufHelm.Count - 2;
                        else if ((i == (sufHelm.Count - 1)) & (j == (sufHelm.Count - 3))) wynikTab[0] = sufHelm.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = sufHelm.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < sufHelm.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void prefZbrojaPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefZbroja")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "PrefZbroja";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = prefZbroja.Count();
                tabela.dataGridView1.ColumnCount = prefZbroja.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < prefZbroja.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = prefZbroja[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = prefZbroja[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < prefZbroja.Count(); i++)
                {
                    for (int j = 1; j < prefZbroja.Count(); j++)
                    {
                        if ((i == (prefZbroja.Count - 1)) & (j == (prefZbroja.Count - 2))) wynikTab[0] = prefZbroja.Count - 3; // wyjątki
                        else if ((i == (prefZbroja.Count - 2)) & (j == (prefZbroja.Count - 1))) wynikTab[0] = prefZbroja.Count - 3;
                        else if ((i == (prefZbroja.Count - 3)) & (j == (prefZbroja.Count - 1))) wynikTab[0] = prefZbroja.Count - 2;
                        else if ((i == (prefZbroja.Count - 1)) & (j == (prefZbroja.Count - 3))) wynikTab[0] = prefZbroja.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = prefZbroja.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < prefZbroja.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void bazaZbrojaPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaZbroja")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "BazaZbroja";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = bazaZbroja.Count();
                tabela.dataGridView1.ColumnCount = bazaZbroja.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < bazaZbroja.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = bazaZbroja[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = bazaZbroja[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < bazaZbroja.Count(); i++)
                {
                    for (int j = 1; j < bazaZbroja.Count(); j++)
                    {
                        if ((i == (bazaZbroja.Count - 1)) & (j == (bazaZbroja.Count - 2))) wynikTab[0] = bazaZbroja.Count - 3; // wyjątki
                        else if ((i == (bazaZbroja.Count - 2)) & (j == (bazaZbroja.Count - 1))) wynikTab[0] = bazaZbroja.Count - 3;
                        else if ((i == (bazaZbroja.Count - 3)) & (j == (bazaZbroja.Count - 1))) wynikTab[0] = bazaZbroja.Count - 2;
                        else if ((i == (bazaZbroja.Count - 1)) & (j == (bazaZbroja.Count - 3))) wynikTab[0] = bazaZbroja.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = bazaZbroja.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < bazaZbroja.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void sufZbrojaPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufZbroja")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "SufZbroja";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = sufZbroja.Count();
                tabela.dataGridView1.ColumnCount = sufZbroja.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < sufZbroja.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = sufZbroja[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = sufZbroja[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < sufZbroja.Count(); i++)
                {
                    for (int j = 1; j < sufZbroja.Count(); j++)
                    {
                        if ((i == (sufZbroja.Count - 1)) & (j == (sufZbroja.Count - 2))) wynikTab[0] = sufZbroja.Count - 3; // wyjątki
                        else if ((i == (sufZbroja.Count - 2)) & (j == (sufZbroja.Count - 1))) wynikTab[0] = sufZbroja.Count - 3;
                        else if ((i == (sufZbroja.Count - 3)) & (j == (sufZbroja.Count - 1))) wynikTab[0] = sufZbroja.Count - 2;
                        else if ((i == (sufZbroja.Count - 1)) & (j == (sufZbroja.Count - 3))) wynikTab[0] = sufZbroja.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = sufZbroja.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < sufZbroja.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void prefSpodniePanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefSpodnie")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "PrefSpodnie";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = prefSpodnie.Count();
                tabela.dataGridView1.ColumnCount = prefSpodnie.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < prefSpodnie.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = prefSpodnie[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = prefSpodnie[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < prefSpodnie.Count(); i++)
                {
                    for (int j = 1; j < prefSpodnie.Count(); j++)
                    {
                        if ((i == (prefSpodnie.Count - 1)) & (j == (prefSpodnie.Count - 2))) wynikTab[0] = prefSpodnie.Count - 3; // wyjątki
                        else if ((i == (prefSpodnie.Count - 2)) & (j == (prefSpodnie.Count - 1))) wynikTab[0] = prefSpodnie.Count - 3;
                        else if ((i == (prefSpodnie.Count - 3)) & (j == (prefSpodnie.Count - 1))) wynikTab[0] = prefSpodnie.Count - 2;
                        else if ((i == (prefSpodnie.Count - 1)) & (j == (prefSpodnie.Count - 3))) wynikTab[0] = prefSpodnie.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = prefSpodnie.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < prefSpodnie.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void bazaSpodniePanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaSpodnie")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "BazaSpodnie";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = bazaSpodnie.Count();
                tabela.dataGridView1.ColumnCount = bazaSpodnie.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < bazaSpodnie.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = bazaSpodnie[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = bazaSpodnie[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < bazaSpodnie.Count(); i++)
                {
                    for (int j = 1; j < bazaSpodnie.Count(); j++)
                    {
                        if ((i == (bazaSpodnie.Count - 1)) & (j == (bazaSpodnie.Count - 2))) wynikTab[0] = bazaSpodnie.Count - 3; // wyjątki
                        else if ((i == (bazaSpodnie.Count - 2)) & (j == (bazaSpodnie.Count - 1))) wynikTab[0] = bazaSpodnie.Count - 3;
                        else if ((i == (bazaSpodnie.Count - 3)) & (j == (bazaSpodnie.Count - 1))) wynikTab[0] = bazaSpodnie.Count - 2;
                        else if ((i == (bazaSpodnie.Count - 1)) & (j == (bazaSpodnie.Count - 3))) wynikTab[0] = bazaSpodnie.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = bazaSpodnie.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < bazaSpodnie.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void sufSpodniePanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufSpodnie")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "SufSpodnie";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = sufSpodnie.Count();
                tabela.dataGridView1.ColumnCount = sufSpodnie.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < sufSpodnie.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = sufSpodnie[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = sufSpodnie[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < sufSpodnie.Count(); i++)
                {
                    for (int j = 1; j < sufSpodnie.Count(); j++)
                    {
                        if ((i == (sufSpodnie.Count - 1)) & (j == (sufSpodnie.Count - 2))) wynikTab[0] = sufSpodnie.Count - 3; // wyjątki
                        else if ((i == (sufSpodnie.Count - 2)) & (j == (sufSpodnie.Count - 1))) wynikTab[0] = sufSpodnie.Count - 3;
                        else if ((i == (sufSpodnie.Count - 3)) & (j == (sufSpodnie.Count - 1))) wynikTab[0] = sufSpodnie.Count - 2;
                        else if ((i == (sufSpodnie.Count - 1)) & (j == (sufSpodnie.Count - 3))) wynikTab[0] = sufSpodnie.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = sufSpodnie.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < sufSpodnie.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void prefPierscienPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefPierscien")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "PrefPierscien";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = prefPierscien.Count();
                tabela.dataGridView1.ColumnCount = prefPierscien.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < prefPierscien.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = prefPierscien[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = prefPierscien[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < prefPierscien.Count(); i++)
                {
                    for (int j = 1; j < prefPierscien.Count(); j++)
                    {
                        if ((i == (prefPierscien.Count - 1)) & (j == (prefPierscien.Count - 2))) wynikTab[0] = prefPierscien.Count - 3; // wyjątki
                        else if ((i == (prefPierscien.Count - 2)) & (j == (prefPierscien.Count - 1))) wynikTab[0] = prefPierscien.Count - 3;
                        else if ((i == (prefPierscien.Count - 3)) & (j == (prefPierscien.Count - 1))) wynikTab[0] = prefPierscien.Count - 2;
                        else if ((i == (prefPierscien.Count - 1)) & (j == (prefPierscien.Count - 3))) wynikTab[0] = prefPierscien.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = prefPierscien.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < prefPierscien.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void bazaPierscienPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaPierscien")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "BazaPierscien";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = bazaPierscien.Count();
                tabela.dataGridView1.ColumnCount = bazaPierscien.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < bazaPierscien.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = bazaPierscien[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = bazaPierscien[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < bazaPierscien.Count(); i++)
                {
                    for (int j = 1; j < bazaPierscien.Count(); j++)
                    {
                        if ((i == (bazaPierscien.Count - 1)) & (j == (bazaPierscien.Count - 2))) wynikTab[0] = bazaPierscien.Count - 3; // wyjątki
                        else if ((i == (bazaPierscien.Count - 2)) & (j == (bazaPierscien.Count - 1))) wynikTab[0] = bazaPierscien.Count - 3;
                        else if ((i == (bazaPierscien.Count - 3)) & (j == (bazaPierscien.Count - 1))) wynikTab[0] = bazaPierscien.Count - 2;
                        else if ((i == (bazaPierscien.Count - 1)) & (j == (bazaPierscien.Count - 3))) wynikTab[0] = bazaPierscien.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = bazaPierscien.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < bazaPierscien.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void sufPierscienPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufPierscien")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "SufPierscien";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = sufPierscien.Count();
                tabela.dataGridView1.ColumnCount = sufPierscien.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < sufPierscien.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = sufPierscien[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = sufPierscien[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < sufPierscien.Count(); i++)
                {
                    for (int j = 1; j < sufPierscien.Count(); j++)
                    {
                        if ((i == (sufPierscien.Count - 1)) & (j == (sufPierscien.Count - 2))) wynikTab[0] = sufPierscien.Count - 3; // wyjątki
                        else if ((i == (sufPierscien.Count - 2)) & (j == (sufPierscien.Count - 1))) wynikTab[0] = sufPierscien.Count - 3;
                        else if ((i == (sufPierscien.Count - 3)) & (j == (sufPierscien.Count - 1))) wynikTab[0] = sufPierscien.Count - 2;
                        else if ((i == (sufPierscien.Count - 1)) & (j == (sufPierscien.Count - 3))) wynikTab[0] = sufPierscien.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = sufPierscien.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < sufPierscien.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void prefAmuletPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefAmulet")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "PrefAmulet";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = prefAmulet.Count();
                tabela.dataGridView1.ColumnCount = prefAmulet.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < prefAmulet.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = prefAmulet[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = prefAmulet[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < prefAmulet.Count(); i++)
                {
                    for (int j = 1; j < prefAmulet.Count(); j++)
                    {
                        if ((i == (prefAmulet.Count - 1)) & (j == (prefAmulet.Count - 2))) wynikTab[0] = prefAmulet.Count - 3; // wyjątki
                        else if ((i == (prefAmulet.Count - 2)) & (j == (prefAmulet.Count - 1))) wynikTab[0] = prefAmulet.Count - 3;
                        else if ((i == (prefAmulet.Count - 3)) & (j == (prefAmulet.Count - 1))) wynikTab[0] = prefAmulet.Count - 2;
                        else if ((i == (prefAmulet.Count - 1)) & (j == (prefAmulet.Count - 3))) wynikTab[0] = prefAmulet.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = prefAmulet.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < prefAmulet.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void bazaAmuletPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaAmulet")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "BazaAmulet";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = bazaAmulet.Count();
                tabela.dataGridView1.ColumnCount = bazaAmulet.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < bazaAmulet.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = bazaAmulet[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = bazaAmulet[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < bazaAmulet.Count(); i++)
                {
                    for (int j = 1; j < bazaAmulet.Count(); j++)
                    {
                        if ((i == (bazaAmulet.Count - 1)) & (j == (bazaAmulet.Count - 2))) wynikTab[0] = bazaAmulet.Count - 3; // wyjątki
                        else if ((i == (bazaAmulet.Count - 2)) & (j == (bazaAmulet.Count - 1))) wynikTab[0] = bazaAmulet.Count - 3;
                        else if ((i == (bazaAmulet.Count - 3)) & (j == (bazaAmulet.Count - 1))) wynikTab[0] = bazaAmulet.Count - 2;
                        else if ((i == (bazaAmulet.Count - 1)) & (j == (bazaAmulet.Count - 3))) wynikTab[0] = bazaAmulet.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = bazaAmulet.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < bazaAmulet.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void sufAmuletPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufAmulet")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "SufAmulet";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = sufAmulet.Count();
                tabela.dataGridView1.ColumnCount = sufAmulet.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < sufAmulet.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = sufAmulet[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = sufAmulet[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < sufAmulet.Count(); i++)
                {
                    for (int j = 1; j < sufAmulet.Count(); j++)
                    {
                        if ((i == (sufAmulet.Count - 1)) & (j == (sufAmulet.Count - 2))) wynikTab[0] = sufAmulet.Count - 3; // wyjątki
                        else if ((i == (sufAmulet.Count - 2)) & (j == (sufAmulet.Count - 1))) wynikTab[0] = sufAmulet.Count - 3;
                        else if ((i == (sufAmulet.Count - 3)) & (j == (sufAmulet.Count - 1))) wynikTab[0] = sufAmulet.Count - 2;
                        else if ((i == (sufAmulet.Count - 1)) & (j == (sufAmulet.Count - 3))) wynikTab[0] = sufAmulet.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = sufAmulet.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < sufAmulet.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void prefBiala1hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefBiala1h")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "PrefBiala1h";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = prefBiala1h.Count();
                tabela.dataGridView1.ColumnCount = prefBiala1h.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < prefBiala1h.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = prefBiala1h[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = prefBiala1h[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < prefBiala1h.Count(); i++)
                {
                    for (int j = 1; j < prefBiala1h.Count(); j++)
                    {
                        if ((i == (prefBiala1h.Count - 1)) & (j == (prefBiala1h.Count - 2))) wynikTab[0] = prefBiala1h.Count - 3; // wyjątki
                        else if ((i == (prefBiala1h.Count - 2)) & (j == (prefBiala1h.Count - 1))) wynikTab[0] = prefBiala1h.Count - 3;
                        else if ((i == (prefBiala1h.Count - 3)) & (j == (prefBiala1h.Count - 1))) wynikTab[0] = prefBiala1h.Count - 2;
                        else if ((i == (prefBiala1h.Count - 1)) & (j == (prefBiala1h.Count - 3))) wynikTab[0] = prefBiala1h.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = prefBiala1h.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < prefBiala1h.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void bazaBiala1hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaBiala1h")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "BazaBiala1h";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = bazaBiala1h.Count();
                tabela.dataGridView1.ColumnCount = bazaBiala1h.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < bazaBiala1h.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = bazaBiala1h[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = bazaBiala1h[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < bazaBiala1h.Count(); i++)
                {
                    for (int j = 1; j < bazaBiala1h.Count(); j++)
                    {
                        if ((i == (bazaBiala1h.Count - 1)) & (j == (bazaBiala1h.Count - 2))) wynikTab[0] = bazaBiala1h.Count - 3; // wyjątki
                        else if ((i == (bazaBiala1h.Count - 2)) & (j == (bazaBiala1h.Count - 1))) wynikTab[0] = bazaBiala1h.Count - 3;
                        else if ((i == (bazaBiala1h.Count - 3)) & (j == (bazaBiala1h.Count - 1))) wynikTab[0] = bazaBiala1h.Count - 2;
                        else if ((i == (bazaBiala1h.Count - 1)) & (j == (bazaBiala1h.Count - 3))) wynikTab[0] = bazaBiala1h.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = bazaBiala1h.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < bazaBiala1h.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void sufBiala1hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufBiala1h")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "SufBiala1h";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = sufBiala1h.Count();
                tabela.dataGridView1.ColumnCount = sufBiala1h.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < sufBiala1h.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = sufBiala1h[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = sufBiala1h[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < sufBiala1h.Count(); i++)
                {
                    for (int j = 1; j < sufBiala1h.Count(); j++)
                    {
                        if ((i == (sufBiala1h.Count - 1)) & (j == (sufBiala1h.Count - 2))) wynikTab[0] = sufBiala1h.Count - 3; // wyjątki
                        else if ((i == (sufBiala1h.Count - 2)) & (j == (sufBiala1h.Count - 1))) wynikTab[0] = sufBiala1h.Count - 3;
                        else if ((i == (sufBiala1h.Count - 3)) & (j == (sufBiala1h.Count - 1))) wynikTab[0] = sufBiala1h.Count - 2;
                        else if ((i == (sufBiala1h.Count - 1)) & (j == (sufBiala1h.Count - 3))) wynikTab[0] = sufBiala1h.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = sufBiala1h.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < sufBiala1h.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void prefBiala2hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefBiala2h")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "PrefBiala2h";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = prefBiala2h.Count();
                tabela.dataGridView1.ColumnCount = prefBiala2h.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < prefBiala2h.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = prefBiala2h[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = prefBiala2h[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < prefBiala2h.Count(); i++)
                {
                    for (int j = 1; j < prefBiala2h.Count(); j++)
                    {
                        if ((i == (prefBiala2h.Count - 1)) & (j == (prefBiala2h.Count - 2))) wynikTab[0] = prefBiala2h.Count - 3; // wyjątki
                        else if ((i == (prefBiala2h.Count - 2)) & (j == (prefBiala2h.Count - 1))) wynikTab[0] = prefBiala2h.Count - 3;
                        else if ((i == (prefBiala2h.Count - 3)) & (j == (prefBiala2h.Count - 1))) wynikTab[0] = prefBiala2h.Count - 2;
                        else if ((i == (prefBiala2h.Count - 1)) & (j == (prefBiala2h.Count - 3))) wynikTab[0] = prefBiala2h.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = prefBiala2h.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < prefBiala2h.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void bazaBiala2hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaBiala2h")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "BazaBiala2h";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = bazaBiala2h.Count();
                tabela.dataGridView1.ColumnCount = bazaBiala2h.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < bazaBiala2h.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = bazaBiala2h[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = bazaBiala2h[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < bazaBiala2h.Count(); i++)
                {
                    for (int j = 1; j < bazaBiala2h.Count(); j++)
                    {
                        if ((i == (bazaBiala2h.Count - 1)) & (j == (bazaBiala2h.Count - 2))) wynikTab[0] = bazaBiala2h.Count - 3; // wyjątki
                        else if ((i == (bazaBiala2h.Count - 2)) & (j == (bazaBiala2h.Count - 1))) wynikTab[0] = bazaBiala2h.Count - 3;
                        else if ((i == (bazaBiala2h.Count - 3)) & (j == (bazaBiala2h.Count - 1))) wynikTab[0] = bazaBiala2h.Count - 2;
                        else if ((i == (bazaBiala2h.Count - 1)) & (j == (bazaBiala2h.Count - 3))) wynikTab[0] = bazaBiala2h.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = bazaBiala2h.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < bazaBiala2h.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void sufBiala2hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufBiala2h")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "SufBiala2h";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = sufBiala2h.Count();
                tabela.dataGridView1.ColumnCount = sufBiala2h.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < sufBiala2h.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = sufBiala2h[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = sufBiala2h[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < sufBiala2h.Count(); i++)
                {
                    for (int j = 1; j < sufBiala2h.Count(); j++)
                    {
                        if ((i == (sufBiala2h.Count - 1)) & (j == (sufBiala2h.Count - 2))) wynikTab[0] = sufBiala2h.Count - 3; // wyjątki
                        else if ((i == (sufBiala2h.Count - 2)) & (j == (sufBiala2h.Count - 1))) wynikTab[0] = sufBiala2h.Count - 3;
                        else if ((i == (sufBiala2h.Count - 3)) & (j == (sufBiala2h.Count - 1))) wynikTab[0] = sufBiala2h.Count - 2;
                        else if ((i == (sufBiala2h.Count - 1)) & (j == (sufBiala2h.Count - 3))) wynikTab[0] = sufBiala2h.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = sufBiala2h.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < sufBiala2h.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void prefPalna1hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefPalna1h")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "PrefPalna1h";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = prefPalna1h.Count();
                tabela.dataGridView1.ColumnCount = prefPalna1h.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < prefPalna1h.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = prefPalna1h[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = prefPalna1h[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < prefPalna1h.Count(); i++)
                {
                    for (int j = 1; j < prefPalna1h.Count(); j++)
                    {
                        if ((i == (prefPalna1h.Count - 1)) & (j == (prefPalna1h.Count - 2))) wynikTab[0] = prefPalna1h.Count - 3; // wyjątki
                        else if ((i == (prefPalna1h.Count - 2)) & (j == (prefPalna1h.Count - 1))) wynikTab[0] = prefPalna1h.Count - 3;
                        else if ((i == (prefPalna1h.Count - 3)) & (j == (prefPalna1h.Count - 1))) wynikTab[0] = prefPalna1h.Count - 2;
                        else if ((i == (prefPalna1h.Count - 1)) & (j == (prefPalna1h.Count - 3))) wynikTab[0] = prefPalna1h.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = prefPalna1h.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < prefPalna1h.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void bazaPalna1hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaPalna1h")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "BazaPalna1h";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = bazaPalna1h.Count();
                tabela.dataGridView1.ColumnCount = bazaPalna1h.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < bazaPalna1h.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = bazaPalna1h[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = bazaPalna1h[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < bazaPalna1h.Count(); i++)
                {
                    for (int j = 1; j < bazaPalna1h.Count(); j++)
                    {
                        if ((i == (bazaPalna1h.Count - 1)) & (j == (bazaPalna1h.Count - 2))) wynikTab[0] = bazaPalna1h.Count - 3; // wyjątki
                        else if ((i == (bazaPalna1h.Count - 2)) & (j == (bazaPalna1h.Count - 1))) wynikTab[0] = bazaPalna1h.Count - 3;
                        else if ((i == (bazaPalna1h.Count - 3)) & (j == (bazaPalna1h.Count - 1))) wynikTab[0] = bazaPalna1h.Count - 2;
                        else if ((i == (bazaPalna1h.Count - 1)) & (j == (bazaPalna1h.Count - 3))) wynikTab[0] = bazaPalna1h.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = bazaPalna1h.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < bazaPalna1h.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void sufPalna1hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufPalna1h")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "SufPalna1h";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = sufPalna1h.Count();
                tabela.dataGridView1.ColumnCount = sufPalna1h.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < sufPalna1h.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = sufPalna1h[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = sufPalna1h[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < sufPalna1h.Count(); i++)
                {
                    for (int j = 1; j < sufPalna1h.Count(); j++)
                    {
                        if ((i == (sufPalna1h.Count - 1)) & (j == (sufPalna1h.Count - 2))) wynikTab[0] = sufPalna1h.Count - 3; // wyjątki
                        else if ((i == (sufPalna1h.Count - 2)) & (j == (sufPalna1h.Count - 1))) wynikTab[0] = sufPalna1h.Count - 3;
                        else if ((i == (sufPalna1h.Count - 3)) & (j == (sufPalna1h.Count - 1))) wynikTab[0] = sufPalna1h.Count - 2;
                        else if ((i == (sufPalna1h.Count - 1)) & (j == (sufPalna1h.Count - 3))) wynikTab[0] = sufPalna1h.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = sufPalna1h.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < sufPalna1h.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void prefPalna2hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefPalna2h")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "PrefPalna2h";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = prefPalna2h.Count();
                tabela.dataGridView1.ColumnCount = prefPalna2h.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < prefPalna2h.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = prefPalna2h[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = prefPalna2h[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < prefPalna2h.Count(); i++)
                {
                    for (int j = 1; j < prefPalna2h.Count(); j++)
                    {
                        if ((i == (prefPalna2h.Count - 1)) & (j == (prefPalna2h.Count - 2))) wynikTab[0] = prefPalna2h.Count - 3; // wyjątki
                        else if ((i == (prefPalna2h.Count - 2)) & (j == (prefPalna2h.Count - 1))) wynikTab[0] = prefPalna2h.Count - 3;
                        else if ((i == (prefPalna2h.Count - 3)) & (j == (prefPalna2h.Count - 1))) wynikTab[0] = prefPalna2h.Count - 2;
                        else if ((i == (prefPalna2h.Count - 1)) & (j == (prefPalna2h.Count - 3))) wynikTab[0] = prefPalna2h.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = prefPalna2h.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < prefPalna2h.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void bazaPalna2hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaPalna2h")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "BazaPalna2h";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = bazaPalna2h.Count();
                tabela.dataGridView1.ColumnCount = bazaPalna2h.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < bazaPalna2h.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = bazaPalna2h[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = bazaPalna2h[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < bazaPalna2h.Count(); i++)
                {
                    for (int j = 1; j < bazaPalna2h.Count(); j++)
                    {
                        if ((i == (bazaPalna2h.Count - 1)) & (j == (bazaPalna2h.Count - 2))) wynikTab[0] = bazaPalna2h.Count - 3; // wyjątki
                        else if ((i == (bazaPalna2h.Count - 2)) & (j == (bazaPalna2h.Count - 1))) wynikTab[0] = bazaPalna2h.Count - 3;
                        else if ((i == (bazaPalna2h.Count - 3)) & (j == (bazaPalna2h.Count - 1))) wynikTab[0] = bazaPalna2h.Count - 2;
                        else if ((i == (bazaPalna2h.Count - 1)) & (j == (bazaPalna2h.Count - 3))) wynikTab[0] = bazaPalna2h.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = bazaPalna2h.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < bazaPalna2h.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void sufPalna2hPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufPalna2h")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "SufPalna2h";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = sufPalna2h.Count();
                tabela.dataGridView1.ColumnCount = sufPalna2h.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < sufPalna2h.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = sufPalna2h[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = sufPalna2h[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < sufPalna2h.Count(); i++)
                {
                    for (int j = 1; j < sufPalna2h.Count(); j++)
                    {
                        if ((i == (sufPalna2h.Count - 1)) & (j == (sufPalna2h.Count - 2))) wynikTab[0] = sufPalna2h.Count - 3; // wyjątki
                        else if ((i == (sufPalna2h.Count - 2)) & (j == (sufPalna2h.Count - 1))) wynikTab[0] = sufPalna2h.Count - 3;
                        else if ((i == (sufPalna2h.Count - 3)) & (j == (sufPalna2h.Count - 1))) wynikTab[0] = sufPalna2h.Count - 2;
                        else if ((i == (sufPalna2h.Count - 1)) & (j == (sufPalna2h.Count - 3))) wynikTab[0] = sufPalna2h.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = sufPalna2h.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < sufPalna2h.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void prefDystansPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "PrefDystans")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "PrefDystans";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = prefDystans.Count();
                tabela.dataGridView1.ColumnCount = prefDystans.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < prefDystans.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = prefDystans[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = prefDystans[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < prefDystans.Count(); i++)
                {
                    for (int j = 1; j < prefDystans.Count(); j++)
                    {
                        if ((i == (prefDystans.Count - 1)) & (j == (prefDystans.Count - 2))) wynikTab[0] = prefDystans.Count - 3; // wyjątki
                        else if ((i == (prefDystans.Count - 2)) & (j == (prefDystans.Count - 1))) wynikTab[0] = prefDystans.Count - 3;
                        else if ((i == (prefDystans.Count - 3)) & (j == (prefDystans.Count - 1))) wynikTab[0] = prefDystans.Count - 2;
                        else if ((i == (prefDystans.Count - 1)) & (j == (prefDystans.Count - 3))) wynikTab[0] = prefDystans.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = prefDystans.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < prefDystans.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void bazaDystansPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "BazaDystans")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "BazaDystans";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = bazaDystans.Count();
                tabela.dataGridView1.ColumnCount = bazaDystans.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < bazaDystans.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = bazaDystans[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = bazaDystans[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < bazaDystans.Count(); i++)
                {
                    for (int j = 1; j < bazaDystans.Count(); j++)
                    {
                        if ((i == (bazaDystans.Count - 1)) & (j == (bazaDystans.Count - 2))) wynikTab[0] = bazaDystans.Count - 3; // wyjątki
                        else if ((i == (bazaDystans.Count - 2)) & (j == (bazaDystans.Count - 1))) wynikTab[0] = bazaDystans.Count - 3;
                        else if ((i == (bazaDystans.Count - 3)) & (j == (bazaDystans.Count - 1))) wynikTab[0] = bazaDystans.Count - 2;
                        else if ((i == (bazaDystans.Count - 1)) & (j == (bazaDystans.Count - 3))) wynikTab[0] = bazaDystans.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = bazaDystans.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < bazaDystans.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
        }

        private void sufDystansPanelLabel_Click(object sender, EventArgs e)
        {
            if (tabela == null || tabela.IsOpen == false || tabela.DisplayedTable != "SufDystans")
            {
                if (tabela != null)
                {
                    tabela.IsOpen = false;
                    tabela.Dispose();
                    tabela.Close();
                }

                tabela = new Form2();
                tabela.DisplayedTable = "SufDystans";

                tabela.dataGridView1.RowCount = 1;
                tabela.dataGridView1.ColumnCount = 1;
                tabela.dataGridView1.RowCount = sufDystans.Count();
                tabela.dataGridView1.ColumnCount = sufDystans.Count();

                tabela.Height = 60 + (tabela.dataGridView1.RowCount * tabela.dataGridView1.RowTemplate.Height); // obramowanie = 60, + (rowCount * rowHeight)
                if (tabela.Height < 150) tabela.Height = 150;
                tabela.Width = Convert.ToInt32(tabela.Height * 1.78);   // szerokość do dopasowania do formatu 16:9

                for (int i = 0; i < sufDystans.Count(); i++)
                {
                    tabela.dataGridView1.Rows[i].Cells[0].Value = sufDystans[i];
                    tabela.dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                    tabela.dataGridView1.Rows[0].Cells[i].Value = sufDystans[i];
                    tabela.dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.Gainsboro;
                }

                for (int i = 1; i < sufDystans.Count(); i++)
                {
                    for (int j = 1; j < sufDystans.Count(); j++)
                    {
                        if ((i == (sufDystans.Count - 1)) & (j == (sufDystans.Count - 2))) wynikTab[0] = sufDystans.Count - 3; // wyjątki
                        else if ((i == (sufDystans.Count - 2)) & (j == (sufDystans.Count - 1))) wynikTab[0] = sufDystans.Count - 3;
                        else if ((i == (sufDystans.Count - 3)) & (j == (sufDystans.Count - 1))) wynikTab[0] = sufDystans.Count - 2;
                        else if ((i == (sufDystans.Count - 1)) & (j == (sufDystans.Count - 3))) wynikTab[0] = sufDystans.Count - 2;
                        else if (true) wynikTab = polacz(i, 0, 0, j, 0, 0);

                        tabela.dataGridView1.Rows[i].Cells[j].Value = sufDystans.ElementAt(wynikTab[0]);
                    }
                }

                for (int i = 1; i < sufDystans.Count(); i++) tabela.dataGridView1.Rows[i].Cells[i].Style.BackColor = Color.LightBlue;

                tabela.Show();
            }
            else
            {
                tabela.BringToFront();
            }
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
            skladnik1 = new int[4] { 0, 0, 0, 0 };
            skladnik2 = new int[4] { 0, 0, 0, 0 };
            wynikLaczenia = new int[4] { 0, 0, 0, 0 };
            dodano = false;

            switch (tabControl1.SelectedTab.Text)
            {
                case "Hełm":
                    helmWynik.Clear();
                    break;
                case "Zbroja":
                    zbrojaWynik.Clear();
                    break;
                case "Spodnie":
                    spodnieWynik.Clear();
                    break;
                case "Pierścień":
                    pierscienWynik.Clear();
                    break;
                case "Amulet":
                    amuletWynik.Clear();
                    break;
                case "Biała 1h":
                    biala1hWynik.Clear();
                    break;
                case "Biała 2h":
                    biala2hWynik.Clear();
                    break;
                case "Palna 1h":
                    palna1hWynik.Clear();
                    break;
                case "Palna 2h":
                    palna2hWynik.Clear();
                    break;
                case "Dystans":
                    dystansWynik.Clear();
                    break;
                case "Analizator raportu":
                    AnalizatorRaportuTekst.Clear();
                    break;
            }
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

        private void Label_TextChanged(object sender, EventArgs e)
        {
            if (skladnik1[3] != 0)
            {
                int[] TempSkladnik = new int[3];
                int[] TempWynik = new int[3];

                switch (tabControl1.SelectedTab.Text)
                {
                    case "Hełm":
                        TempSkladnik[0] = prefHelm.IndexOf(cbHelmPref.Text);
                        TempSkladnik[1] = bazaHelm.IndexOf(cbHelmBaza.Text);
                        TempSkladnik[2] = sufHelm.IndexOf(cbHelmSuf.Text);

                        TempWynik = polacz(skladnik1[0], skladnik1[1], skladnik1[2], TempSkladnik[0], TempSkladnik[1], TempSkladnik[2]);

                        if ((skladnik1[0] == (prefHelm.Count - 1)) & (TempSkladnik[0] == (prefHelm.Count - 2))) TempWynik[0] = prefHelm.Count - 3; // runiczny + rytualny = szturmowy
                        if ((skladnik1[0] == (prefHelm.Count - 2)) & (TempSkladnik[0] == (prefHelm.Count - 1))) TempWynik[0] = prefHelm.Count - 3;
                        if ((skladnik1[0] == (prefHelm.Count - 3)) & (TempSkladnik[0] == (prefHelm.Count - 1))) TempWynik[0] = prefHelm.Count - 2; // szturmowy + rytualny = runiczny
                        if ((skladnik1[0] == (prefHelm.Count - 1)) & (TempSkladnik[0] == (prefHelm.Count - 3))) TempWynik[0] = prefHelm.Count - 2;
                        if ((skladnik1[1] == (bazaHelm.Count - 1)) & (TempSkladnik[1] == (bazaHelm.Count - 2))) TempWynik[1] = bazaHelm.Count - 3; // bandana + korona = opaska
                        if ((skladnik1[1] == (bazaHelm.Count - 2)) & (TempSkladnik[1] == (bazaHelm.Count - 1))) TempWynik[1] = bazaHelm.Count - 3;
                        if ((skladnik1[1] == (bazaHelm.Count - 3)) & (TempSkladnik[1] == (bazaHelm.Count - 1))) TempWynik[1] = bazaHelm.Count - 2; // opaska + korona = bandana
                        if ((skladnik1[1] == (bazaHelm.Count - 1)) & (TempSkladnik[1] == (bazaHelm.Count - 3))) TempWynik[1] = bazaHelm.Count - 2;
                        if ((skladnik1[2] == (sufHelm.Count - 1)) & (TempSkladnik[2] == (sufHelm.Count - 2))) TempWynik[2] = sufHelm.Count - 3; // magii + mocy = smoczej łuski
                        if ((skladnik1[2] == (sufHelm.Count - 2)) & (TempSkladnik[2] == (sufHelm.Count - 1))) TempWynik[2] = sufHelm.Count - 3;
                        if ((skladnik1[2] == (sufHelm.Count - 3)) & (TempSkladnik[2] == (sufHelm.Count - 1))) TempWynik[2] = sufHelm.Count - 2; // smoczej łuski + magii = mocy
                        if ((skladnik1[2] == (sufHelm.Count - 1)) & (TempSkladnik[2] == (sufHelm.Count - 3))) TempWynik[2] = sufHelm.Count - 2;

                        if (cbHelmPref.Text != "") PrefHelmL.Text = prefHelm.ElementAt(TempWynik[0]);
                        break;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Odsyłacz do mojej postaci
            System.Diagnostics.Process.Start("https://r19.bloodwars.interia.pl/showmsg.php?a=profile&uid=2755");
        }
    }
}