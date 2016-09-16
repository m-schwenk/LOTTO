using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Lotto
{
    public class Lottoschein
    {
        private ArrayList tipps;
        private int superzahl;

        public int Superzahl
        {
            get { return superzahl; }
            set { superzahl = value; }
        }

        public void AddTipp(int [] tipp)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateTipp(int tippnummer, int[] tipp)
        {
            throw new System.NotImplementedException();
        }
    }
}
