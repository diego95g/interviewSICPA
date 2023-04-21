using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace interviewSICPA.Models
{
    public class DepartmentManagement
    {

        public List<Department> getDepartment(int id)
        {
            List<Department> lista = new List<Department>();
            string strConn = ConfigurationManager.ConnectionStrings["BD_Local"].ToString();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand command = new SqlCommand("select " +
                                                    "id_department, " +
                                                    "status_department, " +
                                                    "description_department, " +
                                                    "name_department, " +
                                                    "phone_department " +
                                                "from department where id_enterprise=@id", conn);
            try
            {
                command.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Department department = new Department();
                        department.id = reader.GetInt32(0);
                        department.status = reader.GetBoolean(1);
                        department.description = reader.GetString(2);
                        department.name=reader.GetString(3);
                        department.phone = reader.GetString(4);

                        
                        lista.Add(department);
                    }
                    reader.Close();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to get departments. Error message: {e.Message}");
            }
            conn.Close();


            return lista;
        }

        public int addDepartment(Department department)
        {
            int result = 0;

            string strConn = ConfigurationManager.ConnectionStrings["BD_Local"].ToString();

            using (SqlConnection openCon = new SqlConnection(strConn))
            {
                string saveStaff = "INSERT into department (ID_ENTERPRISE, CREATED_BY_DEPARTMENT,CREATED_DATE_DEPARTMENT,MODIFIED_BY_DEPARTMENT,MODIFIED_DATE_DEPARTMENT," +
                                                            "STATUS_DEPARTMENT, DESCRIPTION_DEPARTMENT, NAME_DEPARTMENT, PHONE_DEPARTMENT) " +
                                                            "VALUES (@id, 'test',getdate(),'test', getdate(), @status, @description, @name, @phone)";
                try
                {
                    using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
                    {
                        querySaveStaff.Connection = openCon;
                        querySaveStaff.Parameters.Add("@id", SqlDbType.Int, 30).Value = department.idEnterprise;
                        querySaveStaff.Parameters.Add("@status", SqlDbType.Bit, 30).Value = department.status;
                        querySaveStaff.Parameters.Add("@description", SqlDbType.VarChar, 30).Value = department.description;
                        querySaveStaff.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = department.name;
                        querySaveStaff.Parameters.Add("@phone", SqlDbType.VarChar, 30).Value = department.phone;
                        openCon.Open();

                        result = querySaveStaff.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to register department. Error message: {e.Message}");
                }
            }
            return result;

        }

        public int updateDepartment(int id, Department department)
        {
            int result = 0;

            string strConn = ConfigurationManager.ConnectionStrings["BD_Local"].ToString();

            var sql = "UPDATE department SET status_department = @status, description_department = @description, name_department = @name, phone_department=@phone " +
                        "where id_department=@id";// repeat for all variables
            try
            {
                using (var connection = new SqlConnection(strConn))
                {
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@status", SqlDbType.Bit).Value = department.status;
                        command.Parameters.Add("@description", SqlDbType.NVarChar).Value = department.description;
                        command.Parameters.Add("@name", SqlDbType.NVarChar).Value = department.name;
                        command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = department.phone;
                        command.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                        connection.Open();
                        result=command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to update department. Error message: {e.Message}");
            }
            return result;
        }
    }
}