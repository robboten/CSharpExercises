using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning1
{
    internal class Employee
    {
        public string Id { get; } //are get/set of any use here?
        public string Name; //are get/set of any use here?
        public Employee(string name, string id)
        {
            Id = id;
            Name = name;
        }
    }
}
