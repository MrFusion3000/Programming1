using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmering_1___Mod_3___Uppg_1
{
    class Program
    {
        public static bool BetweenRanges(int a, int b, int number)
        {
            return (a <= number && number <= b);
        }

        //public static bool NoDuplicate(int[] compareVektor, int compareNumber)
        //{
        //    for (int j = 0; j < compareVektor.Length; j++)        //loopa igenom vektorn för inmatade tal
        //    {
        //        return (compareVektor[j] == compareNumber) ;          //kontrollera resp tal i vektorn om senaste talet redan finns
        //    }
        //    
        //}

        static void Main(string[] args)
        {
            // Skapa vektor 1 med 10 platshållare för lagring av användarinmatning
            int[] vektorInmatning;                                              // Deklaration
            vektorInmatning = new int[10];                                      // Skapa 10 platshållare av typen int åt vektorn

            // Skapa vektor 2 med 10 platshållare för lagring av slumptal
            int[] vektorSlumptal;                                               // Deklaration
            vektorSlumptal = new int[10];                                       // Skapa 10 platshållare av typen int åt vektorn

            // Skapa vektor 3 med 10 platshållare för lagring av vinsttal
            int[] vektorVinst;                                                  // Deklaration
            vektorVinst = new int[10];                                       // Skapa 10 platshållare av typen int åt vektorn

            //Hantering och kontroll av användarinmatning
            Console.Write("Välkommen till Blotto. \nDu anger 10 tal (mellan 1-25) så får vi se om du vinner något.\n\n");

            for (int i = 0; i < vektorInmatning.Length; i++)                    // loopa igenom antal nummer (bestämt av vektorn)
            {
                Console.Write("Skriv in tal nr. " + (i + 1) + " : ");           
                string strNr = Console.ReadLine();                              // deklarera sträng strNr och läs in inmatat nr i strängen
                try
                {
                    int nr = Convert.ToInt16(strNr);                            // konvertera sträng till heltal

                    while (!BetweenRanges (1, 25, nr))                          // kontrollera om tal inte är mellan 1-25
                    {
                        Console.WriteLine("Det måste vara ett tal mellan 1-25.\n");
                        Console.Write("Skriv in tal nr. " + (i + 1) + " : ");
                        nr = Convert.ToInt16(Console.ReadLine());               // konvertera nytt inmatat värde i sträng till heltal
                    }

                    // Kontrollera dubbletter
                    if (vektorInmatning.Contains(nr))
                    {
                        Console.WriteLine("Du har redan valt talet " + nr + ".\nVälj ett annat.\n");
                        i--;
                    }
                    else
                    {
                        vektorInmatning[i] = nr;                                // placera värdet i vektorn för inmatade tal
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Obs! Inga bokstäver eller andra tecken.\n");
                    i--;
                }
            }

            //Slumpgenerator
            Random rnd = new Random();
            
            for (int i = 0; i < vektorSlumptal.Length; i++)
            {
                int slumpf = rnd.Next(1, 25);                                   // skapar slumptal mellan 1 and 25

                // Kontrollera dubbletter
                if (vektorSlumptal.Contains(slumpf))
                {
                    //Console.WriteLine("Du har redan valt talet " + nr + ".\nVälj ett annat.\n");
                    i--;
                }
                else
                {
                    vektorSlumptal[i] = slumpf;                                 // placera värdet i vektorn för inmatade tal
                }
                
            }

            //Skriv ut användarens valda nummer
            Console.WriteLine("\nHär är dina valda nummer\n ");
            for (int j = 0; j < vektorInmatning.Length; j++)                    //loopa igenom vektorn för inmatade tal
            {
                Console.Write(vektorInmatning[j] + " | ");                      //skriv ut resp tal och avskiljare
            }

            //Skriv ut de framslumpade numren
            Console.WriteLine("\n\nHär är vinnarnumren\n ");
            for (int j = 0; j < vektorSlumptal.Length; j++)                     //loopa igenom vektorn för slumptalen
            {
                Console.Write(vektorSlumptal[j] + " | ");                       //skriv ut resp tal och avskiljare
            }

            // Kontroll av vinnande nr
            int totalWins = 0;
            foreach (int matchI in vektorInmatning)                             // Loopa alla tal i vektorInmatning 
            {
                foreach (int matchS in vektorSlumptal)                          // Loopa alla tal i vektorSlumptal
                {
                    if (matchI.Equals (matchS))                                 // Jämför alla inmatade tal mot varje slumptal
                    {                                               
                        totalWins ++;                                           // Om ett tal matchas adderas detta till vinst-totalen
                        vektorVinst[totalWins] = matchI;
                    }
                }
            }

            // Vid vinst skrivs antal vinstnummer ut
            if (totalWins > 0)
            {
                Console.WriteLine("\n\nGrattis! Du har vunnit på " + totalWins + " av dina nummer.\n");

                //Skriv ut de matchande vinstnumren
                for (int j = 0; j < vektorVinst.Length; j++)                     //loopa igenom vektorn för vinstnumren
                {
                    if (vektorVinst[j] > 0)                                      // Om ett vektorelement innehåller ett värde...
                    Console.Write(vektorVinst[j] + " | ");                       //skriv ut talet och avskiljare
                }
                Console.Read();
            }
            else
            {
                Console.WriteLine("\n\nTyvärr, ingen vinst denna gång.");
                Console.Read();
            }
        }
    }
}
