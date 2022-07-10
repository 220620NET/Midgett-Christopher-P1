
using System.Data.SqlClient;
using Sensitive;

namespace DataAccess;
public class DBConnection
{
    public void Instance()
    {

    }

    public void Connection()
    {
        //connects to sql server
        string connectionString = 
            "Server=tcp:revatureproject1.database.windows.net,1433;Initial Catalog=revproject1;"
            + "Persist Security Info=False;User ID=sqluser;Password=" + Sensitive.SensitiveVariables.dbpassword + ";"
            + "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    
        string queryString = "select * from db_ExpenseReimbursement.users";

        //create and open connection
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            //command and parameter objects
            SqlCommand command = new SqlCommand(queryString,connection);

            //open the connection
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}",reader[0], reader[1], reader[2]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
