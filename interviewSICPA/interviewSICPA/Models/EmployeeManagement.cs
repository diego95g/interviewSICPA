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

        public List<Employee> getEmployee(int id)
        {
            List<Employee> lista = new List<Employee>();
            string strConn = ConfigurationManager.ConnectionStrings["BD_Local"].ToString();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand command = new SqlCommand("select " +
                                                    "e.id_employee, " +
                                                    "status_employee, " +
                                                    "age_employee, " +
                                                    "name_employee, " +
                                                    "surname_employee," +
                                                    "email_employee," +
                                                    "position_employee " +
                                                "from employee e inner join DEPARTMENT_EMPLOYEE de " +
                                                "on e.ID_EMPLOYEE=de.ID_EMPLOYEE " +
                                                "where de.ID_DEPARTMENT=@id", conn);
            
            try
            {
                command.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.id = reader.GetInt32(0);
                        employee.status = reader.GetBoolean(1);
                        employee.age = reader.GetInt32(2);
                        employee.name = reader.GetString(3);
                        employee.surname = reader.GetString(4);
                        employee.email = reader.GetString(5);
                        employee.position = reader.GetString(6);

                        
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
            int idEmployee =0;

            string strConn = ConfigurationManager.ConnectionStrings["BD_Local"].ToString();
            try
            {
                using (SqlConnection openCon = new SqlConnection(strConn))
                {

                    string saveStaff = "INSERT into EMPLOYEE (CREATED_BY_EMPLOYEE,CREATED_DATE_EMPLOEE,MODIFIED_BY_EMPLOEE,MODIFIED_DATE_EMPLOYEE," +
                                                                "STATUS_EMPLOYEE, AGE_EMPLOYEE, EMAIL_EMPLOYEE, NAME_EMPLOYEE, POSITION_EMPLOYEE, SURNAME_EMPLOYEE) " +
                                                                " OUTPUT inserted.ID_EMPLOYEE VALUES ('test',getdate(),'test', getdate(), @status, @age, @email, @name, @position, @surname)";
                    
                    using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
                    {
                        querySaveStaff.Connection = openCon;
                        querySaveStaff.Parameters.Add("@status", SqlDbType.Bit, 30).Value = employee.status;
                        querySaveStaff.Parameters.Add("@age", SqlDbType.Int, 30).Value = employee.age;
                        querySaveStaff.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = employee.email;
                        querySaveStaff.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = employee.name;
                        querySaveStaff.Parameters.Add("@position", SqlDbType.VarChar, 30).Value = employee.position;
                        querySaveStaff.Parameters.Add("@surname", SqlDbType.VarChar, 30).Value = employee.surname;
                        
                        openCon.Open();
                        idEmployee = (int)querySaveStaff.ExecuteScalar();
                    }

                    string saveStaff2 = "INSERT into department_employee (ID_EMPLOYEE,ID_DEPARTMENT,CREATED_BY_DEPARTMENT_EMPLOYEE,CREATED_DATE_DEPARTMENT_EMPLOYEE," +
                                                                   " MODIFIED_BY_DEPARTMENT_EMPLOYEE, MODIFIED_DATE_DEPARTMENT_EMPLOYEE, STATUS) " +
                                                                   "VALUES (@id,@idDepartment,'test', getdate(), 'test', getdate(), @status)";

                    using (SqlCommand querySaveStaff2 = new SqlCommand(saveStaff2))
                    {
                        querySaveStaff2.Connection = openCon;
                        querySaveStaff2.Parameters.Add("@id", SqlDbType.Int, 30).Value = idEmployee;
                        querySaveStaff2.Parameters.Add("@idDepartment", SqlDbType.Int, 30).Value = employee.idDepartment;
                        querySaveStaff2.Parameters.Add("@status", SqlDbType.Bit, 30).Value = employee.status;
                        result = querySaveStaff2.ExecuteNonQuery();
                        openCon.Close();
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to register employee. Error message: {e.Message}");
            }
            return idEmployee;

        }

        public int updateEmployee(int id, Employee employee)
        {
            int result = 0;

            string strConn = ConfigurationManager.ConnectionStrings["BD_Local"].ToString();

            var sql = "UPDATE employee SET modified_date_employee=getdate(), status_employee = @status, age_employee = @age, email_employee = @email, name_employee=@name, " +
                        " position_employee=@position, surname_employee=@surname " +
                        " where id_employee=@id";
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
                        command.Parameters.Add("@position", SqlDbType.VarChar).Value = employee.position;
                        command.Parameters.Add("@surname", SqlDbType.VarChar).Value = employee.surname;
                        command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        connection.Open();
                        result=command.ExecuteNonQuery();
                        connection.Close();
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