
using Ovning1.IO;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace Ovning1
{
    internal class Payroll 
    {
        private readonly ISerialize employeeIn;
        private readonly List<Employee> EmployeeList;
        public Payroll(ISerialize deserialized) {
            employeeIn = deserialized;
            EmployeeList = employeeIn.DeserializeEmployees();
        }

        public void test()
        {
            Console.WriteLine(EmployeeList[0].Name);
        }
        public void AddItem()
        {
            Console.WriteLine("\nInput new employee:");
            string iName = Utils.ValidateString("name", true);
            int iSalary = Utils.ValidateInt("salary", true);

            Employee employee = new(iName, iSalary);
            EmployeeList.Add(employee);
            Console.WriteLine(employee.Name + " created with id: " + employee.Id);
            // SaveJSON(EmployeeList);
        }

        public void ListEmployees()
        {
            Console.WriteLine("Listing current employees:");
            foreach (var employee in EmployeeList)
            {
                employee.Print();
            }

        }
        public List<Employee> GetEmployees()
        {
            return EmployeeList.ToList();
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
                employee = EmployeeList.Find(Employee => Employee.Id == id);
            }
            else
            {
                employee = EmployeeList.Find(Employee => Employee.Name.ToLower() == searchStr.ToLower());
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

        private void ClearPayroll() { EmployeeList.Clear(); }
        private void UpdatePayroll() { }


    }
}
