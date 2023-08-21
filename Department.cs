using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocos
{
    public class Department
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public ISet<Employee> Employees { get; set;}


        public override string ToString()
        {
            return $"Department Id:{Id} \t Department Name:{DeptName}";
        }
    }
}
