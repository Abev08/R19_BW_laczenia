namespace R19_BW_laczenia
{
    class Item
    {
        public Item(int pref = 0, int baza = 0, int suf = 0, int iloscL = 0)
        {
            this.pref = pref;
            this.baza = baza;
            this.suf = suf;
            this.iloscLaczen = iloscL;
        }
        public Item(Item i)
        {
            this.pref = i.pref;
            this.baza = i.baza;
            this.suf = i.suf;
            this.hist = i.hist;
            this.iloscLaczen = i.iloscLaczen;
        }

        // Klasa przedmiotu - Typ zmiennej przechowujący statystyki przedmiotu
        public int pref; // Prefix index
        public int baza; // Base index
        public int suf; // Sufix index
        public System.Collections.Generic.List<int[]> hist = new System.Collections.Generic.List<int[]>(); // Hisotira łączeń
        public int iloscLaczen; // Ilość wymaganych łączeń aby otrzymać ten przedmiot
        
        public int Sum()
        {
            return this.pref + this.baza + this.suf;
        }
    }

    class ItemType
    {
        public ItemType()
        {
            prefy = new System.Collections.Generic.List<string>();
            bazy = new System.Collections.Generic.List<string>();
            sufy = new System.Collections.Generic.List<string>();
        }

        public System.Collections.Generic.List<string> prefy; // Lista prefiksów
        public System.Collections.Generic.List<string> bazy; // Lista baz
        public System.Collections.Generic.List<string> sufy; // Lista sufiksów
    }
}