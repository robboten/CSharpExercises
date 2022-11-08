using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning1.IO
{
    internal interface ISerialize
    {
        List<Employee>? DeserializeEmployees();
        void SerializeEmployees(List<Employee> employees);
    }
    
}
