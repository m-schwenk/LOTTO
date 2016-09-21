using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; 

namespace Lotto
{
	class GewinnklassenRechner
	{
		public ArrayList ErgebnisArr = new ArrayList();
		int counter = 0;
		int spieleNr = 1;
		bool fuegeKommaEin; 
		StringBuilder myStringBuilder = new StringBuilder();

		public ArrayList AktuelleZiehungList = new ArrayList(); 
		StringBuilder aktuelleZiehungBuilder = new StringBuilder(); 
		

		public GewinnklassenRechner(Lottoschein lottoschein, int[] aktuelleZiehung, int ziehungSuperzahl)
		{
			aktuelleZiehungBuilder.Append("Ziehung: ");

			for (int i = 0; i < aktuelleZiehung.Length; i++)
			{
				if (i == 0)
				{
					aktuelleZiehungBuilder.Append(aktuelleZiehung[i]);
				}
				else
				{
					aktuelleZiehungBuilder.Append("," + aktuelleZiehung[i]); 
				}
			}
			aktuelleZiehungBuilder.Append(" - (" + ziehungSuperzahl + ")\n");
			AktuelleZiehungList.Add(aktuelleZiehungBuilder.ToString());

			foreach (int[] spiel in lottoschein.spiele)
			{
				fuegeKommaEin = false;
			   
				counter = 0;
				myStringBuilder.Append(spieleNr + "." + "  "); 

				for (int i = 0; i < spiel.Length; i++)
				{
					
					if (aktuelleZiehung.Contains(spiel[i]))
					{
						if (fuegeKommaEin)
						{
							
							myStringBuilder.Append(",");
						}
						else
						{
							fuegeKommaEin = true;                             
						}
						myStringBuilder.Append(spiel[i]);
						counter++;
					}
					
				}

				if (counter > 1)
				{
					myStringBuilder.Append("         Getroffen " + counter);
					if (lottoschein.SuperZahl == Convert.ToString(ziehungSuperzahl))
					{
						myStringBuilder.Append(" + Superzahl " + ziehungSuperzahl); 
					}
				}
				spieleNr++;
				ErgebnisArr.Add(myStringBuilder.ToString());       
			}		   
		}
		
		public string[] GetErgebnisse()
		{
			string[] hilfsvariable = new string[ErgebnisArr.Count];

			for (int i = 0; i < ErgebnisArr.Count; i++)
			{
				hilfsvariable[i] = (string)ErgebnisArr[i]; 
			}
			
			return hilfsvariable; 
		}
		public Lottoschein LeseAusDB()
		{
			throw new NotImplementedException(); 
		}
	}
}
