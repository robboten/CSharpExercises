using System;
using System.Threading.Tasks;

namespace Ovning4
{
    class MyInt
    {
        public int MyValue { get; set; }
    }
    class Program
    {
        //svar 1-3
        static int ReturnValue()
        {
            MyInt x = new MyInt(); //MyValue läggs på heap då den initieras i constructor för den nya instansen (av typen reference)
            x.MyValue = 3;
            // int x=3 om det skulle stått såhär istället skulle det vara en "value type", den läggs på stack när ReturnValue körs/anropas
            MyInt y = new MyInt();
            y = x;    //y sätts till x-objektet/instansen
            y.MyValue = 4; //4 sätts till både MyValue för både x/y
            return x.MyValue;
        }//när vi är klara och inte använder metoden längre kommer allt från stack rensas bort (i detta fall inget)
         //detta då stacken bara är för det som behövs för att komma åt nästa i stack. Eftersom vi är klara med den biten av stack 
         //MyInt kommer inte rensas bort förrens garbage collectorn tycker att det är dags (den ligger på heap men inte på stack)
         //Fördelen med heap är att vi kan använda saker utanför sitt eget scope. MyInt finns kvar och kan återanvändas, 
         //int x däremot är bara en rest som vi inte vill ska ligga kvar i minnet.
         //Heap är dynamiskt och kan anpassas utifrån det vi behöver det till, men kan också leda till problem om vi har dålig garbage collection 
         //i C++ och en del andra språk får du själv hålla mer ansvar för detta och göra .free/destroy och liknande för att ta bort sånt som inte används. 
         //görs inte det kan man få minnesläckor som till slut gör hela systemet instabilt
         //tycker den här sidan förklarar det bra. https://www.bytelab.codes/what-is-memory-part-4-stack-allocations-dynamic-allocations-and-the-heap/

        /// <summary>
        /// The main method, will handle the menus for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            //ReturnValue();
            //CheckParanthesis();
            while (true)
            {
                
                Console.WriteLine("please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. examine a list"
                    + "\n2. examine a queue"
                    + "\n3. examine a stack"
                    + "\n4. checkparanthesis"
                    + "\n0. exit the application");
                char input = ' '; //creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //if the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

            /// <summary>
            /// Examines the datastructure List
            /// </summary>
            static void ExamineList()
            {
                /*
                 * Loop this method untill the user inputs something to exit to main menue.
                 * Create a switch statement with cases '+' and '-'
                 * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
                 * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
                 * In both cases, look at the count and capacity of the list
                 * As a default case, tell them to use only + or -
                 * Below you can see some inspirational code to begin working.
                */

                //2.När ökar listans kapacitet ? (Alltså den underliggande arrayens storlek)
                // När count > capacity
                //3.Med hur mycket ökar kapaciteten?
                //dubbla tyckte jag det verkade som, men testade inte mer än några gånger (från 4 först till 8
                //4.Varför ökar inte listans kapacitet i samma takt som element läggs till ?
                //onödigt att öka utan att det behövs
                //5.Minskar kapaciteten när element tas bort ur listan?
                //nej
                //6.När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
                //när man redan på förhand vet hur många som ska finnas i listan/array

                List<string> theList = new List<string>();
                while (true)
                {
                    Console.WriteLine("+Add, -Remove");
                    string input = Console.ReadLine();
                    char nav = input[0];
                    string value = input.Substring(1);
                    switch (nav)
                    {
                        case '+':
                            theList.Add(value);
                            Console.WriteLine(theList.Count);
                            Console.WriteLine(theList.Capacity);
                            break;
                        case '-':
                            theList.Remove(value);
                            Console.WriteLine(theList.Count);
                            Console.WriteLine(theList.Capacity);
                            break;
                        case '0':
                            return;
                        default:
                            Console.WriteLine("use only + or -");
                            break;
                    }
                }

            }

            /// <summary>
            /// Examines the datastructure Queue
            /// </summary>
            static void ExamineQueue()
            {
                /*
                 * Loop this method untill the user inputs something to exit to main menue.
                 * Create a switch with cases to enqueue items or dequeue items
                 * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
                */
                Queue<string> theList = new Queue<string>();
                
                while (true)
                {
                Console.WriteLine("+queu -dequeu 0=Exit");
                
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);
                switch (nav)
                {
                    case '+':
                        theList.Enqueue(value);
                        Console.WriteLine(theList.Count);
                        break;
                    case '-':
                        theList.Dequeue();
                        Console.WriteLine(theList.Count);
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("use only + or -");
                        break;
                }
                }
            return;
            }

