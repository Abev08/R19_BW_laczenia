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

namespace Narzędzie_Blood_Wars___R19
{
    public partial class HelpWindow : Window
    {
        public HelpWindow(string s, int itemsNumber = 0)
        {
            InitializeComponent();

            switch (s)
            {
                case "Analizator raportów":
                    this.Width = 600;
                    this.Height = 230;
                    this.Title = "Pomoc - " + s;
                    rtbHelp.AppendText("1.Skopiuj zawartość raportu z ulepszania.\n" +
                                    "Możesz zaznaczyć wszystko (CTRL+A) i skopiować (CTRL+C).\n" +
                                    "2. Wlej skopiowaną zawartość raportu do okienka obok.\n" +
                                    "3. Kliknij 'Oblicz'.\n" +
                                    "\n" +
                                    "Podsumowanie raportu po prawej stronie przedstawia ulepszenia w postaci:\n" +
                                    "Ilość udanych ulepszeń / Ilość wszystkich ulepszeń, Procentowa wartość powodzenia.");
                    break;

                case "Analizator łączeń":
                    this.Width = 900;
                    this.Height = 400;
                    this.Title = "Pomoc - " + s;
                    rtbHelp.AppendText("1. Wklej do okienka po lewej stronie listę przedmiotów do łączenia.\n" +
                                   "Możesz wkleić przedmioty wraz z cenami i \"SPRZEDAJ\", \"EKWIPUJ\", lecz w jednej linii musi znajdować się jeden przedmiot\n" +
                                   "oraz prefiks, baza i sufiks przedmiotu muszą zaczynać się z dużej litery (muszą zgadzać się z nazewnictwem przedmiotów przez Blood Wars).\n" +
                                   "2. Z listy w górnej części okna wybierz typ przedmiotu jaki chcesz łączyć.\n" +
                                   "3. Kliknij \"Załaduj przedmioty\".\n" +
                                   "4. Sprawdź czy załadowane przedmioty zgadzają się z przedmiotami z listy.\n" +
                                   "Załadowane przedmioty możesz edytować klikając w \"Edytuj przedmioty\" i sortować klikając w \"Sortuj przedmioty\".\n" +
                                   "Przedmioty po sortowaniu należy ponownie załadować.\n" +
                                   "5. Jeżeli szukasz konkretnego wyniku łączeń możesz zadeklarować szukany prefiks / bazę / sufiks korzystając z odpowiednich okienek.\n" +
                                   "Przy dużej ilości wyników łączeń znacząco obniża to wykorzystanie pamięci przez program.\n" +
                                   "6. Jeżeli załadowano powyżej 10 przedmiotów wybierz ilość łączeń do sprawdzania.\n" +
                                   "Ilość łączeń określa ilość sprawdzanych połączeń \"w głąb\".\n" +
                                   "Dla dużej ilości przedmiotów warto zacząć od niskiej wartości (1 - 2) i zwiększać o 1 jeżeli komputer daje radę z obliczeniami :).\n" +
                                   "7. Kliknij \"Analizuj połączenia\".\n" +
                                   "Postęp analizowania połączeń aktualizowany jest stopniowo.\n" +
                                   "Jeżeli analiza połączeń trwa zbyt długo możesz ją przerwać naciskając klawisz \"Esc\" na klawiaturze.\n" +
                                   "Po zakończonym analizowaniu połączeń wyniki są sortowane. Sortowanie może trwać długo jeżeli znaleziono wiele połączeń.\n" +
                                   "8. Wybierz filtr (dla dużej ilości wyników - powyżej kilkuset tysięcy - dodawanie ich do listy przefiltrowanych wyników trwa bardzo długo).\n" +
                                   "Lista wyników powyżej 60 tysięcy nie scrolluje się za dobrze - możliwe jest wyświetlenie każdego wyniku,\n" +
                                   "lecz chwycenie za pasek przewijania po prawej stronie i przeciągnięcie w dół nie przescrolluje listy.\n" +
                                   "Możliwe jest poruszanie się po liście wyników używając klawiszy \"Home\" - skok na początek listy, \"End\" - skok na koniec listy,\n" +
                                   "\"Page Up\" - przewinięcie listy o jedno okienko w górę, \"Page Down\" - przewinięcie listy o jedno okienko w dół.\n" +
                                   "9. Kliknij \"Aktualizuj filtr\".\n" +
                                   "10. Po wyborze wyniku łączenia z listy przefiltrowanych wyników w okienku po lewej stronie pokaże się lista wymaganych łączeń.");
                    break;

                case "Wyniki łączeń":
                    this.Width = 520;
                    this.Height = 190;
                    this.Title = "Sugestia dotycząca filtra";
                    rtbHelp.AppendText("Powyżej 60 tyś. wyników do wyświetlenia (" + itemsNumber.ToString() + " wyników).\n" +
                                   "Jeżeli mimo wszystko chcesz je wyświetlić zaznacz odpowiedni CheckBox.\n" +
                                   "\n" +
                                   "W trakcie wczytywania program może przestać odpowiadać!\n" +
                                   "Wczytywania przedmiotów nie da się przerwać!");
                    break;
            }
        }


        private void PomocOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Zamknij okno pomocy po kliknięciu OK
        }
    }
}
