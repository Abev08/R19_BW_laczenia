using System;
using System.Drawing;
using System.Windows.Forms;

namespace R19_BW_laczenia
{
    public partial class About : Form
    {
        public About(string v)
        {
            InitializeComponent();

            // Ustawienia okienka
            this.DoubleBuffered = true;
            this.BackColor = Color.FromArgb(5, 5, 5);
            this.Icon = R19_BW_laczenia.Properties.Resources.Help_icon;
            this.BackgroundImageLayout = ImageLayout.Tile;   // Wybór typu obrazu tła - kafelka
            this.BackgroundImage = Properties.Resources.Background_black;    // Obraz tła

            // Ustawienia czcionki głównego tekstu
            text.ForeColor = Color.FromName("ControlLightLight");
            text.Font = new System.Drawing.Font("Franklin Gothic Book", 10.2f);

            // Ustawienia czcionki tesktu by Abev
            byMe.ForeColor = Color.FromName("ControlLightLight");
            byMe.Font = new System.Drawing.Font("Franklin Gothic Book", 10.2f, FontStyle.Italic);

            // Ustawienia czcionki tesktu by Abev
            repo.ForeColor = Color.FromName("ControlLightLight");
            repo.Font = new System.Drawing.Font("Franklin Gothic Book", 10.2f, FontStyle.Italic);

            // Główny tekst
            text.Text = "\nZnalazłeś(aś) błąd? Masz sugestie dotyczące programu?\n\n" +
                "Możesz je zgłosić znajdując mnie w grze,\n" +
                "pisząc na abev088@gmail.com\n" +
                "lub wykorzystując zakładkę \"Issues\" w repozytorium GitHub'a.\n\n" +
                "Zgłaszając problemy i sugestie pomagasz rozwijać program! :)";

            // Przypisanie wersji programu
            version.ForeColor = Color.FromName("ControlLightLight");
            version.Font = new System.Drawing.Font("Franklin Gothic Book", 10.2f, FontStyle.Italic);
            version.Text = "Wersja programu:" + v.Remove(0, v.IndexOf(" "));
        }

        private void PomocOK_Click(object sender, EventArgs e)
        {
            // Zamknij okno pomocy po kliknięciu OK
            this.Dispose();
            this.Close();
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Zamknij okno po kliknięciu "X" w prawym górnym rogu okna
            this.Dispose();
            this.Close();
        }

        private void ByMe_Click(object sender, EventArgs e)
        {
            // Po kliknięciu w by Abev przekieruj do mojej postaci
            System.Diagnostics.Process.Start("https://r19.bloodwars.interia.pl/showmsg.php?a=profile&uid=2755");
        }

        private void ByMe2_Click(object sender, EventArgs e)
        {
            // Po kliknięciu w by Abev 2 przekieruj do mojej postaci
            System.Diagnostics.Process.Start("https://r19.bloodwars.interia.pl/showmsg.php?a=profile&uid=13059");
        }

        private void Repo_Click(object sender, EventArgs e)
        {
            // Po kliknięciu w link repozytorium przekieruj do repozytorium
            System.Diagnostics.Process.Start("https://github.com/Abev08/R19_BW_laczenia");
        }
    }
}
