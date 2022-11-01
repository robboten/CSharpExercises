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

        private string Name;
        public string name
        {
            get => Name;
            set => Name = value;
        }
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

        public bool Equals(Employee e)
        {
            if (e == null) return false;
            return (this.Name.Equals(e.Name));
        }

    }
}
