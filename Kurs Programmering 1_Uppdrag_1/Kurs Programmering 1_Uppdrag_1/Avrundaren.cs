using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avrundaren
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deklarationer
            string Inmatning;                   // Variabel sträng för att plocka upp inmatning från användaren
            double Tal1;                        // Variabel double/flyttal för att spara decimaltal
            int AntDec;                         // Variabel heltal för att spara önskat antal decimaler
            int AntalDecimaler;
            double Tal2avr;                     // Variabel double/flyttal för at spara det avrundade talet

            int i = 1;                          // Variabel heltal med värde 1 tills godtagbar inmatning skett (sen 0)
            while (i != 0)                      // Loop tills godtagbar inmatning skett
            {
                Console.WriteLine("Skriv in ett decimaltal:");                                      // Skriv instruktion till användaren
                Inmatning = Console.ReadLine();                                                     // Ta emot inmatning från användaren
                

                if (double.TryParse(Inmatning, out Tal1))                                           // Kontroll om inmatningen är ett tal eller inte
                {
                    // Räkna ut hur många decimaler talet innehåller 
                    // (Modifierad från källa http://stssoft.com/forum/threads/462-Number-of-digits-after-decimal-point)
                    //string s = Convert.ToString(Inmatning);                                       // Konvertera double till sträng
                    string s = Inmatning;                                                           // Skapa en ny sträng för att kunna dela upp och räkna decimalerna
                    string[] array = s.Split(',');                                                  // dela strängen vid kommatecknet
                    AntalDecimaler = array.Length > 1 ? array[1].Length : 0;                        // Räkna antal decimaler i delsträngen efter kommatecknet
                    Console.WriteLine("Ditt tal har " + AntalDecimaler + " decimaler.");            // Meddela användaren om antalet
                    Console.Write(Environment.NewLine);                                             // Ny rad

                    // Om inmatning är ett tal så spara talet i variabel Tal1
                    Console.WriteLine("Detta är ett godkänt tal. ");                                // Skriv meddelande till användaren
                    Console.Write(Environment.NewLine);                                             // Ny rad

                    Console.WriteLine("Hur många decimaler vill du avrunda till?");
                    Inmatning = Console.ReadLine();                                                 // Ta emot inmatning från användaren
                    if (Int32.TryParse(Inmatning, out AntDec))                                      // Kontroll om inmatningen är ett tal eller inte
                    {
                        if (AntDec < AntalDecimaler)                                                // Felhantering om önskat antal decimaler överskrider inmatat antal
                            {
                            // Om inmatning är ett tal så spara talet i variabel Tal1
                            Console.WriteLine("Ditt avrundade decimaltal är: ");                    // Skriv meddelande till användaren
                            Tal2avr = Math.Round(Tal1, AntDec);                                     // Ge variabeln Tal2avr det avrundade värdet 
                            Console.WriteLine($"Avrundat: {Tal2avr}");                              // Skriv ut svaret till användaren

                            // Slutmeddelande till användaren
                            Console.Write(Environment.NewLine);                                     // Ny rad
                            Console.WriteLine("Tack för att du använde Avrundare2000 från Hogia 1992 AB.");
                            Console.Write(Environment.NewLine);                                     // Ny rad
                            Console.WriteLine("Tryck valfri tangent för att avsluta.");
                            Console.ReadKey();                                                      // Inväntar respons från användaren
                            i = 0;                                                                  // Ange i = 0 för att avsluta while-loopen.
                        }
                        else
                        {
                            Console.WriteLine("Ditt önskade antal decimaler har lika många eller överskrider talets antal decimaler.");
                            Console.WriteLine("Vänligen börja om från början.");
                            Console.Write(Environment.NewLine);                                         // Ny rad
                        }
                    }
                    else
                    {
                        // Om inmatning inte är ett godkänt tal 
                        Console.WriteLine("Du har matat in något som ej är ett godkänt tal.");      // Meddelande till användaren om felaktikt tal
                        Console.ReadKey();                                                          // Invänta respons från användaren

                    }
                }
                else
                {
                    // Om inmatning inte är ett godkänt tal 
                    Console.WriteLine("Du har matat in något som ej är ett godkänt tal.");      // Meddelande till användaren om felaktikt tal
                    Console.ReadKey();                                                          // Invänta respons från användaren

                }

                
            }
        }
    }
}
