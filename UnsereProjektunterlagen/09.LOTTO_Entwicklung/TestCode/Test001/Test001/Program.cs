using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test001
{
    class Program
    {
        static void Main(string[] args)
        {
            Lottoschein lotto1 = new Lottoschein("9847");
            Console.WriteLine(lotto1.SuperZahl);
            lotto1.fuelleSpiel();
            lotto1.ZeigeSpiele(); 
            //lotto1.ZeigeSpiele(); 
            DummyDatabase unserTest = new DummyDatabase(); 
            
            
        }
    }
}
