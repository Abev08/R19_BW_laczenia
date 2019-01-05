using System;
using System.Collections.Generic;

namespace R19_BW_laczenia
{
    public class Budynek
    {
        // Klasa budynku
        public Budynek(int _poziom, KosztBudynku _koszt, WymaganiaBudynku _wymagania, TimeSpan _czas, EfektBudynku _efekt)
        {
            this.Poziom = _poziom;
            this.Koszt = _koszt;
            this.Wymagania = _wymagania;
            this.CzasBudowy = _czas;
            this.Efekt = _efekt;
        }

        public int Poziom = 0; // Poziom ulepszenia budynku
        public KosztBudynku Koszt = new KosztBudynku(0, 0, 0); // Koszt ulepszenia budynku (pieniądze, ludzie krew)
        public WymaganiaBudynku Wymagania; // Wymagania do ulepszenia budynku
        public TimeSpan CzasBudowy; // Czas rozbudowy budynku
        public EfektBudynku Efekt; // Efekt budynku
        
        public static List<Budynek> UtworzPosredniak(List<Budynek> lb)
        {
            // Lista poziomów Pośredniaka
            lb.Add(new Budynek(0, new KosztBudynku(0, 0, 0), new WymaganiaBudynku(), new TimeSpan(), new EfektBudynku(_przyrostLudzi: 5)));
            lb.Add(new Budynek(1, new KosztBudynku(500, 10, 0), new WymaganiaBudynku(_inteligencja: 5), new TimeSpan(0, 0, 10), new EfektBudynku(_przyrostLudzi: 15, _czasBudowy: 2)));
            lb.Add(new Budynek(2, new KosztBudynku(750, 15, 0), new WymaganiaBudynku(_inteligencja: 7), new TimeSpan(0, 7, 48), new EfektBudynku(_przyrostLudzi: 17, _czasBudowy: 4)));
            lb.Add(new Budynek(3, new KosztBudynku(1125, 24, 0), new WymaganiaBudynku(_inteligencja: 9), new TimeSpan(0, 9, 21), new EfektBudynku(_przyrostLudzi: 20, _czasBudowy: 6)));
            lb.Add(new Budynek(4, new KosztBudynku(1687, 37, 0), new WymaganiaBudynku(_inteligencja: 11), new TimeSpan(0, 11, 13), new EfektBudynku(_przyrostLudzi: 24, _czasBudowy: 8)));
            lb.Add(new Budynek(5, new KosztBudynku(2531, 57, 0), new WymaganiaBudynku(_inteligencja: 13), new TimeSpan(0, 13, 29), new EfektBudynku(_przyrostLudzi: 28, _czasBudowy: 10)));
            lb.Add(new Budynek(6, new KosztBudynku(3796, 89, 0), new WymaganiaBudynku(_inteligencja: 15), new TimeSpan(0, 16, 10), new EfektBudynku(_przyrostLudzi: 33, _czasBudowy: 12)));
            lb.Add(new Budynek(7, new KosztBudynku(5695, 138, 0), new WymaganiaBudynku(_inteligencja: 17), new TimeSpan(0, 19, 25), new EfektBudynku(_przyrostLudzi: 39, _czasBudowy: 14)));
            lb.Add(new Budynek(8, new KosztBudynku(8542, 214, 0), new WymaganiaBudynku(_inteligencja: 19), new TimeSpan(0, 23, 18), new EfektBudynku(_przyrostLudzi: 46, _czasBudowy: 16)));
            lb.Add(new Budynek(9, new KosztBudynku(12814, 333, 0), new WymaganiaBudynku(_inteligencja: 21), new TimeSpan(0, 27, 56), new EfektBudynku(_przyrostLudzi: 54, _czasBudowy: 18)));
            lb.Add(new Budynek(10, new KosztBudynku(19221, 516, 0), new WymaganiaBudynku(_inteligencja: 23), new TimeSpan(0, 33, 32), new EfektBudynku(_przyrostLudzi: 63, _czasBudowy: 20)));

            return lb;
        }
        
