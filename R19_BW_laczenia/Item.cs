class Item
{
    // Klasa przedmiotu - Typ zmiennej przechowujący statystyki przedmiotu
    public int p; // Prefix index
    public int b; // Base index
    public int s; // Sufix index
    public string h; // History

    public Item(int pref = 0, int baza = 0, int suf = 0)
    {
        p = pref;
        b = baza;
        s = suf;
    }
    public Item(Item i)
    {
        p = i.p;
        b = i.b;
        s = i.s;
        h = i.h;
    }

    public int Sum()
    {
        return p + b + s;
    }

    public void Set(int pref, int baza, int suf)
    {
        p = pref;
        b = baza;
        s = suf;
    }
    public void Set(Item i)
    {
        p = i.p;
        b = i.b;
        s = i.s;
    }
}