using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ovning1
{
    internal class Employee
    {
        static private int c = 0;
        public int Id { get; set; }

        //private string guid; //Field
        //public string Id2 //property
        //{
        //    get => guid; //property accessor
        //    set => guid = value; //value = keyword
        //}

        public string Name { get; set; }
        public int Salary { get; set; }

        public Employee(string name, int salary)
        {
            c++;
            //Guid guid = Guid.NewGuid();
            //this.guid = guid.ToString();
            Id = c;
            Name = name;
            Salary = salary;
        }
        [JsonConstructor]
        public Employee(string name, int salary, int id)
        {
            c++;
            Id = id;
            Name = name;
            Salary = salary;
        }
        public bool Equals(Employee e)
        {
            if (e == null) return false;
            return (this.Name.Equals(e.Name));
        }
        public void Print()
        {
            Console.WriteLine("Id:" + Id + " Name: " + Name + " - Salary: " + Salary);
        }
    }
}
