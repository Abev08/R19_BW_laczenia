using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narzędzie_Blood_Wars___R19
{
    public class Item
    {
        // Klasa przedmiotu - Typ zmiennej przechowujący statystyki przedmiotu
        public Item(int pref = 0, int baza = 0, int suf = 0, int jointsNum = 0)
        {
            this.pref = pref;
            this.baza = baza;
            this.suf = suf;
            this.jointsNumber = jointsNum;
        }
        public Item(Item i)
        {
            this.pref = i.pref;
            this.baza = i.baza;
            this.suf = i.suf;
            this.history = i.history;
            this.jointsNumber = i.jointsNumber;
        }

        public int pref;
        public int baza;
        public int suf;
        public List<int[]> history = new List<int[]>();
        public int jointsNumber;

        // Wykorzystywane do sprawdzenia czy przedmiot istnieje (nie jest pusty)
        public int Sum() => this.pref + this.baza + this.suf;

        public Item Polacz(Item i2, ItemType typ, bool helmetException = false)
        {
            int[] result = new int[] { 0, 0, 0 };
            double x = 0d, y = 0d;

            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        x = this.pref;
                        y = i2.pref;
                        break;
                    case 1:
                        x = this.baza;
                        y = i2.baza;
                        break;
                    case 2:
                        x = this.suf;
                        y = i2.suf;
                        break;
                }

                if ((int)x == 0 || (int)y == 0) result[i] = 0;
                else if (x == y) result[i] = (int)x;
                else result[i] = Convert.ToInt32(Math.Ceiling((x + y) / 2d) + 1d);
                // Wyjątek przy łączeniu Czapka + Hełm = Maska
                if (helmetException == true && x == 1 && y == 3 && i == 1) result[i] = 4;
                if (helmetException == true && x == 3 && y == 1 && i == 1) result[i] = 4;
            }

            Item w = new Item(result[0], result[1], result[2]);

            // Sprawdzenie wyjątkow przy łączeniu przy końcu tabeli łączeń
            // Prefiksy
            if ((this.pref == (typ.pref.Count - 1)) && (i2.pref == (typ.pref.Count - 2))) w.pref = typ.pref.Count - 3;
            if ((this.pref == (typ.pref.Count - 2)) && (i2.pref == (typ.pref.Count - 1))) w.pref = typ.pref.Count - 3;
            if ((this.pref == (typ.pref.Count - 1)) && (i2.pref == (typ.pref.Count - 3))) w.pref = typ.pref.Count - 2;
            if ((this.pref == (typ.pref.Count - 3)) && (i2.pref == (typ.pref.Count - 1))) w.pref = typ.pref.Count - 2;
            // Bazy
            if ((this.baza == (typ.baza.Count - 1)) && (i2.baza == (typ.baza.Count - 2))) w.baza = typ.baza.Count - 3;
            if ((this.baza == (typ.baza.Count - 2)) && (i2.baza == (typ.baza.Count - 1))) w.baza = typ.baza.Count - 3;
            if ((this.baza == (typ.baza.Count - 1)) && (i2.baza == (typ.baza.Count - 3))) w.baza = typ.baza.Count - 2;
            if ((this.baza == (typ.baza.Count - 3)) && (i2.baza == (typ.baza.Count - 1))) w.baza = typ.baza.Count - 2;
            // Sufiksy
            if ((this.suf == (typ.suf.Count - 1)) && (i2.suf == (typ.suf.Count - 2))) w.suf = typ.suf.Count - 3;
            if ((this.suf == (typ.suf.Count - 2)) && (i2.suf == (typ.suf.Count - 1))) w.suf = typ.suf.Count - 3;
            if ((this.suf == (typ.suf.Count - 1)) && (i2.suf == (typ.suf.Count - 3))) w.suf = typ.suf.Count - 2;
            if ((this.suf == (typ.suf.Count - 3)) && (i2.suf == (typ.suf.Count - 1))) w.suf = typ.suf.Count - 2;

            return w;
        }

        public static int Polacz(int i1, int i2, List<string> types, bool helmetException = false)
        {
            int result;
            int count = types.Count;

            // Połączenie itemów
            if (i1 == 0 || i2 == 0) result = 0;
            else if (i1 == i2) result = i1;
            else result = Convert.ToInt32(Math.Ceiling(((double)i1 + (double)i2) / 2d) + 1d);
            // Wyjątek przy łączeniu Czapka + Hełm = Maska
            if (helmetException == true && i1 == 1 && i2 == 3) result = 4;
            if (helmetException == true && i1 == 3 && i2 == 1) result = 4;

            // Sprawdzenie wyjątków przy końcu tabeli łączeń
            if ((i1 == (count - 1)) && (i2 == (count - 2))) result = count - 3;
            if ((i1 == (count - 2)) && (i2 == (count - 1))) result = count - 3;
            if ((i1 == (count - 1)) && (i2 == (count - 3))) result = count - 2;
            if ((i1 == (count - 3)) && (i2 == (count - 1))) result = count - 2;

            return result;
        }

        public string ToString(ItemType it)
        {
            // Funkcja zwracająca prefiks, bazę i sufiks przedmiotu w postaci stringa bez niepotrzebnych spacji
            string s = "";
            if (this.pref != 0) s = it.pref.ElementAt(this.pref);
            if (this.pref != 0 && this.baza != 0) s += " ";
            if (this.baza != 0) s += it.baza.ElementAt(this.baza);
            if ((this.pref != 0 || this.baza != 0) && this.suf != 0) s += " ";
            if (this.suf != 0) s += it.suf.ElementAt(this.suf);
            return s;
        }
    }
}