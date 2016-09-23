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
            return _lottoDummy;  
        }

        private readonly Lottoschein _lottoDummy = new Lottoschein("995437");
        
        public DBDummy()
        {           
            _lottoDummy.Add(1, new int[]{12,15,39,49,27,30}); 
        }

    }
}
