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
        private readonly Dictionary<int, SortedSet<int>> _spiele = new Dictionary<int, SortedSet<int>>(12);

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

        /// <summary>
        /// Erlaubt die in diesem Lottoschein vorhandenen Spiele zu enumerieren.
        /// <returns>Die Spiele 1-12 als Kombination aus SpielNr und den getippten Zahlen als Set</returns>
        /// </summary>
        public IEnumerable<KeyValuePair<int, SortedSet<int>>> Spiele
        {
            get
            {
                foreach (KeyValuePair<int, SortedSet<int>> tipp in _spiele)
                {
                    yield return tipp;
                }
            }
        }

        // Konstruktor: 

        public Lottoschein(string losnummer)
        {
            this.Losnummer = losnummer;
        }

        /// <summary>
        /// Nimmt das angegebene Spiel in diesem Lottoschein auf
        /// </summary>
        /// <param name="spielNr">Muss im Bereich 1-12 liegen</param>
        /// <param name="spiel">Muss 6 voneinander verschiedene Zahlen im Bereich 1-49 enthalten</param>
        /// <returns>true wenn spiel erfolgreich aufgenommen wurde, ansonsten false</returns>
        public bool Add(int spielNr, int[] spiel)
        {
            SortedSet<int> spielSet = new SortedSet<int>(spiel);
            if (_spiele.ContainsKey(spielNr) || // Spiel schon vorhanden?
                (spielNr < 1) || (spielNr > 12) || // spielNr ausserhalb des Bereichs 1-12?
                (spielSet.Count != 6) || // nicht exakt 6 voneinander verschiedene Zahlen getippt?
                (spielSet.Min() < 1) || (spielSet.Max() > 49)) // getippte Zahlen ausserhalb des Bereichs 1-49?
                return false;
            _spiele[spielNr] = spielSet;
            return true;
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
                _spiele.Remove(spielNr);
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
        /// <remarks>Beibehalten zur Binaerkompatiblitaet</remarks>
        public bool Update(int spielNr, int[] spielNeu)
        {
            return Remove(spielNr) && Add(spielNr, spielNeu);
        }
    }
}
