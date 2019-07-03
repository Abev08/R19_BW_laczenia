using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Narzędzie_Blood_Wars___R19
{
    class JoinByHand
    {
        public JoinByHand()
        {
            this.Clear();
        }

        public Item i1, i2;
        public List<Item> historyItem;
        public List<string> historyJoin;

        public void Polacz(ItemType it, bool helmetException = false)
        {
            this.i1 = this.i1.Polacz(this.i2, it, helmetException);
            this.historyJoin.Add(" + " + this.i2.ToString(it) + "\r= " + this.i1.ToString(it));
        }

        public void Clear()
        {
            i1 = new Item();
            i2 = new Item();
            historyItem = new List<Item>();
            historyJoin = new List<string>();
        }

        public void UpdateLabel(Label labelPref, Label labelBaza, Label labelSuf, Item newItem, ItemType it, bool helmetException = false)
        {
            Item i = new Item(this.i1.Polacz(newItem, it, helmetException));

            labelPref.Content = it.pref.ElementAt(i.pref);
            labelBaza.Content = it.baza.ElementAt(i.baza);
            labelSuf.Content = it.suf.ElementAt(i.suf);
        }
    }
}