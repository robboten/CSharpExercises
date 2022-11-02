//1 -Classes: Employee (Company, Menu)
//2 - attr: name, salary, id, (role); methods: SetEmployee, GetEmployee (by name/id), UpdateEmployee, RemoveEmployee, ListEmployees
//3
using System.Security.Cryptography;
using System.Text.Json;
namespace Ovning1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a command:\n c to create new \t l to list all \t n to search by name \t i to seach by id \t q to quit");
                char command = Console.ReadKey().KeyChar;
                switch (command)
                {
                    case 'q': Console.WriteLine("\n quitting..."); return;
                    case 'c': SetEmployee(); break;
                    case 'l': ListEmployees(); break;
                    case 'n': GetEmployeeByName(); break;
                    case 'i': GetEmployeeById(); break;
                    default: Console.WriteLine("\n enter a valid command"); break;
                }
            }
        }

        static void SetEmployee()
        {
            Console.WriteLine("Input new employee:");
            Console.Write("Employee name:");
            string iName = Console.ReadLine();

            while (string.IsNullOrEmpty(iName))
            {
                Console.WriteLine("Not a valid input");
                Console.WriteLine("Input new employee name:");
                iName = Console.ReadLine();
            }
            Console.Write("Employee salary:");
            string iSalary = Console.ReadLine();
            while (string.IsNullOrEmpty(iSalary))
            {
                Console.WriteLine("Not a valid input");
                Console.WriteLine("Input new employee salary:");
                iSalary = Console.ReadLine();
            }

            Employee employee = new Employee(iName, Int32.Parse(iSalary));

            List<Employee> employees = new List<Employee>();

            employees = ReadJSON();
            employees.Add(employee);
            SaveJSON(employees);

            Console.WriteLine(employee.Name + " created with id: " + employee.Id);
        }

        static void GetEmployeeById()
        {
            Console.WriteLine("Search employee by id:");
            Console.Write("Employee id:");
            string iId = Console.ReadLine();

            while (string.IsNullOrEmpty(iId))
            {
                Console.WriteLine("Not a valid input");
                Console.WriteLine("Input new employee name:");
                iId = Console.ReadLine();
            }

            List<Employee> employees = new List<Employee>();
            employees = ReadJSON();
            var employee = employees.Find(Employee => Employee.Id == iId);
            //Console.WriteLine(employees.Contains(employees[3]));
            //if not found...
            if (employee != null)
            {
                Console.WriteLine();
                Console.WriteLine("Requested employee (by id " + iId + "):");
                Console.WriteLine("Id: " + employee.Id + " Name: " + employee.Name + " - Salary: " + employee.Salary);
            }
            else
            {
                Console.WriteLine("Employee (by id " + iId + ") does not exist");
            }
            
        }

        static void GetEmployeeByName()
        {
            Console.WriteLine("Search employee by name:");
            Console.Write("Employee name:");
            string iName = Console.ReadLine();

            while (string.IsNullOrEmpty(iName))
            {
                Console.WriteLine("Not a valid input");
                Console.WriteLine("Input new employee name:");
                iName = Console.ReadLine();
            }

            List<Employee> employees = new List<Employee>();
            employees = ReadJSON();
            var employee = employees.Find(Employee => Employee.Name == iName);
            //if not found...
            if(employee != null)
            {
                Console.WriteLine();
                Console.WriteLine("Requested employee (by name " + iName + "):");
                Console.WriteLine("Id: " + employee.Id +" Name: " + employee.Name + " - Salary: " + employee.Salary);
            }
            else
            {
                Console.WriteLine("Employee " + iName + " does not exist");
            }

        }

        static void ListEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees = ReadJSON();
            Console.WriteLine("Listing current employees:");
            foreach (Employee employee in employees)
            {
                Console.WriteLine("Id: " + employee.Id + " Name: " + employee.Name + " - Salary: " + employee.Salary);
            }
        }

        static List<Employee> ReadJSON()
        {
            string path = @"D:\employees.json";
            string json;
            if (File.Exists(path))
            {
                 json = File.ReadAllText(@"D:\employees.json");
                //Console.WriteLine(json);
            } 
            else
            {
                //make a dummy json for now if file doesn't load...
                json = "[{\"Id\":\"541d9753-82b8-486a-97e2-1af3cd005dc2\",\"Name\":\"Robert\",\"Salary\":1},{\"Id\":\"c5bc3970-e36d-4624-a1d1-dd2913bbeda3\",\"Name\":\"Soran\",\"Salary\":64},{\"Id\":\"9737d643-e961-41d1-8e8a-ca05cf625fc2\",\"Name\":\"Bethany\",\"Salary\":990},{\"Id\":\"003e1152-8add-4ee7-8ab5-3a5b6bad0d58\",\"Name\":\"Julian\",\"Salary\":667},{\"Id\":\"d9edc44c-d087-4c4e-adce-ca00d94b1da9\",\"Name\":\"Stephani\",\"Nicole\":900},{\"Id\":\"222c335d-11d4-46d8-8641-fae8d491f6a7\",\"Name\":\"Seth\",\"Salary\":988}]";
            }
            //how to safeguard this return if the file is empty/doesn't exist/bugs out in reading?
            return JsonSerializer.Deserialize<List<Employee>>(json);

        }

        static void SaveJSON(List<Employee> employees)
        {
            string json = JsonSerializer.Serialize(employees);
            File.WriteAllText(@"D:\employees.json", json);
        }

    }
}