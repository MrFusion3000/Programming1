using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmering_1_Uppg_3_Gissa_Talet                                // Unikt namn för denna programkod
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            int antalForsok = 1;                                            // Heltalsvariabel för att räkna antal försök innan spelaren träffar rätt. 
            do                                                              // Do-While-Loop tills användaren tröttnar på att spela
            {
                Random redRum = new Random();                               // Skapa instans av slumpgeneratorn Random och tillge heltalsvariabeln redRum
                int slumpatTal = redRum.Next(1, 11);                        // Ange intervallet 1-10 (måste alltid ha +1 i för önskat intervall)


                Console.Write("Guess a number between 1 and 10.");          // Skriv ut instruktion till användaren
                Console.Write(Environment.NewLine);
                string dullBoy = Console.ReadLine();                        // Erhåll respons från användaren och lagra i strängvariabeln dullBoy
                int gissatTal = Convert.ToInt32(dullBoy);                   // Konvertera indatasträngen till heltalsvariabeln gissatTal

                if (gissatTal == slumpatTal)                                // Kontrollera om rätt tal angetts av användaren
                {
                    Console.WriteLine("Nice work!");                        // Meddelande till användaren att rätt svar angetts
                    Console.WriteLine("It took you " + antalForsok + " tries to catch the right number."); // och hur många försök
                    antalForsok = 1;                                        // Nollställ antal försök-räknaren
                }
                else                                                        // Eller om fel tal angetts av användaren
                {
                    Console.WriteLine("Eeek, no can do! Correct number is: " + slumpatTal);   // Meddelande till användaren att fel tal angetts och presentera rätt tal
                    Console.WriteLine("This is your try no: " + antalForsok + "."); // och hur många försök.
                    antalForsok++;
                }

                Console.WriteLine("How nice that you wanted to play.");     // Meddelande, meny med 2-valsalternativ.
                Console.WriteLine("Press 1 to play again.");
                Console.WriteLine("Press 2 to exit.");
                
                string Jack = Console.ReadLine();                           // Invänta respons från användaren om att avsluta eller börja om

                if (Jack == "2")                                            // Om användaren trycker 2 så avslutas spelet
                {
                    Console.WriteLine("All work and no play makes Jack a dull boy..."); // Avslutsmeddelande
                    i = 0;                                                  // variabel 'i' sätts till värde '0' vilket gör att Do-While-loopen bryts
                    Console.ReadKey();                                      // Pausa tills användaren trycker på ngn tangent.
                }
                else if (Jack == "1")
                {
                    Console.WriteLine("Try, try again.");                   // Meddelande till användaren, while-loopen börjar om.
                }
                else
                {
                    Console.WriteLine("That's not a valid choice. Therefore you have to guess another number.");
                }
            }
            while (i != 0);                                                 // Do-While-loopen repeterar koden tills variabeln 'i' är lika med något annat än '0'.
        }
    }
}
