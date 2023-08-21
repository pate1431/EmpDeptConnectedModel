using Pocos;
using Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDeptConnectedModel
{
    public class Program
    {
        static void Main(string[] args)
        {
            string name = "SN3HAL";
            string db = "CompanyFdm";
            string security = "true";
            string connectionString = $"Data Source={name}; Initial Catalog={db}; Integrated Security={security};";
            EmployeeRepository empRepo = new EmployeeRepository(connectionString);
            DepartmentRepository deptRepo = new DepartmentRepository(connectionString);

            //Step 1
            Department department = new Department();
            department.DeptName = "Law";
            deptRepo.createRow(department);
            
            //Step 2
            Department d2 = new Department();
            d2.Id = deptRepo.ReadRowByName(department.DeptName).Id;
            Employee employee = new Employee();
            employee.FirstName = "Goku";
            employee.LastName = "Kakarot";
            employee.Dept = d2;
            empRepo.createRow(employee);
            
            //Step 3
            Console.WriteLine("\n\t\t\tSTEP 3");
            foreach (Department dept in deptRepo.readAllRows())
            {
                Console.WriteLine(dept.ToString());
                foreach (Employee i in empRepo.readAllRows().Where(e => e.Dept.Id == dept.Id))
                {
                    Console.WriteLine($"-->{i}");
                }

            }


            //Step 4
            Console.WriteLine("\n\t\t\tSTEP 4");
            foreach (Employee b in empRepo.readAllRows())
            {
                Console.WriteLine(b.ToString());
            }

            /*

             Step 5: Deleting a Department will cause error as the Employee Table has all elements set to NotNull in the table.
            If we try to delete it will cause error as the data related to the department will no longer have foreign key relation as the key will get empty
            and we mentioned that the column cannot have any null element.

            So if we want to delete a department we will have to change the employees related to department and shift them to other department
            then we may delete the department as there is no employee related to the department

            Method to delete Department by Id
            deptRepo.DeleteRow(5);


             */



            /*****************************************************************************************************************************
                                        Methods Calls used to run the EmployeeRepository and DepartmentRepository
             ****************************************************************************************************************************/

            //deptRepo.ReadRowByName("IT");
            //deptRepo.DeleteRow(5);

            // Department department1 = new Department();
            /*department1.Id = 6;
            department1.DeptName = "TECHNICAL";
            deptRepo.DeleteRow(department1);*/

            /*foreach (Department b in deptRepo.readAllRows())
            {
                Console.WriteLine(b);
            }
            */

            //Console.WriteLine(deptRepo.ReadRowById(3));

            /*Employee e = new Employee();
            Department d = new Department();

               d.Id = 2;
               d.DeptName = "Sales";

               e.FirstName = "Snehal";
               e.LastName = "Patel";
               e.Dept = d;*/

            //repo.createRow(e);

            //repo.DeleteRow(10);
            //repo.DeleteRow(e);
            /*Employee e1 = new Employee();
            Department d2 = new Department();

            d2.DeptName = "Sales";
            e1.Id = 13;
            e1.FirstName = "Prince";
            e1.LastName = "Vegeta";
            e1.Dept = d2;*/

            // repo.UpdateRow(e1);

            //Console.WriteLine(repo.ReadRowById(2));

            //repo.ReadRowByName("Joe", "Bloggs");




        }
    }
}
