//1 -Classes: Employee (Company, Menu)
//2 - attr: name, salary, (role); methods: SetEmployee, GetEmployee (by name/id), UpdateEmployee, RemoveEmployee, ListEmployees
//3
using System;

namespace Ovning1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //make an array with created employees - append for each?
            SetEmployee();

            //not working atm...
            //GetEmployeeById(Id);
            //GetEmployeeByName(Name);

            //GetEmployees() - loop thru array with employees to get info...
        }

        static void SetEmployee()
        {
            //should this return employee?
            Console.WriteLine("Input new employee:");
            Console.Write("Employee name:");
            string iName = Console.ReadLine();
            Guid guid = Guid.NewGuid();
            string idStr = guid.ToString();

            if (iName != null)
            {
                Employee employee = new Employee(iName, idStr);
                Console.WriteLine(employee.Name +" created with id: "+ employee.Id);
            } 
            else 
            {
                Console.WriteLine("Not a valid input");
                //not sure how to deal with a null return value..
            }
            
        }

        static string GetEmployeeById(string Id)
        {
            return Id;
        }

        static string GetEmployeeByName(string Name)
        {
            return Name;
        }

        static string GetEmployees() {
            return "list of employees...";
        }

    }
}