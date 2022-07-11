
using System.Data.SqlClient;
using Sensitive;
using Models;

namespace DataAccess;
public class DBConnection
{
    public void Instance()
    {
        return;
    }

    public List<UserModel> Connection(string passedSQL)
    {
        List<UserModel> listee = new List<UserModel>();
        //connects to sql server
        string connectionString = 
            "Server=tcp:revatureproject1.database.windows.net,1433;Initial Catalog=revproject1;"
            + "Persist Security Info=False;User ID=sqluser;Password=" + Sensitive.SensitiveVariables.dbpassword + ";"
            + "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //sql command we'd like to do
        string queryString = passedSQL;

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
                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}",
                        reader[0], reader[1], reader[2],reader[3]);
                    listee.Add(new UserModel((int)reader[0], (string)reader[1], (string)reader[2],(string)reader[3]));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return listee;
        }
    }
}
