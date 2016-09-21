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
		StringBuilder myStringBuilder; 

		public GewinnklassenRechner(Lottoschein lottoschein, int[] aktuelleZiehung)
		{
			foreach (int[] spiel in lottoschein.Spiele)
			{
				counter = 0;
				myStringBuilder = new StringBuilder(spieleNr + "." + "  "); 

				for (int i = 0; i < spiel.Length; i++)
				{
					if (aktuelleZiehung.Contains(spiel[i]))
					{
						counter++; 
						//trefferInSpiel[i] = spiel[i];
						myStringBuilder.Append("," + spiel[i]);
					}
					//ErgebnisArr[spieleNr-1] = Convert.ToString(spieleNr) + "." + "  " + trefferInSpiel[i]; 
				}

				if (counter > 1)
				{
					myStringBuilder.Append("         Getroffen " + counter); 
				}
				spieleNr++;
				ErgebnisArr.Add(myStringBuilder.ToString());
 
				
				

				//for (int k = 0; k < lottoschein.spiele.Count; k++)
				//{
				//    if (counter > 1)
				//    {
						
				//    }
					
				//}        
			}
		   
		}
		// (string[])myarrayList.ToArray(typeof(string));
		// strArrayList.CopyTo(strArray)

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
