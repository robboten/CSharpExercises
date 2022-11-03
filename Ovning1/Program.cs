//1 -Classes: Employee (Company, Menu)
//2 - attr: name, salary, id, (role); methods: SetEmployee, GetEmployee (by name/id), UpdateEmployee, RemoveEmployee, ListEmployees
//3
using System.Security.Cryptography;
using static Ovning1.Menu;

namespace Ovning1
{

    internal class Program
    {
        static Payroll employees = new Payroll();
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
            Console.Write("Employee name:");
            string iName = Utils.ValidateString(Console.ReadLine(),"name");

            Console.Write("Employee salary:");
            int iSalary = Utils.ValidateInt(Console.ReadLine(),"salary");

            Employee employee = new Employee(iName, iSalary);
            employees.AddEmployee(employee);
            Console.WriteLine(employee.Name + " created with id: " + employee.Id);
        }

        static void GetEmployeeById()
        {
            Console.WriteLine("\nSearch employee by id:");
            Console.Write("Employee id:");

            int iId = Utils.ValidateInt(Console.ReadLine(), "id");

            var employeeList = employees.GetEmployees();
            var employee = employeeList.Find(Employee => Employee.Id == iId);

            
            if (employee != null)
            {
                Console.WriteLine("\nRequested employee:");
                PrintEmployee(employee);
            }
            else
            {
                Console.WriteLine("Employee (by id " + iId + ") does not exist");
            }
        }

        static void GetEmployeeByName()
        {
            Console.WriteLine("\nSearch employee by name:");
            Console.Write("Employee name:");
            string iName = Utils.ValidateString(Console.ReadLine(),"name");

            var employee = employees.GetEmployees().Find(Employee => Employee.Name == iName);

            if (employee != null)
            {
                Console.WriteLine("\nRequested employee:");
                PrintEmployee(employee);
            }
            else
            {
                Console.WriteLine("Employee " + iName + " does not exist");
            }
        }
        static void PrintEmployee(Employee emp)
        {
            Console.WriteLine("Id:" + emp.Id + " Name: " + emp.Name + " - Salary: " + emp.Salary);
        }
        static void ListEmployees()
        {
            Console.WriteLine("Listing current employees:");
            foreach (var employee in employees.GetEmployees())
            {
                PrintEmployee(employee);
            }

        }
    }
}