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
		public string Losnummer { get; set; }

		public string SuperZahl { get; set; }

		public ArrayList spiele = new ArrayList();

		public int[] spiel = new int[6];

		private string ans;


		// Konstruktor: 

		public Lottoschein(string losnummer)
		{
			this.Losnummer = losnummer;
			this.SuperZahl = Convert.ToString(Losnummer[Losnummer.Length -1]);
		}

		// ToDo: Konsoleneingabe heraustrennen...
		/// <summary>
		/// Methode um ein Spiel eines Lottoscheins zu spielen durch Benutzereingabe mittels Konsole. 
		/// Zusätzliche Überprüfung auf valide Benutzereingaben:
		/// </summary>
		public void fuelleSpiel()
		{
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

				/// <summary>
				/// Methode um ein evtl. weiteres Spiel auf einem Lottoschein zu spielen oder den Schein abzuschließen:
				/// </summary>
				spiele.Add(spiel);
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

		//public void AddSpiele(int[] spiel)
		//{

		//}


		/// <summary>
		/// Methode um ein Spiel des Lottscheins zu löschen: 
		/// </summary>
		/// <param name="pos"></param>
		public void RemoveSpiel(int pos)
		{
			spiele.RemoveAt(pos);
		}


		/// <summary>
		/// Methode um ein fehlerhaftes Spiel eines Lottoscheins erneut eingeben zu können:
		/// </summary>
		/// <param name="tippNeu"></param>
		public void UpdateSpiel(int[] tippNeu)
		{
			spiele.RemoveAt(spiele.Count - 1);
			spiele.Add(tippNeu);
		}

		/// <summary>
		/// Methode um alle gespielten Zahlen eines Scheins an der Konsole auszugeben: 
		/// </summary>
		public void ZeigeSpiele()
		{
			foreach (int[] s in spiele)
			{
				for (int i = 0; i < s.Length; i++)
				{
					Console.Write(s[i] + ", ");
				}
				Console.WriteLine();
			}
		}

		/// <summary>
		/// Fügt einem Lottoscheinobjekt ein weiteres Spiel hinzu. 
		/// </summary>
		/// <param name="spiel"></param>
		public void Add(int[] spiel)
		{
			spiele.Add(spiel);
		}

		// Auskommentierter dummy Code: 
		
		////private int superzahl;
		////private ArrayList spiele;
		////private int[] spiel;

		////public string Losnummer { get; set; }

		////private int _superZahl;

		////public int SuperZahl
		////{
		////    get { return _superZahl; }
		////    set
		////    {
		////        char last = Losnummer[Losnummer.Length - 1];
		////        _superZahl = Convert.ToInt32(last);
		////    }
		////}

		////// Konstruktor: 

		////public Lottoschein(string losnummer)
		////{
		////    this.Losnummer = losnummer;
		////}

		////public void Add(int[] tipp)
		////{
		////   spiele.Add(tipp); 
		////}

		////public void RemoveTipp(int pos)
		////{
		////    spiele.RemoveAt(pos);              
		////}
		
		////public void UpdateTipp(int tippnummer, int[] tipp)
		////{
		////    throw new System.NotImplementedException();
		////}
	}
}
