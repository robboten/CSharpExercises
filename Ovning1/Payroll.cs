
using Ovning1.IO;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace Ovning1
{
    internal class Payroll 
    {
        private readonly ISerialize employeeIn;
        private readonly List<Employee> employeeList;
        public Payroll(ISerialize deserialized) {
            employeeIn = deserialized;
            employeeList = employeeIn.DeserializeEmployees()!;
        }

        public void test()
        {
            Console.WriteLine(employeeList[0].Name);
        }
        public void AddItem()
        {
            Console.WriteLine("\nInput new employee:");
            string iName = Utils.ValidateString("name", true);
            int iSalary = Utils.ValidateInt("salary", true);

            Employee employee = new(iName, iSalary);
            employeeList.Add(employee);
            employeeIn.SerializeEmployees(employeeList);
            Console.WriteLine(employee.Name + " created with id: " + employee.Id);
        }

        public void ListEmployees()
        {
            Console.WriteLine("Listing current employees:");
            foreach (var employee in employeeList)
            {
                employee.Print();
            }

        }
        public List<Employee> GetEmployees()
        {
            return employeeList.ToList();
        }

        public void SearchEmployee()
        {
            Console.WriteLine($"\nSearch for employee (name or id):");
            string sStr = Utils.ValidateInput();
            FindIt(sStr);
        }

        private void FindIt(string searchStr)
        {
            Employee? employee;
            if (int.TryParse(searchStr, out int id))
            {
                employee = employeeList.Find(Employee => Employee.Id == id);
            }
            else
            {
                employee = employeeList.Find(Employee => Employee.Name.ToLower() == searchStr.ToLower());
            }
            
            if (employee != null)
            {
                Console.WriteLine("\nRequested employee:");
                employee.Print();
            }
            else
            {
                Console.WriteLine("Employee " + searchStr + " does not exist");
            }
        }

        private void ClearPayroll() { employeeList.Clear(); }
        private void UpdatePayroll() { }


    }
}
