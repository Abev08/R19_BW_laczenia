using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Narzędzie_Blood_Wars___R19
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Spróbuj ustawic protokół zabezpieczeń umożliwiający sprawdzenie aktualizacji
            try { ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; } // TLS - 192, TLS1.1 - 768, TLS1.2 - 3072, TLS1.3 - 12288
            catch { this.Title += "     --> NIE BYŁO MOŻLIWE SPRAWDZENIE AKTUALIZACJI! <--"; }

            ItemType.Items.TrimExcess(); // Lista typów przedmiotów

            BazaHelm = new ItemType(ItemType.Items[0]); // Hełm
            BazaZbroja = new ItemType(ItemType.Items[1]); // Zbroja
            BazaSpodnie = new ItemType(ItemType.Items[2]); // Spodnie
            BazaPierscien = new ItemType(ItemType.Items[3]); // Pierścień
            BazaAmulet = new ItemType(ItemType.Items[4]); // Amulet
            BazaBiala1h = new ItemType(ItemType.Items[5]); // Biała 1h
            BazaBiala2h = new ItemType(ItemType.Items[6]); // Biała 2h
            BazaPalna1h = new ItemType(ItemType.Items[7]); // Palna 1h
            BazaPalna2h = new ItemType(ItemType.Items[8]); // Palna 2h
            BazaDystans = new ItemType(ItemType.Items[9]); // Dystansowa

            byHand = new JoinByHand(); // Obiekt do łączenia ręcznego

            // Dodanie elementów ComboBox'a na stronie łączeń ręcznych
            cbLaczenieReczne.ItemsSource = ItemType.Items;
            cbLaczenieReczne.SelectedIndex = 0;

            // Dodanie elementów ComboBox'ów na stronie analizatora łączeń
            cbAnalizatorLaczenItemType.ItemsSource = ItemType.Items;
            cbAnalizatorLaczenItemType.SelectedIndex = 0;

            // Inicjowanie zmiennych analizatora łączeń
            AnaLaczItems = new List<Item>();
            AnaLaczResults = new List<Item>();
            AnaLaczItemsFiltered = new List<int>();
            AnaLaczWorker = new BackgroundWorker();
            AnaLaczWorker.WorkerSupportsCancellation = true;
            AnaLaczWorker.DoWork += AnaLaczWorker_DoWork;

            // Dodaj obsługę klaiwsza ESC
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);

            // Dodaj poczatkowy tekst do analizatora raportów
            AnalizatorRaportuOblicz_Click(null, null);

            // Obiekt analizatora walki
            BattleResult = new BattleReportAnalyzer.BattleResult();

            Building.Buildings.TrimExcess(); // Lista budynków Placu Budowy
            cbPlacBudowyBudynki.ItemsSource = Building.Buildings;
            cbPlacBudowyBudynki.SelectedIndex = 0;

            // Sprawdzenie aktualizacji
            VersionWorker = new BackgroundWorker();
            VersionWorker.DoWork += VersionWorker_DoWork;
            if (ServicePointManager.SecurityProtocol == (SecurityProtocolType)3072) VersionWorker.RunWorkerAsync();
            
            // Wersja programu (tooltip na labelu "by Abev")
            byMe.ToolTip = "Wersja programu: " + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString() + "\nProszę zgłaszać wszelkie znalezione błędy / sugestie :D";
        }

        const string Version = "Version 3.0"; // Aktuwalna wersja programu, trzeba pamiętać o zmianie :(
        BackgroundWorker VersionWorker;

        TableWindow TableWindow;
        EditWindow EditWindow;
        HelpWindow HelpWindow;
        AboutWindow AboutWindow;

        static ItemType BazaHelm, BazaZbroja, BazaSpodnie, BazaPierscien, BazaAmulet, BazaBiala1h, BazaBiala2h, BazaPalna1h, BazaPalna2h, BazaDystans;
        JoinByHand byHand;

        List<Item> AnaLaczItems, AnaLaczResults;
        BackgroundWorker AnaLaczWorker;
        List<int> AnaLaczItemsFiltered;
        bool DoOnceAnalizator = true;

        BattleReportAnalyzer.BattleResult BattleResult;

        private void VersionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            WebClient conn = new WebClient();
            conn.Headers.Add("User-Agent: Other");
            Stream stream = conn.OpenRead("https://api.github.com/repos/Abev08/R19_BW_laczenia/commits");
            using (StreamReader reader = new StreamReader(stream))
            {
                dynamic commits = JArray.Parse(reader.ReadToEnd());
                string lastCommit = commits[0].commit.message;

                if (lastCommit != null)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        if (MessageBox.Show(this, "Nowa wersja programu dostępna na GitHub'ie!\nAktualnie używana: " + Version + "\nDostępna na GitHub'ie: " + lastCommit + "\n\nCzy chcesz teraz odwiedzić repozytorium?", "Znaleziono nowszą wersję programu!", MessageBoxButton.YesNo, MessageBoxImage.None) == MessageBoxResult.Yes)
                        {
                            Process.Start("https://github.com/Abev08/R19_BW_laczenia");
                        }
                    }));
                }
            }
        }

        private void CbLaczenieReczne_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Zakutualizuj zawartosc ComboBoxow z prefami, bazami i sufami
            if (byHand != null) byHand.Clear(); // Zresetuj łączenie ręczne
            rtbLaczenieReczne.Document.Blocks.Clear();
            rtbLaczenieReczne.ScrollToEnd();

            string selectedItem = ((ComboBox)sender).SelectedItem.ToString();
            if (selectedItem == ItemType.Items[0]) PopulateComboBox(new ComboBox[] { cbLaczenieRecznePref, cbSchowekPref1, cbSchowekPref2, cbSchowekPref3 }, new ComboBox[] { cbLaczenieReczneBaza, cbSchowekBaza1, cbSchowekBaza2, cbSchowekBaza3 }, new ComboBox[] { cbLaczenieReczneSuf, cbSchowekSuf1, cbSchowekSuf2, cbSchowekSuf3 }, BazaHelm);
            else if (selectedItem == ItemType.Items[1]) PopulateComboBox(new ComboBox[] { cbLaczenieRecznePref, cbSchowekPref1, cbSchowekPref2, cbSchowekPref3 }, new ComboBox[] { cbLaczenieReczneBaza, cbSchowekBaza1, cbSchowekBaza2, cbSchowekBaza3 }, new ComboBox[] { cbLaczenieReczneSuf, cbSchowekSuf1, cbSchowekSuf2, cbSchowekSuf3 }, BazaZbroja);
            else if (selectedItem == ItemType.Items[2]) PopulateComboBox(new ComboBox[] { cbLaczenieRecznePref, cbSchowekPref1, cbSchowekPref2, cbSchowekPref3 }, new ComboBox[] { cbLaczenieReczneBaza, cbSchowekBaza1, cbSchowekBaza2, cbSchowekBaza3 }, new ComboBox[] { cbLaczenieReczneSuf, cbSchowekSuf1, cbSchowekSuf2, cbSchowekSuf3 }, BazaSpodnie);
            else if (selectedItem == ItemType.Items[3]) PopulateComboBox(new ComboBox[] { cbLaczenieRecznePref, cbSchowekPref1, cbSchowekPref2, cbSchowekPref3 }, new ComboBox[] { cbLaczenieReczneBaza, cbSchowekBaza1, cbSchowekBaza2, cbSchowekBaza3 }, new ComboBox[] { cbLaczenieReczneSuf, cbSchowekSuf1, cbSchowekSuf2, cbSchowekSuf3 }, BazaPierscien);
            else if (selectedItem == ItemType.Items[4]) PopulateComboBox(new ComboBox[] { cbLaczenieRecznePref, cbSchowekPref1, cbSchowekPref2, cbSchowekPref3 }, new ComboBox[] { cbLaczenieReczneBaza, cbSchowekBaza1, cbSchowekBaza2, cbSchowekBaza3 }, new ComboBox[] { cbLaczenieReczneSuf, cbSchowekSuf1, cbSchowekSuf2, cbSchowekSuf3 }, BazaAmulet);
            else if (selectedItem == ItemType.Items[5]) PopulateComboBox(new ComboBox[] { cbLaczenieRecznePref, cbSchowekPref1, cbSchowekPref2, cbSchowekPref3 }, new ComboBox[] { cbLaczenieReczneBaza, cbSchowekBaza1, cbSchowekBaza2, cbSchowekBaza3 }, new ComboBox[] { cbLaczenieReczneSuf, cbSchowekSuf1, cbSchowekSuf2, cbSchowekSuf3 }, BazaBiala1h);
            else if (selectedItem == ItemType.Items[6]) PopulateComboBox(new ComboBox[] { cbLaczenieRecznePref, cbSchowekPref1, cbSchowekPref2, cbSchowekPref3 }, new ComboBox[] { cbLaczenieReczneBaza, cbSchowekBaza1, cbSchowekBaza2, cbSchowekBaza3 }, new ComboBox[] { cbLaczenieReczneSuf, cbSchowekSuf1, cbSchowekSuf2, cbSchowekSuf3 }, BazaBiala2h);
            else if (selectedItem == ItemType.Items[7]) PopulateComboBox(new ComboBox[] { cbLaczenieRecznePref, cbSchowekPref1, cbSchowekPref2, cbSchowekPref3 }, new ComboBox[] { cbLaczenieReczneBaza, cbSchowekBaza1, cbSchowekBaza2, cbSchowekBaza3 }, new ComboBox[] { cbLaczenieReczneSuf, cbSchowekSuf1, cbSchowekSuf2, cbSchowekSuf3 }, BazaPalna1h);
            else if (selectedItem == ItemType.Items[8]) PopulateComboBox(new ComboBox[] { cbLaczenieRecznePref, cbSchowekPref1, cbSchowekPref2, cbSchowekPref3 }, new ComboBox[] { cbLaczenieReczneBaza, cbSchowekBaza1, cbSchowekBaza2, cbSchowekBaza3 }, new ComboBox[] { cbLaczenieReczneSuf, cbSchowekSuf1, cbSchowekSuf2, cbSchowekSuf3 }, BazaPalna2h);
            else if (selectedItem == ItemType.Items[9]) PopulateComboBox(new ComboBox[] { cbLaczenieRecznePref, cbSchowekPref1, cbSchowekPref2, cbSchowekPref3 }, new ComboBox[] { cbLaczenieReczneBaza, cbSchowekBaza1, cbSchowekBaza2, cbSchowekBaza3 }, new ComboBox[] { cbLaczenieReczneSuf, cbSchowekSuf1, cbSchowekSuf2, cbSchowekSuf3 }, BazaDystans);
            else
            {
                cbLaczenieRecznePref.ItemsSource = null;
                cbSchowekPref1.ItemsSource = null;
                cbSchowekPref2.ItemsSource = null;
                cbSchowekPref3.ItemsSource = null;
                cbLaczenieReczneBaza.ItemsSource = null;
                cbSchowekBaza1.ItemsSource = null;
                cbSchowekBaza2.ItemsSource = null;
                cbSchowekBaza3.ItemsSource = null;
                cbLaczenieReczneSuf.ItemsSource = null;
                cbSchowekSuf1.ItemsSource = null;
                cbSchowekSuf2.ItemsSource = null;
                cbSchowekSuf3.ItemsSource = null;
            }
        }

        private void CbLaczenieReczne_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            // Zmieniono wybrany prefiks / bazę / sufiks przy łaczeniu ręcznym - zaktualizuj potencjalny wynik łaczenia
            UpdateLabelByHand();
        }

        private void UpdateLabelByHand()
        {
            // Zmieniono wybrany prefiks / bazę / sufiks przy łaczeniu ręcznym - zaktualizuj potencjalny wynik łaczenia
            Item i = new Item(cbLaczenieRecznePref.SelectedIndex, cbLaczenieReczneBaza.SelectedIndex, cbLaczenieReczneSuf.SelectedIndex);
            if ((byHand.i1.Sum() == 0) || (i.Sum() == 0))
            {
                labelLaczenieRecznePref.Content = "";
                labelLaczenieReczneBaza.Content = "";
                labelLaczenieReczneSuf.Content = "";
                return;
            }

            string selectedItem = cbLaczenieReczne.SelectedItem.ToString();
            if (selectedItem == ItemType.Items[0]) byHand.UpdateLabel(labelLaczenieRecznePref, labelLaczenieReczneBaza, labelLaczenieReczneSuf, i, BazaHelm, true);
            else if (selectedItem == ItemType.Items[1]) byHand.UpdateLabel(labelLaczenieRecznePref, labelLaczenieReczneBaza, labelLaczenieReczneSuf, i, BazaZbroja);
            else if (selectedItem == ItemType.Items[2]) byHand.UpdateLabel(labelLaczenieRecznePref, labelLaczenieReczneBaza, labelLaczenieReczneSuf, i, BazaSpodnie);
            else if (selectedItem == ItemType.Items[3]) byHand.UpdateLabel(labelLaczenieRecznePref, labelLaczenieReczneBaza, labelLaczenieReczneSuf, i, BazaPierscien);
            else if (selectedItem == ItemType.Items[4]) byHand.UpdateLabel(labelLaczenieRecznePref, labelLaczenieReczneBaza, labelLaczenieReczneSuf, i, BazaAmulet);
            else if (selectedItem == ItemType.Items[5]) byHand.UpdateLabel(labelLaczenieRecznePref, labelLaczenieReczneBaza, labelLaczenieReczneSuf, i, BazaBiala1h);
            else if (selectedItem == ItemType.Items[6]) byHand.UpdateLabel(labelLaczenieRecznePref, labelLaczenieReczneBaza, labelLaczenieReczneSuf, i, BazaBiala2h);
            else if (selectedItem == ItemType.Items[7]) byHand.UpdateLabel(labelLaczenieRecznePref, labelLaczenieReczneBaza, labelLaczenieReczneSuf, i, BazaPalna1h);
            else if (selectedItem == ItemType.Items[8]) byHand.UpdateLabel(labelLaczenieRecznePref, labelLaczenieReczneBaza, labelLaczenieReczneSuf, i, BazaPalna2h);
            else if (selectedItem == ItemType.Items[9]) byHand.UpdateLabel(labelLaczenieRecznePref, labelLaczenieReczneBaza, labelLaczenieReczneSuf, i, BazaDystans);
        }

        private void PopulateComboBox(ComboBox cbP, ComboBox cbB, ComboBox cbS, ItemType it)
        {
            if (it == null) return;

            // Ustawia listy ComboBox'ów i resetuje wybrany element
            if ((cbP != null) && (it.pref != null))
            {
                cbP.ItemsSource = it.pref;
                cbP.SelectedIndex = 0;
            }
            if ((cbB != null) && (it.baza != null))
            {
                cbB.ItemsSource = it.baza;
                cbB.SelectedIndex = 0;
            }
            if ((cbS != null) && (it.suf != null))
            {
                cbS.ItemsSource = it.suf;
                cbS.SelectedIndex = 0;
            }
        }

        private void PopulateComboBox(ComboBox[] cbP, ComboBox[] cbB, ComboBox[] cbS, ItemType it)
        {
            if (it == null) return;

            // Ustawia listy ComboBox'ów i resetuje wybrany element (działa dla tablic ComboBox'ów)
            foreach (ComboBox cb in cbP)
            {
                cb.ItemsSource = it.pref;
                cb.SelectedIndex = 0;
            }
            foreach (ComboBox cb in cbB)
            {
                cb.ItemsSource = it.baza;
                cb.SelectedIndex = 0;
            }
            foreach (ComboBox cb in cbS)
            {
                cb.ItemsSource = it.suf;
                cb.SelectedIndex = 0;
            }
        }

        private void RtbAnalizatorLaczen_GotFocus(object sender, RoutedEventArgs e)
        {
            // Usuń "startowy" tekst w okienku analizatora łączeń po kliknięciu w nie
            if (DoOnceAnalizator == false) return;
            string txt = new TextRange(rtbAnalizatorLaczen.Document.ContentStart, rtbAnalizatorLaczen.Document.ContentEnd).Text;
            if (txt.Contains("Wklej tutaj listę przedmiotów do łączenia.")) rtbAnalizatorLaczen.Document.Blocks.Clear();
            DoOnceAnalizator = false;
        }

        private void Polacz_Click(object sender, RoutedEventArgs e)
        {
            /// Funkcja do łączenia przedmiotów przy łączeniu ręcznym
            // Opuść funkcję jeżeli nie wybrano żadnego prefiksu / bazy / sufiksu
            if (cbLaczenieRecznePref.SelectedIndex + cbLaczenieReczneBaza.SelectedIndex + cbLaczenieReczneSuf.SelectedIndex == 0) return;

            if (byHand.i1.Sum() == 0)
            {
                byHand.i1 = new Item(cbLaczenieRecznePref.SelectedIndex, cbLaczenieReczneBaza.SelectedIndex, cbLaczenieReczneSuf.SelectedIndex);
                if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[0]) byHand.historyJoin.Add(byHand.i1.ToString(BazaHelm));
                else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[1]) byHand.historyJoin.Add(byHand.i1.ToString(BazaZbroja));
                else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[2]) byHand.historyJoin.Add(byHand.i1.ToString(BazaSpodnie));
                else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[3]) byHand.historyJoin.Add(byHand.i1.ToString(BazaPierscien));
                else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[4]) byHand.historyJoin.Add(byHand.i1.ToString(BazaAmulet));
                else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[5]) byHand.historyJoin.Add(byHand.i1.ToString(BazaBiala1h));
                else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[6]) byHand.historyJoin.Add(byHand.i1.ToString(BazaBiala2h));
                else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[7]) byHand.historyJoin.Add(byHand.i1.ToString(BazaPalna1h));
                else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[8]) byHand.historyJoin.Add(byHand.i1.ToString(BazaPalna2h));
                else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[9]) byHand.historyJoin.Add(byHand.i1.ToString(BazaDystans));

                byHand.historyItem.Add(new Item(byHand.i1)); // Dodaj przedmiot do historii przedmiotów
            }
            else
            {
                byHand.i2 = new Item(cbLaczenieRecznePref.SelectedIndex, cbLaczenieReczneBaza.SelectedIndex, cbLaczenieReczneSuf.SelectedIndex);
                byHand.historyItem.Add(new Item(byHand.i2)); // Dodaj przedmiot do historii przedmiotów

                if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[0]) byHand.Polacz(BazaHelm, true);
                else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[1]) byHand.Polacz(BazaZbroja);
                else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[2]) byHand.Polacz(BazaSpodnie);
                else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[3]) byHand.Polacz(BazaPierscien);
                else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[4]) byHand.Polacz(BazaAmulet);
                else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[5]) byHand.Polacz(BazaBiala1h);
                else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[6]) byHand.Polacz(BazaBiala2h);
                else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[7]) byHand.Polacz(BazaPalna1h);
                else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[8]) byHand.Polacz(BazaPalna2h);
                else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[9]) byHand.Polacz(BazaDystans);

                byHand.historyItem.Add(new Item(byHand.i1)); // Dodaj wynik łączenia do historii przedmiotów
            }

            // Zaktualizuj wyświetlane połączenia
            rtbLaczenieReczne.Document.Blocks.Clear();
            foreach (string s in byHand.historyJoin) rtbLaczenieReczne.AppendText(s);
            rtbLaczenieReczne.ScrollToEnd();

            UpdateLabelByHand(); // Zaktualizuj potencjalny wynik łączenia
        }

        private void Cofnij_Click(object sender, RoutedEventArgs e)
        {
            /// Funkcja "wróć" przy łączeniu ręcznym
            if (byHand.historyJoin.Count > 0)
            {
                // Usuń ostatnie łączenie i zaktualizuj tekst
                byHand.historyJoin.RemoveAt(byHand.historyJoin.Count - 1);

                // Usuń drugi składnik i wynik łączenia
                if (byHand.historyItem.Count > 0) byHand.historyItem.RemoveAt(byHand.historyItem.Count - 1);
                if (byHand.historyItem.Count > 0) byHand.historyItem.RemoveAt(byHand.historyItem.Count - 1);

                // Przywróć wynik poprzedniego łączenia jako pierwszy składnik, wyczyść drugi składnik
                if (byHand.historyItem.Count > 0) byHand.i1 = byHand.historyItem[byHand.historyItem.Count - 1];
                else byHand.i1 = new Item();
                byHand.i2 = new Item();

                // Zaktualizuj tekst łączenia
                rtbLaczenieReczne.Document.Blocks.Clear();
                foreach (string s in byHand.historyJoin) rtbLaczenieReczne.AppendText(s);
                rtbLaczenieReczne.ScrollToEnd();

                UpdateLabelByHand(); // Zaktualizuj potencjalny wynik łączenia
            }
        }

        private void MouseEnterFocus(object sender, MouseEventArgs e)
        {
            /// Ustawia focus na kontrolce przy najechaniu na nią myszką
            if (this.IsActive == false) return;
            ((ComboBox)sender).Focus();
        }

        private void ChkBAnalizatorLaczenDodatkowe_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (((CheckBox)sender).IsChecked == true) chkBAnalizatorLaczenMieszane.IsEnabled = true;
            else
            {
                chkBAnalizatorLaczenMieszane.IsEnabled = false;
                chkBAnalizatorLaczenMieszane.IsChecked = false;
            }
        }

        private void TablePrefClick(object sender, RoutedEventArgs e)
        {
            /// Funkcja wywołująca otwarcie tabeli łaczeń w zależności od wybranych elementów w comboBoxach (do tablic łączeń prefiksów)
            if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[0]) InitializeTableWindow(ItemType.Items[0] + " Pref", BazaHelm.pref);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[1]) InitializeTableWindow(ItemType.Items[1] + " Pref", BazaZbroja.pref);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[2]) InitializeTableWindow(ItemType.Items[2] + " Pref", BazaSpodnie.pref);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[3]) InitializeTableWindow(ItemType.Items[3] + " Pref", BazaPierscien.pref);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[4]) InitializeTableWindow(ItemType.Items[4] + " Pref", BazaAmulet.pref);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[5]) InitializeTableWindow(ItemType.Items[5] + " Pref", BazaBiala1h.pref);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[6]) InitializeTableWindow(ItemType.Items[6] + " Pref", BazaBiala2h.pref);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[7]) InitializeTableWindow(ItemType.Items[7] + " Pref", BazaPalna1h.pref);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[8]) InitializeTableWindow(ItemType.Items[8] + " Pref", BazaPalna2h.pref);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[9]) InitializeTableWindow(ItemType.Items[9] + " Pref", BazaDystans.pref);
        }

        private void TableBazaClick(object sender, RoutedEventArgs e)
        {
            /// Funkcja wywołująca otwarcie tabeli łaczeń w zależności od wybranych elementów w comboBoxach (do tablic łączeń baz)
            if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[0]) InitializeTableWindow(ItemType.Items[0] + " Baza", BazaHelm.baza, true);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[1]) InitializeTableWindow(ItemType.Items[1] + " Baza", BazaZbroja.baza);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[2]) InitializeTableWindow(ItemType.Items[2] + " Baza", BazaSpodnie.baza);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[3]) InitializeTableWindow(ItemType.Items[3] + " Baza", BazaPierscien.baza);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[4]) InitializeTableWindow(ItemType.Items[4] + " Baza", BazaAmulet.baza);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[5]) InitializeTableWindow(ItemType.Items[5] + " Baza", BazaBiala1h.baza);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[6]) InitializeTableWindow(ItemType.Items[6] + " Baza", BazaBiala2h.baza);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[7]) InitializeTableWindow(ItemType.Items[7] + " Baza", BazaPalna1h.baza);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[8]) InitializeTableWindow(ItemType.Items[8] + " Baza", BazaPalna2h.baza);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[9]) InitializeTableWindow(ItemType.Items[9] + " Baza", BazaDystans.baza);
        }

        private void TableSufClick(object sender, RoutedEventArgs e)
        {
            /// Funkcja wywołująca otwarcie tabeli łaczeń w zależności od wybranych elementów w comboBoxach (do tablic łączeń sufiksów)
            if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[0]) InitializeTableWindow(ItemType.Items[0] + " Suf", BazaHelm.suf);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[1]) InitializeTableWindow(ItemType.Items[1] + " Suf", BazaZbroja.suf);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[2]) InitializeTableWindow(ItemType.Items[2] + " Suf", BazaSpodnie.suf);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[3]) InitializeTableWindow(ItemType.Items[3] + " Suf", BazaPierscien.suf);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[4]) InitializeTableWindow(ItemType.Items[4] + " Suf", BazaAmulet.suf);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[5]) InitializeTableWindow(ItemType.Items[5] + " Suf", BazaBiala1h.suf);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[6]) InitializeTableWindow(ItemType.Items[6] + " Suf", BazaBiala2h.suf);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[7]) InitializeTableWindow(ItemType.Items[7] + " Suf", BazaPalna1h.suf);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[8]) InitializeTableWindow(ItemType.Items[8] + " Suf", BazaPalna2h.suf);
            else if (cbLaczenieReczne.SelectedItem.ToString() == ItemType.Items[9]) InitializeTableWindow(ItemType.Items[9] + " Suf", BazaDystans.suf);
        }

        private void InitializeTableWindow(string s, List<string> ls, bool helmetException = false)
        {
            /// Funkcja obsługi okienka tablic łączeń
            if (TableWindow == null || TableWindow.IsOpen == false) TableWindow = new TableWindow();
            TableWindow.AddTab(s, ls, helmetException);
            if (TableWindow.IsVisible == false) TableWindow.Show();
            if (TableWindow.WindowState == WindowState.Minimized) TableWindow.WindowState = WindowState.Normal;
            TableWindow.Activate();
        }

        private void CbAnalizatorLaczenItemType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /// Zakutualizuj zawartosc ComboBoxow z prefami, bazami i sufami w analizatorze łaczeń
            string selectedItem = ((ComboBox)sender).SelectedItem.ToString();
            if (selectedItem == ItemType.Items[0]) PopulateComboBox(new ComboBox[] { cbAnalizatorLaczenPoszukiwanyPref, cbAnalizatorLaczenFiltrPref }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanyBaza, cbAnalizatorLaczenFiltrBaza }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanySuf, cbAnalizatorLaczenFiltrSuf }, BazaHelm);
            else if (selectedItem == ItemType.Items[1]) PopulateComboBox(new ComboBox[] { cbAnalizatorLaczenPoszukiwanyPref, cbAnalizatorLaczenFiltrPref }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanyBaza, cbAnalizatorLaczenFiltrBaza }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanySuf, cbAnalizatorLaczenFiltrSuf }, BazaZbroja);
            else if (selectedItem == ItemType.Items[2]) PopulateComboBox(new ComboBox[] { cbAnalizatorLaczenPoszukiwanyPref, cbAnalizatorLaczenFiltrPref }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanyBaza, cbAnalizatorLaczenFiltrBaza }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanySuf, cbAnalizatorLaczenFiltrSuf }, BazaSpodnie);
            else if (selectedItem == ItemType.Items[3]) PopulateComboBox(new ComboBox[] { cbAnalizatorLaczenPoszukiwanyPref, cbAnalizatorLaczenFiltrPref }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanyBaza, cbAnalizatorLaczenFiltrBaza }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanySuf, cbAnalizatorLaczenFiltrSuf }, BazaPierscien);
            else if (selectedItem == ItemType.Items[4]) PopulateComboBox(new ComboBox[] { cbAnalizatorLaczenPoszukiwanyPref, cbAnalizatorLaczenFiltrPref }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanyBaza, cbAnalizatorLaczenFiltrBaza }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanySuf, cbAnalizatorLaczenFiltrSuf }, BazaAmulet);
            else if (selectedItem == ItemType.Items[5]) PopulateComboBox(new ComboBox[] { cbAnalizatorLaczenPoszukiwanyPref, cbAnalizatorLaczenFiltrPref }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanyBaza, cbAnalizatorLaczenFiltrBaza }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanySuf, cbAnalizatorLaczenFiltrSuf }, BazaBiala1h);
            else if (selectedItem == ItemType.Items[6]) PopulateComboBox(new ComboBox[] { cbAnalizatorLaczenPoszukiwanyPref, cbAnalizatorLaczenFiltrPref }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanyBaza, cbAnalizatorLaczenFiltrBaza }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanySuf, cbAnalizatorLaczenFiltrSuf }, BazaBiala2h);
            else if (selectedItem == ItemType.Items[7]) PopulateComboBox(new ComboBox[] { cbAnalizatorLaczenPoszukiwanyPref, cbAnalizatorLaczenFiltrPref }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanyBaza, cbAnalizatorLaczenFiltrBaza }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanySuf, cbAnalizatorLaczenFiltrSuf }, BazaPalna1h);
            else if (selectedItem == ItemType.Items[8]) PopulateComboBox(new ComboBox[] { cbAnalizatorLaczenPoszukiwanyPref, cbAnalizatorLaczenFiltrPref }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanyBaza, cbAnalizatorLaczenFiltrBaza }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanySuf, cbAnalizatorLaczenFiltrSuf }, BazaPalna2h);
            else if (selectedItem == ItemType.Items[9]) PopulateComboBox(new ComboBox[] { cbAnalizatorLaczenPoszukiwanyPref, cbAnalizatorLaczenFiltrPref }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanyBaza, cbAnalizatorLaczenFiltrBaza }, new ComboBox[] { cbAnalizatorLaczenPoszukiwanySuf, cbAnalizatorLaczenFiltrSuf }, BazaDystans);
            else
            {
                cbAnalizatorLaczenPoszukiwanyPref.ItemsSource = null;
                cbAnalizatorLaczenPoszukiwanyBaza.ItemsSource = null;
                cbAnalizatorLaczenPoszukiwanySuf.ItemsSource = null;
                cbAnalizatorLaczenFiltrPref.ItemsSource = null;
                cbAnalizatorLaczenFiltrBaza.ItemsSource = null;
                cbAnalizatorLaczenFiltrSuf.ItemsSource = null;
            }
        }

        private void ZalPrzedAnalizatorLaczen_Click(object sender, RoutedEventArgs e)
        {
            cbAnalizatorLaczenZalPrzed.Items.Clear(); // Wyczyść comboBox'a z listą załadowanych przedmiotów
            cbAnalizatorLaczenPolPrzed.ItemsSource = null; // Wyczyść przefiltrowane przedmioty
            cbAnalizatorLaczenPolPrzed.IsEnabled = false; // Wyłącz listę przefiltrowanych wyników
            laAnalizatorLaczenZnalPol.Content = " "; // Wyczyśc ilość znalezionych połączeń
            tbAnalizatorLaczenIloscLacz.IsEnabled = false; // Wyłącz okienko z ilością sprawdzanych łączeń 
            btnAnalizatorLaczenAktuFiltr.IsEnabled = false; // Wyłącz przycisk aktualizacji filtra
            cbAnalizatorLaczenFiltrPref.IsEnabled = false; // Wyłącz okienka filtra
            cbAnalizatorLaczenFiltrBaza.IsEnabled = false;
            cbAnalizatorLaczenFiltrSuf.IsEnabled = false;
            chkBAnalizatorLaczenDodatkowe.IsEnabled = false;
            chkBAnalizatorLaczenDodatkowe.IsChecked = false; // Odznacz dodatkowe łączenia
            chkBAnalizatorLaczenMieszane.IsEnabled = false;
            chkBAnalizatorLaczenMieszane.IsChecked = false; // Odznacz mieszane łączenia
            chkBAnalizatorLaczenWyswietl.IsEnabled = false; // Wyłącz checkBox "Wyświetl mimio wszystko"
            chkBAnalizatorLaczenWyswietl.IsChecked = false; // Odznacz checkBox "Wyświetl mimio wszystko"
            btnAnalizatorLaczenEdytuj.IsEnabled = false; // Wyłącz przyciski "Edytuj przedmioty" i "Sortuj przedmioty"
            btnAnalizatorLaczenSortuj.IsEnabled = false;

            // Wyczyść listę załadowanych przedmiotów
            AnaLaczItems.Clear();
            AnaLaczItems.TrimExcess();

            // Załaduj przedmioty
            string selectedItem = cbAnalizatorLaczenItemType.SelectedItem.ToString();
            if (selectedItem == ItemType.Items[0]) Zaladuj(BazaHelm);
            else if (selectedItem == ItemType.Items[1]) Zaladuj(BazaZbroja);
            else if (selectedItem == ItemType.Items[2]) Zaladuj(BazaSpodnie);
            else if (selectedItem == ItemType.Items[3]) Zaladuj(BazaPierscien);
            else if (selectedItem == ItemType.Items[4]) Zaladuj(BazaAmulet);
            else if (selectedItem == ItemType.Items[5]) Zaladuj(BazaBiala1h);
            else if (selectedItem == ItemType.Items[6]) Zaladuj(BazaBiala2h);
            else if (selectedItem == ItemType.Items[7]) Zaladuj(BazaPalna1h);
            else if (selectedItem == ItemType.Items[8]) Zaladuj(BazaPalna2h);
            else if (selectedItem == ItemType.Items[9]) Zaladuj(BazaDystans);

            AnaLaczItems.TrimExcess();

            // W zależności od ilości załadowanych przedmiotów wyświetl poprawną (słownie) ilość
            if (AnaLaczItems.Count == 1) lbAnalizatorLaczenZalPrzed.Content = "Załadowano " + AnaLaczItems.Count + " przedmiot:";
            if (AnaLaczItems.Count > 1 && AnaLaczItems.Count < 5) lbAnalizatorLaczenZalPrzed.Content = "Załadowano " + AnaLaczItems.Count + " przedmioty:";
            if (AnaLaczItems.Count >= 5 || AnaLaczItems.Count == 0) lbAnalizatorLaczenZalPrzed.Content = "Załadowano " + AnaLaczItems.Count + " przedmiotów:";
            btnAnalizatorLaczenEdytuj.IsEnabled = true; // Włącz przycisk "Edytuj przedmioty"
            // Jeżeli załadowano przynajmniej 1 przedmiot włącz przycisk "Sortuj przedmioty"
            if (AnaLaczItems.Count > 0)
            {
                cbAnalizatorLaczenZalPrzed.SelectedIndex = 0;
                btnAnalizatorLaczenSortuj.IsEnabled = true;
            }
            // Jeżeli załadowano przynajmniej 2 przedmioty włącz przyciski "Analizuj połączenia" i checkBox'y "Dodatkowe łączenia" i "Mieszane łączenia"
            if (AnaLaczItems.Count > 1)
            {
                btnAnalizatorLaczenAnalizuj.IsEnabled = true;
                chkBAnalizatorLaczenDodatkowe.IsEnabled = true;
                chkBAnalizatorLaczenMieszane.IsChecked = false;
                if (AnaLaczItems.Count < 8) tbAnalizatorLaczenIloscLacz.Value = AnaLaczItems.Count - 1; // Jeżeli załadowano poniżej 8 przedmiotów ustaw ilość łączeń na ilość przedmiotów
                else tbAnalizatorLaczenIloscLacz.Value = 1; // Jeżeli załadowano więcej przedmiotów ustaw wartość początkową równą 1
                tbAnalizatorLaczenIloscLacz.IsEnabled = true; // Aktywuj kontrolkę
            }
            if (AnaLaczItems.Count < 2)
            {
                // Jeżeli załadowano mniej niż 2 przedmioty wyłącz przycisk "Analizuj połączenia" oraz checkBox dodatkoweLaczenia i ustaw ilość łączeń na 1
                btnAnalizatorLaczenAnalizuj.IsEnabled = false;
                chkBAnalizatorLaczenDodatkowe.IsEnabled = false;
                chkBAnalizatorLaczenDodatkowe.IsChecked = false;
                chkBAnalizatorLaczenMieszane.IsChecked = false;
                tbAnalizatorLaczenIloscLacz.Value = 1;
            }
        }

        private void Zaladuj(ItemType TypPrzedmiotu)
        {
            /// Funkcja ładująca przedmioty - identyfikuje przedmioty z ciągu znaków
            string[] linie = (new TextRange(rtbAnalizatorLaczen.Document.ContentStart, rtbAnalizatorLaczen.Document.ContentEnd).Text).Split('\n', '\r'); // Podziel wklejony tekst na linie
            Item item; // Identyfikowany przedmiot

            foreach (string line in linie)
            {
                item = new Item();
                string linia = line;

                for (int i = 1; i < TypPrzedmiotu.suf.Count; i++)
                {
                    if (linia.Contains(TypPrzedmiotu.suf[i]))
                    {
                        linia = linia.Remove(linia.IndexOf(TypPrzedmiotu.suf[i]), TypPrzedmiotu.suf[i].Length);
                        item.suf = i;
                        break;
                    }
                }
                for (int i = TypPrzedmiotu.baza.Count - 1; i >= 1; i--)
                {
                    if (linia.Contains(TypPrzedmiotu.baza[i]))
                    {
                        linia = linia.Remove(linia.IndexOf(TypPrzedmiotu.baza[i]), TypPrzedmiotu.baza[i].Length);
                        item.baza = i;
                        break;
                    }
                }
                for (int i = 1; i < TypPrzedmiotu.pref.Count; i++)
                {
                    if (TypPrzedmiotu.baza[item.baza] == "Spódnica")
                    {
                        // Wyjątek do sprawdzania prefiksów przy bazie "Spódnica"
                        if (linia.Contains(TypPrzedmiotu.pref[i].Remove(TypPrzedmiotu.pref[i].Length - 2, 2)))
                        {
                            linia = linia.Remove(linia.IndexOf(TypPrzedmiotu.pref[i].Remove(TypPrzedmiotu.pref[i].Length - 2, 2)), TypPrzedmiotu.pref[i].Length);
                            item.pref = i;
                            break;
                        }
                    }
                    else
                    {
                        if (linia.Contains(TypPrzedmiotu.pref[i].Remove(TypPrzedmiotu.pref[i].Length - 1, 1)))
                        {
                            linia = linia.Remove(linia.IndexOf(TypPrzedmiotu.pref[i].Remove(TypPrzedmiotu.pref[i].Length - 1, 1)), TypPrzedmiotu.pref[i].Length);
                            item.pref = i;
                            break;
                        }
                    }
                }

                if (item.Sum() > 0)
                {
                    AnaLaczItems.Add(item);
                    cbAnalizatorLaczenZalPrzed.Items.Add(item.ToString(TypPrzedmiotu));
                }
            }
            AnaLaczItems.TrimExcess();
        }

        private void SortujPrzedmioty_Click(object sender, RoutedEventArgs e)
        {
            /// Funkcja do sortowania załadowanych przedmiotów
            rtbAnalizatorLaczen.Document.Blocks.Clear();
            AnaLaczItems = AnaLaczItems.OrderBy(y => y.pref).ThenBy(z => z.baza).ThenBy(k => k.suf).ToList();

            string selectedItem = cbAnalizatorLaczenItemType.SelectedItem.ToString();
            if (selectedItem == ItemType.Items[0]) foreach (Item i in AnaLaczItems) rtbAnalizatorLaczen.AppendText(i.ToString(BazaHelm) + '\r');
            else if (selectedItem == ItemType.Items[1]) foreach (Item i in AnaLaczItems) rtbAnalizatorLaczen.AppendText(i.ToString(BazaZbroja) + '\r');
            else if (selectedItem == ItemType.Items[2]) foreach (Item i in AnaLaczItems) rtbAnalizatorLaczen.AppendText(i.ToString(BazaSpodnie) + '\r');
            else if (selectedItem == ItemType.Items[3]) foreach (Item i in AnaLaczItems) rtbAnalizatorLaczen.AppendText(i.ToString(BazaPierscien) + '\r');
            else if (selectedItem == ItemType.Items[4]) foreach (Item i in AnaLaczItems) rtbAnalizatorLaczen.AppendText(i.ToString(BazaAmulet) + '\r');
            else if (selectedItem == ItemType.Items[5]) foreach (Item i in AnaLaczItems) rtbAnalizatorLaczen.AppendText(i.ToString(BazaBiala1h) + '\r');
            else if (selectedItem == ItemType.Items[6]) foreach (Item i in AnaLaczItems) rtbAnalizatorLaczen.AppendText(i.ToString(BazaBiala2h) + '\r');
            else if (selectedItem == ItemType.Items[7]) foreach (Item i in AnaLaczItems) rtbAnalizatorLaczen.AppendText(i.ToString(BazaPalna1h) + '\r');
            else if (selectedItem == ItemType.Items[8]) foreach (Item i in AnaLaczItems) rtbAnalizatorLaczen.AppendText(i.ToString(BazaPalna2h) + '\r');
            else if (selectedItem == ItemType.Items[9]) foreach (Item i in AnaLaczItems) rtbAnalizatorLaczen.AppendText(i.ToString(BazaDystans) + '\r');

            rtbAnalizatorLaczen.ScrollToEnd();
        }

        private void BtnAnalizatorLaczenAnalizuj_Click(object sender, RoutedEventArgs e)
        {
            /// Kliknięto przycisk "Analizuj połączenia"
            btnAnalizatorLaczenAnalizuj.IsEnabled = false; // Na czas analizy wyłącz przycisk "Analizuj połączenia" i zmień jego tekst na "Analizuję..."
            btnAnalizatorLaczenAnalizuj.Content = "Analizuję...";
            tbAnalizatorLaczenIloscLacz.IsEnabled = false; // Na czas analizy wyłącz okienko z zadeklarowaną ilością łączeń
            chkBAnalizatorLaczenDodatkowe.IsEnabled = false; // Na czas analizy wyłącz checkBox'y dodatkoweLaczenia i mieszaneLaczenia
            chkBAnalizatorLaczenMieszane.IsEnabled = false;
            btnAnalizatorLaczenZaladuj.IsEnabled = false; // Na czas analizy wyłącz przycisk "Załaduj Przedmioty", "Edytuj Przedmioty" i "Sortuj Przedmioty"
            btnAnalizatorLaczenEdytuj.IsEnabled = false;
            btnAnalizatorLaczenSortuj.IsEnabled = false;
            cbAnalizatorLaczenItemType.IsEnabled = false; // Na czas analizy wyłącz comboBox z wyborem typu łączonego przedmiotu i comboBox'y z wyborem prefu / bazy / sufu poszukiwanego przedmiotu
            cbAnalizatorLaczenPoszukiwanyPref.IsEnabled = false;
            cbAnalizatorLaczenPoszukiwanyBaza.IsEnabled = false;
            cbAnalizatorLaczenPoszukiwanySuf.IsEnabled = false;
            btnAnalizatorLaczenAktuFiltr.IsEnabled = false; // Wyłącz przycisk "Aktualizuj filtr" i wyczyść wyświetlane wyniki łączeń
            cbAnalizatorLaczenPolPrzed.ItemsSource = null;
            // Wyłącz i odznacz checkBox "Wyświetl mimio wszystko"
            chkBAnalizatorLaczenWyswietl.IsEnabled = false;
            chkBAnalizatorLaczenWyswietl.IsChecked = false;
            // Wyczyść wyniki łączeń
            AnaLaczResults.Clear();
            AnaLaczResults.TrimExcess();

            // Lista z listami prefiksów, baz i sufiksów wysyłana do backgroundWorker'a
            string selectedItem = cbAnalizatorLaczenItemType.SelectedItem.ToString();
            if (selectedItem == ItemType.Items[0]) AnaLaczWorker.RunWorkerAsync(BazaHelm);
            else if (selectedItem == ItemType.Items[1]) AnaLaczWorker.RunWorkerAsync(BazaZbroja);
            else if (selectedItem == ItemType.Items[2]) AnaLaczWorker.RunWorkerAsync(BazaSpodnie);
            else if (selectedItem == ItemType.Items[3]) AnaLaczWorker.RunWorkerAsync(BazaPierscien);
            else if (selectedItem == ItemType.Items[4]) AnaLaczWorker.RunWorkerAsync(BazaAmulet);
            else if (selectedItem == ItemType.Items[5]) AnaLaczWorker.RunWorkerAsync(BazaBiala1h);
            else if (selectedItem == ItemType.Items[6]) AnaLaczWorker.RunWorkerAsync(BazaBiala2h);
            else if (selectedItem == ItemType.Items[7]) AnaLaczWorker.RunWorkerAsync(BazaPalna1h);
            else if (selectedItem == ItemType.Items[8]) AnaLaczWorker.RunWorkerAsync(BazaPalna2h);
            else if (selectedItem == ItemType.Items[9]) AnaLaczWorker.RunWorkerAsync(BazaDystans);
        }

        private void AnaLaczWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            /// Wątek do analizowania połączeń przedmiotów w analizatorze łączeń
            ItemType arg = (ItemType)e.Argument; // Potraktuj otrzymany argument jako lista list prefiksów, baz i sufiksów
            AnalizujPolaczenia(arg); // Wywołaj analizator połączeń

            // Po skończonej analizie zaktualizuj tekst przycisku i włącz kontrolki wyłączone na czas analizy
            this.Dispatcher.Invoke(new Action(() =>
            {
                if (AnaLaczItems.Count >= 2) tbAnalizatorLaczenIloscLacz.IsEnabled = true; // Aktywuj kontrolkę ilości szukanych połączeń
                btnAnalizatorLaczenAnalizuj.Content = "Analizuj połączenia"; // Aktywuj przycisk "Analizuj połączenia"
                btnAnalizatorLaczenAnalizuj.IsEnabled = true;
                chkBAnalizatorLaczenDodatkowe.IsEnabled = true; // Aktywuj kontrolki "łączenia dodatkowe" i "łączenia mieszane"
                if (chkBAnalizatorLaczenDodatkowe.IsChecked == true) chkBAnalizatorLaczenMieszane.IsEnabled = true;
                btnAnalizatorLaczenZaladuj.IsEnabled = true; // Aktywuj przyciski "Załaduj przedmioty", "Edytuj przedmioty", "Sortuj przedmioty"
                btnAnalizatorLaczenEdytuj.IsEnabled = true;
                btnAnalizatorLaczenSortuj.IsEnabled = true;
                cbAnalizatorLaczenItemType.IsEnabled = true; // Aktywuj kontrolkę typu łączonego przedmiotu
                cbAnalizatorLaczenPoszukiwanyPref.IsEnabled = true; // Aktywuj kontrolki wyboru szukanego przedmiotu
                cbAnalizatorLaczenPoszukiwanyBaza.IsEnabled = true;
                cbAnalizatorLaczenPoszukiwanySuf.IsEnabled = true;
                btnAnalizatorLaczenAktuFiltr.IsEnabled = true; // Aktywuj kontrolki filtra
                chkBAnalizatorLaczenWyswietl.IsEnabled = true;
                cbAnalizatorLaczenFiltrPref.IsEnabled = true;
                cbAnalizatorLaczenFiltrBaza.IsEnabled = true;
                cbAnalizatorLaczenFiltrSuf.IsEnabled = true;
            }));
        }

        private void AnalizujPolaczenia(ItemType TypPrzedmiotu)
        {
            /// Główna funkcja analizatora połączeń sprawdzająca pierwsze połączenie
            Stopwatch sw = new Stopwatch(); // Stoper do mierzenia czasu analizy
            sw.Start();

            List<int> indeksy = new List<int>(); // Lista wykorzystanych indeksów przedmiotów
            Item wynik = new Item(); // Zmienna do przechowywania wyniku łączenia
            int iloscPrzedmiotów = AnaLaczItems.Count; // Zmienna do przechowywania ilości łączonych przedmiotów
            int iloscLacz = 1; // Początkowa ilość łączeń = 1
            int maxIloscLaczen = 0;
            Item szukanyItem = new Item(); // Szukasz konkretnego przedmiotu?
            bool dodatkoweLaczenia = false;
            bool mieszaneLaczenia = false;
            this.Dispatcher.Invoke(new Action(() =>
            {
                maxIloscLaczen = tbAnalizatorLaczenIloscLacz.Value; // Maksymalna ilość łączeń odczytana z kontrolki do ustawiania ilości łączeń
                szukanyItem = new Item(cbAnalizatorLaczenPoszukiwanyPref.SelectedIndex, cbAnalizatorLaczenPoszukiwanyBaza.SelectedIndex, cbAnalizatorLaczenPoszukiwanySuf.SelectedIndex);
                dodatkoweLaczenia = (bool)chkBAnalizatorLaczenDodatkowe.IsChecked;
                mieszaneLaczenia = (bool)chkBAnalizatorLaczenMieszane.IsChecked;
            }));
            bool helmetException = TypPrzedmiotu.baza == BazaHelm.baza; // Sprawdź czy łączone są bazy hełmów

            for (int sk1 = 0; sk1 < iloscPrzedmiotów; sk1++)
            {
                // Wyczyść listę wykorzystanych indeksów oraz dodaj aktualnie wykorzystywany indeks
                indeksy.Clear();
                indeksy.TrimExcess();
                indeksy.Add(sk1);

                // Zaktualizuj procentowy postęp analizy połączeń
                this.Dispatcher.Invoke(new Action(() =>
                {
                    laAnalizatorLaczenZnalPol.Content = "Znaleziono " + Math.Ceiling(((double)sk1 / ((double)iloscPrzedmiotów)) * 100d) + "% połączeń.";
                }));

                // Rozpocznij drugą pętlę od następnego przedmiotu
                for (int sk2 = sk1 + 1; sk2 < iloscPrzedmiotów; sk2++)
                {
                    // Dodaj wykorzystany "indeks" przedmiotu z listy
                    indeksy.Add(sk2);
                    
                    // Połącz składniki, dodaj historię łączenia oraz zwiększ ilość łączeń wyniku o 1, uwzględnij wyjątek przy łączeniu baz hełmów
                    wynik = new Item(AnaLaczItems[sk1].Polacz(AnaLaczItems[sk2], TypPrzedmiotu, helmetException));

                    // Dodaj historię łączenia
                    wynik.history.Add(new int[] { AnaLaczItems[sk1].pref, AnaLaczItems[sk1].baza, AnaLaczItems[sk1].suf, 0 });
                    wynik.history.Add(new int[] { AnaLaczItems[sk2].pref, AnaLaczItems[sk2].baza, AnaLaczItems[sk2].suf, -1 });
                    wynik.history.Add(new int[] { wynik.pref, wynik.baza, wynik.suf, -2 });
                    wynik.history.TrimExcess();
                    wynik.jointsNumber += 1;

                    if ((wynik.pref == szukanyItem.pref || szukanyItem.pref == 0) && (wynik.baza == szukanyItem.baza || szukanyItem.baza == 0) && (wynik.suf == szukanyItem.suf || szukanyItem.suf == 0))
                    {
                        AnaLaczResults.Add(new Item(wynik));
                    }

                    // Wywołaj pętle sprawdzające pozostałe łączenia
                    // Połączenia (((A+B)+C)+D) itd.
                    if (iloscLacz < maxIloscLaczen && AnaLaczWorker.CancellationPending == false) AnalizujRekFunc(indeksy, iloscPrzedmiotów, iloscLacz, maxIloscLaczen, wynik, TypPrzedmiotu, szukanyItem, helmetException, mieszaneLaczenia);
                    // Połączenia dodatkowe ((A+B)+(C+D)) itd.
                    if (iloscLacz + 2 <= maxIloscLaczen && dodatkoweLaczenia == true && AnaLaczWorker.CancellationPending == false) AnalizujRekFunc2(indeksy, iloscPrzedmiotów, iloscLacz, maxIloscLaczen, wynik, TypPrzedmiotu, szukanyItem, helmetException, mieszaneLaczenia);

                    indeksy.Remove(sk2); // Usuń wykorzystany "indeks" przedmiotu z listy
                    // Jeżeli wciśnięto klawisz Esc przerwij analizowanie
                    if (AnaLaczWorker.CancellationPending == true)
                    {
                        this.Dispatcher.Invoke(new Action(() =>
                        {
                            laAnalizatorLaczenZnalPol.Content = "Przerwano analizę."; // Daj użytkownikowi znać, że przerwał analizę
                        }));
                        return;
                    }
                }

                AnaLaczResults.TrimExcess();
            }

            sw.Stop();

            string elapsedTime = "";
            
            if ((double)sw.ElapsedMilliseconds >= 60000d)
            {
                // Analiza trwała ponad 1 min
                elapsedTime = Math.Round(((double)sw.ElapsedMilliseconds / 60000d), 3).ToString();
                elapsedTime += " min.";
            }
            else if ((double)sw.ElapsedMilliseconds > 1000d)
            {
                // Analiza trwała ponad 1 sec
                elapsedTime = Math.Round(((double)sw.ElapsedMilliseconds / 1000d), 3).ToString();
                elapsedTime += " s.";
            }
            else
            {
                // Analiza trwała poniżej 1 sec
                elapsedTime = Math.Round(((double)sw.ElapsedMilliseconds), 3).ToString();
                elapsedTime += " ms.";
            }

            // Po zakończonej analizie połączeń wyświetl ilość znalezionych wyników
            this.Dispatcher.Invoke(new Action(() =>
            {
                if (AnaLaczResults.Count == 1) laAnalizatorLaczenZnalPol.Content = "Znaleziono " + AnaLaczResults.Count + " połączenie w " + elapsedTime;
                if (AnaLaczResults.Count > 1 && AnaLaczResults.Count < 5) laAnalizatorLaczenZnalPol.Content = "Znaleziono " + AnaLaczResults.Count + " połączenia w " + elapsedTime;
                if (AnaLaczResults.Count >= 5 || AnaLaczResults.Count == 0) laAnalizatorLaczenZnalPol.Content = "Znaleziono " + AnaLaczResults.Count + " połączeń w " + elapsedTime;

                btnAnalizatorLaczenAnalizuj.Content = "Sortuję wyniki...";
            }));

            // Sortowanie wyników: jakość prefiksu -> jakość bazy -> jakość sufiksu -> ilość łączeń
            AnaLaczResults = AnaLaczResults.OrderBy(x => x.pref).ThenBy(y => y.baza).ThenBy(z => z.suf).ThenBy(l => l.jointsNumber).ToList();
        }

        private void AnalizujRekFunc(List<int> indeksy, int iloscPrzed, int iloscLacz, int maxIloscLaczen, Item skladnik, ItemType TypPrzedmiotu, Item szukanyItem, bool helmetException, bool mieszaneLaczenia)
        {
            /// Funkcja sprawdzająca proste łączenia - ((A+B)+C)+D
            Item wynik = new Item(); // Zmienna do przechowywania wyniku łączenia
            int iloscL = iloscLacz + 1; // Zwiększ ilość łączeń o 1

            // Połącz wszystkie pozostałe przedmioty
            for (int i = 0; i < iloscPrzed; i++)
            {
                if (indeksy.Contains(i)) continue; // Jeżeli wcześniej wykorzystano "indeks" przedmiotu to go pomiń
                indeksy.Add(i); // Dodaj wykorzystany "indeks" przedmiotu do listy

                // Połącz otrzymany w argumentach składnik z pozostałym przedmiotem, uwzględnij wyjątek przy łączeniu baz hełmów
                wynik = new Item(skladnik.Polacz(AnaLaczItems[i], TypPrzedmiotu, helmetException));

                // Dodaj jego historię łączenia - historia łącznia składnika + aktualnie sprawdzany przedmiot + wynik łączenia
                wynik.history.AddRange(skladnik.history); // Dodaj historię składnika
                wynik.history.Add(new int[] { AnaLaczItems[i].pref, AnaLaczItems[i].baza, AnaLaczItems[i].suf, -1 }); // Dodaj łączony przedmiot
                wynik.history.Add(new int[] { wynik.pref, wynik.baza, wynik.suf, -2 }); // Dodaj wynik łączenia
                wynik.history.TrimExcess();

                // Zwiększ ilość łączeń wyniku - ilość łączeń składnika + ilość łączeń aktualnego przedmiotu + 1
                wynik.jointsNumber = skladnik.jointsNumber + AnaLaczItems[i].jointsNumber + 1;

                if ((wynik.pref == szukanyItem.pref || szukanyItem.pref == 0) && (wynik.baza == szukanyItem.baza || szukanyItem.baza == 0) && (wynik.suf == szukanyItem.suf || szukanyItem.suf == 0))
                {
                    AnaLaczResults.Add(new Item(wynik)); // Dodaj wynik do listy wyników
                }

                // Wywołaj sam siebie + ogranicznie ilości sprawdzanych łączeń
                if (iloscL < maxIloscLaczen && AnaLaczWorker.CancellationPending == false) AnalizujRekFunc(indeksy, iloscPrzed, iloscL, maxIloscLaczen, wynik, TypPrzedmiotu, szukanyItem, helmetException, mieszaneLaczenia);
                // Jeżeli zaznaczono połączenia mieszane wywołaj funkcję dodatkowych łączeń
                if (iloscL + 2 <= maxIloscLaczen && mieszaneLaczenia == true && AnaLaczWorker.CancellationPending == false) AnalizujRekFunc2(indeksy, iloscPrzed, iloscL, maxIloscLaczen, wynik, TypPrzedmiotu, szukanyItem, helmetException, mieszaneLaczenia);

                indeksy.Remove(i); // Usuń wykorzystany "indeks" przedmiotu z listy
                if (AnaLaczWorker.CancellationPending == true) return; // Wyjdź z funkcji jeżeli przerwano analizę połączeń
            }
        }

        private void AnalizujRekFunc2(List<int> indeksy, int iloscPrzed, int iloscLacz, int maxIloscLaczen, Item skladnik, ItemType TypPrzedmiotu, Item szukanyItem, bool helmetException, bool mieszaneLaczenia)
        {
            /// Funkcja sprawdzająca dodatkowe łączenia (A+B)+(C+D)
            Item skladnikTemp = new Item(); // Zmienna do przechowywania tymczasowego składnika - wyniku łączenia dwóch przedmiotów, które zostaną połączone z otrzymanym składnikiem w argumentach funkcji
            Item wynik = new Item(); // Zmienna do przechowywania wyniku łączenia
            int iloscL = iloscLacz + 2; // Zwiększ ilość łączeń o 2

            for (int i = 0; i < iloscPrzed; i++)
            {
                if (indeksy.Contains(i)) continue; // Jeżeli wcześniej wykorzystano "indeks" przedmiotu to go pomiń
                indeksy.Add(i); // Dodaj wykorzystany "indeks" przedmiotu do listy

                for (int j = 0; j < iloscPrzed; j++)
                {
                    if (indeksy.Contains(j)) continue; // Jeżeli wcześniej wykorzystano "indeks" przedmiotu to go pomiń
                    indeksy.Add(j); // Dodaj wykorzystany "indeks" przedmiotu do listy

                    // Połącz dwa przedmioty aby otrzymać tymczasowy składnik, uwzględnij wyjątek przy łączeniu baz hełmów
                    skladnikTemp = new Item(AnaLaczItems[i].Polacz(AnaLaczItems[j], TypPrzedmiotu, helmetException));

                    // Dodaj historię łączenia tymczasowego składnika - historia łączenia przedmiotu 1 + historia łączenia przedmiotu 2
                    skladnikTemp.history.Add(new int[] { AnaLaczItems[i].pref, AnaLaczItems[i].baza, AnaLaczItems[i].suf, -3 });
                    skladnikTemp.history.Add(new int[] { AnaLaczItems[j].pref, AnaLaczItems[j].baza, AnaLaczItems[j].suf, -4 });
                    skladnikTemp.history.TrimExcess();

                    // Ustaw ilość łączeń tymczasowego składnika - ilość łączeń przedmiotu 1 + ilość łączeń przedmiotu 2 + 1
                    skladnikTemp.jointsNumber = AnaLaczItems[i].jointsNumber + AnaLaczItems[j].jointsNumber + 1;

                    // Połącz tymczasowy składnik ze składnikiem otrzymanym w argumencie funkcji, uwzględnij wyjątek przy łączeniu baz hełmów
                    wynik = new Item(skladnik.Polacz(skladnikTemp, TypPrzedmiotu, helmetException));

                    // Dodaj historię łączenia wyniku - historia łączenia skłądnika + historia łączenia tymczasowego składnika + wynik łączenia
                    wynik.history.AddRange(skladnik.history); // Dodaj historię składnika
                    wynik.history.AddRange(skladnikTemp.history); // Dodaj historię składnika pośredniego
                    wynik.history.Add(new int[] { wynik.pref, wynik.baza, wynik.suf, -2 }); // Dodaj historię wyniku
                    wynik.history.TrimExcess();

                    // Ustaw ilość łączeń wyniku - ilość łączeń składnika + ilość łączeń tymczasowego składnika
                    wynik.jointsNumber = skladnik.jointsNumber + skladnikTemp.jointsNumber + 1;

                    if ((wynik.pref == szukanyItem.pref || szukanyItem.pref == 0) && (wynik.baza == szukanyItem.baza || szukanyItem.baza == 0) && (wynik.suf == szukanyItem.suf || szukanyItem.suf == 0))
                    {
                        AnaLaczResults.Add(new Item(wynik)); // Dodaj otrzymany wynik łączenia do listy wyników
                    }

                    // Wywołaj sam siebie jeżeli ilość itemów > ilości pętli + 2
                    if (iloscL + 2 <= maxIloscLaczen && AnaLaczWorker.CancellationPending == false) AnalizujRekFunc2(indeksy, iloscPrzed, iloscL, maxIloscLaczen, wynik, TypPrzedmiotu, szukanyItem, helmetException, mieszaneLaczenia);
                    // Jeżeli zaznaczono połączenia mieszane wywołaj funkcję domyślnych łączeń
                    if (iloscL < maxIloscLaczen && mieszaneLaczenia == true && AnaLaczWorker.CancellationPending == false) AnalizujRekFunc(indeksy, iloscPrzed, iloscL, maxIloscLaczen, wynik, TypPrzedmiotu, szukanyItem, helmetException, mieszaneLaczenia);

                    indeksy.Remove(j); // Usuń wykorzystany "indeks" przedmiotu z listy
                    if (AnaLaczWorker.CancellationPending == true) return; // Wyjdź z funkcji jeżeli przerwano analizę połączeń
                }
                
                indeksy.Remove(i); // Usuń wykorzystany "indeks" przedmiotu z listy
            }
        }

        private void FiltrUpdate_Click(object sender, EventArgs e)
        {
            /// Przefiltruj wyniki połączeń
            cbAnalizatorLaczenPolPrzed.SelectionChanged -= new SelectionChangedEventHandler(PolaczonePrzedmioty_SelectedIndexChanged); // Na czas filtrowania i dodawania wyników wyłącz obsługę zdarzeń
            cbAnalizatorLaczenPolPrzed.ItemsSource = null; // Wyczyść wyświetlane przefiltorwane wyniki
            btnAnalizatorLaczenAktuFiltr.IsEnabled = false; // Na czas filtrowania i dodawania wyników wyłącz przycisk "Aktualizuj filtr" oraz zmień jego tekst na "Aktualizuję..."
            btnAnalizatorLaczenAktuFiltr.Content = "Aktualizuję...";
            cbAnalizatorLaczenFiltrPref.IsEnabled = false; // Wyłącz kontrolki wykorzystywane do filtrowania wyników
            cbAnalizatorLaczenFiltrBaza.IsEnabled = false;
            cbAnalizatorLaczenFiltrSuf.IsEnabled = false;
            chkBAnalizatorLaczenWyswietl.IsEnabled = false;
            cbAnalizatorLaczenPolPrzed.IsEnabled = false;

            // Dispatcher jest wykorzystywany do "opóźnienia" aktualizacji comboBox'a - po wszystkich zdarzeniach renderowania
            this.InvalidateVisual();
            Dispatcher.Invoke(new Action(() =>
            {
                // Wywołaj funkcję do filtrowania wyników łączeń
                string selectedItem = cbAnalizatorLaczenItemType.SelectedItem.ToString();
                if (selectedItem == ItemType.Items[0]) FiltrUpdate(BazaHelm);
                else if (selectedItem == ItemType.Items[1]) FiltrUpdate(BazaZbroja);
                else if (selectedItem == ItemType.Items[2]) FiltrUpdate(BazaSpodnie);
                else if (selectedItem == ItemType.Items[3]) FiltrUpdate(BazaPierscien);
                else if (selectedItem == ItemType.Items[4]) FiltrUpdate(BazaAmulet);
                else if (selectedItem == ItemType.Items[5]) FiltrUpdate(BazaBiala1h);
                else if (selectedItem == ItemType.Items[6]) FiltrUpdate(BazaBiala2h);
                else if (selectedItem == ItemType.Items[7]) FiltrUpdate(BazaPalna1h);
                else if (selectedItem == ItemType.Items[8]) FiltrUpdate(BazaPalna2h);
                else if (selectedItem == ItemType.Items[9]) FiltrUpdate(BazaDystans);
            }), DispatcherPriority.Background, null);

            // Po zakończonym filtorwaniu wyników włącz listę wyświetlającą wyniki oraz dodaj obsługę zdarzeń
            btnAnalizatorLaczenAktuFiltr.Content = "Aktualizuj filtr";
            btnAnalizatorLaczenAktuFiltr.IsEnabled = true;
            cbAnalizatorLaczenFiltrPref.IsEnabled = true;
            cbAnalizatorLaczenFiltrBaza.IsEnabled = true;
            cbAnalizatorLaczenFiltrSuf.IsEnabled = true;
            chkBAnalizatorLaczenWyswietl.IsEnabled = true;
            cbAnalizatorLaczenPolPrzed.IsEnabled = true;
            cbAnalizatorLaczenPolPrzed.SelectionChanged += new SelectionChangedEventHandler(PolaczonePrzedmioty_SelectedIndexChanged);
            cbAnalizatorLaczenPolPrzed.SelectedIndex = -1;
        }

        private void FiltrUpdate(ItemType TypPrzedmiotu)
        {
            /// Funkcja filtrująca wyniki łączeń oraz zmieniająca Item'y na postać stringa
            List<string> wynikiTekst = new List<string>(); // Lista przechowująca przefiltrowanie wyniki łączeń w postaci string'ów
            int filtrPref = cbAnalizatorLaczenFiltrPref.SelectedIndex; // Zmienne do przechowywania wybranych parametrów filtra
            int filtrBaza = cbAnalizatorLaczenFiltrBaza.SelectedIndex;
            int filtrSuf = cbAnalizatorLaczenFiltrSuf.SelectedIndex;
            
            AnaLaczItemsFiltered.Clear(); // Lista wiążąca przefiltorwane wyniki w postaci tekstu z listą wszystkich wyników, lista ta przechowuje "indeks" wyniku dodawanego do listy przefiltorwanych wyników
            AnaLaczItemsFiltered.TrimExcess();

            for (int i = 0; i < AnaLaczResults.Count; i++) // Przefiltruj wyniki
            {
                if (filtrPref == 0 && filtrBaza == 0 && filtrSuf == 0)
                {
                    wynikiTekst.Add(AnaLaczResults[i].ToString(TypPrzedmiotu)); // Pref, baza i suf dowolny - pokaż wszystko
                    AnaLaczItemsFiltered.Add(i);
                    continue;
                }
                else if (AnaLaczResults[i].pref == filtrPref)
                {
                    if (AnaLaczResults[i].baza == filtrBaza) // Wybrano prefiks do filtrowania
                    {
                        if (AnaLaczResults[i].suf == filtrSuf) // Wybrano prefiks i bazę do filtrowania
                        {
                            wynikiTekst.Add(AnaLaczResults[i].ToString(TypPrzedmiotu)); // Wybrano prefiks, bazę i sufiks do filtrowania
                            AnaLaczItemsFiltered.Add(i);
                            continue;
                        }
                        else if (filtrSuf == 0)
                        {
                            wynikiTekst.Add(AnaLaczResults[i].ToString(TypPrzedmiotu)); // Wybrano prefiks i bazę do filtrowania, dowolny sufiks
                            AnaLaczItemsFiltered.Add(i);
                            continue;
                        }
                    }
                    else if (filtrBaza == 0)
                    {
                        if (AnaLaczResults[i].suf == filtrSuf) // Wybrano prefiks do filtrowania i dowolną bazę
                        {
                            wynikiTekst.Add(AnaLaczResults[i].ToString(TypPrzedmiotu)); // Wybrano prefiks i sufiks do filtrowania
                            AnaLaczItemsFiltered.Add(i);
                            continue;
                        }
                        else if (filtrSuf == 0)
                        {
                            wynikiTekst.Add(AnaLaczResults[i].ToString(TypPrzedmiotu)); // Wybrano prefiks do filtrowania, dowolna baza i sufiks
                            AnaLaczItemsFiltered.Add(i);
                            continue;
                        }
                    }
                }
                else if (filtrPref == 0)
                {
                    if (AnaLaczResults[i].baza == filtrBaza) // Dowolny prefiks
                    {
                        if (AnaLaczResults[i].suf == filtrSuf) // Wybrano bazę do filtrowania, dowolny prefiks
                        {
                            wynikiTekst.Add(AnaLaczResults[i].ToString(TypPrzedmiotu)); // Wybrano bazę i sufiks do filtrowania, dowolny prefiks
                            AnaLaczItemsFiltered.Add(i);
                            continue;
                        }
                        else if (filtrSuf == 0)
                        {
                            wynikiTekst.Add(AnaLaczResults[i].ToString(TypPrzedmiotu)); // Wybrano bazę do filtrowania, dowolny prefiks i sufiks
                            AnaLaczItemsFiltered.Add(i);
                            continue;
                        }
                    }
                    else if (filtrBaza == 0)
                    {
                        if (AnaLaczResults[i].suf == filtrSuf) // Dowolny prefiks i baza
                        {
                            wynikiTekst.Add(AnaLaczResults[i].ToString(TypPrzedmiotu)); // Wybrano sufiks do filtrowania, dowolny prefiks i baza
                            AnaLaczItemsFiltered.Add(i);
                            continue;
                        }
                        else if (filtrSuf == 0)
                        {
                            wynikiTekst.Add(AnaLaczResults[i].ToString(TypPrzedmiotu)); // Dowolny prefiks, baza i sufiks
                            AnaLaczItemsFiltered.Add(i);
                            continue;
                        }
                    }
                }
            }

            // Jeżeli ilość przefiltrowanych wyników jest większa niż 62 tyś. wyświetl ostrzeżenie i wyjdź z funkcji
            if (wynikiTekst.Count > 62000 && chkBAnalizatorLaczenWyswietl.IsChecked == false)
            {
                HelpWindow = new HelpWindow("Wyniki łączeń", wynikiTekst.Count);
                HelpWindow.Owner = this;
                HelpWindow.ShowDialog();
                return;
            }

            // Dodaj przefiltrowane wyniki do listy wyświetlanych wyników
            cbAnalizatorLaczenPolPrzed.ItemsSource = wynikiTekst;
            cbAnalizatorLaczenPolPrzed.IsDropDownOpen = true; // Wymuszenie załadowania przedmiotów do comboBox'a
            cbAnalizatorLaczenPolPrzed.IsDropDownOpen = false;
        }

        private void PolaczonePrzedmioty_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            /// Funkcja wyświetlająca historię łączeń przedmiotów w analizatorze łączeń po wybraniu wyniku z listy
            if (cbAnalizatorLaczenPolPrzed.SelectedIndex >= 0)
            {
                rtbAnalizatorLaczen.Document.Blocks.Clear();
                int index = AnaLaczItemsFiltered[cbAnalizatorLaczenPolPrzed.SelectedIndex]; // Aktualizacja historii łączeń po zmianie wybranego wyniku połączenia
                ItemType itemType = null;
                string selectedItem = cbAnalizatorLaczenItemType.SelectedItem.ToString();
                if (selectedItem == ItemType.Items[0]) itemType = BazaHelm;
                else if (selectedItem == ItemType.Items[1]) itemType = BazaZbroja;
                else if (selectedItem == ItemType.Items[2]) itemType = BazaSpodnie;
                else if (selectedItem == ItemType.Items[3]) itemType = BazaPierscien;
                else if (selectedItem == ItemType.Items[4]) itemType = BazaAmulet;
                else if (selectedItem == ItemType.Items[5]) itemType = BazaBiala1h;
                else if (selectedItem == ItemType.Items[6]) itemType = BazaBiala2h;
                else if (selectedItem == ItemType.Items[7]) itemType = BazaPalna1h;
                else if (selectedItem == ItemType.Items[8]) itemType = BazaPalna2h;
                else if (selectedItem == ItemType.Items[9]) itemType = BazaDystans;
                
                string text = "";
                for (int i = 0; i < AnaLaczResults[index].history.Count; i++)
                {
                    switch (AnaLaczResults[index].history[i][3])
                    {
                        case 0:
                            // Nic nie dodawaj
                            text += (new Item(AnaLaczResults[index].history[i][0], AnaLaczResults[index].history[i][1], AnaLaczResults[index].history[i][2])).ToString(itemType);
                            break;
                        case -1:
                            // Dodaj " + "
                            text += " + " + (new Item(AnaLaczResults[index].history[i][0], AnaLaczResults[index].history[i][1], AnaLaczResults[index].history[i][2])).ToString(itemType);
                            break;
                        case -2:
                            // Dodaj "\n= "
                            text += "\n= " + (new Item(AnaLaczResults[index].history[i][0], AnaLaczResults[index].history[i][1], AnaLaczResults[index].history[i][2])).ToString(itemType);
                            break;
                        case -3:
                            // Dodaj " + ("
                            text += " + (" + (new Item(AnaLaczResults[index].history[i][0], AnaLaczResults[index].history[i][1], AnaLaczResults[index].history[i][2])).ToString(itemType);
                            break;
                        case -4:
                            // Dodaj " + " i ")"
                            text += " + " + (new Item(AnaLaczResults[index].history[i][0], AnaLaczResults[index].history[i][1], AnaLaczResults[index].history[i][2])).ToString(itemType) + ")";
                            break;
                    }
                }

                rtbAnalizatorLaczen.AppendText(text);
                rtbAnalizatorLaczen.ScrollToEnd();
            }
        }

        private void EdytujPrzedmioty_Click(object sender, RoutedEventArgs e)
        {
            /// Wywołaj okienko edytora przedmiotu 
            string selectedItem = cbAnalizatorLaczenItemType.SelectedItem.ToString();
            if (selectedItem == ItemType.Items[0]) EditWindow = new EditWindow(AnaLaczItems, BazaHelm, this);
            else if (selectedItem == ItemType.Items[1]) EditWindow = new EditWindow(AnaLaczItems, BazaZbroja, this);
            else if (selectedItem == ItemType.Items[2]) EditWindow = new EditWindow(AnaLaczItems, BazaSpodnie, this);
            else if (selectedItem == ItemType.Items[3]) EditWindow = new EditWindow(AnaLaczItems, BazaPierscien, this);
            else if (selectedItem == ItemType.Items[4]) EditWindow = new EditWindow(AnaLaczItems, BazaAmulet, this);
            else if (selectedItem == ItemType.Items[5]) EditWindow = new EditWindow(AnaLaczItems, BazaBiala1h, this);
            else if (selectedItem == ItemType.Items[6]) EditWindow = new EditWindow(AnaLaczItems, BazaBiala2h, this);
            else if (selectedItem == ItemType.Items[7]) EditWindow = new EditWindow(AnaLaczItems, BazaPalna1h, this);
            else if (selectedItem == ItemType.Items[8]) EditWindow = new EditWindow(AnaLaczItems, BazaPalna2h, this);
            else if (selectedItem == ItemType.Items[9]) EditWindow = new EditWindow(AnaLaczItems, BazaDystans, this);
            EditWindow.Owner = this;
            EditWindow.ShowDialog();
        }

        public void UpdateLoadedItems(List<Item> _il, ItemType _it)
        {
            /// Funkcja wywoływana przez Edit Window przy zamykaniu. Aktualizuje listę załadowanych przedmiotów
            AnaLaczItems = _il; // Zaktualizuj załadowane przedmioty
            AnaLaczItems.TrimExcess();
            cbAnalizatorLaczenZalPrzed.Items.Clear(); // Wyczyść comoBox z załadowanymi przedtmiotami
            foreach (Item i in AnaLaczItems) cbAnalizatorLaczenZalPrzed.Items.Add(i.ToString(_it)); // Dodaj załadowane przedmioty do comboBox'a

            // W zależności od ilości załadowanych przedmiotów wyświetl poprawną (słownie) ilość
            if (AnaLaczItems.Count == 1) lbAnalizatorLaczenZalPrzed.Content = "Załadowano " + AnaLaczItems.Count + " przedmiot:";
            if (AnaLaczItems.Count > 1 && AnaLaczItems.Count < 5) lbAnalizatorLaczenZalPrzed.Content = "Załadowano " + AnaLaczItems.Count + " przedmioty:";
            if (AnaLaczItems.Count >= 5 || AnaLaczItems.Count == 0) lbAnalizatorLaczenZalPrzed.Content = "Załadowano " + AnaLaczItems.Count + " przedmiotów:";
            // Jeżeli załadowano przynajmniej 1 przedmiot włącz przyciski "Edytuj przedmioty" i "Sortuj przedmioty"
            if (AnaLaczItems.Count > 0)
            {
                cbAnalizatorLaczenZalPrzed.SelectedIndex = 0;
                btnAnalizatorLaczenSortuj.IsEnabled = true;
            }
            else
            {
                tbAnalizatorLaczenIloscLacz.IsEnabled = false;
                btnAnalizatorLaczenSortuj.IsEnabled = false;
            }
            // Jeżeli załadowano przynajmniej 2 przedmioty włącz przyciski "Analizuj połączenia" i checkBox'y dodatkoweLaczenia i mieszaneLaczenia
            if (AnaLaczItems.Count > 1)
            {
                btnAnalizatorLaczenAnalizuj.IsEnabled = true;
                chkBAnalizatorLaczenDodatkowe.IsEnabled = true;
                chkBAnalizatorLaczenDodatkowe.IsChecked = false;
                chkBAnalizatorLaczenMieszane.IsChecked = false;
                // Jeżeli załadowano poniżej 10 przedmiotów ustaw ilość łączeń na ilość przedmiotów
                if (AnaLaczItems.Count < 8) tbAnalizatorLaczenIloscLacz.Value = AnaLaczItems.Count - 1;
                // Jeżeli załadowano więcej przedmiotów ustaw wartość początkową równą 1
                else tbAnalizatorLaczenIloscLacz.Value = 1;

                tbAnalizatorLaczenIloscLacz.IsEnabled = true;
            }
            if (AnaLaczItems.Count < 2)
            {
                // Jeżeli załadowano mniej niż 2 przedmioty wyłącz przycisk "Analizuj połączenia" oraz checkBox dodatkoweLaczenia i ustaw ilość łączeń na 1
                btnAnalizatorLaczenAnalizuj.IsEnabled = false;
                chkBAnalizatorLaczenDodatkowe.IsEnabled = false;
                chkBAnalizatorLaczenDodatkowe.IsChecked = false;
                chkBAnalizatorLaczenMieszane.IsEnabled = false;
                chkBAnalizatorLaczenMieszane.IsChecked = false;
                tbAnalizatorLaczenIloscLacz.Value = 1;
            }
        }

        private void AnalizatorLaczenPomoc_Click(object sender, RoutedEventArgs e)
        {
            /// Szybka pomoc jak korzystać z analizatora łączeń
            HelpWindow = new HelpWindow("Analizator łączeń");
            HelpWindow.Owner = this;
            HelpWindow.ShowDialog();
        }

        private void AnalizatorRaportuPomoc_Click(object sender, RoutedEventArgs e)
        {
            /// Szybka pomoc jak korzystać z analizatora raportów
            HelpWindow = new HelpWindow("Analizator raportów");
            HelpWindow.Owner = this;
            HelpWindow.ShowDialog();
        }

        private void AnalizatorRaportuOblicz_Click(object sender, RoutedEventArgs e)
        {
            /// Kliknięto "Analizuj raport"
            var result = UpgradeReportAnalyzer.Analyze(new TextRange(rtbAnalizatorRaportu.Document.ContentStart, rtbAnalizatorRaportu.Document.ContentEnd).Text);
            tbAnalizatorRaportuWynik1.Text = result.Item1[0]; // Wprowadź obliczone wartości
            tbAnalizatorRaportuWynik2.Text = result.Item1[1];
            tbAnalizatorRaportuWynik3.Text = result.Item1[2];

            // Pokoloruj tekst
            TextRange txtRange = new TextRange(rtbAnalizatorRaportu.Document.ContentStart, rtbAnalizatorRaportu.Document.ContentEnd);
            string[] txt = txtRange.Text.Split(new string[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);

            for (int j = 0; j < txt.Count() - 1; j++)
            {
                int offset1 = 0, offset2 = 0;
                for (int i = 0; i <= j; i++)
                {
                    if (txt[i].Length == 0)
                    {
                        // Jeżeli linia jest pusta (length == 0) to "\r\n" ma długość 2 znaków
                        offset1 += 2;
                        offset2 += 2;
                        continue;
                    }
                    else
                    {
                        // W innym wypadku "\r\n" ma długość 4 znaków
                        if (i != j) offset1 += txt[i].Length + 4;
                        offset2 += txt[i].Length + 4;
                    }
                }

                txtRange.Select(rtbAnalizatorRaportu.Document.ContentStart.GetPositionAtOffset(offset1), rtbAnalizatorRaportu.Document.ContentStart.GetPositionAtOffset(offset2));
                if (result.Item2[j] == 1) txtRange.ApplyPropertyValue(ForegroundProperty, Brushes.ForestGreen);
                if (result.Item2[j] == 2) txtRange.ApplyPropertyValue(ForegroundProperty, Brushes.Red);
                if (result.Item2[j] == 3) txtRange.ApplyPropertyValue(ForegroundProperty, "#FF707070");
            }
        }

        private void BtnBattleReportAnalyze_Click(object sender, RoutedEventArgs e)
        {
            /// Kliknięto "Analizuj" w raporcie walki
            BattleResult = BattleReportAnalyzer.Analyze(new TextRange(rtbAnalizatorRaportuWalki.Document.ContentStart, rtbAnalizatorRaportuWalki.Document.ContentEnd).Text, cbAnalizatorWalkWataha.IsChecked == true);
            lAnalizatorWalkiAtakujacy.Content = BattleResult.Attacker;
            lAnalizatorWalkiObronca.Content = BattleResult.Defender;
            lAnalizatorWalkiEfekt.Text = BattleResult.Effect;
            dgAnalizatorWalki.ItemsSource = BattleResult.Participants;
        }

        private void PlacBudowyWyswietl_Click(object sender, RoutedEventArgs e)
        {
            /// Kliknięto "Wyświetl" na Placu Budowy - zapytaj klasę Building o statystyki budynku i je wyświetl
            Building building = Building.Wyswietl(cbPlacBudowyBudynki.SelectedIndex, numPlacBudowyPoziom.Value);

            rtbPlacBudowyKoszty.Document.Blocks.Clear();
            rtbPlacBudowyKoszty.AppendText(building.Koszt.ToString(single: true));

            rtbPlacBudowyKosztyLaczne.Document.Blocks.Clear();
            rtbPlacBudowyKosztyLaczne.AppendText(building.Koszt.ToString(single: false));

            rtbPlacBudowyWymagania.Document.Blocks.Clear();
            rtbPlacBudowyWymagania.AppendText(building.Wymagania.ToString(numPlacBudowyLatwosc.Value));

            rtbPlacBudowyEfekt.Document.Blocks.Clear();
            rtbPlacBudowyEfekt.AppendText(building.Efekt.ToString());

            rtbPlacBudowyCzasBudowy.Document.Blocks.Clear();
            rtbPlacBudowyCzasBudowy.AppendText(building.Czas(numPlacBudowyPosredniak.Value * 2));
        }

        private void CbPlacBudowyBudynki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /// Jeżeli wybrano element z opisem strefy to zmień wybór na pierwszy budynek wybranej strefy
            if (((ComboBox)sender).SelectedItem.ToString().Contains("--")) ((ComboBox)sender).SelectedIndex++;
        }

        private void CbPlacBudowyPosredniak_CheckChanged(object sender, RoutedEventArgs e)
        {
            /// Zmieniono stan checkBox'a "uwzględnij skrócenie z pośredniaka"
            if (((CheckBox)sender).IsChecked == true) numPlacBudowyPosredniak.IsEnabled = true;
            else
            {
                numPlacBudowyPosredniak.IsEnabled = false;
                numPlacBudowyPosredniak.Value = 0;
            }
        }

        private void NumPlacBudowyPosredniak_ValueChanged(object sender, RoutedPropertyChangedEventArgs<int> e)
        {
            /// Aktualizuje tekst skrócenia czasu budowy z Pośredniaka
            int val = ((NumericUpDownLib.NumericUpDown)sender).Value * 2;
            if (val > 80) val = 80;
            lPlacBudowyPosredniak.Content = "Redukcja czasu budowy: " + val.ToString() + "%";
        }

        private void CbPlacBudowyLatwosc_CheckChanged(object sender, RoutedEventArgs e)
        {
            /// Zmieniono stan checkBox'a "uwzględnij łatwość"
            if (((CheckBox)sender).IsChecked == true) numPlacBudowyLatwosc.IsEnabled = true;
            else
            {
                numPlacBudowyLatwosc.IsEnabled = false;
                numPlacBudowyLatwosc.Value = 0;
            }
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            /// Jeżeli wciśnięto klawisz ESC zakończ analizowanie połączeń
            if (e.Key == Key.Escape) AnaLaczWorker.CancelAsync();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            /// Funkcja wywoływana przy zamykaniu głównego okienka
            if (TableWindow != null) TableWindow.Close();
            if (EditWindow != null) EditWindow.Close();
            if (HelpWindow != null) HelpWindow.Close();
            AnaLaczWorker.CancelAsync();
        }

        private void ByMe_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            /// Wyświetl okienko About
            AboutWindow = new AboutWindow(Version);
            AboutWindow.Owner = this;
            AboutWindow.ShowDialog();
        }
    }
}