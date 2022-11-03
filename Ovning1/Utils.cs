using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning1
{
    internal class Utils
    {
        public static int ValidateInt(string str, bool o)
        {

            if (o)
            {
                Console.Write($"Employee {str}:");
            }
            string val = Console.ReadLine()!;

            while (true)
            {
                if (!string.IsNullOrEmpty(val) && int.TryParse(val, out int i))
                {
                    return i;
                }
                else
                {
                    Console.WriteLine("Not a valid input for " + str);
                    Console.WriteLine("Try again:");
                    val = Console.ReadLine()!;
                }
            }
        }

        public static string ValidateString(string str, bool o)
        {
            if (o)
            {
                Console.Write($"Employee {str}:");
            }
            string val = Console.ReadLine()!;

            while (true)
            {
                if (string.IsNullOrEmpty(val) || int.TryParse(val, out int i))
                {
                    Console.WriteLine("Not a valid input for " + str);
                    Console.WriteLine("Try again:");
                    val = Console.ReadLine()!;
                }
                else
                {
                    return val;
                }
            }
        }

    }
}
