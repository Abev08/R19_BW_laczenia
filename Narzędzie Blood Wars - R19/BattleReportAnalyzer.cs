using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Narzędzie_Blood_Wars___R19
{
    class BattleReportAnalyzer
    {
        public BattleReportAnalyzer(string _nick)
        {
            this.Nick = _nick;
            this.Weapons = new string[] { "", "" };
            this.NumAttack = 0; // Ilość ataków
            this.NumCrits = 0; // Ilość ataków krytycznych
            this.NumHits = 0; // Ilość trafień
            this.NumGotAttacked = 0; // Ilość trafionych otrzymanych ataków
            this.NumMisses = 0; // Ilość chybień (atakujący chybił atak we mnie)
            this.NumDodges = 0; // Ilość uników
            this.NumDmg = 0; // Ilość zadanych obrażeń
            this.NumGotDmg = 0; // Ilość otrzymanych obrażeń
            this.NumRegenHP = 0; // Ilość zregenerowanych PKT ŻYCIA
            this.SpecialAttack = ""; // Nazwa ataku specjalnego
        }

        public string Nick { get; set; }
        public string[] Weapons { get; set; }
        public int NumAttack { get; set; }
        public int NumCrits { get; set; }
        public int NumHits { get; set; }
        public int NumGotAttacked { get; set; }
        public int NumMisses { get; set; }
        public int NumDodges { get; set; }
        public int NumRegenHP { get; set; }
        public int NumDmg { get; set; }
        public int NumGotDmg { get; set; }
        public string SpecialAttack { get; set; }

        public struct BattleResult
        {
            public string Attacker;
            public string Defender;
            public string Effect;
            public List<BattleReportAnalyzer> Participants;
        }

        public static BattleResult Analyze(string input, bool includePackAttack)
        {
            /// Funkcja analizująca raport wejściowy
            BattleResult result = new BattleResult(); // Utworzenie obiektu zwrotnego analizy

            // Wczytanie najważniejszych linii raportu
            List<string> report = new List<string>();
            report = LoadNeededLines(input.Split(new string[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries));

            // Wczytanie uczestników
            List<string> uczestnicyS = new List<string>();
            uczestnicyS = LoadParticipats(input.Split(new string[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries));
            result.Participants = new List<BattleReportAnalyzer>();

            // Przygotowanie listy uczestników z statystykami
            foreach (string s in uczestnicyS) result.Participants.Add(new BattleReportAnalyzer(s));

            // Wyczyść atakujących, obrońców i efekt
            result.Attacker = "Atakujący:";
            result.Defender = "Obrońca:";
            result.Effect = " ";
            bool addedAttacker = false;

            // Interpretacja raportu
            foreach (string s in report)
            {
                if (s.Contains("komendę"))
                {
                    // Komenda specjalna - Atak watahy
                    if (s.Contains("Atak watahy") && (includePackAttack == true))
                    {
                        string[] line = s.Split(','); // Podzielenie linii na atakującego i obrońcę
                        int indexAttacker = -1, indexDefender = -1;
                        int indexWydaje = line[0].IndexOf("wydaje");

                        // Wyszukanie nicków atakującego i obrońcy
                        for (int i = 0; i < result.Participants.Count(); i++)
                        {
                            if (line[0].Substring(0, indexWydaje).Contains(result.Participants[i].Nick)) indexAttacker = i;
                            if (line[2].Contains(result.Participants[i].Nick)) indexDefender = i;
                            if ((indexAttacker != -1) && (indexDefender != -1)) break;
                        }

                        string[] temp = line[2].Split(' ');
                        int dmg = Convert.ToInt32(temp[temp.Count() - 3]);
                        result.Participants[indexAttacker].NumDmg += dmg; // Dodaj atakującemu zadane obrażenia
                        result.Participants[indexDefender].NumGotDmg += dmg; // Dodaj obrońcy otrzymane obrażenia
                    }
                }
                else if (s.Contains("Efekt"))
                {
                    result.Effect = s; // Ewent
                }
                else if (s.Contains("specjalny"))
                {
                    string[] line = s.Split(new string[] { ", ", ". " }, StringSplitOptions.None); // Podzielenie linii na atakującego i obrońcę
                    int indexAttacker = -1, indexDefender = -1;

                    string attacker = "";
                    if (line[0].Contains(" wykonuje")) attacker = line[0].Substring(0, line[0].IndexOf(" wykonuje"));
                    if (attacker.Contains(" (*)")) attacker = attacker.Substring(0, attacker.IndexOf(" (*)"));
                    if (attacker.Contains(" (s)")) attacker = attacker.Substring(0, attacker.IndexOf(" (s)"));
                    string defender = "";
                    if (line[1].Contains(" wykonuje")) defender = line[1].Substring(0, line[1].IndexOf(" wykonuje"));
                    if (line[1].Contains(" zostaje")) defender = line[1].Substring(0, line[1].IndexOf(" zostaje"));
                    if (line[1].Contains(" nie zostaje")) defender = line[1].Substring(0, line[1].IndexOf(" nie zostaje"));
                    if (line[1].Contains(" zastyg")) defender = line[1].Substring(0, line[1].IndexOf(" zastyg"));
                    if (line[1].Contains(" unieruchamiają ")) defender = line[1].Substring(line[1].IndexOf(" unieruchamiają ") + 16, line[1].Length - 1 - (line[1].IndexOf(" unieruchamiają ") + 16));
                    if (defender.Contains(" (*)")) defender = defender.Substring(0, defender.IndexOf(" (*)"));
                    if (defender.Contains(" (s)")) defender = defender.Substring(0, defender.IndexOf(" (s)"));
                    for (int j = 0; j < 2; j++)
                    {
                        for (int i = 0; i < result.Participants.Count(); i++)
                        {
                            if ((attacker == result.Participants[i].Nick) && (indexAttacker == -1)) indexAttacker = i;
                            if ((defender == result.Participants[i].Nick) && (indexDefender == -1)) indexDefender = i;
                            if ((indexAttacker != -1) && (indexDefender != -1)) break;
                        }
                        if (indexAttacker == -1) result.Participants.Add(new BattleReportAnalyzer(attacker));
                        if (indexDefender == -1) result.Participants.Add(new BattleReportAnalyzer(defender));
                    }

                    string attack = line[0].Substring(line[0].IndexOf("specjalny") + 10);
                    if (attack.Contains(" zadając")) attack = attack.Substring(0, attack.IndexOf(" zadając"));
                    if (!result.Participants[indexAttacker].SpecialAttack.Contains(attack))
                    {
                        if (result.Participants[indexAttacker].SpecialAttack.Length != 0) result.Participants[indexAttacker].SpecialAttack += ", " + attack;
                        else result.Participants[indexAttacker].SpecialAttack += attack;
                    }

                    try
                    {
                        int offset = line[1].IndexOf(" za ") + 4;
                        int dmg = Convert.ToInt32(line[1].Substring(offset, line[1].IndexOf(" PKT ŻYCIA") - offset));
                        if (dmg < 0) dmg = 0;
                        result.Participants[indexAttacker].NumDmg += dmg; // Dodaj atakującemu zadane obrażenia
                        result.Participants[indexDefender].NumGotDmg += dmg; // Dodaj obrońcy otrzymane obrażenia
                    }
                    // Atak specjalny nie zadał obrażeń - złap zwrócony przez konwerter wyjątek
                    catch { };

                    result.Participants[indexAttacker].NumAttack += 1; // Dodaj atak do atakującego
                    result.Participants[indexDefender].NumGotAttacked += 1; // Dodaj otrzymany atak do obrońcy
                    if (line[0].Contains("cios krytyczny")) result.Participants[indexAttacker].NumCrits += 1; // Atakujący zadał cios krytyczny
                    if (line[1].Contains("unika")) result.Participants[indexDefender].NumDodges += 1; // Linia zawiera "unika" - obrońca uniknął trafienia
                    else if (!line[1].Contains(" nie zostaje"))
                    {
                        result.Participants[indexAttacker].NumHits += 1; // Linia nie zawiera "nie zostaje" - obronca został trafiony
                    }
                    else if (line[1].Contains(" nie zostaje"))
                    {
                        // Obrońca nie został trafiony
                        result.Participants[indexDefender].NumMisses += 1;
                    }
                }
                else if (s.Contains("odzyskuje"))
                {
                    // Linia z regeneracją życia
                    string[] temp;
                    if (s.Contains("że ")) temp = s.Split(new string[] { "że " }, StringSplitOptions.RemoveEmptyEntries);
                    else temp = new string[] { "", s };
                    string somebody = temp[1].Substring(0, temp[1].IndexOf(" odzyskuje"));
                    if (somebody.Contains(" (*)")) somebody = somebody.Substring(0, somebody.IndexOf(" (*)"));
                    if (somebody.Contains(" (s)")) somebody = somebody.Substring(0, somebody.IndexOf(" (s)"));

                    for (int i = 0; i < result.Participants.Count(); i++)
                    {
                        if (somebody == result.Participants[i].Nick)
                        {
                            int offset = temp[1].IndexOf("odzyskuje") + 10;
                            int regen = Convert.ToInt32(temp[1].Substring(offset, temp[1].IndexOf(" PKT ŻYCIA") - offset));
                            if (regen < 0) regen = 0;
                            result.Participants[i].NumRegenHP += regen;
                            break;
                        }
                    }
                }
                else if (s.Contains(',') && !s.Contains("pokrywają"))
                {
                    // Sprawdzana linia zawiera przecinek - linia ataku
                    // "xxx pokrywają Gnijące Resztki, efekty przedmiotów i ewolucji przestają działać do końca walki." - nie wchodź
                    string[] line = s.Split(','); // Podzielenie linii na atakującego i obrońcę
                    int indexAttacker = -1, indexDefender = -1;
                    int indexWeapon = line[0].IndexOf("bron"); // "... atakuje bronią ...", "... z broni ..."
                    if (indexWeapon == -1)
                    {
                        // Broń specjalna?
                        if (line[0].Contains("atakuje")) indexWeapon = line[0].IndexOf("atakuje") + 8;
                        if (line[0].Contains("Plagę")) indexWeapon = line[0].IndexOf("Plagę");
                        if (line[0].Contains("Aura")) indexWeapon = line[0].IndexOf("Aura");
                    }

                    // Wyszukanie nicków atakującego i obrońcy
                    string attacker = "";
                    if (line[0].Contains(" atakuje")) attacker = line[0].Substring(0, line[0].IndexOf(" atakuje"));
                    if (line[0].Contains(" zadaje")) attacker = line[0].Substring(0, line[0].IndexOf(" zadaje"));
                    if (line[0].Contains(" zużywa")) attacker = line[0].Substring(0, line[0].IndexOf(" zużywa"));
                    if (line[0].Contains(" zbiera")) attacker = line[0].Substring(0, line[0].IndexOf(" zbiera"));
                    if (attacker.Contains(" (*)")) attacker = attacker.Substring(0, attacker.IndexOf(" (*)"));
                    if (attacker.Contains(" (s)")) attacker = attacker.Substring(0, attacker.IndexOf(" (s)"));
                    string defender = "";
                    if (line[1].Contains(" wykonuje")) defender = line[1].Substring(1, line[1].IndexOf(" wykonuje") - 1);
                    if (line[1].Contains(" zostaje")) defender = line[1].Substring(1, line[1].IndexOf(" zostaje") - 1);
                    if (line[1].Contains(" nie zostaje")) defender = line[1].Substring(1, line[1].IndexOf(" nie zostaje") - 1);
                    if (defender.Contains(" (*)")) defender = defender.Substring(0, defender.IndexOf(" (*)"));
                    if (defender.Contains(" (s)")) defender = defender.Substring(0, defender.IndexOf(" (s)"));
                    for (int j = 0; j < 2; j++)
                    {
                        for (int i = 0; i < result.Participants.Count(); i++)
                        {
                            if ((attacker == result.Participants[i].Nick) && (indexAttacker == -1)) indexAttacker = i;
                            if ((defender == result.Participants[i].Nick) && (indexDefender == -1)) indexDefender = i;
                            if ((indexAttacker != -1) && (indexDefender != -1)) break;
                        }
                        if ((indexAttacker != -1) && (indexDefender != -1)) break;
                        if (indexAttacker == -1) result.Participants.Add(new BattleReportAnalyzer(attacker));
                        if (indexDefender == -1) result.Participants.Add(new BattleReportAnalyzer(defender));
                    }

                    result.Participants[indexAttacker].NumAttack += 1; // Dodaj atak do atakującego
                    result.Participants[indexDefender].NumGotAttacked += 1; // Dodaj otrzymany atak do obrońcy
                    if (line[0].Contains("cios krytyczny")) result.Participants[indexAttacker].NumCrits += 1; // Atakujący zadał cios krytyczny
                    if (line[1].Contains("unika")) result.Participants[indexDefender].NumDodges += 1; // Linia zawiera "unika" - obrońca uniknął trafienia
                    else if (!line[1].Contains(" nie zostaje"))
                    {
                        result.Participants[indexAttacker].NumHits += 1; // Linia nie zawiera "nie zostaje" - obronca został trafiony

                        int offset = line[1].LastIndexOf(" za ") + 4;
                        int dmg = Convert.ToInt32(line[1].Substring(offset, line[1].IndexOf(" PKT ŻYCIA") - offset));
                        if (dmg < 0) dmg = 0;
                        result.Participants[indexAttacker].NumDmg += dmg; // Dodaj atakującemu zadane obrażenia
                        result.Participants[indexDefender].NumGotDmg += dmg; // Dodaj obrońcy otrzymane obrażenia
                    }
                    else if (line[1].Contains(" nie zostaje"))
                    {
                        // Obrońca nie został trafiony
                        result.Participants[indexDefender].NumMisses += 1;
                    }

                    // Sprawdzenie jaką bronią atakował atakujący
                    string weapon = line[0].Substring(indexWeapon);
                    if (weapon.Contains("bron")) weapon = weapon.Substring(weapon.IndexOf(" ") + 1);
                    if (weapon.Contains("zadając")) weapon = weapon.Substring(0, weapon.IndexOf("zadając") - 1);
                    if (weapon.Contains("zbiera")) weapon = weapon.Substring(0, weapon.IndexOf("zbiera") - 1);
                    if (result.Participants[indexAttacker].Weapons[0] == "") result.Participants[indexAttacker].Weapons[0] = weapon;
                    else if (result.Participants[indexAttacker].Weapons[0] == weapon) { } // Nic nie rob
                    else if (result.Participants[indexAttacker].Weapons[1] == "") result.Participants[indexAttacker].Weapons[1] = weapon;
                }
                else
                {
                    if (s.Contains("vs") && (addedAttacker == false))
                    {
                        // Atakujący vs Obrońca
                        if (s.Contains("zasadzkę") || s.Contains(" arenie:"))
                        {
                            // Walka w zasadzce / arenie
                            result.Attacker = "Atakujący: " + result.Participants[0].Nick;
                            result.Defender = "Obrońca: " + result.Participants[1].Nick;
                            addedAttacker = true;
                        }
                        else
                        {
                            string[] temp = s.Split('\t');
                            result.Attacker = "Atakujący: " + temp[0];
                            result.Defender = "Obrońca: " + temp[2];
                            addedAttacker = true;
                        }
                    }
                }
            }

            return result;
        }

        static List<string> LoadNeededLines(string[] s)
        {
            /// Początkowa interpretacja raportu - zostawia jedynie ważne linie i zmienia tablicę stringów na listę stringów
            List<string> ret = new List<string>();

            for (int i = 0; i < s.Count(); i++)
            {
                string linia = s[i].ToLower();
                if (linia.Contains("zostaje") || linia.Contains("odzyskuje") || linia.Contains("unika") || linia.Contains("efekt") || linia.Contains("vs") || linia.Contains("specjalny"))
                {
                    ret.Add(s[i]); // Sprawdzana linia zawiera "zostaje trafiony", "nie zostaje trafiony", "odzyskuje PKT ŻYCIA", "unika trafienia", "Efekt:...", "xxx vs yyy"
                }
            }

            ret.TrimExcess();
            return ret;
        }

        static List<string> LoadParticipats(string[] s)
        {
            /// Wczytuje wszystkich uczestników walki
            List<string> ret = new List<string>();
            int firstIndex = -1, lastIndex = -1; // Indeksy gdzie zaczynają i kończą się uczestnicy oblężenia

            List<int[]> ls = new List<int[]>();
            int i1 = -1, i2 = -1;

            // Wyszukanie indeksów w raporcie
            for (int i = 0; i < s.Count(); i++)
            {
                string temp = s[i].ToLower();
                if ((temp.Contains("zasadzkę na") || (temp.Contains(" na arenie"))) && (temp.Contains("tytuł") == false))
                {
                    firstIndex = i;
                    break;
                }
                if (temp.Contains("vs"))
                {
                    if (firstIndex == -1) firstIndex = i;
                    if (i1 == -1) i1 = i;
                }
                if (temp.Contains("=== runda 1"))
                {
                    if (lastIndex == -1) lastIndex = i;
                    if (i2 == -1) i2 = i;
                }
                if ((i1 != -1) && (i2 != -1))
                {
                    ls.Add(new int[] { i1, i2 });
                    i1 = -1;
                    i2 = -1;
                }
            }

            if ((firstIndex != -1) && (lastIndex == -1))
            {
                // Analiza raportu zasadzki
                if (s[firstIndex].Contains("zasadzkę"))
                {
                    string[] temp2 = s[firstIndex].Split(new string[] { "zasadzkę" }, StringSplitOptions.RemoveEmptyEntries);
                    ret.Add(temp2[0].Substring(0, temp2[0].IndexOf("urzą") - 1));
                    ret.Add(temp2[1].Substring(temp2[1].IndexOf("na") + 3, temp2[1].Length - (temp2[1].IndexOf("na") + 3) - 2));
                }
                else if (s[firstIndex].Contains(" na arenie"))
                {
                    string[] temp2 = s[firstIndex].Split(new string[] { " vs " }, StringSplitOptions.RemoveEmptyEntries);
                    ret.Add(temp2[0].Substring(temp2[0].LastIndexOf(" arenie:") + 9));
                    ret.Add(temp2[1]);
                }
            }

            // Dodawanie uczestników do listy
            for (int i = (firstIndex + 1); i < lastIndex; i++)
            {
                string temp = s[i];
                if (temp.Contains("(*)")) temp = temp.Substring(0, temp.IndexOf(" (*)"));
                if (temp.Contains("(s)")) temp = temp.Substring(0, temp.IndexOf(" (s)"));
                if (!ret.Contains(temp)) ret.Add(temp);
            }

            for (int j = 0; j < ls.Count() - 1; j++)
            {
                for (int i = (ls[j][0] + 1); i < ls[j][1]; i++)
                {
                    string temp = s[i];
                    if (temp.Contains("(*)")) temp = temp.Substring(0, temp.IndexOf(" (*)"));
                    if (temp.Contains("(s)")) temp = temp.Substring(0, temp.IndexOf(" (s)"));
                    if (!ret.Contains(temp)) ret.Add(temp);
                }
            }

            ret.TrimExcess();
            return ret;
        }
    }
}
