//1 -Classes: Employee (Company, Menu)
//2 - attr: name, salary, id, (role); methods: SetEmployee, GetEmployee (by name/id), UpdateEmployee, RemoveEmployee, ListEmployees
//3
using System.Collections;
using System.Security.Cryptography;
using static Ovning1.Menu;

namespace Ovning1
{

    internal class Program
    {
        static Payroll employees = new();
        static void Main(string[] args)
        {
            //postgresql.dosql();
            while (true)
            {
                Console.WriteLine("Enter a command:\na to add new \tl to list all \tn to search by name \ti to seach by id \tq to quit");
                char command = Console.ReadKey().KeyChar;
                switch (command)
                {
                    case MenuHelpers.Quit: Console.WriteLine("\nquitting..."); return;
                    case MenuHelpers.Add: AddEmployee(); break;
                    case MenuHelpers.List: ListEmployees(); break;
                    case MenuHelpers.SearchName: GetEmployeeByName(); break;
                    case MenuHelpers.SearchId: GetEmployeeById(); break;
                    default: Console.WriteLine("\nEnter a valid command"); break;
                }
            }
        }

        static void AddEmployee()
        {
            Console.WriteLine("\nInput new employee:");
            string iName = Utils.ValidateString("name",true);
            int iSalary = Utils.ValidateInt("salary",true);

            Employee employee = new Employee(iName, iSalary);
            employees.AddEmployee(employee);
            Console.WriteLine(employee.Name + " created with id: " + employee.Id);
        }

        static void GetEmployeeById()
        {
            Console.WriteLine("\nSearch employee by id:");
            int iId = Utils.ValidateInt("id", false);

            var employeeList = employees.GetEmployees();
            var employee = employeeList.Find(Employee => Employee.Id == iId);

            
            if (employee != null)
            {
                Console.WriteLine("\nRequested employee:");
                employee.Print();
            }
            else
            {
                Console.WriteLine("Employee (by id " + iId + ") does not exist");
            }
        }

        static void GetEmployeeByName()
        {
            Console.WriteLine("\nSearch employee by name:");
            string iName = Utils.ValidateString("name", false);

            var employee = employees.GetEmployees().Find(Employee => Employee.Name.ToLower() == iName.ToLower());

            if (employee != null)
            {
                Console.WriteLine("\nRequested employee:");
                employee.Print();
            }
            else
            {
                Console.WriteLine("Employee " + iName + " does not exist");
            }
        }

        static void ListEmployees()
        {
            Console.WriteLine("Listing current employees:");
            foreach (var employee in employees.GetEmployees())
            {
                employee.Print();
            }

        }
    }
}