        public static List<Budynek> UtworzDomPubliczny(List<Budynek> lb)
        {
            // Lista poziomów Domu Publicznego
            lb.Add(new Budynek(0, new KosztBudynku(0, 0, 0), new WymaganiaBudynku(), new TimeSpan(), new EfektBudynku(_przyrostKasy: 10)));
            lb.Add(new Budynek(1, new KosztBudynku(200, 30, 0), new WymaganiaBudynku(_wplywy: 8, _inteligencja: 6), new TimeSpan(0, 0, 10), new EfektBudynku(_przyrostKasy: 120)));
            lb.Add(new Budynek(2, new KosztBudynku(330, 54, 0), new WymaganiaBudynku(_wplywy: 12, _inteligencja: 9), new TimeSpan(0, 6, 36), new EfektBudynku(_przyrostKasy: 144)));
            lb.Add(new Budynek(3, new KosztBudynku(544, 97, 0), new WymaganiaBudynku(_wplywy: 16, _inteligencja: 12), new TimeSpan(0, 7, 55), new EfektBudynku(_przyrostKasy: 174)));
            lb.Add(new Budynek(4, new KosztBudynku(898, 174, 0), new WymaganiaBudynku(_wplywy: 20, _inteligencja: 15), new TimeSpan(0, 9, 30), new EfektBudynku(_przyrostKasy: 208)));
            lb.Add(new Budynek(5, new KosztBudynku(1482, 314, 0), new WymaganiaBudynku(_wplywy: 24, _inteligencja: 18), new TimeSpan(0, 11, 25), new EfektBudynku(_przyrostKasy: 250)));

            return lb;
        }

        public static List<Budynek> UtworzRzeznia(List<Budynek> lb)
        {
            // Lista poziomów Rzeźni
            lb.Add(new Budynek(0, new KosztBudynku(0, 0, 0), new WymaganiaBudynku(), new TimeSpan(), new EfektBudynku(_przyrostKrwi: 10)));
            lb.Add(new Budynek(1, new KosztBudynku(400, 100, 0), new WymaganiaBudynku(_sila: 7), new TimeSpan(0, 0, 10), new EfektBudynku(_przyrostKrwi: 20)));
            lb.Add(new Budynek(2, new KosztBudynku(660, 150, 0), new WymaganiaBudynku(_sila: 11), new TimeSpan(0, 9, 36), new EfektBudynku(_przyrostKrwi: 25)));
            lb.Add(new Budynek(3, new KosztBudynku(1088, 225, 0), new WymaganiaBudynku(_sila: 15), new TimeSpan(0, 11, 32), new EfektBudynku(_przyrostKrwi: 30)));
            lb.Add(new Budynek(4, new KosztBudynku(1796, 337, 0), new WymaganiaBudynku(_sila: 19), new TimeSpan(0, 13, 50), new EfektBudynku(_przyrostKrwi: 35)));
            lb.Add(new Budynek(5, new KosztBudynku(2964, 506, 0), new WymaganiaBudynku(_sila: 23), new TimeSpan(0, 16, 35), new EfektBudynku(_przyrostKrwi: 40)));
            lb.Add(new Budynek(6, new KosztBudynku(4891, 759, 0), new WymaganiaBudynku(_sila: 27), new TimeSpan(0, 19, 55), new EfektBudynku(_przyrostKrwi: 45)));

            return lb;
        }

        public static List<Budynek> UtworzPosterunekPolicji(List<Budynek> lb)
        {
            // Lista poziomów Posterunku Policji
            lb.Add(new Budynek(0, new KosztBudynku(0, 0, 0), new WymaganiaBudynku(), new TimeSpan(), new EfektBudynku()));
            lb.Add(new Budynek(1, new KosztBudynku(2000, 70, 0), new WymaganiaBudynku(_charyzma: 20, _wiedza: 11), new TimeSpan(0, 5, 0), new EfektBudynku(_spostWZasadzce: 1, _zycieWObronie: 15)));
            lb.Add(new Budynek(2, new KosztBudynku(3200, 119, 0), new WymaganiaBudynku(_charyzma: 29, _wiedza: 16), new TimeSpan(0, 6, 0), new EfektBudynku(_spostWZasadzce: 2, _zycieWObronie: 42)));

            return lb;
        }

