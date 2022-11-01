//1 -Classes: Employee (Company, Menu)
//2 - attr: name, salary, id, (role); methods: SetEmployee, GetEmployee (by name/id), UpdateEmployee, RemoveEmployee, ListEmployees
//3
using System;
using System.Text.Json;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Numerics;

namespace Ovning1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            string json = File.ReadAllText(@"D:\employees.json");
            employees = JsonSerializer.Deserialize<List<Employee>>(json);

            //make an array with created employees - append for each?

            var temp =SetEmployee();
            if (temp != null)
            {
                employees.Add(temp);
            }

            //employees.Add(new Employee("Jürgen"));
            //employees.Add(new Employee("Ture"));
            //employees.Add(new Employee("Vidar"));
            //employees.Add(new Employee("Bahare"));

            SaveJSON(employees);

            Console.WriteLine();

            ListEmployees(employees); // loop thru array with employees to get info...

            Employee empl=GetEmployeeById(employees, employees[3].id);
            Console.WriteLine();
            Console.WriteLine("Requested employee (by id " + employees[3].id + "):");
            Console.WriteLine("Name: " + empl.name + " - Id: " + empl.id);

            Console.WriteLine();

            GetEmployeeByName(employees, employees[2].name);

            //Console.WriteLine(employees.Contains(employees[3]));
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
            Console.WriteLine(employee.name + " created with id: " + employee.id);

            return employee;
        }

        static Employee GetEmployeeById(List<Employee> employeeList, string Id)
        {
            var temp=employeeList.Find(Employee=>Employee.id==Id);
            //check if not empty...
            return temp;
        }

        static void GetEmployeeByName(List<Employee> employeeList, string Name)
        {
            var temp = employeeList.Find(Employee => Employee.name == Name);

            Console.WriteLine();
            Console.WriteLine("Requested employee (by name " + Name + "):");
            Console.WriteLine("Name: " + temp.name + " - Id: " + temp.id);
        }

        static void ListEmployees(List<Employee> employees)
        {
            Console.WriteLine("Listing current employees:");
            foreach (Employee employee in employees)
            {
                Console.WriteLine("Name: "+employee.name+" - Id: "+employee.id);
            }
        }

        static void SaveJSON(List<Employee> employees)
        {
            string json = JsonSerializer.Serialize(employees);
            File.WriteAllText(@"D:\employees.json", json);
        }

    }
}