using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodacrate
{
    class Crate
    {
        private string name;            // Backens namn
        private Bottle[] bottles;       // Vektor att hålla flaskor att fylla backen med
        private Bottle[] stock;         // Vektor att hålla flaskor att beställa
        int bottleTotal = 0;            // Räknare för antal flaskor i backen

        string nameTemp;                // Temporära variabler för flaskdata
        string typeTemp;                //
        int priceTemp;                  //

        //Skapa konstruktor för backen med 24 fack för flaskorna och 4 för butikens lager (koden använder bara 3)
        public Crate(string _name)
        {
            name = _name;               //Sträng för backens namn
            bottles = new Bottle[24];   //Sätt backens storlek i antal flaskor
            stock = new Bottle[4];      //Sätt butikens lagerstorlek i antal flaskor(varor)
        }

        // Huvudmetod med huvudmeny
        public void Run()
        {
            // * Huvudmenyn listar alla grundalternativ för programmet
            Console.SetWindowSize(100, 40);             // Sätt fönsterstorleken till 100 b, 40 h
            Console.WriteLine("* ** *** Welcome to the awesome Sodacrate-simulator - " + name + " *** ** *");

            int antalMenyval = 6;                      // initiera antal menyval på huvudmenyn
            int menyVal = 0;                            // initiera heltalsvariabel menyVal för användarinput

            // *** Switch och case med do-while-loop så länge menyVal är annat än 0
            do
            {
                Console.Clear();                        // Rensa skärmen
                Console.WriteLine("* ** *** H U V U D M E N Y *** ** *\n");
                Console.WriteLine("Välj ett alternativ:\n");
                Console.WriteLine("1. Lägg till/byt ut en dryck i backen");
                Console.WriteLine("2. Visa innehållet i backen");
                Console.WriteLine("3. Beräkna det totala värdet av backen");                
                Console.WriteLine("4. Hitta dryck");
                Console.WriteLine("5. Sortera flaskorna\n");
                Console.WriteLine("0. Avsluta programmet\n");

                menyVal = Check_Valid(antalMenyval);   // Kontroll av godkända tecken och blockering av annat än siffror

                switch (menyVal)
                {
                    case 1:                             // Val 1, hoppar till metoden Add_soda() för att lägga till flaskor i backen
                        Add_soda();
                        break;
                    case 2:                             // Val 2, hoppar till metoden Print_crate() för att skriva ut innehållet
                        Print_crate();
                        break;
                    case 3:                             // Val 3, hoppar till metoden Calc_total() för att räkna ut totalkostnaden
                        int crateTotal = Calc_total();  // Hämta totalkostnad
                        Console.WriteLine("\nBackens totalkostnad är: " + crateTotal + " kr.");
                        Console.Write("\n\nPress any key to continue . . . ");
                        Console.ReadKey(true);
                        break;
                    case 4:                             // Val 4, hoppar till metoden Find_soda() för att hitta en specifik dryck i backens innehåll
                        Find_soda();
                        break;
                    case 5:                             // Val 5, hoppar till metoden Sort_soda() för att sortera backens innehåll alfabetiskt
                        Sort_sodas();
                        break;
                    case 0:                             // Val 0, ger meddelande till användaren och avslutar programmet.
                        Console.WriteLine("Du har avslutat programmet.");
                        Environment.Exit(0);
                        break;
                    default:                        
                        Console.WriteLine("Felaktigt val. Endast menyval mellan 0 - " + (antalMenyval -- ) + " är giltiga.");
                        break;
                }

            } while (menyVal != 0);
        } // **** End Run() ****

        // *** Metod för att lägga till en läskflaska
        public void Add_soda()
        {
            int antalMenyval = 6;       // Anger hur många menyval
            int undermeny1Val = 0;      // initierar heltalsvariabeln för menyval

            // *** Fyll på lagerurval
            stock[0] = new Bottle("Loka Gul Snö", "Vatten", 10);
            stock[1] = new Bottle("Svampsoda", "Läsk", 14);
            stock[2] = new Bottle("Flaskon Lättöl", "Öl", 24);
            //stock[3] = new Bottle("Empty", "Empty", 0);
            // ***

            do
            {
                Console.Clear();        // Rensa skärmen
                Console.WriteLine("* ** *** M E N Y - L Ä G G  T I L L / B Y T  U T  D R Y C K *** ** *\n");
                Console.WriteLine("Du har följande val för att fylla din back:\n");
                Console.WriteLine("1. Loka Gul snö              10:-");
                Console.WriteLine("2. Svampsoda                 12:-");
                Console.WriteLine("3. Flaskon lättöl            24:-");
                Console.WriteLine("4. Do you feel lucky, Punk?  240 - 576:-");
                Console.WriteLine("5. Byta ut dryck                ");
                Console.WriteLine("0. Åter Huvudmeny\n");

                //*** Räkna antal flaskor i backen
                bottleTotal = 0;
                foreach (Bottle bottle in bottles)
                    if (bottle != null)
                    {
                        bottleTotal++;
                    }
                //***

                //*** Om bara en flaska i backen
                if (bottleTotal == 1)
                {
                    Console.WriteLine("\nDin back innehåller just nu " + bottleTotal + " flaska.");
                }
                //*** annars om noll eller plural
                else
                {
                    Console.WriteLine("\nDin back innehåller just nu " + bottleTotal + " flaskor.");
                }
                //***

                undermeny1Val = Check_Valid(antalMenyval);      // Kontroll av godkända tecken och blockering av annat än siffror

                if (undermeny1Val > antalMenyval)               // Felmeddelande om val ej finns på menyn.
                {
                    Console.WriteLine("Felaktigt val. Endast menyval mellan 0 - " + (antalMenyval--) + " är giltiga.");
                    Console.ReadKey();
                    Add_soda();
                }

                // *** Om menyval 0 hoppa till Huvudmeny 
                if (undermeny1Val == 0)
                {
                    Run();
                    break;
                }
                // ***

                // *** Om menyval 4 hoppa till funktion för att slumpa hel back 
                if (undermeny1Val == 4)
                {
                    int undermeny2Val = 2;
                    Console.WriteLine("\nDu har valt att slumpa fram en hel back.\nDetta kommer radera " + bottleTotal + " från backen. ");
                    Console.WriteLine("\nÄr du säker på att du vill göra detta? (1.JA | 2.NEJ) \n");

                    undermeny2Val = Check_Valid(antalMenyval);    // Kontroll av godkända tecken och blockering av annat än siffror

                        if (undermeny2Val == 2)
                        {
                            Add_soda();
                            break;
                        }
                        else
                        {
                            Random_Crate();
                        }
                        break;
                    }
                // ***

                if (undermeny1Val == 5)
                {
                    int flaskByte = 0;
                    Console.WriteLine("Vilken dryck vill du lägga till i backen? (1-3)");
                    flaskByte = Check_Valid(antalMenyval);

                    foreach (var item in stock.Select((value, i) => new { i, value }))
                    {
                        var value = item.value;
                        var index = item.i;

                        // Välj flaska från lagret beroende på vilket nummer i menyn man valt
                        if (item.i == flaskByte - 1)
                        {
                            //Console.Write("I lager :" + stock[item.i].bottleName);
                            nameTemp = stock[index].bottleName;
                            typeTemp = stock[index].bottleType;
                            priceTemp = stock[index].bottlePrice;
                        }
                    }

                    Change_bottle(nameTemp, typeTemp, priceTemp);
                }

                // *** Iterera igenom lagret för att hitta önskad flaska
                foreach (var item in stock.Select((value, i) => new { i, value }))
                {
                    var value = item.value;
                    var index = item.i;

                    // Välj flaska från lagret beroende på vilket nummer i menyn man valt
                    if (item.i == undermeny1Val - 1)
                    {
                        //Console.Write("I lager :" + stock[item.i].bottleName);
                        nameTemp = stock[index].bottleName;
                        typeTemp = stock[index].bottleType;
                        priceTemp = stock[index].bottlePrice;
                    }
                }
                // ***

                // *** Iterera igenom backen för att hitta plats för vald flaska
                foreach (var item in bottles.Select((value, i) => new { i, value }))
                {
                    var value = item.value;
                    var index = item.i;

                    // ** Om backen är full gå till metod för att byta ut en flaska
                    if (index >= 23)
                    {
                        Console.Write("Backen är full. Vill du byta ut någon flaska så välj val 5 i menyn.");
                        // Kod för utbyte av en flaska
                        //Change_bottle(nameTemp, typeTemp, priceTemp);
                        Console.ReadKey(true);
                        break;
                    }
                    // **

                    // ** Så länge inget fack är tomt
                    if (value != null)
                    {
                        //Gör ingenting
                    }
                    // Om tomt fack hittats lägg till vald dryck
                    else
                    {
                        bottles[index] = new Bottle(nameTemp, typeTemp, priceTemp);                  //Lägg till flaska från lagret i tomt fack
                        Console.Write("\nLägg till " + bottles[index] + "\n");
                        //Console.ReadKey(true);
                        break;
                    }
                }
                // ***

                /*switch (undermeny1Val) Jag valde att inte använda denna då jag gjorde en "lager"-konstruktor för att hantera butikens flaskdata
            {
                case 1:                     //Val 1, Loka Gul snö
                    nameTemp = "Loka Gul Snö";
                    typeTemp = "Vatten";
                    priceTemp = 10;
                    break;
                case 2:                     //Val 2, Svampsoda
                    nameTemp = "Svampsoda";
                    typeTemp = "Läsk";
                    priceTemp = 12;
                    break;
                case 3:                     //Val 3, Flaskon lättöl, hur många?
                    nameTemp = "Flaskon Lättöl";
                    typeTemp = "Öl";
                    priceTemp = 24;
                    break;
                case 4:
                    //***Om backen är tom 
                    //***Then slumpa en hel back
                case 0:                     //Val 0, Hoppa till huvudmeny.
                    Console.WriteLine("Åter Huvudmeny.");
                    Run();
                    break;
                default:
                    Console.WriteLine("Felaktigt val. Välj något från menyn (0-3).\n");
                    break;
            }*/
            } while (undermeny1Val != 0);

        }   // **** End Add_Soda() ****

        // **** Kontroll av godkända tecken och blockering av annat än siffror ****
        public int Check_Valid(int _antalMenyval)       // Metoden tar med sig argumentet _antalMenyval
        {
            int antalMenyval = _antalMenyval;
            int _menyVal = 0;
            while (!int.TryParse(Console.ReadLine(), out _menyVal))
            {
                Console.WriteLine("Endast något av menyvalen 0 - " + (antalMenyval --) + " är giltiga.");

            }
            return _menyVal;        // Metoden returnerar ett korrekt valalternativ

        }   // **** End Check_Valid() ****

        // **** Utskrift av backens innehåll
        public void Print_crate()
        {
            Console.Clear();                            // Rensa skärmen
            Console.Write("\n* ** *** L I S T A  B A C K E N S  I N N E H Å L L *** ** *\n\n");

            Console.WriteLine("Fack\tNamn\t\t\tSort\t\tPris");
            Console.WriteLine("-----------------------------------------------------------");
            //Itererar igenom alla fack i backen, läser av om ett fack har innehåll
            foreach (var item in bottles.Select((value, i) => new { i, value }))
            {
                var value = item.value;
                var index = item.i;

                if (value != null)
                {
                    nameTemp = bottles[index].bottleName;
                    typeTemp = bottles[index].bottleType;
                    priceTemp = bottles[index].bottlePrice;
                    Console.Write(index + 1 + " -\t");                                              //Skriver ut fack nr
                    Console.Write(nameTemp + "\t\t" + typeTemp + "\t\t" + priceTemp + "\n");        //Skriver ut innehållet 
                }
            }

            int crateTotal = Calc_total();                                                           // Hämta totalkostnad

            // Om singular (Allergisk mot "Innehåller 1 flaskor" eller "innehåller 0 flaska")
            if (bottleTotal == 1)
            {
                Console.WriteLine("\nDin back innehåller just nu " + bottleTotal + " flaska till ett pris av " + crateTotal + " kr.");
            }
            // annars om noll eller plural
            else
            {
                Console.WriteLine("\nDin back innehåller just nu " + bottleTotal + " flaskor till ett pris av " + crateTotal + " kr.");
            }
            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey(true);

        }   // **** End Print_crate() ****

        // **** Summering av totalkostnad
        public int Calc_total()
        {
            // *** Itererar igenom alla fack i backen, läser av om ett fack har innehåll och lägger till värdet i totalen

            int crateTotal = 0;

            foreach (var item in bottles.Select((value, i) => new { i, value }))
            {
                var value = item.value;
                var index = item.i;

                if (value != null)                                              // Om flaska finns addera priset till crateTotal
                {
                    
                    crateTotal = crateTotal + bottles[index].bottlePrice;       // Addera värdet från Bottles.bottlePrice till crateTotal
                }
            }

            return crateTotal;

        }   // **** End Calc_total() ****

        // **** Hitta dryck - Sök på namn
        public void Find_soda()
        {
            Console.Clear();                                            // Rensa skärmen
            Console.WriteLine("* ** *** S Ö K  D R Y C K *** ** *\n");
            Console.WriteLine("Ange vilken läsk vill du leta efter: ");
            string searchString = Console.ReadLine();                   // Tilldela inmatat värde till sträng searchString
            int searchStringCount = 0;

            //Kontroll om sökt flaska finns i backen
            // *** Iterera igenom backen för att hitta plats för vald flaska
            foreach (var item in bottles.Select((value, i) => new { i, value }))
            {
                var value = item.value;
                var index = item.i;

                // ** Så länge inget fack är tomt
                if (value != null)
                {
                    nameTemp = bottles[index].bottleName;

                    if (searchString == nameTemp)
                    {
                        Console.WriteLine("Flaska med namn " + nameTemp + " funnen i fack " + (index+1));
                        //Console.Write("\nPress any key to continue . . . ");
                        //Console.ReadKey(true);
                        searchStringCount++;
                    }
                    else
                    {
                    }
                }
            }
            if (searchStringCount == 0)
            {
                Console.WriteLine("Inga matchande flaskor med det namnet.\n");
            }

            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey(true);
        } // **** End Find_Soda() ****

        // **** Sortera drycker - Alfabetiskt på Namn eller Typ, eller på Pris
        public void Sort_sodas()
        { 
            int undermeny3Val = 0;                             // initiera heltalsvariabel menyVal för användarinput
            int antalMenyval = 4;                              // initiera antal menyval på huvudmenyn

            do
            {
                Console.Clear();
                Console.WriteLine("* ** *** S O R T E R A  B A C K E N *** ** *\n");
                Console.WriteLine("Hur vill du sortera din back?\n");
                Console.WriteLine("1. på Läsknamn");
                Console.WriteLine("2. på typ");
                Console.WriteLine("3. på Pris");
                Console.WriteLine("0. Åter till huvudmenyn");

                //*** Räkna antal flaskor i backen för att inte få null error
                bottleTotal = 0;
                foreach (Bottle bottle in bottles)
                    if (bottle != null)
                    {
                        bottleTotal++;
                    }
                //***

                undermeny3Val = Check_Valid(antalMenyval);     // Kontroll av godkända menyval

                if (undermeny3Val > antalMenyval)              // Felmeddelande om val ej finns på menyn.
                {
                    Console.WriteLine("Felaktigt val.");
                    Console.ReadKey();
                    Add_soda();

                }

                switch (undermeny3Val)
                {
                    case 1:     // Val 1, Sorterar innehållet alfabetiskt på flasknamn                        

                        int max = bottleTotal;

                        // Yttre loop, går igenom vektorns fyllda platser
                        for (int i = 0; i < max; i++)
                        {
                            //Inre loop, går igenom element för element
                            int nrLeft = max - 1;                                                   // Heltal håller antal ej sorterade element 

                            for (int j = 0; j < nrLeft; j++)                                        // Jämför element
                            {
                                string firstCharOfFirstName = bottles[j].bottleName;                // Deklarera temp sträng för lagring av flasknamn
                                int charFirst = (int)firstCharOfFirstName[0];                       // Plocka ASCII-värdet för första bokstaven ur första flasknamnet
                                string firstCharOfSecondName = bottles[j+1].bottleName;             // Deklarera temp sträng för lagring av andra flasknamnet
                                int charSecond = (int) firstCharOfSecondName[0];                    // Plocka ASCII-värdet för första bokstaven ur andra flasknamnet

                                if (charFirst > charSecond)                                         // Om 1:a bokstav i namn 1 är större än 1:a bokstav i namn 2 
                                {                                    
                                    //Byt plats
                                    int tempPrice = bottles[j].bottlePrice;                         // Skapa temp heltalsvariabel för pris
                                    string tempName = bottles[j].bottleName;                        // Skapa temp sträng för flasknamn
                                    string tempType = bottles[j].bottleType;                        // Skapa temp sträng för flasktyp
                                    Bottle tempBottle = new Bottle(tempName, tempType, tempPrice);  // Skapa temp objekt
                                    bottles[j] = bottles[j + 1];                                    // Flytta objektet med störst pris nedåt i vektorn
                                    bottles[j + 1] = tempBottle;                                    // Flytta objektet med minsta pris uppåt i vektorn
                                }
                            }
                        }

                        //bottles = bottles.OrderBy(a => a.bottleName).ToArray();                   //Fungerar endast om hela vektorn är fylld                        
                        break;
                    case 2:     // Val 2, Sorterar innehållet alfabetiskt på dryckestyp
                        int max2 = bottleTotal;

                        // Yttre loop, går igenom vektorns fyllda platser
                        for (int i = 0; i < max2; i++)
                        {
                            //Inre loop, går igenom element för element
                            int nrLeft = max2 - 1;                                                  // Heltal håller antal ej sorterade element 

                            for (int j = 0; j < nrLeft; j++)                                        // Jämför element
                            {
                                string firstCharOfFirstName = bottles[j].bottleType;                // Deklarera temp sträng för lagring av flasknamn
                                int charFirst = (int)firstCharOfFirstName[0];                       // Plocka ASCII-värdet för första bokstaven ur första flasknamnet
                                string firstCharOfSecondName = bottles[j + 1].bottleType;           // Deklarera temp sträng för lagring av andra flasknamnet
                                int charSecond = (int)firstCharOfSecondName[0];                     // Plocka ASCII-värdet för första bokstaven ur andra flasknamnet

                                if (charFirst > charSecond)                                         // Om 1:a bokstav i namn 1 är större än 1:a bokstav i namn 2 
                                {
                                    //Byt plats
                                    int tempPrice = bottles[j].bottlePrice;                         // Skapa temp heltalsvariabel för pris
                                    string tempName = bottles[j].bottleName;                        // Skapa temp sträng för flasknamn
                                    string tempType = bottles[j].bottleType;                        // Skapa temp sträng för flasktyp
                                    Bottle tempBottle = new Bottle(tempName, tempType, tempPrice);  // Skapa temp objekt
                                    bottles[j] = bottles[j + 1];                                    // Flytta objektet med störst pris nedåt i vektorn
                                    bottles[j + 1] = tempBottle;                                    // Flytta objektet med minsta pris uppåt i vektorn
                                }
                            }
                        }
                        break;
                    case 3:                                                                         // Val 3, Sorterar innehållet numeriskt på pris                        

                        int max3 = bottleTotal;

                        // Yttre loop, går igenom vektorns fyllda platser
                        for (int i = 0; i < max3; i++)
                        {
                            //Inre loop, går igenom element för element
                            int nrLeft = max3 - 1;                                                  // Heltal håller antal ej sorterade element 

                            for (int j = 0; j < nrLeft; j++)                                        // Jämför element
                            {
                                if (bottles[j].bottlePrice > bottles[j + 1].bottlePrice)            // Om 1:a objekt.pris är större än 2:a objekt.pris
                                {
                                    //Byt plats
                                    int tempPrice = bottles[j].bottlePrice;                         // Skapa temp heltalsvariabel för pris
                                    string tempName = bottles[j].bottleName;                        // Skapa temp sträng för flasknamn
                                    string tempType = bottles[j].bottleType;                        // Skapa temp sträng för flasktyp
                                    Bottle tempBottle = new Bottle(tempName, tempType, tempPrice);  // Skapa temp objekt
                                    bottles[j] = bottles[j + 1];                                    // Flytta objektet med störst pris nedåt i vektorn
                                    bottles[j + 1] = tempBottle;                                    // Flytta objektet med minsta pris uppåt i vektorn
                                }
                            }
                        }

                        // bottles = bottles.OrderBy(a => a.bottlePrice).ToArray();
                        break;
                    case 0:                                                                         // Hoppa tillbaka till menyn
                        Run();
                        break;
                    default:
                        Console.WriteLine("Felaktigt val. Endast mellan 1-3.");
                        Sort_sodas();
                        break;
                }                
            } while (undermeny3Val != 0);
        } // **** End Sort_Sodas() ****

        // **** Byt ut dryck
        public void Change_bottle(string _nameTemp, string _typeTemp, int _priceTemp)
        {
            //*** Räkna antal flaskor i backen
            bottleTotal = 0;
            foreach (Bottle bottle in bottles)
                if (bottle != null)
                {
                    bottleTotal++;
                }
            //***

            int antalMenyval = bottleTotal;                                 // Initiera antal valbara flaskor baserat på antalet flaskor i backen.
            int flaskByte = 0;                                              // Initiera heltalsvariabel menyVal för användarinput
            Print_crate();                                                  // Visa backens innehåll för översikt.

            Console.WriteLine("\nVilken flaska vill du byta ut?\n");        // Kommunicera med användaren
            Console.WriteLine("Välj fack från kolumn 1: ");

            flaskByte = Check_Valid(antalMenyval) - 1;                      // Kontroll av godkända tecken och blockering av annat än siffror

            //Byt plats            
            string tempName = _nameTemp;                                    // Skapa temp sträng för flasknamn
            string tempType = _typeTemp;                                    // Skapa temp sträng för flasktyp
            int tempPrice = _priceTemp;                                     // Skapa temp heltalsvariabel för pris
            Bottle changeBottle = bottles[flaskByte];
            Bottle tempBottle = new Bottle(tempName, tempType, tempPrice);  // Skapa temp objekt            
            bottles[flaskByte] = tempBottle;                                // Byt flasknamn

            Console.WriteLine("Flaskan " + changeBottle.bottleName + " är utbytt mot " + bottles[flaskByte].bottleName);
            Console.ReadKey(true);
            Run();

        } // **** End Change_bottle() ****

        // *** Slumpa 24 nummer mellan 0 - 2 för att matcha lagervarorna (0-Läsk, 1-Vatten, 2-Öl)
        public void Random_Crate()
        {   
            bottleTotal = 0;                                                            // Nollställ räknaren för antal flaskor

            Random rnd = new Random();                                                  //Slumpgenerator

            for (int i = 0; i < bottles.Length; i++)                                    // Iterera igenom hela backen
            {
                int slumpf = rnd.Next(0, 3);                                            // Skapar slumptal mellan 0-2
                //Console.Write("\nI lager :" + slumpf + "\t" + stock[slumpf].bottleName);
                nameTemp = stock[slumpf].bottleName;                                    // Lägg till dryckens namn för slumpad flaska i tempvariabel
                typeTemp = stock[slumpf].bottleType;                                    // Lägg till dryckens typ för slumpad flaska i tempvariabel
                priceTemp = stock[slumpf].bottlePrice;                                  // Lägg till dryckens pris för slumpad flaska i tempvariabel

                bottles[i] = new Bottle(nameTemp, typeTemp, priceTemp);                 // Lägg till flaska från lagret i tomt fack   
                bottleTotal++;                                                          // Addera 1 till flasktotal
            }
        }   // **** End Random_Crate()
    }

class Bottle
    {
        public string bottleName;  // Deklarera sträng för flasknamn
        public string bottleType;  // Deklarera sträng för dryckestyp
        public int bottlePrice;    //Deklarera heltal för pris

        //Skapa konstruktor för flaska med argumentlistan _name, _type och _price
        public Bottle(string _name, string _type, int _price)
        {
            this.bottleName = _name;
            this.bottleType = _type;
            this.bottlePrice = _price;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", bottleName, bottleType, bottlePrice);
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            //Skapar ett objekt av klassen Sodacrate som heter sodacrate
            var sodacrate = new Crate("My Super Crate");

            //Kör huvudprogrammet med meny
            sodacrate.Run();

            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey(true);            
        }
    }
}