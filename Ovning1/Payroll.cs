
using System.ComponentModel;
using System.Text.Json;

namespace Ovning1
{
    internal class Payroll 
    {
        private List<Employee> EmployeeList;
        //private int lastId;
        
        public Payroll() {
            EmployeeList = new List<Employee>();
            EmployeeList = ReadJSON();
            //lastId= EmployeeList.Last().Id;
            //Console.WriteLine(lastId);
        }

        public void AddEmployee(Employee employee)
        {
            ReadJSON();
            EmployeeList.Add(employee);
            SaveJSON(EmployeeList);
        }

        public List<Employee> GetEmployees()
        {
            return EmployeeList.ToList();
        }

        private List<Employee> ReadJSON()
        {
            string path = @"D:\employees.json";
            string json;
            if (File.Exists(path))
            {
                json = File.ReadAllText(@"D:\employees.json");
            }
            else
            {
                //make a dummy json for now if file doesn't load...
                json = "[{\"Id\":1,\"Name\":\"Robert\",\"Salary\":10}]";
            }
            //how to safeguard this return if the file is empty/doesn't exist/bugs out in reading?
            //Console.WriteLine(json);
            var EmployeeList = JsonSerializer.Deserialize<List<Employee>>(json);

            //var emp = new Employee("hej", 99,9);
            //EmployeeList.Add(emp);
            //emp = new Employee("ap", 99,6);
            //EmployeeList.Add(emp);

            return EmployeeList;
        }

        private void SaveJSON(List<Employee> employees)
        {
            string json = JsonSerializer.Serialize(employees);
            File.WriteAllText(@"D:\employees.json", json);
        }
    }
}