        public static List<Budynek> UtworzSchroniskoDlaBezdomnych(List<Budynek> lb)
        {
            // Lista poziomów Schroniska Dla Bezdomnych
            lb.Add(new Budynek(0, new KosztBudynku(0, 0, 0), new WymaganiaBudynku(), new TimeSpan(), new EfektBudynku()));
            lb.Add(new Budynek(1, new KosztBudynku(200, 2, 0), new WymaganiaBudynku(_inteligencja: 10, _wiedza: 10), new TimeSpan(0, 4, 30), new EfektBudynku(_szpiegowanie: 2, _wplywyWZasadzce: 1)));
            lb.Add(new Budynek(2, new KosztBudynku(400, 4, 0), new WymaganiaBudynku(_inteligencja: 17, _wiedza: 18), new TimeSpan(0, 5, 24), new EfektBudynku(_szpiegowanie: 4, _wplywyWZasadzce: 2)));

            return lb;
        }

        public static List<Budynek> UtworzAgencjaOchrony(List<Budynek> lb)
        {
            // Lista poziomów Agencji Ochrony
            lb.Add(new Budynek(0, new KosztBudynku(0, 0, 0), new WymaganiaBudynku(), new TimeSpan(), new EfektBudynku()));
            lb.Add(new Budynek(1, new KosztBudynku(500, 50, 0), new WymaganiaBudynku(_wplywy: 14, _inteligencja: 5), new TimeSpan(0, 4, 0), new EfektBudynku(_zycieWAtaku: 15, _obrazeniaWAtaku: 1)));
            lb.Add(new Budynek(2, new KosztBudynku(850, 85, 0), new WymaganiaBudynku(_wplywy: 20, _inteligencja: 10), new TimeSpan(0, 4, 49), new EfektBudynku(_zycieWAtaku: 32, _obrazeniaWAtaku: 2)));
            lb.Add(new Budynek(3, new KosztBudynku(1444, 144, 0), new WymaganiaBudynku(_wplywy: 26, _inteligencja: 15), new TimeSpan(0, 5, 45), new EfektBudynku(_zycieWAtaku: 60, _obrazeniaWAtaku: 3)));

            return lb;
        }

        public static List<Budynek> UtworzZbrojownia(List<Budynek> lb)
        {
            // Lista poziomów Zbrojowni
            lb.Add(new Budynek(0, new KosztBudynku(0, 0, 0), new WymaganiaBudynku(), new TimeSpan(), new EfektBudynku()));
            lb.Add(new Budynek(1, new KosztBudynku(1000, 0, 10), new WymaganiaBudynku(_wiedza: 8), new TimeSpan(0, 20, 0), new EfektBudynku(_miejsceWZbrojowni: 10)));
            lb.Add(new Budynek(2, new KosztBudynku(1400, 0, 15), new WymaganiaBudynku(_wiedza: 12), new TimeSpan(0, 24, 0), new EfektBudynku(_miejsceWZbrojowni: 15)));
            lb.Add(new Budynek(3, new KosztBudynku(1959, 0, 22), new WymaganiaBudynku(_wiedza: 16), new TimeSpan(0, 28, 48), new EfektBudynku(_miejsceWZbrojowni: 20)));

            return lb;
        }

        public static List<Budynek> UtworzStaryRynek(List<Budynek> lb)
        {
            // Lista Poziomów Sterego Rynku
            lb.Add(new Budynek(0, new KosztBudynku(0, 0, 0), new WymaganiaBudynku(), new TimeSpan(), new EfektBudynku()));
            lb.Add(new Budynek(1, new KosztBudynku(20000, 8000, 2000), new WymaganiaBudynku(_wyglad: 30, _wiedza: 25, _domPubliczny: 7), new TimeSpan(1, 0, 0), new EfektBudynku(_iloscOfert: 4, _iloscOfertDodatek: 1)));

            return lb;
        }

        public static List<Budynek> UtworzPostojTaxi(List<Budynek> lb)
        {
            // Lista poziomów Postoju Taxi
            lb.Add(new Budynek(0, new KosztBudynku(0, 0, 0), new WymaganiaBudynku(), new TimeSpan(0, 0, 0), new EfektBudynku()));
            lb.Add(new Budynek(1, new KosztBudynku(1300, 20, 120), new WymaganiaBudynku(_wplywy: 13, _wiedza: 12), new TimeSpan(0, 30, 0), new EfektBudynku(_szybkoscTaxi: 1)));
            lb.Add(new Budynek(2, new KosztBudynku(6500, 100, 600), new WymaganiaBudynku(_wplywy: 28, _wiedza: 22), new TimeSpan(1, 30, 0), new EfektBudynku(_szybkoscTaxi: 1)));

            return lb;
        }

