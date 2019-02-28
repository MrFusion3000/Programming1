using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bastun1
{
    class Program

    {
        // metod för omvandling från Farenheit till Celcius

        public static int FahrToCels(int fahr)
        {
            int cel = (fahr - 32) * 5 / 9;      //omv fahrenheit till celsius
            return cel;                         //skicka tillbaka värdet
        }

        public static int TempRight(int celsius)
        {
            int insideInterval = celsius;
            int correct = 0;

            if (insideInterval < 73)
            {
                if (insideInterval > 77)
                {
                    correct = 1;
                }
            }
            return correct;
        }

        public static void Main(string[] args)
        {
            // Deklarationer
            int fahrenheit = 1;
            int celsius = 1;

            int CheckTempInterval = 0;
            bool loop = true;

            while (CheckTempInterval != 1)
            {
                do
                {
                    // Besökaren skriver in ett värde
                    Console.WriteLine("Please enter desired heat for the sauna using degrees Farenheit : ");
                    Console.WriteLine("Recommended temperature is between 163-171 f (approx. 73-77 degrees C )");

                    // *** Exception handling Start ***
                    // Kontrollera att inget annat än ett tal matats in
                    try
                {
                    fahrenheit = int.Parse(Console.ReadLine()); // korrekt värde lagras i heltalsvariabeln fahrenheit
                    loop = false; // Hoppa ur loop om korrekt inmatning
                }
                catch
                {
                    Console.WriteLine("Fel! Ange endast tal");  // Meddelande till besökaren om felaktigt värde angetts
                }
                // *** Exception handling End ***

                //Metoden FahrToCels anropas med värdet i variabeln fahrenheit
                celsius = FahrToCels(fahrenheit);
                // I heltalsvariabeln celsius finns nu antal grader omvandlat från F till C

                    // Kontrollera att valet är inom rätt intervall
                    if (celsius < 72)
                    {
                        Console.WriteLine("To darn cold. Turn it up!");
                        CheckTempInterval = 0;
                    }
                    if (celsius > 78)
                    {
                        Console.WriteLine("Hotter than hell. Turn it down!");
                        CheckTempInterval = 0;
                    }
                    if ((celsius >= 72) & (celsius <= 78)) 
                    {
                        Console.WriteLine("Sauna set to " + celsius + " degrees celsius");
                        CheckTempInterval = 1;
                    }
                    
                Console.WriteLine(celsius);
                Console.ReadKey(true);

                } while (loop);
            }

        }
    }
}
