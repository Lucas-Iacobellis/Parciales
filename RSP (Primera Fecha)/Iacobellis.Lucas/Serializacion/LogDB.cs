using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializacion
{
    public class LogDB : ILog
    {
        string connectionString =
            //"Data Source=(local);Initial Catalog=20201203-sp;"
            //+ "Integrated Security=true";
            "Data Source=DESKTOP-L86C8Q5\\SQLEXPRESS;Initial Catalog=20201203-sp;"
            + "Integrated Security=true";

        public bool GetInfo(out string datos)
        {


         
            string queryString =
               "SELECT [id]" +
                      ",[entrada]" +
                      ",[alumno]" +
                    " FROM [dbo].[log]";

          
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                
                SqlCommand command = new SqlCommand(queryString, connection);

                datos = "";

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        datos += string.Format("\t{0}\t{1}\t{2}",
                            reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                }

                catch (Exception)
                {
                    return false;
                }
               
            }

            return true;
        }

        public bool Info(string info)
        {
            string insertString =
               "INSERT INTO [dbo].[log] ([entrada]" +
                      ",[alumno]) values ('" + info + "','Iacobellis Lucas')";


            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(insertString, connection);

                try
                {
                    connection.Open();
                    int rowCount = command.ExecuteNonQuery();

                    if (rowCount == 1)
                    {
                        return true;
                    }

                    else 
                    {
                        return false;
                    }
                }

                catch (Exception e)
                {
                    return false;
                }

            }
        }
    }
}