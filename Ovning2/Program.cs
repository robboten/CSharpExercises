using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;

namespace Ovning2
{
    internal class Program
    {
        //För att skapa programmets huvudmeny ska ni göra följande:
        //1. Berätta för användaren att de har kommit till huvudmenyn och de kommer navigera
        //genom att skriva in siffror för att testa olika funktioner.
        //2. Skapa skalet till en Switch-sats som till en början har Två Cases. Ett för ”0” som
        //stänger ner programmet och ett default som berättar att det är felaktig input.
        //3. Skapa en oändlig iteration, alltså något som inte tar slut innan vi säger till att den
        //ska ta slut.Detta löser ni med att skapa en egen bool med tillhörande while-loop.
        //4. Bygg ut menyn med val att exekvera de övriga övningarna.


        static class MenuItem
        {
            public const char First = '1';
            public const char Second = '2';
            public const char Third = '3';
            public const char Fourth = '4';
            public const char Quit = '0';
        }

        static void Main(string[] args)
        {
            Console.Clear();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Huvudmeny");
                Console.WriteLine("---------");
                Console.WriteLine("Välj ett av följande val:");
                Console.WriteLine($"{MenuItem.First}: Se pris baserat på din ålder");
                Console.WriteLine($"{MenuItem.Second}: Beräkna pris för ett sällskap");
                Console.WriteLine($"{MenuItem.Third}: Stycka upp mening till ord");
                Console.WriteLine($"{MenuItem.Fourth}: Tredje ordet");
                Console.WriteLine($"{MenuItem.Quit}: Avsluta");

                char command = Console.ReadKey(true).KeyChar;
                switch (command)
                {
                    case MenuItem.First: Console.Clear(); CheckAgeAlt(true); break;
                    case MenuItem.Second: Console.Clear(); CalcPrice(); break;
                    case MenuItem.Third: Console.Clear(); Dahmer(); break;
                    case MenuItem.Fourth: Console.Clear(); ThirdWord(); break;
                    case MenuItem.Quit: return;
                    default: Console.WriteLine($"\nVälj ett av valen 1-4 eller {MenuItem.Quit}\n"); break;
                } 
            }
        }


        //1. Användaren anger en ålder i siffror
        //2.Programmet konverterar detta från en sträng till en int
        //3.Programmet ser om personen är ungdom(under 20 år)
        //4.Om det ovanstående är sant skall programmet skriva ut: Ungdomspris: 80kr
        //5.Annars kollar programmet om personen är en pensionär(över 64 år)
        //6.Om ovanstående är sant skall programmet skruva ut: Pensionärspris: 90kr
        //7.Annars skall programmet skriva ut: Standardpris: 120k

        //alt with old ifs, could be case too maybe? Good - easy to read, more output. Bad - long and unflexible
        static int CheckAge() //1
        {
            int price;
            while (true)
            {
                Console.Write("Skriv en ålder: ");
                if (uint.TryParse(Console.ReadLine(), out uint age))
                {
                    if (age < 20)
                    {
                        price = 80;
                        Console.WriteLine($"Ungdomspris: {price}kr");
                    }
                    else if (age>122)
                    {
                        price = 0;
                        Console.WriteLine("Wow! Du är nu äldst i världen och får gå gratis!");
                    }
                    else if(age > 64)
                    {
                        price = 90;
                        Console.WriteLine($"Pensionärspris: {price}kr");
                    }
                    else if (age < 5 || age>100)
                    {
                        price = 0;
                        Console.WriteLine("Gratis!");
                    }
                    else
                    {
                        price = 120;
                        Console.WriteLine($"Standardpris: {price}kr");
                    }
                    return price;
                }
                else
                {
                    Console.WriteLine("Skriv åldern i siffror");
                }
            }
        }

