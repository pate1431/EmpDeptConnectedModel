using Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        

        public DepartmentRepository(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand("", sqlConnection);
        }

        public Department ReadRowByName(string name)
        {
            Department dept = new Department();
            string sqlStatement = "SELECT dept_no, emp_dept_name FROM dbo.departments Where emp_dept_name = @dName";
            sqlCommand.CommandText = sqlStatement;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("dName", name);

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    dept.Id = int.Parse(dataReader["dept_no"].ToString());
                    dept.DeptName = dataReader["emp_dept_name"].ToString();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"caught - {e.GetType()}: {e.Message}");
            }
            sqlConnection.Close();
            return dept;
        }

        public IEnumerable<Department> readAllRows()
        {
            List<Department> list = new List<Department>();
            string sqlStatement = "SELECT dept_no, emp_dept_name FROM dbo.departments";
            sqlCommand.CommandText = sqlStatement;
            try
            {
                sqlConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    list.Add(new Department
                    {
                        Id = int.Parse(dataReader["dept_no"].ToString()),
                        DeptName = dataReader["emp_dept_name"].ToString()
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
        public Department ReadRowById(int id)
        {
            Department dept = new Department();
            string sqlStatement = "SELECT dept_no, emp_dept_name FROM dbo.departments Where dept_no= @Id";
            sqlCommand.CommandText = sqlStatement;
            try
            {
                sqlConnection.Open();
                Console.WriteLine("Success");
                sqlCommand.Parameters.AddWithValue("Id", id);
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    dept.Id = int.Parse(dataReader["dept_no"].ToString());
                    dept.DeptName = dataReader["emp_dept_name"].ToString();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"caught - {e.GetType()}: {e.Message}");
            }
            sqlConnection.Close();
            return dept;
        }
      
        public bool createRow(Department entity)
        {
            bool success = false;
            string sqlStatement = "INSERT INTO [CompanyFdm].[dbo].departments (emp_dept_name) VALUES (@deptName)";
            sqlCommand.CommandText = sqlStatement;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("deptName", entity.DeptName);
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

        public bool UpdateRow(Department entity)
        {
            bool success = false;
            Department emp = new Department();

            string sqlStatement = "Update [CompanyFdm].[dbo].departments  SET emp_dept_name = @dName WHERE dept_no = @dId";
            sqlCommand.CommandText = sqlStatement;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("dId", entity.Id);
                sqlCommand.Parameters.AddWithValue("dName", entity.DeptName);
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
        public bool DeleteRow(Department entity)
        {
            bool success = false;
            Department dept = new Department();
            string sqlStatement = "SELECT dept_no, emp_dept_name FROM dbo.departments Where emp_dept_name = @firstName";
            sqlCommand.CommandText = sqlStatement;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("firstName", entity.DeptName);

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    dept.Id = int.Parse(dataReader["dept_no"].ToString());
                    dept.DeptName = dataReader["emp_dept_name"].ToString();
                    Console.WriteLine(dept);
                }
                sqlConnection.Close();
                if (DeleteRow(dept.Id) == true)
                {
                    success = true;
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
            string sqlStatement = "DELETE FROM [CompanyFdm].[dbo].departments where dept_no = @id";
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
