using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace interviewSICPA.Models
{
    public class EnterpriseManagement
    {
        public List<Enterprise> getEnterprise()
        {
            List<Enterprise> lista = new List<Enterprise>();
            string strConn = ConfigurationManager.ConnectionStrings["BD_Local"].ToString();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand command = new SqlCommand("select " +
                                                    "id_enterprise, " +
                                                    "status_enterprise, " +
                                                    "address_enterprise, " +
                                                    "name_enterprise, " +
                                                    "phone_enterprise " +
                                                "from enterprise", conn);
            try{
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Enterprise enterprise = new Enterprise();
                        enterprise.id=reader.GetInt32(0);
                        enterprise.status = reader.GetBoolean(1);
                        enterprise.address = reader.GetString(2);
                        enterprise.name = reader.GetString(3);
                        enterprise.phone = reader.GetString(4);

                        
                        lista.Add(enterprise);
                    }
                    reader.Close();
                    conn.Close();
                }
            }catch (Exception e)
            {
                Console.WriteLine($"Failed to get enterprises. Error message: {e.Message}");
            }
            conn.Close();
            

            return lista;
        }

        public int addEnterprise(Enterprise enterprise)
        {
            int result = 0;

            string strConn = ConfigurationManager.ConnectionStrings["BD_Local"].ToString();

            using (SqlConnection openCon = new SqlConnection(strConn))
            {
                string saveStaff = "INSERT into enterprise (CREATED_BY_ENTERPRISE,CREATED_DATE_ENTERPRISE,MODIFIED_BY_ENTERPRISE,MODIFIED_DATE_ENTERPRISE," +
                                                            "STATUS_ENTERPRISE, ADDRESS_ENTERPRISE, NAME_ENTERPRISE, PHONE_ENTERPRISE) " +
                                                            "VALUES ('test',getdate(),'test', getdate(), @status, @address, @name, @phone)";
                try { 
                    using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
                    {
                        querySaveStaff.Connection = openCon;
                        querySaveStaff.Parameters.Add("@status", SqlDbType.Bit, 30).Value = enterprise.status;
                        querySaveStaff.Parameters.Add("@address", SqlDbType.VarChar, 30).Value = enterprise.address;
                        querySaveStaff.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = enterprise.name;
                        querySaveStaff.Parameters.Add("@phone", SqlDbType.VarChar, 30).Value = enterprise.phone;
                        openCon.Open();

                        result= querySaveStaff.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to register. Error message: {e.Message}");
                }
            }
            return result;
            
        }

        public int updateEnterprise(int id, Enterprise enterprise)
        {
            int result = 0;

            string strConn = ConfigurationManager.ConnectionStrings["BD_Local"].ToString();

            var sql = "UPDATE enterprise SET status_enterprise = @status, name_enterprise = @name, phone_enterprise = @phone, address_enterprise=@address " +
                        " where id_enterprise=@id";// repeat for all variables
            try
            {
                using (var connection = new SqlConnection(strConn))
                {
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@status", SqlDbType.Bit).Value = enterprise.status;
                        command.Parameters.Add("@name", SqlDbType.NVarChar).Value = enterprise.name;
                        command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = enterprise.phone;
                        command.Parameters.Add("@address", SqlDbType.NVarChar).Value = enterprise.address;
                        command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        connection.Open();
                        result=command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to update. Error message: {e.Message}");
            }
            return result;
        }

       
    }
}