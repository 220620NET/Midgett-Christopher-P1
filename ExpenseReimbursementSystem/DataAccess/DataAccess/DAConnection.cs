using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess;

public class ConnectionFactory
{
    public void Instance()
    {

    }

    public void Connection()
    {
        //connects to sql server
        string connectionString = 
            "Server=tcp:revatureproject1.database.windows.net,1433;Initial Catalog=revproject1;"
            + "Persist Security Info=False;User ID=sqluser;Password={your_password};"
            + "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    
        string queryString = "dummy placeholder";

        //create and open connection
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            //command and parameter objects
            SqlCommand command = new SqlCommand(queryString,connectionString);

            //open the connection
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}",reader[0], reader[1], reader[2]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}