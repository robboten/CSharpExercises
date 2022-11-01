//1 -Classes: Employee (Company, Menu)
//2 - attr: name, salary, id, (role); methods: SetEmployee, GetEmployee (by name/id), UpdateEmployee, RemoveEmployee, ListEmployees
//3
using System;
using System.Runtime.InteropServices;

namespace Ovning1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            //make an array with created employees - append for each?

            var temp=SetEmployee();
            if (temp != null)
            {
                employees.Add(temp);
            }

            employees.Add(new Employee("Anna"));
            employees.Add(new Employee("Ture"));
            employees.Add(new Employee("Vidar"));
            employees.Add(new Employee("Bahare"));

            //not working atm...
            //GetEmployeeById(Id);
            //GetEmployeeByName(Name);

            ListEmployees(employees); // loop thru array with employees to get info...
        }

        static Employee SetEmployee()
        {
            Console.WriteLine("Input new employee:");
            Console.Write("Employee name:");
            string iName = Console.ReadLine();

            while (string.IsNullOrEmpty(iName)) {
                Console.WriteLine("Not a valid input");
                Console.WriteLine("Input new employee:");
                iName = Console.ReadLine();
            }
 
            Employee employee = new Employee(iName);
            Console.WriteLine(employee.Name + " created with id: " + employee.id);

            return employee;
        }

        static void ListEmployees(List<Employee> employees)
        {
            Console.WriteLine("Listing current employees:");
            foreach (Employee employee in employees)
            {
                Console.WriteLine("Name: "+employee.Name+" - Id: "+employee.id);
            }
        }

    }
}