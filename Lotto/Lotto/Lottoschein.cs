using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections; 

namespace Lotto
{
    public class Lottoschein
    {
        // Lottoschein besteht aus: Losnummer, 12 Spiele, superzahl 
        private string _losnummer;
        public string Losnummer
        {
            get { return _losnummer; }
            set
            {
                if (value.Length <= 7)
                    value = value.PadLeft(7, '0');
                else throw new FormatException("Ungueltige Losnummer");

                foreach (char c in value)
                    if ((c < '0') || (c > '9'))
                        throw new FormatException("Ungueltige Losnummer");

                _losnummer = value;
            }
        }

        public byte SuperZahl
        {
            get { return Convert.ToByte(Losnummer.Last().ToString()); } // Superzahl ist untrennbar an die Losnummer gebunden, daher dynamische Berechnung
        }

  //      string[] month = { [...] };

  //public IEnumerable GetList() {
  //  for (int i = 0; i < month.Length; i++)
  //    yield return month[i];
  //}
        public IEnumerable<int[]> Spiele
        {
            get
            {
                foreach (int[] t in _spiele)
                    if (t != null)
                        yield return t;
            }
        }

        private int[][] _spiele = new int[12][];

        // Konstruktor: 

        public Lottoschein() : this("0") {}

        public Lottoschein(string losnummer)
        {
            this.Losnummer = losnummer;
        }

        // todo: Konsoleneingabe heraustrennen...
        public void fuelleSpiel()
        {
            int[] spiel = new int[6];
            string ans;
            do
            {
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

                //_spiele.Add(spiel);
                Console.WriteLine("Wollen Sie ein weiteres Spiel tippen? (J / N)");
                spiel = new int[6];
                ans = Console.ReadLine();
                if (ans.ToUpper() == "J")
                {

                }
                else if (ans.ToUpper() == "N")
                {

                }
                else
                {
                    Console.WriteLine("Fehlerhafte Eingabe");
                }
            } while (ans.ToUpper() == "J");
        }

        /// <summary>
        /// Nimmt das angegebene Spiel in diesem Lottoschein auf
        /// </summary>
        /// <param name="spielNr">Muss im Bereich 1-12 liegen</param>
        /// <param name="spiel">Muss 6 voneinander verschiedene Zahlen im Bereich 1-49 enthalten</param>
        /// <returns>true wenn spiel erfolgreich aufgenommen wurde, ansonsten false</returns>
        public bool Add(int spielNr, int[] spiel)
        {
            HashSet<int> spielSet = new HashSet<int>(spiel);
            if ((spielNr < 1) || (spielNr > 12) || // spielNr ausserhalb des Bereichs 1-12?
                (spiel.Length != 6) || // nicht exakt 6 zahlen in spiel?
                (spielSet.Count < 6) || // sind Zahlen doppelt getippt worden?
                (spielSet.Min() < 1) || (spielSet.Max() > 49)) // getippte Zahlen asuserhalb des Bereichs 1-49?
                return false;
            _spiele[spielNr-1] = spiel;
            return true;
        }

        public bool Add(int[] spiel)
        {
            for (int i = 0; i < _spiele.Length; i++)
            {
                if (_spiele[i] == null)
                {
                    _spiele[i] = spiel;
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Entfernt das angegebene Spiel
        /// </summary>
        /// <param name="spielNr"></param>
        /// <returns></returns>
        public bool Remove(int spielNr)
        {
            if ((spielNr >= 1) && (spielNr <= 12))
            {
                _spiele[spielNr-1] = null;
                return true;
            }
            return false;

        }

        /// <summary>
        /// Ersetzt ein vorhandenes Spiel.
        /// </summary>
        /// <param name="spielNr">Zu ersetzendes Spiel</param>
        /// <param name="spielNeu">Neu aufzunehmendes Spiel</param>
        /// <returns>true wenn spiel erfolgreich aufgenommen wurde, ansonsten false</returns>
        public bool Update(int spielNr, int[] spielNeu)
        {
            return Remove(spielNr) && Add(spielNr, spielNeu);
        }

        public void ZeigeSpiele()
        {
            foreach (int[] s in _spiele)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    Console.Write(s[i] + ", ");
                }
                Console.WriteLine();
            }
        }

    }
}
