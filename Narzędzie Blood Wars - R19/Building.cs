using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Narzędzie_Blood_Wars___R19
{
    class Building
    {
        public Building(KosztBudynku _koszt, WymaganiaBudynku _wymagania, TimeSpan _czas, EfektBudynku _efekt)
        {
            this.Koszt = _koszt;
            this.Wymagania = _wymagania;
            this.CzasBudowy = _czas;
            this.Efekt = _efekt;
        }

        public KosztBudynku Koszt; // Koszt ulepszenia budynku (pieniądze, ludzie, krew)
        public WymaganiaBudynku Wymagania; // Wymagania do ulepszenia budynku
        public TimeSpan CzasBudowy; // Czas rozbudowy budynku
        public EfektBudynku Efekt; // Efekt budynku

        public static List<string> Buildings = new List<string>() { "-- STREFA 5 --", "Pośredniak", "Dom Publiczny", "Rzeźnia", "Posterunek Policji", "Schronisko dla Bezdomnych", "Agencja Ochrony", "Zbrojownia", "Stary Rynek", "Postój Taxi",
                                                                    "-- STREFA 4 --", "Garnizon", "Handlarz Bronią", "Pogotowie", "Lombard",
                                                                    "-- STREFA 3 --", "Dziennik Lokalny \"Nocna Zmiana\"", "Szpital",
                                                                    "-- STREFA 2 --", "Cmentarz", "Bank Krwi",
                                                                    "-- STREFA 1 --", "Katedra" };

        public static Building Wyswietl(int indeks, int _poziom)
        {
            Building budynek = new Building(new KosztBudynku(), new WymaganiaBudynku(), new TimeSpan(0), new EfektBudynku());
            int poziom = _poziom - 1;
            double[] wspolczynnik = new double[] { 0d, 0d, 0d, 0d, 0d }; // Pieniądze, ludzie, krew, czas budowy, start index czasu budowy

            switch (indeks)
            {
                case 1:
                    // Pośredniak
                    if (poziom >= 0)
                    {
                        budynek.Koszt.Pieniadze = 500d; // Baza 500, wspołczynnik *1.5 na poziom
                        budynek.Koszt.AllPieniadze += budynek.Koszt.Pieniadze;
                        wspolczynnik[0] = 1.5d;
                        budynek.Koszt.Ludzie = 10d; // Baza 10, wpsółczynnik *1.55 na poziom
                        budynek.Koszt.AllLudzie += budynek.Koszt.Ludzie;
                        wspolczynnik[1] = 1.55d;
                        wspolczynnik[2] = 0d;
                        budynek.Wymagania.Inteligencja = 5 + (2 * poziom); // Baza 5, współczynnik +2 na poziom
                        budynek.Efekt.PrzyrostLudzi = 15; // Baza 15, współczynnik *1.175 na poziom do 14 poziomu budynku od 15 poziomu *1.18
                        for (int i = 0; i < poziom; i++)
                        {
                            if (i < 14) budynek.Efekt.PrzyrostLudzi *= 1.175d;
                            else budynek.Efekt.PrzyrostLudzi *= 1.18d;
                        }
                        budynek.Efekt.CzasBudowy = 2 * (poziom + 1);
                        if (budynek.Efekt.CzasBudowy > 80) budynek.Efekt.CzasBudowy = 80; // Max 80% redukcji czasu budowy
                        if (poziom == 0) budynek.CzasBudowy = new TimeSpan(0, 0, 10); // Czas budowy - baza 7min 48sek na poziomie 2, współczynnik *120% co poziom
                        else budynek.CzasBudowy = new TimeSpan(0, 7, 48);
                        wspolczynnik[3] = 1.2d;
                        wspolczynnik[4] = 2; // Zacznij obliczanie czasu od poziomu 2
                    }
                    break;

                case 2:
                    // Dom Publiczny
                    if (poziom >= 0)
                    {
                        budynek.Koszt.Pieniadze = 200d; // Baza 200, współczynnik *1.65 na poziom
                        budynek.Koszt.AllPieniadze += budynek.Koszt.Pieniadze;
                        wspolczynnik[0] = 1.65d;
                        budynek.Koszt.Ludzie = 30d; // Baza 30, współczynnik *1.8 na poziom
                        budynek.Koszt.AllLudzie += budynek.Koszt.Ludzie;
                        wspolczynnik[1] = 1.8d;
                        wspolczynnik[2] = 0d;
                        budynek.Wymagania.Wplywy = 8 + (4 * poziom); // Baza 8, współczynnik +4 na poziom
                        budynek.Wymagania.Inteligencja = 6 + (3 * poziom); // Baza 6, współczynnik +3 na poziom
                        budynek.Efekt.PrzyrostKasy = 120d; // Baza 120, współczynnik *1.2 na poziom
                        for (int i = 0; i < poziom; i++) budynek.Efekt.PrzyrostKasy *= 1.2d;
                        if (poziom == 0) budynek.CzasBudowy = new TimeSpan(0, 0, 10); // Czas budowy - baza 6min 36sek na poziomie 2, współczynnik *120% co poziom
                        else budynek.CzasBudowy = new TimeSpan(0, 6, 36);
                        wspolczynnik[3] = 1.2d;
                        wspolczynnik[4] = 2d; // Zacznij obliczanie czasu od poziomu 2
                    }
                    break;

                case 3:
                    // Rzeźnia
                    if (poziom >= 0)
                    {
                        budynek.Koszt.Pieniadze = 400d; // Baza 400, współczynnik *1.65 na poziom
                        budynek.Koszt.AllPieniadze += budynek.Koszt.Pieniadze;
                        wspolczynnik[0] = 1.65d;
                        budynek.Koszt.Ludzie = 100d; // Baza 100, współczynnik *1.5 na poziom
                        budynek.Koszt.AllLudzie += budynek.Koszt.Ludzie;
                        wspolczynnik[1] = 1.5d;
                        wspolczynnik[2] = 0d;
                        budynek.Wymagania.Sila = 7 + (4 * poziom); // Baza 7, współczynnik +4 na poziom
                        budynek.Efekt.PrzyrostKrwi = 20 + (5 * poziom); // Baza 20, współczynnik +5 na poziom
                        if (poziom == 0) budynek.CzasBudowy = new TimeSpan(0, 0, 10); // Czas budowy - baza 9min 36sek na poziomie 2, współczynnik *120% co poziom
                        else budynek.CzasBudowy = new TimeSpan(0, 9, 36);
                        wspolczynnik[3] = 1.2d;
                        wspolczynnik[4] = 2; // Zacznij obliczanie czasu od poziomu 2
                    }
                    break;

                case 4:
                    // Posterunek Policji
                    if (poziom >= 0)
                    {
                        budynek.Koszt.Pieniadze = 2000d; // Baza 2000, współczynnik *1.6 na poziom
                        budynek.Koszt.AllPieniadze += budynek.Koszt.Pieniadze;
                        wspolczynnik[0] = 1.6d;
                        budynek.Koszt.Ludzie = 70d; // Baza 70, współczynnik *1.7 na poziom
                        budynek.Koszt.AllLudzie += budynek.Koszt.Ludzie;
                        wspolczynnik[1] = 1.7d;
                        wspolczynnik[2] = 0d;
                        budynek.Wymagania.Charyzma = 20 + (9 * poziom); // Baza 20, współczynnik +9 na poziom
                        budynek.Wymagania.Wiedza = 11 + (5 * poziom); // Baza 11, współczynnik +5 na poziom
                        budynek.Efekt.SpostWZasadzce = poziom + 1; // +poziom spostrzegawczości w zasadzce
                        budynek.Efekt.ZycieWObroniePP = poziom + 1; // życie w obronie = wartość charyzmy * poziom budynku
                        budynek.CzasBudowy = new TimeSpan(0, 5, 0); // Czas budowy - baza 5min, współczynnik *120% co poziom
                        wspolczynnik[3] = 1.2d;
                        wspolczynnik[4] = 1; // Zacznij obliczanie czasu od poziomu 1
                    }
                    break;

                case 5:
                    // Schronisko dla Bezdomnych
                    if (poziom >= 0)
                    {
                        budynek.Koszt.Pieniadze = 200d; // Baza 200, współczynnik *2 na poziom
                        budynek.Koszt.AllPieniadze += budynek.Koszt.Pieniadze;
                        wspolczynnik[0] = 2d;
                        budynek.Koszt.Ludzie = 2d; // Baza 2, współczynnik *2.1 na poziom
                        budynek.Koszt.AllLudzie += budynek.Koszt.Ludzie;
                        wspolczynnik[1] = 2.1d;
                        wspolczynnik[2] = 0d;
                        budynek.Wymagania.Inteligencja = 10 + (7 * poziom); // Baza 10, współczynnik +7 na poziom
                        budynek.Wymagania.Wiedza = 10 + (8 * poziom); // Baza 10, współczynnik +8 na poziom
                        budynek.Efekt.Szpiegowanie = 2 * (poziom + 1); // współczynnik +2 na poziom
                        budynek.Efekt.WplywyWZasadzce = poziom + 1; // +poziom wpływów w zasadzce
                        budynek.CzasBudowy = new TimeSpan(0, 4, 30); // Czas budowy - baza 4min 30sek, współczynnik *120% co poziom
                        wspolczynnik[3] = 1.2d;
                        wspolczynnik[4] = 1; // Zacznij obliczanie czasu od poziomu 1
                    }
                    break;

                case 6:
                    // Agencja Ochrony
                    if (poziom >= 0)
                    {
                        budynek.Koszt.Pieniadze = 500d; // Baza 500, współczynnik *1.7 na poziom
                        budynek.Koszt.AllPieniadze += budynek.Koszt.Pieniadze;
                        wspolczynnik[0] = 1.7d;
                        budynek.Koszt.Ludzie = 50d; // Baza 2, współczynnik *1.7 na poziom
                        budynek.Koszt.AllLudzie += budynek.Koszt.Ludzie;
                        wspolczynnik[1] = 1.7d;
                        wspolczynnik[2] = 0d;
                        budynek.Wymagania.Wplywy = 14 + (6 * poziom); // Baza 14, współczynnik +6 na poziom
                        budynek.Wymagania.Inteligencja = 5 + (5 * poziom); // Baza 5, współczynnik +5 na poziom
                        budynek.Efekt.ZycieWAtakuAO = poziom + 1; // życie w ataku = wartość wpływów * poziom budynku
                        budynek.Efekt.ObrazeniaWAtaku = poziom + 1; // +poziom obrażen w ataku
                        budynek.CzasBudowy = new TimeSpan(0, 4, 0); // Czas budowy - baza 4min, współczynnik *120% co poziom
                        wspolczynnik[3] = 1.2d;
                        wspolczynnik[4] = 1;
                    }
                    break;

                case 7:
                    // Zbrojownia
                    if (poziom >= 0)
                    {
                        if (poziom > 14)
                        {
                            poziom = 14; // Max poziom budynku = 15
                            budynek.Efekt.MaxLvl = 15;
                        }
                        budynek.Koszt.Pieniadze = 1000d; // Baza 1000, współczynnik *1.4 na poziom
                        budynek.Koszt.AllPieniadze += budynek.Koszt.Pieniadze;
                        wspolczynnik[0] = 1.4d;
                        wspolczynnik[1] = 0d;
                        budynek.Koszt.Krew = 10d; // Baza 10, współczynnik *1.5 na poziom
                        budynek.Koszt.AllKrew += budynek.Koszt.Krew;
                        wspolczynnik[2] = 1.5d;
                        budynek.Wymagania.Wiedza = 8 + (4 * poziom); // Baza 8, współczynnik +4 na poziom
                        budynek.Efekt.MiejsceWZbrojowni = 5 + (5 * (poziom + 1)); // Baza 10 (min poziom 1), współczynnik +5 na poziom
                        budynek.CzasBudowy = new TimeSpan(0, 20, 0); // Czas budowy - baza 20min, współczynnik *120% co poziom
                        wspolczynnik[3] = 1.2d;
                        wspolczynnik[4] = 1;
                    }
                    break;

                case 8:
                    // Stary Rynek
                    if (poziom >= 0)
                    {
                        if (poziom > 4)
                        {
                            poziom = 4; // Max poziom budynku = 5
                            budynek.Efekt.MaxLvl = 5;
                        }
                        budynek.Koszt.Pieniadze = 20000d; // Baza 20000, współczynnik *3 na poziom
                        budynek.Koszt.AllPieniadze += budynek.Koszt.Pieniadze;
                        wspolczynnik[0] = 3d;
                        budynek.Koszt.Ludzie = 8000d; // Baza 8000, współczynnik *3 na poziom
                        budynek.Koszt.AllLudzie += budynek.Koszt.Ludzie;
                        wspolczynnik[1] = 3d;
                        budynek.Koszt.Krew = 2000d; // Baza 2000, współczynnik *3 na poziom
                        budynek.Koszt.AllKrew += budynek.Koszt.Krew;
                        wspolczynnik[2] = 3d;
                        budynek.Wymagania.Wyglad = 30 + (10 * poziom); // Baza 30, współczynnik +10 na poziom
                        budynek.Wymagania.Wiedza = 25 + (10 * poziom); // Baza 25, współczynnik +10 na poziom
                        budynek.Wymagania.DomPubliczny = 7; // Min 7 poziom Domu Publicznego
                        budynek.Efekt.IloscOfert = 2 * (poziom + 1); // Ilość ofert +2 na poziom
                        budynek.Efekt.IloscOfertDodatek = 1; // Nieużywane oferty handlowe zwiększają ilość wolnego miejsca w zbrojowni 
                        budynek.CzasBudowy = new TimeSpan(1, 0, 0); // Czas budowy - baza 1godz, współczynnik *150% co poziom
                        wspolczynnik[3] = 1.5d;
                        wspolczynnik[4] = 1;
                    }
                    break;

                case 9:
                    // Postój Taxi
                    if (poziom >= 0)
                    {
                        if (poziom > 4)
                        {
                            poziom = 4; // Max poziom budynku = 5
                            budynek.Efekt.MaxLvl = 5;
                        }
                        budynek.Koszt.Pieniadze = 1300d; // Baza 1300, współczynnik *5 na poziom
                        budynek.Koszt.AllPieniadze += budynek.Koszt.Pieniadze;
                        wspolczynnik[0] = 5d;
                        budynek.Koszt.Ludzie = 20d; // Baza 20, współczynnik *5 na poziom
                        budynek.Koszt.AllLudzie += budynek.Koszt.Ludzie;
                        wspolczynnik[1] = 5d;
                        budynek.Koszt.Krew = 120d; // Baza 120, współczynnik *5 na poziom
                        budynek.Koszt.AllKrew += budynek.Koszt.Krew;
                        wspolczynnik[2] = 5d;
                        budynek.Wymagania.Wplywy = 13 + (15 * poziom); // Baza 13, współczynnik +15 na poziom
                        budynek.Wymagania.Wiedza = 12 + (10 * poziom); // Baza 12, współczynnik +10 na poziom
                        budynek.Efekt.SzybkoscTaxi = poziom + 1; // +poziom szybkość taxi
                        budynek.CzasBudowy = new TimeSpan(0, 30, 0); // Czas budowy - baza 30min, współczynnik *300% co poziom
                        wspolczynnik[3] = 3d;
                        wspolczynnik[4] = 1;
                    }
                    break;

                case 11:
                    // Garnizon
                    if (poziom >= 0)
                    {
                        budynek.Koszt.Pieniadze = 10000d; // Baza 10000, współczynnik *1.25 na poziom
                        budynek.Koszt.AllPieniadze += budynek.Koszt.Pieniadze;
                        wspolczynnik[0] = 1.25d;
                        budynek.Koszt.Ludzie = 1000d; // Baza 1000, współczynnik *1.25 na poziom
                        budynek.Koszt.AllLudzie += budynek.Koszt.Ludzie;
                        wspolczynnik[1] = 1.25d;
                        wspolczynnik[2] = 0d;
                        budynek.Wymagania.Charyzma = 70 + (10 * poziom); // Baza 70, współczynnik +10 na poziom
                        budynek.Wymagania.Wplywy = 70 + (10 * poziom); // Baza 70, współczynnik +10 na poziom
                        budynek.Wymagania.PosterunekPolicji = 10; // Wymaga Posterunku Policji na min 10 poziomie
                        budynek.Efekt.ZycieWObronieGar = poziom + 1; // Wartość życia w obornie = Charyzma * poziom Posterunku Policji * (poziom + 2) * 0.1
                        budynek.CzasBudowy = new TimeSpan(0, 30, 0); // Czas budowy - baza 30min, współczynnik *120% co poziom
                        wspolczynnik[3] = 1.2d;
                        wspolczynnik[4] = 1;
                    }
                    break;

                case 12:
                    // Handlarz Bronią
                    if (poziom >= 0)
                    {
                        budynek.Koszt.Pieniadze = 5000d; // Baza 5000, współczynnik *1.2 na poziom
                        budynek.Koszt.AllPieniadze += budynek.Koszt.Pieniadze;
                        wspolczynnik[0] = 1.2d;
                        budynek.Koszt.Ludzie = 1100d; // Baza 1100, współczynnik *1.2 na poziom
                        budynek.Koszt.AllLudzie += budynek.Koszt.Ludzie;
                        wspolczynnik[1] = 1.2d;
                        wspolczynnik[2] = 0d;
                        budynek.Wymagania.Wplywy = 60 + (10 * poziom); // Baza 60, współczynnik +10 na poziom
                        budynek.Wymagania.Inteligencja = 50 + (10 * poziom); // Baza 50, współczynnik +10 na poziom
                        budynek.Wymagania.AgencjaOchrony = 7; // Wymaga Agencji Ochorny na min 7 poziomie
                        budynek.Efekt.ZycieWAtakuHan = poziom + 1; // Wartość życia w obronie = Wpływy * poziom Agencji Ochrony * (poziom + 3) * 0.1
                        budynek.CzasBudowy = new TimeSpan(0, 25, 0); // Czas budowy - baza 25min, współczynnik *120% co poziom
                        wspolczynnik[3] = 1.2d;
                        wspolczynnik[4] = 1;
                    }
                    break;

                case 13:
                    // Pogotowie
                    if (poziom >= 0)
                    {
                        budynek.Koszt.Pieniadze = 7000d; // Baza 7000, współczynnik *1.5 na poziom
                        budynek.Koszt.AllPieniadze += budynek.Koszt.Pieniadze;
                        wspolczynnik[0] = 1.5d;
                        budynek.Koszt.Ludzie = 600d; // Baza 1100, współczynnik *1.4 na poziom
                        budynek.Koszt.AllLudzie += budynek.Koszt.Ludzie;
                        wspolczynnik[1] = 1.4d;
                        wspolczynnik[2] = 0d;
                        budynek.Wymagania.Charyzma = 60 + (15 * poziom); // Baza 60, współczynnik +15 na poziom
                        budynek.Wymagania.Wiedza = 35 + (7 * poziom); // Baza 35, współczynnik +7 na poziom
                        budynek.Efekt.PrzyrostKrwi = 10; // Baza 10 (dla poziomu 1), współczynnik *1.3 na poziom
                        for (int i = 0; i < poziom; i++) budynek.Efekt.PrzyrostKrwi *= 1.3d;
                        budynek.CzasBudowy = new TimeSpan(0, 40, 0); // Czas budowy - baza 40min, współczynnik *120% co poziom
                        wspolczynnik[3] = 1.2d;
                        wspolczynnik[4] = 1;
                    }
                    break;

                case 14:
                    // Lombard
                    if (poziom >= 0)
                    {
                        budynek.Koszt.Pieniadze = 45000d; // Baza 45000, współczynnik *1.4 na poziom
                        budynek.Koszt.AllPieniadze += budynek.Koszt.Pieniadze;
                        wspolczynnik[0] = 1.4d;
                        budynek.Koszt.Ludzie = 1750d; // Baza 1750, współczynnik *1.4 na poziom
                        budynek.Koszt.AllLudzie += budynek.Koszt.Ludzie;
                        wspolczynnik[1] = 1.4d;
                        wspolczynnik[2] = 0d;
                        budynek.Wymagania.Wiedza = 50 + (10 * poziom); // Baza 50, współczynnik +10 na poziom
                        budynek.Efekt.PrzyrostKasy = 300; // Baza 300 (dla poziomu 1), współczynnik *1.2 na poziom
                        for (int i = 0; i < poziom; i++) budynek.Efekt.PrzyrostKasy *= 1.2d;
                        budynek.CzasBudowy = new TimeSpan(0, 27, 0); // Czas budowy - baza 27min, współczynnik *120% co poziom
                        wspolczynnik[3] = 1.2d;
                        wspolczynnik[4] = 1;
                    }
                    break;

                case 16:
                    // Dziennik Lokalny "Nocna Zmiana"
                    if (poziom >= 0)
                    {
                        budynek.Koszt.Pieniadze = 35000d; // Baza 35000, współczynnik *1.5 na poziom
                        budynek.Koszt.AllPieniadze += budynek.Koszt.Pieniadze;
                        wspolczynnik[0] = 1.5d;
                        budynek.Koszt.Ludzie = 700d; // Baza 700, współczynnik *1.8 na poziom
                        budynek.Koszt.AllLudzie += budynek.Koszt.Ludzie;
                        wspolczynnik[1] = 1.8d;
                        wspolczynnik[2] = 0d;
                        budynek.Wymagania.Wyglad = 42 + (14 * poziom); // Baza 0, współczynnik +0 na poziom
                        budynek.Efekt.EfektSchroniska = 20 + (5 * (poziom + 1)); // Baza 20, współczynnik +5 na poziom
                        budynek.CzasBudowy = new TimeSpan(1, 20, 0); // Czas budowy - baza 0, współczynnik *120% co poziom
                        wspolczynnik[3] = 1.2d;
                        wspolczynnik[4] = 1;
                    }
                    break;

                case 17:
                    // Szpital
                    if (poziom >= 0)
                    {
                        if (poziom > 9)
                        {
                            poziom = 9; // Max poziom budynku = 10
                            budynek.Efekt.MaxLvl = 10;
                        }
                        budynek.Koszt.Pieniadze = 0d; // Baza 0, współczynnik *1 na poziom
                        budynek.Koszt.AllPieniadze += budynek.Koszt.Pieniadze;
                        wspolczynnik[0] = 1d;
                        budynek.Koszt.Ludzie = 0d; // Baza 0, współczynnik *1 na poziom
                        budynek.Koszt.AllLudzie += budynek.Koszt.Ludzie;
                        wspolczynnik[1] = 1d;
                        wspolczynnik[2] = 0d;
                        budynek.Wymagania.Pogotowie = 8; // Wymaga Pogotowia na min 8 poziomie
                        budynek.Efekt.PrzyrostKrwi = 0 + (0 * poziom); // Baza 0, współczynnik +0 na poziom
                        budynek.CzasBudowy = new TimeSpan(1, 5, 0); // Czas budowy - baza 1:05, współczynnik *120% co poziom
                        wspolczynnik[3] = 1.2d;
                        wspolczynnik[4] = 1;
                    }
                    break;

                case 19:
                    // Cmentarz
                    if (poziom >= 0)
                    {
                        if (poziom > 2)
                        {
                            poziom = 2; // Max poziom budynku = 3
                            budynek.Efekt.MaxLvl = 3;
                        }
                        budynek.Koszt.Pieniadze = 0d; // Baza 0, współczynnik *1 na poziom
                        budynek.Koszt.AllPieniadze += budynek.Koszt.Pieniadze;
                        wspolczynnik[0] = 1d;
                        budynek.Koszt.Ludzie = 0d; // Baza 0, współczynnik *1 na poziom
                        budynek.Koszt.AllLudzie += budynek.Koszt.Ludzie;
                        wspolczynnik[1] = 1d;
                        wspolczynnik[2] = 0d;
                        //budynek.Wymagania.Wyglad = 0 + (0 * poziom); // Baza 0, współczynnik +0 na poziom
                        budynek.Efekt.Ofiara = 100 + (10 * (poziom + 1)); // Baza 100, współczynnik +10 na poziom
                        budynek.CzasBudowy = new TimeSpan(0, 0, 0); // Czas budowy - baza 0, współczynnik *100% co poziom
                        wspolczynnik[3] = 1d;
                        wspolczynnik[4] = 1;
                    }
                    break;

                case 20:
                    // Bank Krwi
                    if (poziom >= 0)
                    {
                        budynek.Koszt.Pieniadze = 0d; // Baza 0, współczynnik *1 na poziom
                        budynek.Koszt.AllPieniadze += budynek.Koszt.Pieniadze;
                        wspolczynnik[0] = 1d;
                        budynek.Koszt.Ludzie = 0d; // Baza 0, współczynnik *1 na poziom
                        budynek.Koszt.AllLudzie += budynek.Koszt.Ludzie;
                        wspolczynnik[1] = 1d;
                        wspolczynnik[2] = 0d;
                        budynek.Wymagania.Szpital = 4; // Wymaga rozbudowy Szpitala na min 4 poziom
                        budynek.Efekt.ProdukcjaSzpitala = 10 * (poziom + 1); // Baza 0, współczynnik +10 na poziom
                        budynek.CzasBudowy = new TimeSpan(0, 0, 0); // Czas budowy - baza 0, współczynnik *100% co poziom
                        wspolczynnik[3] = 1d;
                        wspolczynnik[4] = 1;
                    }
                    break;
            }


            // Obliczenie kosztów i czasu budowy dla danego poziomu
            for (int i = 0; i < poziom; i++)
            {
                budynek.Koszt.Pieniadze *= wspolczynnik[0];
                budynek.Koszt.AllPieniadze += budynek.Koszt.Pieniadze;
                budynek.Koszt.Ludzie *= wspolczynnik[1];
                budynek.Koszt.AllLudzie += budynek.Koszt.Ludzie;
                budynek.Koszt.Krew *= wspolczynnik[2];
                budynek.Koszt.AllKrew += budynek.Koszt.Krew;
            }
            for (int i = (int)wspolczynnik[4]; i < poziom + 1; i++)
            {
                budynek.CzasBudowy = TimeSpan.FromTicks((long)(budynek.CzasBudowy.Ticks * wspolczynnik[3]));
            }

            return budynek;
        }

        public string Czas(long skrocenie)
        {
            /// Funkcja zwraca czas rozbudowy budynku w postaci string'a
            string ret = "";
            long skrot = skrocenie;
            if (skrot > 80) skrot = 80;
            TimeSpan czas = TimeSpan.FromTicks((long)(this.CzasBudowy.Ticks * (100 - skrot) / 100));
            if (czas.Days != 0)
            {
                if (czas.Days == 1) ret += czas.Days.ToString() + " dzień ";
                else ret += czas.Days.ToString() + " dni ";
            }
            if (czas.Hours != 0)
            {
                if (czas.Hours == 1) ret += czas.Hours.ToString() + " godzina ";
                else if (((czas.Hours > 1) && (czas.Hours < 5)) || ((czas.Hours > 20) && ((czas.Hours % 10) > 1) && ((czas.Hours % 10) < 5))) ret += czas.Hours.ToString() + " godziny ";
                else ret += czas.Hours.ToString() + " godzin ";
            }
            if (czas.Minutes != 0)
            {
                if (czas.Minutes == 1) ret += czas.Minutes.ToString() + " minuta ";
                else if (((czas.Minutes > 1) && (czas.Minutes < 5)) || ((czas.Minutes > 20) && ((czas.Minutes % 10) > 1) && ((czas.Minutes % 10) < 5))) ret += czas.Minutes.ToString() + " minuty ";
                else ret += czas.Minutes.ToString() + " minut ";
            }
            if (czas.Seconds != 0)
            {
                if (czas.Seconds == 1) ret += czas.Seconds.ToString() + " sekunda";
                else if (((czas.Seconds > 1) && (czas.Seconds < 5)) || ((czas.Seconds > 20) && ((czas.Seconds % 10) > 1) && ((czas.Seconds % 10) < 5))) ret += czas.Seconds.ToString() + " sekundy";
                else ret += czas.Seconds.ToString() + " sekund";
            }
            return ret;
        }
    }


    public class KosztBudynku
    {
        // Klasa kosztu rozbudowy budynku
        public double Pieniadze; // Ilość wymaganych pieniędzy do rozbudowy
        public double Ludzie; // Ilość wymaganych ludzi do rozbudowy
        public double Krew; // Ilość wymaganych litrów krwi do rozbudowy
        public double AllPieniadze; // Łączna ilość wymaganych pieniędzy do rozbudowy budynku do danego poziomu
        public double AllLudzie; // Łączna ilość wymaganych ludzi do rozbudowy budynku do danego poziomu
        public double AllKrew; // Łączna ilość wymaganych litrów krwi do rozbudowy budynku do danego poziomu

        public string ToString(bool single)
        {
            /// Zwraca koszta budowy budynku na dany poziom
            string ret = "";
            if (single == true)
            {
                if (this.Pieniadze > 0) ret = Math.Floor(this.Pieniadze).ToString() + " PLN";
                if (this.Ludzie > 0)
                {
                    if (ret.Length > 0) ret += "\r\n";
                    ret += Math.Floor(this.Ludzie).ToString() + " ludzi";
                }
                if (this.Krew > 0)
                {
                    if (ret.Length > 0) ret += "\r\n";
                    ret += Math.Floor(this.Krew).ToString() + " litrów krwi";
                }
            }
            else
            {
                if (this.AllPieniadze > 0) ret = Math.Floor(this.AllPieniadze).ToString() + " PLN";
                if (this.AllLudzie > 0)
                {
                    if (ret.Length > 0) ret += "\r\n";
                    ret += Math.Floor(this.AllLudzie).ToString() + " ludzi";
                }
                if (this.AllKrew > 0)
                {
                    if (ret.Length > 0) ret += "\r\n";
                    ret += Math.Floor(this.AllKrew).ToString() + " litrów krwi";
                }
            }
            return ret;
        }
    }

    public class WymaganiaBudynku
    {
        // Klasa wymagań statystyk postaci / rozbudowy innych budynków do rozbudowy danego budynku
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
        public int PosterunekPolicji; // Wymagania rozbudowy budynku - Posterunek Policji
        public int AgencjaOchrony; // Wymagania rozbudowy budynku - Agencja Ochrony
        public int Szpital; // Wymaga rozbudowy budynku - Szpital
        public int Pogotowie; // Wymaga rozbudowy budynku - Pogotowie

        public string ToString(double latwosc)
        {
            string ret = "";
            if (this.Sila > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                if (latwosc > 0) ret += "Siła: " + Math.Ceiling(((double)this.Sila * (100d - latwosc)) / 100d).ToString() + " (" + this.Sila.ToString() + ")";
                else ret += "Siła: " + this.Sila.ToString();
            }
            if (this.Zwinnosc > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                if (latwosc > 0) ret += "Zwinność: " + Math.Ceiling(((double)this.Zwinnosc * (100d - latwosc)) / 100d).ToString() + " (" + this.Zwinnosc.ToString() + ")";
                else ret += "Zwinność: " + this.Zwinnosc.ToString();
            }
            if (this.Odpornosc > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                if (latwosc > 0) ret += "Odporność: " + Math.Ceiling(((double)this.Odpornosc * (100d - latwosc)) / 100d).ToString() + " (" + this.Odpornosc.ToString() + ")";
                else ret += "Odporność: " + this.Odpornosc.ToString();
            }
            if (this.Wyglad > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                if (latwosc > 0) ret += "Wygląd: " + Math.Ceiling(((double)this.Wyglad * (100d - latwosc)) / 100d).ToString() + " (" + this.Wyglad.ToString() + ")";
                else ret += "Wygląd: " + this.Wyglad.ToString();
            }
            if (this.Charyzma > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                if (latwosc > 0) ret += "Charyzma: " + Math.Ceiling(((double)this.Charyzma * (100d - latwosc)) / 100d).ToString() + " (" + this.Charyzma.ToString() + ")";
                else ret += "Charyzma: " + this.Charyzma.ToString();
            }
            if (this.Wplywy > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                if (latwosc > 0) ret += "Wpływy: " + Math.Ceiling(((double)this.Wplywy * (100d - latwosc)) / 100d).ToString() + " (" + this.Wplywy.ToString() + ")";
                else ret += "Wpływy: " + this.Wplywy.ToString();
            }
            if (this.Spostrzegawczosc > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                if (latwosc > 0) ret += "Spostrzegawczość: " + Math.Ceiling(((double)this.Spostrzegawczosc * (100d - latwosc)) / 100d).ToString() + " (" + this.Spostrzegawczosc.ToString() + ")";
                else ret += "Spostrzegawczość: " + this.Spostrzegawczosc.ToString();
            }
            if (this.Inteligencja > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                if (latwosc > 0) ret += "Inteligencja: " + Math.Ceiling(((double)this.Inteligencja * (100d - latwosc)) / 100d).ToString() + " (" + this.Inteligencja.ToString() + ")";
                else ret += "Inteligencja: " + this.Inteligencja.ToString();
            }
            if (this.Wiedza > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                if (latwosc > 0) ret += "Wiedza: " + Math.Ceiling(((double)this.Wiedza * (100d - latwosc)) / 100d).ToString() + " (" + this.Wiedza.ToString() + ")";
                else ret += "Wiedza: " + this.Wiedza.ToString();
            }
            if (this.DomPubliczny > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "Dom Publiczny: " + this.DomPubliczny.ToString();
            }
            if (this.PosterunekPolicji > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "Posterunek Policji: " + this.PosterunekPolicji.ToString();
            }
            if (this.AgencjaOchrony > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "Agencja Ochrony: " + this.AgencjaOchrony.ToString();
            }
            if (this.Szpital > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "Szpital: " + this.Szpital.ToString();
            }
            if (this.Pogotowie > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "Pogotowie: " + this.Pogotowie.ToString();
            }
            return ret;
        }
    }

    public class EfektBudynku
    {
        // Klasa efektu rozbudowy budynku
        public double PrzyrostLudzi; // "+x ludzi / h"
        public double PrzyrostKasy; // "+x PLN / h"
        public double PrzyrostKrwi; // "+x litrów krwi / h"
        public int CzasBudowy; // "skraca czas budowy wszystkich budynków o x%"
        public int SpostWZasadzce; // "Spostrzegawczość w trakcie zasadzki zwiększona o x"
        public int WplywyWZasadzce; // "+x do Wpływów w czasie ataku"
        public int ZycieWObroniePP; // "+(Charyzma * poziom budynku) do PKT ŻYCIA w obronie przed zasadzką"
        public int ZycieWObronieGar; // "+(Charyzma * (poziom budynku + 2)) do PKT ŻYCIA w obronie przed zasadzką"
        public int ZycieWAtakuAO; // "+(Wpływy * poziom budynku) do PKT ŻYCIA w czasie ataku"
        public double ZycieWAtakuHan; // +(Wpływy * (poziom budynku + 3)) do PKT ŻYCIA w czasie ataku"
        public int ObrazeniaWAtaku; // "obrażenia wszystkich broni +x w trakcie zasadzki
        public int Szpiegowanie; // "+x do szpiegowania"
        public int MiejsceWZbrojowni; // "miejsce w zbrojowni +x"
        public int IloscOfert; // "maksymalna ilość ofert handlowych +x"
        public int IloscOfertDodatek; // "nieużywane oferty handlowe zwiększają ilość wolnego miejsca w zbrojowni"
        public int SzybkoscTaxi; // "szybkość Taxi +x"
        public int EfektSchroniska; // "efekty schroniska zwiększone o x%"
        public int Ofiara; // "pozwala składać ofiarę, gwarantując x% PKT ŻYCIA na oblężeniu (działa zawsze za darmo w obronie)"
        public int ProdukcjaSzpitala; // "produkcja szpitala zwiększona o x%"
        public int MaxLvl; // Osgiąnieto maksymalny poziom budynku (x)

        public string ToString(int charyzma, int wplywy, int pp, int ao)
        {
            string ret = "";
            if (this.PrzyrostLudzi > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "+" + Math.Floor(this.PrzyrostLudzi).ToString() + " ludzi / h";
            }
            if (this.PrzyrostKasy > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "+" + Math.Floor(this.PrzyrostKasy).ToString() + " PLN / h";
            }
            if (this.PrzyrostKrwi > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "+" + Math.Floor(this.PrzyrostKrwi).ToString() + " litrów krwi / h";
            }
            if (this.CzasBudowy > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "Skraca czas budowy wszystkich budynkow o " + this.CzasBudowy.ToString() + "%";
            }
            if (this.SpostWZasadzce > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "Spostrzegawczość w trakcie zasadzki zwiększona o " + this.SpostWZasadzce.ToString();
            }
            if (this.WplywyWZasadzce > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "+" + this.WplywyWZasadzce.ToString() + " do Wpływów w czasie ataku";
            }
            if (this.ZycieWObroniePP > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "+(Charyzma * " + this.ZycieWObroniePP.ToString() + ") do PKT ŻYCIA w obronie przed zasadzką";
                if (charyzma > 0) ret += "\r\n-> +" + (charyzma * this.ZycieWObroniePP).ToString() + " PKT ŻYCIA w obronie przed zasadzką";
            }
            if (this.ZycieWObronieGar > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "+(Charyzma * poziom Posterunku Policji * (" + this.ZycieWObronieGar.ToString() + " + 2) * 0.1) do PKT ŻYCIA w obronie przed zasadzką";
                if ((charyzma > 0) && (pp > 0)) ret += "\r\n-> +" + (charyzma * pp * (this.ZycieWObronieGar + 2) * 0.1).ToString() + " PKT ŻYCIA w obronie przed zasadzką";
            }
            if (this.ZycieWAtakuAO > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "+(Wpływy * " + this.ZycieWAtakuAO.ToString() + ") do PKT ŻYCIA w czasie ataku";
                if (wplywy > 0) ret += "\r\n-> +" + (wplywy * this.ZycieWAtakuAO).ToString() + " PKT ŻYCIA w czasie ataku";
            }
            if (this.ZycieWAtakuHan > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "+(Wpływy * poziom Agencji Ochrony * (" + this.ZycieWAtakuHan.ToString() + " + 3) * 0.1) do PKT ŻYCIA w czasie ataku";
                if ((wplywy > 0) && (ao > 0)) ret += "\r\n-> +" + (wplywy * ao * (this.ZycieWAtakuHan + 3) * 0.1).ToString() + " PKT ŻYCIA w czasie ataku";
            }
            if (this.ObrazeniaWAtaku > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "Obrażenia wszystkich broni +" + this.ObrazeniaWAtaku.ToString() + " w trakcie zasadzki";
            }
            if (this.Szpiegowanie > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "+" + this.Szpiegowanie.ToString() + " do Szpiegowania";
            }
            if (this.MiejsceWZbrojowni > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "Miejsce w zbrojowni +" + this.MiejsceWZbrojowni.ToString();
            }
            if (this.IloscOfert > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "Maksymalna ilość ofert handlowych +" + this.IloscOfert.ToString();
            }
            if (this.IloscOfertDodatek > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "Nieużywane oferty handlowe zwiększają ilość wolnego miejsca w zbrojowni";
            }
            if (this.SzybkoscTaxi > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "Szybkość Taxi +" + this.SzybkoscTaxi.ToString();
            }
            if (this.EfektSchroniska > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "Efekty schroniska zwiększone o " + this.EfektSchroniska.ToString() + "%";
            }
            if (this.Ofiara > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "Pozwala składać ofiarę, gwarantując " + this.Ofiara.ToString() + "% PKT ŻYCIA na oblężeniu (działa zawsze za darmo w obronie)";
            }
            if (this.ProdukcjaSzpitala > 0)
            {
                if (ret.Length > 0) ret += "\r\n";
                ret += "Produkcja Szpitala zwiększona o " + this.ProdukcjaSzpitala.ToString() + "%";
            }
            if (this.MaxLvl > 0)
            {
                if (ret.Length > 0) ret += "\r\n\r\n";
                ret += "Osiągnięto maksymalny poziom rozbudowy budynku (" + this.MaxLvl.ToString() + ")";
            }
            return ret;
        }
    }
}
