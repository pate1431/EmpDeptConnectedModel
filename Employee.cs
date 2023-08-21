using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocos
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }    
        public string LastName { get; set; }

        public Department Dept{ get; set; }

        public override string ToString()
        {
            List<Department> departmentList = new List<Department>();
            
            return $"Employee Id:{Id} \t First Name:{FirstName} \t Last Name:{LastName} \t Dept:{Dept.Id} ";
        }
    }
}
