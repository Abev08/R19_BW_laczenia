using System;
using System.Windows.Forms;

namespace R19_BW_laczenia
{
    public partial class Pomoc : Form
    {
        public Pomoc(string s = "")
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            switch (s)
            {
                case "Analizator raportów":
                    this.Text = "Pomoc: " + s;
                    pomocTekst.Text = "1. Skopiuj zawartość raportu z ulepszania.\n" +
                                        "Możesz zaznaczyć wszystko (CTRL+A) i skopiować (CTRL+C).\n" +
                                        "2. Wlej skopiowaną zawartość raportu do okienka obok.\n" +
                                        "3. Kliknij 'Oblicz'.\n" +
                                        "\n" +
                                        "Podsumowanie raportu po prawej stronie przedstawia ulepszenia w postaci:\n" +
                                        "Ilość udanych ulepszeń / Ilość wszystkich ulepszeń.";

                    this.Width = pomocTekst.Width + 50;
                    this.Height = pomocTekst.Height + pomocOK.Height + 50;
                    break;
                case "Analizator łączeń":
                    this.Text = "Pomoc: " + s;
                    pomocTekst.Text = "1. Wklej do okienka po lewej stronie listę przedmiotów do łączenia.\n" +
                                        "Możesz wkleić przedmioty wraz z cenami i \"SPRZEDAJ\", \"EKWIPUJ\", lecz w jednej linii musi znajdować się jeden przedmiot\n" +
                                        "oraz prefiks, baza i sufiks przedmiotu muszą zaczynać się z dużej litery.\n" +
                                        "2. Z listy u góry okna wybierz typ przedmiotu jaki chcesz łączyć.\n" +
                                        "3. Kliknij \"Załaduj przedmioty\".\n" +
                                        "4. Sprawdź czy załadowane przedmioty zgadzają się z przedmiotami z listy.\n" +
                                        "Załadowane przedmioty możesz edytować klikając w \"Edytuj przedmioty\" i sortować klikając w \"Sortuj przedmioty\".\n" +
                                        "Przedmioty po edycji / sortowaniu należy ponownie załadować.\n" +
                                        "5. Jeżeli załadowano powyżej 10 przedmiotów wybierz ilość łączeń do sprawdzania (ilość łączeń określa ilość sprawdzanych połączeń \"w głąb\").\n" +
                                        "Dla dużej ilości przedmiotów warto zacząć od niskiej wartości (1-2) i zwiększać o 1 jeżeli komputer daje radę z obliczeniami :).\n" +
                                        "6. Kliknij \"Analizuj połączenia\".\n" +
                                        "Jeżeli analiza połączeń trwa zbyt długo możesz ją przerwać klikając klawisz \"Esc\" na klawiaturze.\n" +
                                        "7. Wybierz filtr (dla dużej ilości wyników - powyżej kilkuset tysięcy - dodawanie ich do listy przefiltrowanych wyników trwa bardzo długo).\n" +
                                        "Lista wyników powyżej 60 tysięcy nie scrolluje się za dobrze - możliwe jest wyświetlenie każdego wyniku,\n" +
                                        "lecz chwycenie za pasek przewijania po prawej stronie i przeciągnięcie w dół nie przescrolluje listy.\n" +
                                        "Możliwe jest szybkie skakanie pomiędzy pierwszym i ostatnim wynikiem listy używając klawiszy \"Home\" i \"End\".\n" +
                                        "8. Kliknij \"Aktualizuj filtr\".\n" +
                                        "9. Po wyborze wyniku łączenia z listy przefiltrowanych wyników w okienku po lewej stronie pokaże się lista wymaganych łączeń.\n" +
                                        "\n\n" +
                                        "Jeżeli program nie odpowiada - na pasku tytułowym jest napisane \"brak odpowiedzi\" lub \"not responding\" nie oznacza to,\n" +
                                        "że program się zawiesił - program działa i zajęty jest obliczeniami :).";

                    this.Width = pomocTekst.Width + 50;
                    this.Height = pomocTekst.Height + pomocOK.Height + 50;
                    break;
                case "Wyniki łączeń":
                    this.Text = "Sugestia dotycząca filtra";
                    pomocTekst.Text = "Powyżej 60 tyś. wyników do wyświetlenia.\n" +
                                        "To za dużo do poprawnego działania listy wyników! Użyj filtra.\n" +
                                        "Jeżeli mimo wszystko chcesz je wyświetlić zaznacz odpowiedni CheckBox.\n" +
                                        "\n" +
                                        "Wczytywania przedmiotów nie da się przerwać!";

                    this.Width = pomocTekst.Width + 50;
                    this.Height = pomocTekst.Height + pomocOK.Height + 50;
                    break;
            }
        }

        private void pomocOK_Click(object sender, EventArgs e)
        {
            // Zamknij okno pomocy po kliknięciu OK
            this.Dispose();
            this.Close();
        }

        private void Pomoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Zamknij okno po kliknięciu "X" w prawym górnym rogu okna
            this.Dispose();
            this.Close();
        }
    }
}