        //alternative with ternary operator returning tuple with int and string. Good - clean. Bad - ?
        static int CheckAgeAlt(bool echo)
        {
            (int, string) GetPrice2(uint value)
            {
                return
                    (value > 100) ? (0, "Gratis") :
                    (value > 64) ? (90, "Pensionärspris") :
                    (value > 20) ? (120, "Standardpris") :
                    (value > 5) ? (80, "Ungdomspris") :
                    (value > 0) ? (0, "Gratis") :
                    (120, "Standardpris");
            }
            while (true)
            {
                Console.Write("Skriv en ålder: ");
                if (uint.TryParse(Console.ReadLine(), out uint age))
                {
                    int price = GetPrice2(age).Item1;
                    Console.WriteLine($"Priset för {age} år är {price} kr ({GetPrice2(age).Item2})");
                    if (echo)
                    {
                        Console.WriteLine("Tryck valfri tangent för att fortsätta ...");
                        Console.ReadKey();
                    }
                    return price;
                }
                else
                {
                    Console.WriteLine("Skriv åldern i siffror");
                }
            }

            //alternative with ternary operator returning ints only. Good - clean. Bad - no nice string if keeping the prices as ints
            //int GetPrice(uint value)
            //{
            //    return
            //        (value > 100) ? 0 :
            //        (value > 64) ? 90 :
            //        (value > 20) ? 120 :
            //        (value > 5) ? 80 :
            //        (value > 0) ? 0 :
            //        120;
            //}
            //while (true)
            //{
            //    Console.Write("Skriv en ålder: ");
            //    if (uint.TryParse(Console.ReadLine(), out uint age))
            //    {
            //        int price = GetPrice(age);
            //        Console.WriteLine($"Priset för {age} år är {price} kr");
            //        Console.WriteLine("Tryck valfri tangent för att fortsätta ...");
            //        Console.ReadKey();
            //        return price;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Skriv åldern i siffror");
            //    }
            //}
        }

        static void CalcPrice() //2
        {

            //Vi anger då först hur många vi är som ska gå på bio.Frågar sedan efter ålder på var och en
            //och skriver sedan ut en sammanfattning i konsolen som ska innehålla följande:
            //● Antal personer
            //● Samt totalkostnad för hela sällskapet
            while (true)
            {
                Console.Write("Hur många är ni i sällskapet? ");
                if (uint.TryParse(Console.ReadLine(), out uint nr))
                {
                    int total = 0;
                    for (int i = 0; i < nr; i++)
                    {
                        total=total+ CheckAgeAlt(false);
                    }
                    Console.WriteLine($"Den totala kostnaden för sällskapet är {total} kr");
                    Console.WriteLine("Tryck valfri tangent för att fortsätta ...");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Skriv antal personer i siffror");
                }
                
            }
        }

        static void Dahmer() //3
        {
            //Händelseförloppet visas nedan:
            //1.Användaren anger en godtycklig text
            //2.Programmet sparar texten som en variabel
            //3.Programmet skriver, via en for-loop ut denna text tio gånger på rad, alltså UTAN radbrott.
            //Exempel på output: 1.Input, 2.Input, 3.Input osv.

            Console.Write("Skriv in ett antal ord: ");
            string str = Console.ReadLine(); //if there is no word nothing will happen so not sure if validation is needed here
            var lst = str.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries); //split on space and remove leftover whitespaces
            Console.WriteLine();

            //alt 1 - no number prefix but simple code and no ugly , at the end
            Console.WriteLine($"Output alt 1: {string.Join(", ",lst)}\n");

            //alt 2 - has it all but is a bit tricky to understand (nests join, select and lambda into one)
            //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
            string Prefix = ".";
            string strOutput = string.Join(", ", lst.Select((x,index) => index+1 + Prefix + x));
            Console.WriteLine($"Output alt 2:{strOutput}");
            Console.WriteLine();

            //alt 3 - ugly comma at end and long code
            //would also be possible to add a ", " to each word in lst but the last one, before looping out
            Console.WriteLine("Output alt 3:");
            for (int i = 0; i < (lst.Length); i++)
            {
                Console.Write($"{i+1}.{ lst[i]}, ");
            }
            Console.WriteLine("\n\nTryck valfri tangent för att fortsätta ...");
            Console.ReadKey();
        }

        static void ThirdWord()
        {
            //Händelseförloppet förklaras nedan:
            //1.Användaren anger en mening med minst 3 ord
            //2.Programmet delar upp strängen med split - metoden på varje mellanslag
            //3.Programmet plockar ut den tredje strängen(ordet) ur input
            //4.Programmet skriver ut den tredje strängen(ordet

            while (true)
            {
                int nr = 3;
                Console.Clear();
                Console.Write($"Skriv in minst {nr} ord: ");
                string str = Console.ReadLine();
                if (str != "")
                {
                    var lst = str.Split(null);
                    if (lst.Length > nr-1)
                    {
                        Console.WriteLine($"Ord nr {nr} är: {lst[nr-1]}");
                        Console.WriteLine("\nTryck valfri tangent för att fortsätta ...");
                        Console.ReadKey();
                        return;
                    }
                }
            }
        }

        //Extra uppgifter för de som har tid över:
        //1. Validera alla inputs från användaren.Se till att programmet inte kraschar vid
        //felaktig input.
        //2. Barn under fem och pensionärer över 100 går gratis.
        //3. Hantera flera mellanslag i rad i del 3.
        //4. Vad du tycker verkar vara intressant att få med eller vill träna på!
    }
}