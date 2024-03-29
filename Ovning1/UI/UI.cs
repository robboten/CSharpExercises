﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning1.UI
{
    public class ConsoleUi : IUI
    {
        public string GetInput()
        {
            return Console.ReadLine()!;
        }

        public void Print(string msg)
        {
            Console.WriteLine(msg);
        }
    }
    internal class WinFormsUi : IUI
    {
        public WinFormsUi(Payroll employees)
        {
            Form1 Formen = new(employees);
            var l = employees.GetEmployees().ToArray();

            Formen.AddStuff(l);
            Application.Run(Formen);
        }
        
        public string GetInput()
        {
            return "j";
        }
        public void Print(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