        public static string[] PokazKoszta(List<Budynek> lb, int poziom)
        {
            // Funkcja zwraca koszta wybranego poziomu rozbudowy budynku oraz łączne koszta rozbudowy do wybranego poziomu w postaci tablicy string'ów
            string[] koszta = new string[] { "", "" };

            // Obliczenie kosztów wybranego poziomu - index 0
            if ((poziom <= (lb.Count - 1)) && (poziom != 0))
            {
                if (lb[poziom].Koszt.Pieniadze != 0) koszta[0] = Convert.ToString(lb[poziom].Koszt.Pieniadze) + " PLN\n";
                if (lb[poziom].Koszt.Ludzie != 0) koszta[0] += Convert.ToString(lb[poziom].Koszt.Ludzie) + " ludzi\n";
                if (lb[poziom].Koszt.Krew != 0) koszta[0] += Convert.ToString(lb[poziom].Koszt.Krew) + " litrów krwi";
            }
            else if (poziom == 0) koszta[0] = "Brak";
            else koszta[0] = "? PLN\n? ludzi\n? litrów krwi";

            // Obliczenie łącznych kosztów wszystkich poziomów - index 1
            if ((poziom > 1) && (poziom <= (lb.Count - 1)))
            {
                int poziom2 = poziom - 1;
                int p = lb[poziom].Koszt.Pieniadze;
                int l = lb[poziom].Koszt.Ludzie;
                int k = lb[poziom].Koszt.Krew;

                while (poziom2 > 0)
                {
                    // Sumowanie kosztów poprzednich poziomów
                    p += lb[poziom2].Koszt.Pieniadze;
                    l += lb[poziom2].Koszt.Ludzie;
                    k += lb[poziom2].Koszt.Krew;
                    poziom2--;
                }

                if (p != 0) koszta[1] = Convert.ToString(p) + " PLN\n";
                if (l != 0) koszta[1] += Convert.ToString(l) + " ludzi\n";
                if (k != 0) koszta[1] += Convert.ToString(k) + " litrów krwi";
            }
            else koszta[1] = koszta[0];

            return koszta;
        }

