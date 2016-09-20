using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test001
{   
    class DummyDatabase : IDatabaseAdapter
    {
        public Lottoschein LeseAusDB()
        {
            return lottoDummy;  
        }

        Lottoschein lottoDummy = new Lottoschein("995437");
        
        // DateTime = new DateTime()
        int[] spielDummy = new int[6]; 
        

        public DummyDatabase()
        {           
            spielDummy[0] = 12; 
            spielDummy[1] = 15;
            spielDummy[2] = 39; 
            spielDummy[3] = 49; 
            spielDummy[4] = 27; 
            spielDummy[5] = 12;

            lottoDummy.Add(spielDummy); 
        }
         
        
        
    }
}
