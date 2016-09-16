using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
<<<<<<< HEAD
using System.Collections; 
=======
using System.Collections;
>>>>>>> origin/master

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

<<<<<<< HEAD
        public int GetSuperzahl()
=======
        public void AddTipp(int [] tipp)
>>>>>>> origin/master
        {
            throw new System.NotImplementedException();
        }

<<<<<<< HEAD
        public void SetSuperzahl()
        {
            throw new System.NotImplementedException();
        }

        public void Add(int[] tipp)
        {
            throw new NotImplementedException();
        }

        public void UpdateTipp()
        {
            throw new System.NotImplementedException();
        }

        public int tippnummer()
        {
            throw new System.NotImplementedException();
        }

        public int[] tipp()
=======
        public void UpdateTipp(int tippnummer, int[] tipp)
>>>>>>> origin/master
        {
            throw new System.NotImplementedException();
        }
    }
}