            /// <summary>
            /// Examines the datastructure Stack
            /// </summary>
            static void ExamineStack()
            {
                /*
                 * Loop this method until the user inputs something to exit to main menue.
                 * Create a switch with cases to push or pop items
                 * Make sure to look at the stack after pushing and and poping to see how it behaves
                */
                Stack<string> theList = new Stack<string>();
                
                while (true)
                {
                Console.WriteLine("+push -pop .ReverseText 0=exit");
                string input = Console.ReadLine();
                    char nav = input[0];
                    string value = input.Substring(1);
                    switch (nav)
                    {
                        case '+':
                            theList.Push(value);
                            break;
                        case '-':
                            theList.Pop();
                            break;
                        case '.':
                            ReverseText(value);
                            break;
                        case '0':
                            return;
                        default:
                            Console.WriteLine("use only + or -");
                            break;
                    }
                }
            }

            private static void ReverseText(string value)
            {
                Stack<char> text = new Stack<char>();
                value.ToList().ForEach(c => text.Push(c));
                //for (int i = 0; i < value.Length; i++)
                //{
                //    text.Push(value[i]);
                //}
                //value.ToCharArray().Reverse(); är dock lite enklare...
                text.ToList().ForEach(c => Console.Write(c));
                Console.WriteLine();
                return;
            }

            static void CheckParanthesis()
            {
                /*
                 * Use this method to check if the paranthesis in a string is Correct or incorrect.
                 * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
                 * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
                 */

                //1.Skapa med hjälp av er nya kunskap funktionalitet för att kontrollera en välformad
                //sträng på papper.Du ska använda dig av någon eller några av de datastrukturer vi
                //precis gått igenom.Vilken datastruktur använder du?
                //2.Implementera funktionaliteten i metoden CheckParentheses. Låt programmet läsa
                //in en sträng från användaren och returnera ett svar som reflekterar huruvida
                //strängen är välformad eller ej.

                Console.Write("Mata in text för att testa om den är välformaterad: ");
                 //string text="{[A[(ddf(({}))]]}m";
                 string text = Console.ReadLine();

                IDictionary<char, char> pairs = new Dictionary<char, char>();
                pairs.Add('(', ')');
                pairs.Add('{', '}');
                pairs.Add('[', ']');

                Stack<char> openings = new(text.Where(c => (c == '(' || c == '[' || c == '{')));
                IEnumerable<char> closings = text.Where(c => (c == pairs['('] || c == pairs['['] || c == pairs['{']));
                
                if (openings.Count != closings.Count())
            {
                Console.WriteLine("Olika antal öppnade och stängda. Texten är inte välformaterad. Avbryter");
                Console.WriteLine("Tryck valfri tangent för att komma tillbaka till menyn");
                Console.ReadKey();
            }
                else
            {
                //OBS - buggar ur om man matar in öppningstecken efter sluttecken ex a(())(( har inte hunnit fixa
                for (int i = 0; i < openings.Count; i++)
                {
                    var op = openings.ElementAt(i);
                    var cl = closings.ElementAt(i);
                    if (pairs[op] == cl)
                    {
                        Console.WriteLine($"{i} är välformaterad - {op}={cl}");
                    }
                    else
                    {
                        Console.WriteLine($"{i} matchar inte - {op}={cl}. Texten är inte välformaterad");
                        Console.WriteLine("Tryck valfri tangent för att komma tillbaka till menyn");
                        Console.ReadKey();
                        return;
                    }
                }
            }
            Console.WriteLine("Tryck valfri tangent för att komma tillbaka till menyn");
            Console.ReadKey();
            return;

            }

            private static bool Check2(char q, char s)
            {
                return (q == '(' && s == ')') || (q == '[' && s == ']') || (q == '{' && s == '}');
            }
            private static bool Check3(char c)
            {
                return (c == '(' || c == ')' || c == '[' || c == ']' || c == '{' || c == '}');
            }
        }
    }

