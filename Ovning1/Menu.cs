using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning1
{
    internal class Menu
    {
        public static class MenuHelpers
        {
            public const char Quit = 'q';
            public const char List = 'l';
            public const char Add = 'a';
            public const char Search = 's';
            public const char Remove = 'r';
            public const char Update = 'u';
        }
        //public static void menu()
        //{
        //    while (true)
        //    {
        //        Console.WriteLine("Enter a command:\na to add new \tl to list all \tn to search by name \ti to seach by id \tq to quit");
        //        char command = Console.ReadKey().KeyChar;
        //        switch (command)
        //        {
        //            case MenuHelpers.Quit: Console.WriteLine("\nquitting..."); return;
        //            case MenuHelpers.Add: AddEmployee(); break;
        //            case MenuHelpers.List: ListEmployees(); break;
        //            case MenuHelpers.SearchName: GetEmployeeByName(); break;
        //            case MenuHelpers.SearchId: GetEmployeeById(); break;
        //            default: Console.WriteLine("\nEnter a valid command"); break;
        //        }
        //    }

        //}
        
    }
}
