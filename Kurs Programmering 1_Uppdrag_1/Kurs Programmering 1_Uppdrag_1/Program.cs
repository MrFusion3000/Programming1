using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pension
{
    class Program
    {
        static void Main(string[] args)
        {
            int Age;                                // Sätt variabel Heltal med namn Age
            int Pension = 65;                       // Sätt variabel Heltal med namn Pension till värdet 65
            String Input;                           // Sätt variabel Sträng med namn Input för kontroll av inmatning
            String Firstname;                       // Sätt variabel Sträng med namn Firstname
            String Surname;                         // Sätt variabel Sträng med namn Surname
            String Fullname;                        // Sätt variabel Sträng för att hålla hela namnet

            Console.WriteLine("Välkommen till Pensionsuträknare2000 från Hogia 1992 AB."); // Skriv ut hälsningsfras.
            Console.Write(Environment.NewLine);                 // Ny rad (Vagnretur)

            Console.WriteLine("Ange förnamn:");                 // Skriv ut meddelande "Ange förnamn:"
            Firstname = Console.ReadLine();                     // Läs in användarens textinmatning i strängen Firstname

            Console.WriteLine("Ange efternamn:");               // Skriv ut meddelande "Ange efternamn:"
            Surname = Console.ReadLine();                       // Läs in användarens textinmatning i strängen Surname

            int i = 1;
            while(i != 0)
            {

                Console.WriteLine("Ange din ålder:");           // Skriv ut meddelande "Ange din ålder:".
                Input = Console.ReadLine();                     // Tilldela variabeln Input värdet från användarens inmatning
                if (Int32.TryParse(Input, out Age))             // Kontrollera att siffror skrivits in
                {
                    // Om siffror skrivits in:
                    if (Age <= 64)                              // Kontrollera om personen är yngre än 65 år:
                    {
                        Fullname = Firstname + " " + Surname;   // Lägger samman för- och efternamn
                        Pension = Pension - Age;                // Räknar ut år kvar till pension

                        // Visar användaren hälsningsmeddelande och resultat av uträkningen.                   
                        Console.WriteLine("Hej " + Fullname + ". Det är nu " + Pension + " år kvar tills du går i pension.");
                        Console.Write(Environment.NewLine);     // Ny rad
                    }
                    else
                    {
                        // Om användaren är 65 år eller äldre:
                        Console.WriteLine("Om du är " + Age + ", borde du ju redan gått i pension för " + (Age-Pension) + " år sen. Grattis!");
                        Console.Write(Environment.NewLine);     // Ny rad
                    }

                    // Slutmeddelande till användaren
                    Console.WriteLine("Tack för att du använde Pensionsuträknare2000 från Hogia 1992 AB.");
                    Console.Write(Environment.NewLine);         // Ny rad
                    Console.WriteLine("Tryck valfri tangent för att avsluta.");
                    Console.ReadKey();                          // Inväntar respons från användaren
                    i = 0;                                      // Ange i = 0 för att avsluta while-loopen.
                }
                else
                {
                    // Vid felaktig inmatning av ålder (andra tecken än siffror) visas felmeddelande och programmet avslutas
                    Console.WriteLine("Felaktig inmatning. Vänligen fyll i din ålder i siffror.");
                    // Console.WriteLine("Tryck valfri tangent för att avsluta.");
                    // Console.ReadKey();

                }
            }
            
        }
    }
}
