using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test001
{
    class GewinnklassenRechner  
    {
        public string[] ErgebnisArr { get; set; }
        

        public GewinnklassenRechner(Lottoschein lottoschein, int[] aktuelleZiehung)
        {


            foreach (var zahl in aktuelleZiehung)
            {
                
            }
        }

        public Lottoschein LeseAusDB()
        {
            throw new NotImplementedException(); 
        }
    }
}
