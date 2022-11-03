using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;
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

        static void Main(string[] args)
        {
            Console.WriteLine("Main menu");
            Console.WriteLine("---------");

            while (true)
            {

            }
        }

        void CheckAge() //1
        {
        // Användaren anger en ålder i siffror
        //2.Programmet konverterar detta från en sträng till en int
        //3.Programmet ser om personen är ungdom(under 20 år)
        //4.Om det ovanstående är sant skall programmet skriva ut: Ungdomspris: 80kr
        //5.Annars kollar programmet om personen är en pensionär(över 64 år)
        //6.Om ovanstående är sant skall programmet skruva ut: Pensionärspris: 90kr
        //7.Annars skall programmet skriva ut: Standardpris: 120k
        }

        void CalcPrice() //2
        {
            //Vi anger då först hur många vi är som ska gå på bio.Frågar sedan efter ålder på var och en
            //och skriver sedan ut en sammanfattning i konsolen som ska innehålla följande:
            //● Antal personer
            //● Samt totalkostnad för hela sällskapet
        }

        void Parrot() //3
        {
            //Händelseförloppet visas nedan:
            //1.Användaren anger en godtycklig text
            //2.Programmet sparar texten som en variabel
            //3.Programmet skriver, via en for-loop ut denna text tio gånger på rad, alltså UTAN
            //radbrott.Exempel på output: 1.Input, 2.Input, 3.Input osv.
        }

        void ThirdWord()
        {
            //Händelseförloppet förklaras nedan:
            //1.Användaren anger en mening med minst 3 ord
            //2.Programmet delar upp strängen med split - metoden på varje mellanslag
            //3.Programmet plockar ut den tredje strängen(ordet) ur input
            //4.Programmet skriver ut den tredje strängen(ordet
        }

        //Extra uppgifter för de som har tid över:
        //1. Validera alla inputs från användaren.Se till att programmet inte kraschar vid
        //felaktig input.
        //2. Barn under fem och pensionärer över 100 går gratis.
        //3. Hantera flera mellanslag i rad i del 3.
        //4. Vad du tycker verkar vara intressant att få med eller vill träna på!
    }
}