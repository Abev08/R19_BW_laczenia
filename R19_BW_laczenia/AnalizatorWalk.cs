using System.Collections.Generic;
using System.Linq;

namespace R19_BW_laczenia
{
    class AnalizatorWalk
    {
        public AnalizatorWalk(string _nick)
        {
            this.nick = _nick;
            this.bronie = new string[] { "", "" };
            this.iloscAtakow = 0;
            this.iloscKrytow = 0;
            this.iloscTrafien = 0;
            this.iloscOtrzymanychAtakow = 0;
            this.iloscChybien = 0;
            this.iloscUnikow = 0;
            this.iloscObrazenZadanych = 0;
            this.iloscObrazenOtrzymanych = 0;
            this.iloscZregenerowanychPZ = 0;
        }

        public string nick;
        public string[] bronie;
        public int iloscAtakow, iloscKrytow, iloscTrafien, iloscOtrzymanychAtakow, iloscChybien, iloscUnikow, iloscZregenerowanychPZ, iloscObrazenZadanych, iloscObrazenOtrzymanych;

        public static List<string> PoczatkoweWczytanie(string[] s)
        {
            // Początkowa interpretacja raportu - zostawia jedynie ważne linie i zmienia tablicę stringów na listę stringów
            List<string> ret = new List<string>();

            for (int i = 0; i < s.Count(); i++)
            {
                string linia = s[i].ToLower();
                if (linia.Contains("zostaje") || linia.Contains("odzyskuje") || linia.Contains("unika") || linia.Contains("efekt") || linia.Contains("vs"))
                {
                    // Sprawdzana linia zawiera "zostaje trafiony", "nie zostaje trafiony", "odzyskuje PKT ŻYCIA", "unika trafienia", "Efekt:...", "xxx vs yyy"
                    ret.Add(s[i]);
                }
            }

            ret.TrimExcess();
            return ret;
        }

        public static List<string> WczytanieUczestnikow(string[] s)
        {
            // Wczytuje wszystkich uczestników walki
            List<string> ret = new List<string>();
            int firstIndex = 0, lastIndex = 0; // Indeksy gdzie zaczynają i kończą się uczestnicy oblega

            // Wyszukanie indeksów w raporcie
            for (int i = 0; i < s.Count(); i++)
            {
                string temp = s[i].ToLower();

                if (temp.Contains("vs")) firstIndex = i;
                if (temp.Contains("runda")) lastIndex = i;

                if ((firstIndex != 0) && (lastIndex != 0)) break;
            }

            // Dodawanie uczestników do listy
            for (int i = (firstIndex + 1); i < lastIndex; i++)
            {
                if (!ret.Contains(s[i])) ret.Add(s[i]);
            }

            ret.TrimExcess();
            return ret;
        }
    }
}
