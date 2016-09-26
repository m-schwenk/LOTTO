using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotto
{
    static class Program
    {
        

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

            int[] ziehung = {25, 12, 15, 17, 29, 43};
            int superzahlZiehung = 7; 

            IDatabaseAdapter dummyLotto1 = new DBDummy();

            GewinnklassenRechner gewinn1 = new GewinnklassenRechner(dummyLotto1.LeseLottoscheinAusDb(), ziehung, superzahlZiehung);
            foreach (var s in gewinn1.AktuelleZiehungList)
            {
                Console.WriteLine(s);
            }
            
            foreach (var s in gewinn1.ErgebnisArr)
            {
                Console.WriteLine(s);
            }

        }


        static Lottoschein Konsoleneingabe()
        {
            int[] spiel = new int[6];
            string ans;
            Lottoschein ls;

            while (true)
            {
                try
                {
                    Console.WriteLine("Bitte die Losnummer eingeben:");
                    ls = new Lottoschein(Console.ReadLine());
                    break;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }
            do
            {
                int spielNr;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Bitte die Spielnummer (1-12) eingeben:");
                        spielNr = Convert.ToInt32(Console.ReadLine());
                        if (spielNr >= 1 && spielNr <= 12)
                            break;
                        Console.WriteLine("Ungueltige Spielnummer!");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Fehlerhafte Eingabe. Bitte erneute Eingabe: ");
                    }
                } 

                for (int i = 0; i < spiel.Length; i++)
                {
                    Console.WriteLine("Bitte geben Sie die {0}. Zahl ein: ", i + 1);
                    try
                    {
                        spiel[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Fehlerhafte Eingabe. Bitte erneute Eingabe: ");
                        i--;
                        continue;
                    }

                    if ((spiel[i] < 1) || (spiel[i] > 49))
                    {
                        Console.WriteLine("Fehlerhafte Eingabe. Zahl ist nicht im Bereich.");
                        i--;
                        continue;
                    }

                    for (int k = 0; k < i; k++)
                    {
                        if (spiel[i] == spiel[k])
                        {
                            Console.WriteLine("Fehler: Zahl wurde bereits eingegeben");
                            i--;
                        }

                    }
                }

                Console.WriteLine(ls.Update(spielNr, spiel)
                    ? "Spiel erfolgreich eingetragen"
                    : "Spiel konnte nicht eingetragen werden");
                Console.WriteLine("Wollen Sie ein weiteres Spiel tippen? (J / N)");
                ans = Console.ReadLine();
            } while (ans.ToUpper() == "J");
            return ls;
        }
    }
}
