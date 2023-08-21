using Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    
    public class EmployeeRepository: IEmployeeRepository
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        public EmployeeRepository(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand("",sqlConnection);
        }

        public void ReadRowByName(string firstName, string lastName)
        {
            Employee emp = new Employee();
            string sqlStatement = "SELECT emp_id, emp_first_name, emp_last_name FROM dbo.employees Where emp_first_name = @firstName AND emp_last_name = @lastName";
            sqlCommand.CommandText = sqlStatement;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("firstName", firstName);
                sqlCommand.Parameters.AddWithValue("lastName", lastName);

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Department department = new Department();
                    department.Id = int.Parse(dataReader["fk_dept_no"].ToString());

                    emp.Id = int.Parse(dataReader["emp_id"].ToString());
                    emp.FirstName = dataReader["emp_first_name"].ToString();
                    emp.LastName = dataReader["emp_last_name"].ToString();
                    emp.Dept = department;
                    Console.WriteLine(emp);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"caught - {e.GetType()}: {e.Message}");
            }
            sqlConnection.Close();
        }
        

        public IEnumerable<Employee> readAllRows()
        {
            List<Employee> list = new List<Employee>();
            string sqlStatement = "SELECT emp_id, emp_first_name, emp_last_name, fk_dept_no FROM dbo.employees";
            

            sqlCommand.CommandText = sqlStatement;
            try
            {
                sqlConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Department department = new Department();
                    department.Id = int.Parse(dataReader["fk_dept_no"].ToString());
                    
                    list.Add(new Employee
                    {
                        Id = int.Parse(dataReader["emp_id"].ToString()),
                        FirstName = dataReader["emp_first_name"].ToString(),
                        LastName = dataReader["emp_last_name"].ToString(),
                        Dept = department
                    }); 
                    
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"caught - {e.GetType()}: {e.Message}");
            }
            sqlConnection.Close();
            return list;
        }

        public Employee ReadRowById(int id)
        {
            Employee emp = new Employee();
            string sqlStatement = "SELECT emp_id, emp_first_name, emp_last_name FROM dbo.employees Where emp_id = @Id";
            sqlCommand.CommandText = sqlStatement;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("Id", id);
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    emp.Id = int.Parse(dataReader["emp_id"].ToString());
                    emp.FirstName = dataReader["emp_first_name"].ToString();
                    emp.LastName = dataReader["emp_last_name"].ToString();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"caught - {e.GetType()}: {e.Message}");
            }
            sqlConnection.Close();
            return emp;
        }
        public bool createRow(Employee entity)
        {
            bool success = false;
            string sqlStatement = "INSERT INTO [CompanyFdm].[dbo].employees (emp_first_name, emp_last_name, fk_dept_no) VALUES (@fName, @lName, @deptNo)";
            sqlCommand.CommandText = sqlStatement;
            
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("fName", entity.FirstName);
                sqlCommand.Parameters.AddWithValue("lName", entity.LastName);
                sqlCommand.Parameters.AddWithValue("deptNo", entity.Dept.Id);
                
                int numberAffectedRows = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"created {numberAffectedRows} row(s)");
                success = true;
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"caught - {e.GetType()}: {e.Message}");
                success = false;
            }
            sqlConnection.Close();
            return success;
        }

        public bool UpdateRow(Employee entity)
        {
            bool success = false;
            Employee emp = new Employee();

            string sqlStatement = "Update [CompanyFdm].[dbo].employees  SET emp_first_name = @fstName, emp_last_name = @lstName, fk_dept_no= @departId WHERE emp_id = @eId";
            sqlCommand.CommandText = sqlStatement;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("eId", entity.Id);
                sqlCommand.Parameters.AddWithValue("fstName", entity.FirstName);
                sqlCommand.Parameters.AddWithValue("lstName", entity.LastName);
                sqlCommand.Parameters.AddWithValue("departId", entity.Dept.Id);

                int numberAffectedRows = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"created {numberAffectedRows} row(s)");
                success = true;
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"caught - {e.GetType()}: {e.Message}");
                success= false;
            }
            sqlConnection.Close();
            return success;

        }

        public bool DeleteRow(Employee entity)
        {
            bool success = false;
            Employee emp = new Employee();
            string sqlStatement = "SELECT emp_id, emp_first_name, emp_last_name FROM dbo.employees Where emp_first_name = @firstName AND emp_last_name = @lastName";
            sqlCommand.CommandText = sqlStatement;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("firstName", entity.FirstName);
                sqlCommand.Parameters.AddWithValue("lastName", entity.LastName);

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    emp.Id = int.Parse(dataReader["emp_id"].ToString());
                    emp.FirstName = dataReader["emp_first_name"].ToString();
                    emp.LastName = dataReader["emp_last_name"].ToString();
                    Console.WriteLine(emp);
                }
                sqlConnection.Close();
                if (DeleteRow(emp.Id) == true)
                {
                    success= true;
                }
                else
                {
                    success = false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"caught - {e.GetType()}: {e.Message}");
            }
            sqlConnection.Close();

            return success;
            
        }

        public bool DeleteRow(int id)
        {
            bool success = false;
            string sqlStatement = "DELETE FROM [CompanyFdm].[dbo].employees where emp_id = @id";
            sqlCommand.CommandText = sqlStatement;
            Console.WriteLine(id);
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("id", id);

                int numberAffectedRows = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"created {numberAffectedRows} row(s)");
                success = true;

            }
            catch (Exception e)
            {
                Console.WriteLine($"caught - {e.GetType()}: {e.Message}");
                success = false;
            }
            sqlConnection.Close();
            return success;
        }
    }
}
