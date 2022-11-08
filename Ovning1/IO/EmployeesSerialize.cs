using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ovning1.IO
{
    internal class EmployeesSerialize: ISerialize
    {
        private readonly string path = @"D:\employees.json";
        public List<Employee>? DeserializeEmployees()
        {
            string json = ReadFile();
            List<Employee>? EmployeeList= JsonSerializer.Deserialize<List<Employee>>(json);
            return EmployeeList;
        }
        public void SerializeEmployees(List<Employee> employees)
        {
            string text=JsonSerializer.Serialize(employees);
            SaveFile(text);
        }
        private string ReadFile()
        {
            string text;
            if (File.Exists(this.path))
            {
                text = File.ReadAllText(this.path);
            }
            else
            {
                //make a dummy json for now if file doesn't load...
                text = "[{\"Id\":1,\"Name\":\"Robert\",\"Salary\":10}]";
            }
            return text;
        }
        private void SaveFile(string text)
        {
            File.WriteAllText(this.path, text);
        }

    }
    
}
