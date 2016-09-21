using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    // Klasse um Testdaten zu kreiieren: 
    class DBDummy : IDatabaseAdapter
    {
        
        /// <summary>
        /// Implementierung der bereitgestellten Methode der Schnittstelle IDatabase Adapter.
        /// Methode um aus einer Datenbank Werte auszulesen und gibt 
        /// zurück einen gespielten Lottoschein vom Datentyp Lottoschein
        /// </summary>
        /// <returns>Lottoschein</returns>
        public Lottoschein LeseAusDB()
        {
            return lottoDummy;  
        }

        Lottoschein lottoDummy = new Lottoschein("995437");
        int[] spielDummy = new int[6];
        int superZahlDummy; 

        // Konstruktor: 
        public DBDummy()
        {           
            spielDummy[0] = 12; 
            spielDummy[1] = 15;
            spielDummy[2] = 39; 
            spielDummy[3] = 49; 
            spielDummy[4] = 27; 
            spielDummy[5] = 30;

            lottoDummy.Add(spielDummy);
            superZahlDummy = Convert.ToInt32(lottoDummy.SuperZahl);
        }

        
    }
}