        public static string PokazWymagania(List<Budynek> lb, int poziom, int latwosc)
        {
            // Funkcja zwraca wymagania do rozbudowania wybranego poziomu budynku w postaci string'a
            string wymagania = "";

            if ((poziom <= (lb.Count - 1)) && (poziom != 0))
            {
                if (latwosc != 0)
                {
                    if (lb[poziom].Wymagania.Sila != 0) wymagania = "Siła: " + Convert.ToString(Math.Round((double)lb[poziom].Wymagania.Sila * (100d - (double)latwosc) / 100d)) + " (" + Convert.ToString(lb[poziom].Wymagania.Sila) + ")\n";
                    if (lb[poziom].Wymagania.Zwinnosc != 0) wymagania += "Zwinność: " + Convert.ToString(Math.Round((double)lb[poziom].Wymagania.Zwinnosc * (100d - (double)latwosc) / 100d)) + " (" + Convert.ToString(lb[poziom].Wymagania.Zwinnosc) + ")\n";
                    if (lb[poziom].Wymagania.Odpornosc != 0) wymagania += "Odporność: " + Convert.ToString(Math.Round((double)lb[poziom].Wymagania.Odpornosc * (100d - (double)latwosc) / 100d)) + " (" + Convert.ToString(lb[poziom].Wymagania.Odpornosc) + ")\n";
                    if (lb[poziom].Wymagania.Wyglad != 0) wymagania += "Wygląd: " + Convert.ToString(Math.Round((double)lb[poziom].Wymagania.Wyglad * (100d - (double)latwosc) / 100d)) + " (" + Convert.ToString(lb[poziom].Wymagania.Wyglad) + ")\n";
                    if (lb[poziom].Wymagania.Charyzma != 0) wymagania += "Charyzma: " + Convert.ToString(Math.Round((double)lb[poziom].Wymagania.Charyzma * (100d - (double)latwosc) / 100d)) + " (" + Convert.ToString(lb[poziom].Wymagania.Charyzma) + ")\n";
                    if (lb[poziom].Wymagania.Wplywy != 0) wymagania += "Wpływy: " + Convert.ToString(Math.Round((double)lb[poziom].Wymagania.Wplywy * (100d - (double)latwosc) / 100d)) + " (" + Convert.ToString(lb[poziom].Wymagania.Wplywy) + ")\n";
                    if (lb[poziom].Wymagania.Spostrzegawczosc != 0) wymagania += "Spostrzegawczość: " + Convert.ToString(Math.Round((double)lb[poziom].Wymagania.Spostrzegawczosc * (100d - (double)latwosc) / 100d)) + " (" + Convert.ToString(lb[poziom].Wymagania.Spostrzegawczosc) + ")\n";
                    if (lb[poziom].Wymagania.Inteligencja != 0) wymagania += "Inteligencja: " + Convert.ToString(Math.Round((double)lb[poziom].Wymagania.Inteligencja * (100d - (double)latwosc) / 100d)) + " (" + Convert.ToString(lb[poziom].Wymagania.Inteligencja) + ")\n";
                    if (lb[poziom].Wymagania.Wiedza != 0) wymagania += "Wiedza: " + Convert.ToString(Math.Round((double)lb[poziom].Wymagania.Wiedza * (100d - (double)latwosc) / 100d)) + " (" + Convert.ToString(lb[poziom].Wymagania.Wiedza) + ")\n";
                    if (lb[poziom].Wymagania.DomPubliczny != 0) wymagania += "Dom Publiczny: " + Convert.ToString(lb[poziom].Wymagania.DomPubliczny) + '\n';
                }
                else
                {
                    if (lb[poziom].Wymagania.Sila != 0) wymagania = "Siła: " + Convert.ToString(lb[poziom].Wymagania.Sila) + '\n';
                    if (lb[poziom].Wymagania.Zwinnosc != 0) wymagania += "Zwinność: " + Convert.ToString(lb[poziom].Wymagania.Zwinnosc) + '\n';
                    if (lb[poziom].Wymagania.Odpornosc != 0) wymagania += "Odporność: " + Convert.ToString(lb[poziom].Wymagania.Odpornosc) + '\n';
                    if (lb[poziom].Wymagania.Wyglad != 0) wymagania += "Wygląd: " + Convert.ToString(lb[poziom].Wymagania.Wyglad) + '\n';
                    if (lb[poziom].Wymagania.Charyzma != 0) wymagania += "Charyzma: " + Convert.ToString(lb[poziom].Wymagania.Charyzma) + '\n';
                    if (lb[poziom].Wymagania.Wplywy != 0) wymagania += "Wpływy: " + Convert.ToString(lb[poziom].Wymagania.Wplywy) + '\n';
                    if (lb[poziom].Wymagania.Spostrzegawczosc != 0) wymagania += "Spostrzegawczość: " + Convert.ToString(lb[poziom].Wymagania.Spostrzegawczosc) + '\n';
                    if (lb[poziom].Wymagania.Inteligencja != 0) wymagania += "Inteligencja: " + Convert.ToString(lb[poziom].Wymagania.Inteligencja) + '\n';
                    if (lb[poziom].Wymagania.Wiedza != 0) wymagania += "Wiedza: " + Convert.ToString(lb[poziom].Wymagania.Wiedza) + '\n';
                    if (lb[poziom].Wymagania.DomPubliczny != 0) wymagania += "Dom Publiczny: " + Convert.ToString(lb[poziom].Wymagania.DomPubliczny) + '\n';
                }
            }
            else if (poziom == 0) wymagania = "Brak";
            else wymagania = "Brak danych";

            return wymagania;
        }

