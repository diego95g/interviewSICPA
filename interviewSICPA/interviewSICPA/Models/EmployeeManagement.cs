using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace interviewSICPA.Models
{
    public class EmployeeManagement
    {

        public List<Employee> getEmployee()
        {
            List<Employee> lista = new List<Employee>();
            string strConn = ConfigurationManager.ConnectionStrings["BD_Local"].ToString();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand command = new SqlCommand("select " +
                                                    "id_employee, " +
                                                    "status_employee, " +
                                                    "age_employee, " +
                                                    "name_employee, " +
                                                    "surname_employee," +
                                                    "email_employee," +
                                                    "position_employee " +
                                                "from employee", conn);
            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        Boolean status = reader.GetBoolean(1);
                        int age = reader.GetInt32(2);
                        string name = reader.GetString(3);
                        string surname = reader.GetString(4);
                        string email= reader.GetString(5);
                        string position = reader.GetString(6);

                        Employee employee = new Employee(status, age, email, name, position, surname);
                        lista.Add(employee);
                    }
                    reader.Close();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to get employees. Error message: {e.Message}");
            }
            conn.Close();


            return lista;
        }

        public int addEmployee(Employee employee)
        {
            int result = 0;

            string strConn = ConfigurationManager.ConnectionStrings["BD_Local"].ToString();

            using (SqlConnection openCon = new SqlConnection(strConn))
            {
                string saveStaff = "INSERT into employee (CREATED_BY_EMPLOYEE,CREATED_DATE_EMPLOYEE,MODIFIED_BY_EMPLOYEE,MODIFIED_DATE_EMPLOYEE," +
                                                            "STATUS_EMPLOYEE, AGE_EMPLOYEE, EMAIL_EMPLOYEE, NAME_EMPLOYEE, POSITION_EMPLOYEE, SURNAME_EMPLOYEE) " +
                                                            "VALUES ('test',getdate(),'test', getdate(), @status, @age, @email, @name, @position, @surname)";
                try
                {
                    using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
                    {
                        querySaveStaff.Connection = openCon;
                        querySaveStaff.Parameters.Add("@status", SqlDbType.Bit, 30).Value = employee.status;
                        querySaveStaff.Parameters.Add("@age", SqlDbType.Int, 30).Value =    employee.age;
                        querySaveStaff.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = employee.email;
                        querySaveStaff.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = employee.name;
                        querySaveStaff.Parameters.Add("@position", SqlDbType.VarChar, 30).Value = employee.position;
                        querySaveStaff.Parameters.Add("@surname", SqlDbType.VarChar, 30).Value = employee.surname;
                        openCon.Open();

                        result = querySaveStaff.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to register employee. Error message: {e.Message}");
                }
            }
            return result;

        }

        public int updateEmployee(int id, Employee employee)
        {
            int result = 0;

            string strConn = ConfigurationManager.ConnectionStrings["BD_Local"].ToString();

            var sql = "UPDATE employee SET status_employee = @status, age_employee = @age, email_employee = @email, name_employee=@name, " +
                        " position_employee=@position, surname_employee=@surname " +
                        "where id_enterprise=@id";// repeat for all variables
            try
            {
                using (var connection = new SqlConnection(strConn))
                {
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@status", SqlDbType.Bit).Value = employee.status;
                        command.Parameters.Add("@age", SqlDbType.Int).Value = employee.age;
                        command.Parameters.Add("@email", SqlDbType.NVarChar).Value = employee.email;
                        command.Parameters.Add("@name", SqlDbType.NVarChar).Value = employee.name;
                        command.Parameters.Add("@position", SqlDbType.Int).Value = employee.position;
                        command.Parameters.Add("@surname", SqlDbType.Int).Value = employee.surname;
                        command.Parameters.Add("@id", SqlDbType.Int).Value = employee.id;
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to update employee. Error message: {e.Message}");
            }
            return result;
        }
    }
}