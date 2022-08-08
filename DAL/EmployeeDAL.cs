using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;

namespace SqlTest_CSharp
{
    public class EmployeeDAL
    {
        public List<Employee> GetEmployeeData()
        {
            gjufkctzsdx
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = @"Data Source=abdullah-ali\sqlexpress01;Initial Catalog=Emp;Integrated Security=True";
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM employee", conn);

               //
                List<Employee> employees = new List<Employee>();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                            employees.Add(new Employee
                            {
                                id = Convert.ToInt32(reader["id"]),
                                name = Convert.ToString(reader["name"])
                            }); }
                    }
                    return employees;
                
                    }
                }
              

            }
        }
    