        public static string PokazCzasBudowy(List<Budynek> lb, int poziom, int poziomPosredniaka, List<Budynek> lPosredniak)
        {
            // Funkcja zwraca czas rozbudowy budynku w postaci string'a
            TimeSpan czas = new TimeSpan();
            long multilpier = 0;
            bool brakDanych = false;

            string przerobionyCzas = "";

            if ((poziom <= (lb.Count - 1)) && (poziom != 0))
            {
                if (poziomPosredniaka == 0) czas = lb[poziom].CzasBudowy;
                else if (poziomPosredniaka > (lPosredniak.Count - 1))
                {
                    czas = lb[poziom].CzasBudowy; // + brak danych odnośnie pośredniaka
                    brakDanych = true;
                }
                else
                {
                    multilpier = (long)100 - (long)lPosredniak[poziomPosredniaka].Efekt.czasBudowy;
                    czas = TimeSpan.FromTicks(((lb[poziom].CzasBudowy.Ticks) * multilpier) / (long)100);
                }
            }
            else if (poziom == 0) czas = new TimeSpan();
            else czas = new TimeSpan(0, 0, 0, 0, 1); // 1 milisekunda = Brak danych

            // Przerób czas do postaci stringa
            if (czas.Days != 0)
            {
                if (czas.Days == 1) przerobionyCzas += Convert.ToString(czas.Hours) + " dzień ";
                else przerobionyCzas += Convert.ToString(czas.Days) + " dni ";
            }
            if (czas.Hours != 0)
            {
                if (czas.Hours == 1) przerobionyCzas += Convert.ToString(czas.Hours) + " godzina ";
                else if (((czas.Hours > 1) && (czas.Hours < 5)) || ((czas.Hours > 20) && ((czas.Hours % 10) > 1) && ((czas.Hours % 10) < 5))) przerobionyCzas += Convert.ToString(czas.Hours) + " godziny ";
                else przerobionyCzas += Convert.ToString(czas.Hours) + " godzin ";
            }
            if (czas.Minutes != 0)
            {
                if (czas.Minutes == 1) przerobionyCzas += Convert.ToString(czas.Minutes) + " minuta ";
                else if (((czas.Minutes > 1) && (czas.Minutes < 5)) || ((czas.Minutes > 20) && ((czas.Minutes % 10) > 1) && ((czas.Minutes % 10) < 5))) przerobionyCzas += Convert.ToString(czas.Minutes) + " minuty ";
                else przerobionyCzas += Convert.ToString(czas.Minutes) + " minut ";
            }
            if (czas.Seconds != 0)
            {
                if (czas.Seconds == 1) przerobionyCzas += Convert.ToString(czas.Seconds) + " sekunda";
                else if (((czas.Seconds > 1) && (czas.Seconds < 5)) || ((czas.Seconds > 20) && ((czas.Seconds % 10) > 1) && ((czas.Seconds % 10) < 5))) przerobionyCzas += Convert.ToString(czas.Seconds) + " sekundy";
                else przerobionyCzas += Convert.ToString(czas.Seconds) + " sekund";
            }

            if (czas.Milliseconds == 1) przerobionyCzas = "Brak danych";
            else if (przerobionyCzas == "") przerobionyCzas = "Brak"; // Days = 0, Hours = 0, Minutes = 0, Seconds = 0, Miliseconds = 0

            if (brakDanych == true) przerobionyCzas += " (Brak danych rozbudowy pośredniaka)";

            return przerobionyCzas;
        }

