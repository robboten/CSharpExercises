using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning1
{
    internal class Employee
    {
        private string id; //Field
        public string Id //property
        {
            get => id; //property accessor
            set => id = value; //value = keyword
        }

        private string name;
        public string Name
        {
            get => name;
            set => name = value;
        }

        private int salary;
        public int Salary
        {
            get => salary;
            set => salary = value;
        }
        
        public Employee(string name, int salary)
        {
            Guid guid = Guid.NewGuid();
            id = guid.ToString();
            this.Name = name;
            this.Salary = salary;
        }

        public bool Equals(Employee e)
        {
            if (e == null) return false;
            return (this.Name.Equals(e.Name));
        }

    }
}
