using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections; 

namespace Lotto
{
    public class Lottoschein
    {
        
        private int superzahl;
        private ArrayList spiele;
        private int[] spiel;

        public string Losnummer { get; set; }

        private int _superZahl;

        public int SuperZahl
        {
            get { return _superZahl; }
            set
            {
                char last = Losnummer[Losnummer.Length - 1];
                _superZahl = Convert.ToInt32(last);
            }
        }

        // Konstruktor: 

        public Lottoschein(string losnummer)
        {
            this.Losnummer = losnummer;
        }

        public void Add(int[] tipp)
        {
           tipps.Add(tipp); 
        }

        public void RemoveTipp(int pos)
        {
           tipps.RemoveAt(pos);              
        }
		
        public void UpdateTipp(int tippnummer, int[] tipp)
        {
            throw new System.NotImplementedException();
        }
    }
}
