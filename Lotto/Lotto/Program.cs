using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotto
{
    static class Program
    {
        private static Lottoschein lottoschein
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            Lottoschein lotto1 = new Lottoschein("308857");
            Console.WriteLine("Zusatzzahl: {0}", lotto1.SuperZahl);

            int[] ziehung = {3, 12, 15, 17, 29, 43}; 
            DBDummy dummyLotto1 = new DBDummy();
            GewinnklassenRechner gewinn1 = new GewinnklassenRechner(dummyLotto1.LeseAusDB(), ziehung);
            foreach (var s in gewinn1.ErgebnisArr)
            {
                Console.WriteLine(s);
            }

        }
    }
}