        public static string PokazEfekty(List<Budynek> lb, int poziom)
        {
            // Funkcja zwraca aktywne efekty rozbudowanego budynku w postaci string'a
            string efekty = ""; // Przygotowane zmienne zwracające efekty budynku w pistaci stringa

            if (poziom <= (lb.Count - 1))
            {
                if (lb[poziom].Efekt.przyrostLudzi != 0)
                {
                    // Przyrost ludzi
                    if (poziom > 0) efekty += "+" + Convert.ToString(lb[poziom].Efekt.przyrostLudzi) + " ludzi / h (+" + Convert.ToString(lb[poziom].Efekt.przyrostLudzi + lb[0].Efekt.przyrostLudzi) + " ludzi / h)\n";
                    else efekty += "+" + Convert.ToString(lb[poziom].Efekt.przyrostLudzi) + " ludzi / h\n";
                }
                if (lb[poziom].Efekt.przyrostKasy != 0)
                {
                    // Przyrost pieniędzy
                    if (poziom > 0) efekty += "+" + Convert.ToString(lb[poziom].Efekt.przyrostKasy) + " PLN / h (+" + Convert.ToString(lb[poziom].Efekt.przyrostKasy + lb[0].Efekt.przyrostKasy) + " PLN / h)\n";
                    else efekty += "+" + Convert.ToString(lb[poziom].Efekt.przyrostKasy) + " PLN / h\n";
                }
                if (lb[poziom].Efekt.przyrostKrwi != 0)
                {
                    // Przyrost krwi
                    if (poziom > 0) efekty += "+" + Convert.ToString(lb[poziom].Efekt.przyrostKrwi) + " litrów krwi / h (+" + Convert.ToString(lb[poziom].Efekt.przyrostKrwi + lb[0].Efekt.przyrostKrwi) + " litrów krwi / h)\n";
                    else efekty += "+" + Convert.ToString(lb[poziom].Efekt.przyrostKrwi) + " litrów krwi / h\n";
                }
                if (lb[poziom].Efekt.czasBudowy != 0) efekty += "Skraca czas budowy wszystkich budynków o " + Convert.ToString(lb[poziom].Efekt.czasBudowy) + "%\n";
                if (lb[poziom].Efekt.spostWZasadzce != 0) efekty += "Spostrzegawczość w trakcie zasadzki zwiększona o " + Convert.ToString(lb[poziom].Efekt.spostWZasadzce) + "\n";
                if (lb[poziom].Efekt.wplywyWZasadzce != 0) efekty += "+" + Convert.ToString(lb[poziom].Efekt.wplywyWZasadzce) + " do Wpływów w czasie ataku\n";
                if (lb[poziom].Efekt.zycieWObronie != 0) efekty += "+" + Convert.ToString(lb[poziom].Efekt.zycieWObronie) + " do PKT ŻYCIA w obronie przed zasadzką\n";
                if (lb[poziom].Efekt.zycieWAtaku != 0) efekty += "+" + Convert.ToString(lb[poziom].Efekt.zycieWAtaku) + " do PKT ŻYCIA w czasie ataku\n";
                if (lb[poziom].Efekt.obrazeniaWAtaku != 0) efekty += "Obrażenia wszystkich broni +" + Convert.ToString(lb[poziom].Efekt.obrazeniaWAtaku) + " w trakcie zasadzki\n";
                if (lb[poziom].Efekt.szpiegowanie != 0) efekty += "+" + Convert.ToString(lb[poziom].Efekt.szpiegowanie) + " do szpiegowania\n";
                if (lb[poziom].Efekt.miejsceWZbrojowni != 0) efekty += "Miejsce w zbrojowni +" + Convert.ToString(lb[poziom].Efekt.miejsceWZbrojowni) + "\n";
                if (lb[poziom].Efekt.iloscOfert != 0) efekty += "Maksymalna ilość ofert handlowych +" + Convert.ToString(lb[poziom].Efekt.iloscOfert) + "\n";
                if (lb[poziom].Efekt.iloscOfertDodatek != 0) efekty += "Nieużywane oferty handlowe zwiększają ilość wolnego miejsca w zbrojowni\n";
                if (lb[poziom].Efekt.szybkoscTaxi != 0) efekty += "Szybkość Taxi +" + Convert.ToString(lb[poziom].Efekt.szybkoscTaxi) + "\n";

                if (efekty == "") efekty = "Brak"; // Nie ma żadnego z powyższych efektów = brak efektów
            }
            else efekty = "Brak danych";

            return efekty;
        }
    }

    public class KosztBudynku
    {
        // Klasa kosztu rozbudowy budynku
        public KosztBudynku(int _pieniadze, int _ludzie, int _krew)
        {
            this.Pieniadze = _pieniadze;
            this.Ludzie = _ludzie;
            this.Krew = _krew;
        }

        public int Pieniadze; // Ilość wymaganych pieniędzy do rozbudowy
        public int Ludzie; // Ilość wymaganych ludzi do rozbudowy
        public int Krew; // Ilość wymaganych litrów krwi do rozbudowy
    }

