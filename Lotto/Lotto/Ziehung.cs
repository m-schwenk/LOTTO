using System;
using System.Collections.Generic;

namespace Lotto
{
    public struct Ziehung
    {
        public SortedSet<int> ZiehungsZahlen { get; private set; }
        public int Superzahl { get; private set; }
        public DateTime ZiehungsTag { get; set; }
        public string Spiel77 { get; set; }
        public string Super6 { get; set; }

        public Ziehung(DateTime ziehungsTag) : this()
        {
            ZiehungsZahlen = null;
            Superzahl = -1;
            ZiehungsTag = ziehungsTag;
            Spiel77 = null;
            Super6 = null;
        }

        public Ziehung(int[] ziehungsZahlen, int superZahl, DateTime ziehungsTag, string spiel77 = "", string super6 = "") : this()
        {
            ZiehungsZahlen = new SortedSet<int>(ziehungsZahlen);
            if (ZiehungsZahlen.Count != 6)
            {
                throw new ArgumentException("Ungueltige Ziehungszahlen");
            }
            Superzahl = superZahl;
            ZiehungsTag = ziehungsTag;
            Spiel77 = spiel77;
            Super6 = super6;
        }

        public Ziehung(int[] ziehungsZahlen, int superZahl) : this(ziehungsZahlen, superZahl, DateTime.Today) {}

    }
}
