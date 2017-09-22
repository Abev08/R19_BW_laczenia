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
    public partial class Pomoc : Form
    {
        public string wyswietl = "";

        public Pomoc(string s = "")
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            wyswietl = s;

            switch (s)
            {
                case "Analizator raportów":
                    this.Width = 400;
                    this.Height = 200;
                    pomocTekst.Height = this.Height - pomocOK.Height - 50;

                    pomocTekst.Text = "1. Skopiuj zawartość raportu z ulepszania.\n" +
                "Możesz zaznaczyć wszystko (CTRL+A) i skopiować (CTRL+C).\n" +
                "2. Wlej skopiowaną zawartość raportu do okienka obok.\n" +
                "3. Kliknij 'Oblicz'.";
                    break;
                case "Analizator łączeń":
                    this.Width = 800;
                    this.Height = 400;
                    pomocTekst.Height = this.Height - pomocOK.Height - 50;

                    pomocTekst.Text = "1. Wklej do okienka po lewej stronie listę przedmiotów do łączenia.\n" +
                "Możesz wkleić przedmioty wraz z cenami i \"SPRZEDAJ\", \"EKWIPUJ\", lecz musi być 1 przedmiot na linię oraz prefiks, baza i sufiks przedmiotu muszą zaczynać się z dużej litery.\n" +
                "2. Z listy u góry okna wybierz typ przedmiotu jaki chcesz kleić.\n" +
                "3. Kliknij \"Załaduj przedmioty\".\n" +
                "4. Sprawdź czy załadowane przedmioty zgadzają się z przedmiotami z listy.\n" +
                "5. Wybierz ilość łączeń do sprawdzania (ilość łączeń określa ilość sprawdzanych połączeń \"w głąb\").\n" +
                "Dla dużej ilości przedmiotów warto zacząć od niskiej wartości (1-2) i zwiększać o 1 jeżeli komputer daje radę z obliczeniami :).\n" +
                "6. Kliknij \"Analizuj połączenia\".\n" +
                "7. Wybierz filtr (dla dużej ilości wyników - powyżej kilkudziesięciu tysięcy - dodawanie ich do listy przefiltrowanych wyników trwa bardzo długo).\n" +
                "8. Kliknij \"Aktualizuj filtr\".\n" +
                "9. Po wyborze wyniku łączenia z listy przefiltrowanych wyników w okienku po lewej stronie pokaże się lista wymaganych łączeń.\n" +
                "\n\n" +
                "Jeżeli program nie odpowiada (na pasku tytułowym jest napisane \"Brak odpowiedzi\" lub \"Not responding\" nie oznacza to, że program się zawiesił - program działa i zajęty jest obliczeniami :) Gdy obliczenia trwają za długo polecam zabicie procesu programu - wyłączenie go :) ).";
                    break;
            }
        }

        private void pomocOK_Click(object sender, EventArgs e)
        {
            // Zamknij okno pomocy po kliknięciu OK
            wyswietl = "";
            this.Dispose();
            this.Close();
        }

        private void Pomoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            wyswietl = "";
            this.Dispose();
            this.Close();
        }
    }
}
