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
using System.Windows.Navigation;
using System.Diagnostics;

namespace Narzędzie_Blood_Wars___R19
{
    public partial class AboutWindow : Window
    {
        public AboutWindow(string v)
        {
            InitializeComponent();

            // Główny tekst okienka
            labAboutText.Text = "\rZnalazłeś(aś) błąd? Masz sugestie dotyczące programu?\r\r" +
                "Możesz je zgłosić znajdując mnie w grze,\r" +
                "pisząc na abev088@gmail.com\r" +
                "lub wykorzystując zakładkę \"Issues\" w repozytorium GitHub'a.\r\r" +
                "Zgłaszając problemy i sugestie pomagasz rozwijać program! :)";

            // Przypisanie wersji programu
            labAboutVersion.Content = "Wersja programu:" + v.Remove(0, v.IndexOf(" "));

            byMe.NavigateUri = new Uri("https://r19.bloodwars.interia.pl/showmsg.php?a=profile&uid=2755");
            byMe2.NavigateUri = new Uri("https://r19.bloodwars.interia.pl/showmsg.php?a=profile&uid=13059");
            Repo.NavigateUri = new Uri("https://github.com/Abev08/R19_BW_laczenia");
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Zamknij okienko po kliknięciu w klawisz OK
        }

        private void ByMe_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri)); // Kliknięto by Abev - otwórz stronę postaci
            e.Handled = true;
        }

        private void ByMe2_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri)); // Kliknięto by Abev2 - otwórz stronę postaci
            e.Handled = true;
        }

        private void Repo_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri)); // Kliknięto link do repozytorium
            e.Handled = true;
        }
    }
}
