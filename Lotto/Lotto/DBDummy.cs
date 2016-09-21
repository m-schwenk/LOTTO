using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class DBDummy : IDatabaseAdapter
    {
        
        public Lottoschein LeseAusDB()
        {
            return lottoDummy;  
        }

        readonly Lottoschein lottoDummy = new Lottoschein("995437");
        
        public DBDummy()
        {           
            lottoDummy.Add(1,new int[]{12,15,39,49,27,35}); 
        }

        
    }
}
