using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning1
{
    internal class Employee
    {
        private string Id;
        public string id
        {
            get => Id;
            set => Id = value;
        } //why go thru all this trouble?

        public string Name;
        public Employee(string name)
        {
            Guid guid = Guid.NewGuid();
            Id = guid.ToString();
            Name = name;
        }

        public string GetEmployeeById(string Id)
        {
            return Id;
        }

        public string GetEmployeeByName(string Name)
        {
            return Name;
        }

    }
}