    public class WymaganiaBudynku
    {
        // Klasa wymagań statystyk postaci / rozbudowy innych budynków do rozbudowy danego budynku
        public WymaganiaBudynku(int _sila = 0, int _zwinnosc = 0, int _odpornosc = 0, int _wyglad = 0, int _charyzma = 0, int _wplywy = 0, int _spostrzegawczosc = 0, int _inteligencja = 0, int _wiedza = 0, int _domPubliczny = 0)
        {
            this.Sila = _sila;
            this.Zwinnosc = _zwinnosc;
            this.Odpornosc = _odpornosc;
            this.Wyglad = _wyglad;
            this.Charyzma = _charyzma;
            this.Wplywy = _wplywy;
            this.Spostrzegawczosc = _spostrzegawczosc;
            this.Inteligencja = _inteligencja;
            this.Wiedza = _wiedza;
            this.DomPubliczny = _domPubliczny;
        }

        public int Sila; // Wymagania statystyki Siły
        public int Zwinnosc; // Wymagania statystyki Zwinności
        public int Odpornosc; // Wymagania statystyki Odporności
        public int Wyglad; // Wymagania statystyki Wyglądu
        public int Charyzma; // Wymagania statystyki Charyzmy
        public int Wplywy; // Wymagania statystyki Wpływów
        public int Spostrzegawczosc; // Wymagania statystyki Spostrzegawczości
        public int Inteligencja; // Wymagania statystyki Inteligencji
        public int Wiedza; // Wymagania statystyki Wiedzy
        public int DomPubliczny; // Wymagania rozbudowy budynku - Dom Publiczny
    }

    public class EfektBudynku
    {
        // Klasa efektu rozbudowy budynku
        public EfektBudynku(int _przyrostLudzi = 0, int _przyrostKasy = 0, int _przyrostKrwi = 0, int _czasBudowy = 0, int _spostWZasadzce = 0, int _wplywyWZasadzce = 0, int _zycieWObronie = 0, int _zycieWAtaku = 0,
            int _obrazeniaWAtaku = 0, int _szpiegowanie = 0, int _miejsceWZbrojowni = 0, int _iloscOfert = 0, int _iloscOfertDodatek = 0, int _szybkoscTaxi = 0)
        {
            this.przyrostLudzi = _przyrostLudzi;
            this.przyrostKasy = _przyrostKasy;
            this.przyrostKrwi = _przyrostKrwi;
            this.czasBudowy = _czasBudowy;
            this.spostWZasadzce = _spostWZasadzce;
            this.wplywyWZasadzce = _wplywyWZasadzce;
            this.zycieWObronie = _zycieWObronie;
            this.zycieWAtaku = _zycieWAtaku;
            this.obrazeniaWAtaku = _obrazeniaWAtaku;
            this.szpiegowanie = _szpiegowanie;
            this.miejsceWZbrojowni = _miejsceWZbrojowni;
            this.iloscOfert = _iloscOfert;
            this.iloscOfertDodatek = _iloscOfertDodatek;
            this.szybkoscTaxi = _szybkoscTaxi;
        }
        
        public int przyrostLudzi; // "+x ludzi / h"
        public int przyrostKasy; // "+x PLN / h"
        public int przyrostKrwi; // "+x litrów krwi / h"
        public int czasBudowy; // "skraca czas budowy wszystkich budynków o x%"
        public int spostWZasadzce; // "Spostrzegawczość w trakcie zasadzki zwiększona o x"
        public int wplywyWZasadzce; // "+x do Wpływów w czasie ataku"
        public int zycieWObronie; // "+x do PKT ŻYCIA w obronie przed zasadzką"
        public int zycieWAtaku; // "+x do PKT ŻYCIA w czasie ataku"
        public int obrazeniaWAtaku; // "obrażenia wszystkich broni +x w trakcie zasadzki
        public int szpiegowanie; // "+x do szpiegowania"
        public int miejsceWZbrojowni; // "miejsce w zbrojowni +x"
        public int iloscOfert; // "maksymalna ilość ofert handlowych +x"
        public int iloscOfertDodatek; // "nieużywane oferty handlowe zwiększają ilość wolnego miejsca w zbrojowni"
        public int szybkoscTaxi; // "szybkość Taxi +x"
    }
}
