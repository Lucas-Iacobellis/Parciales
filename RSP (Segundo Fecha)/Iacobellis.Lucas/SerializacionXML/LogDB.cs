using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializacionXML
{
    public class LogDB
    {
        string connectionString =
            "Data Source=(local)\\SQLEXPRESS;Initial Catalog=20201210-sp;"
            + "Integrated Security=true";
        public LogDB()
        {

        }
        public bool GetInfo(out string datos)
        {



            string queryString =
               "SELECT [id]" +
                     ",[jugador]" +
                     ",[puntos]" +
                    " FROM [dbo].[log]";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);

                datos = "";

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        datos += string.Format("{0}\t{1}\t{2}|", reader[0], reader[1], reader[2]);
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

        public bool Info(string jugador, int puntos)
        {
            //string insertString =
            //   "INSERT INTO [dbo].[log] ([jugador]" +
            //                           ",[puntos]) values (" + jugador + "," + puntos.ToString() + ")";

            bool retorno = false;
            string insertString = string.Format("INSERT INTO LOG (JUGADOR,PUNTOS) VALUES ('{0}',{1})", jugador, puntos);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(insertString, connection);

                try
                {
                    connection.Open();
                    int rowCount = command.ExecuteNonQuery();

                    if (rowCount == 1)
                    {
                        retorno = true;
                    }

                }

                catch (Exception)
                {
                    return false;
                }

                return retorno;

            }
        }
    }
}
