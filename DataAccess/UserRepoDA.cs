using Models;
using System.Data.SqlClient;

namespace DataAccess;

public class UserRepoDA
{
    string connectionString = 
            "Server=tcp:revatureproject1.database.windows.net,1433;Initial Catalog=revproject1;"
            + "Persist Security Info=False;User ID=sqluser;Password=" + Sensitive.SensitiveVariables.dbpassword + ";"
            + "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    List<UserModel> users = new List<UserModel>();
    // public List<UserModel> GetUserByID()
    // {
    //     users = true;
    //     return users;
    // }

    // public List<UserModel> GetUserByUsername()
    // {
        
    // }

    public bool CreateUser(UserModel newUser)
    {
        string queryString = "insert into db_ExpenseReimbursement.users (username,password,User_Role) values(@username,@password,@User_Role)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(queryString,connection);
            command.Parameters.AddWithValue("@username",newUser.Username);
            command.Parameters.AddWithValue("@password",newUser.Password);
            command.Parameters.AddWithValue("@User_Role",newUser.Role);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                

                if(rowsAffected != 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }

    public List<UserModel> GetAllUsers()
    {
        List<UserModel> users2 = new List<UserModel>();

        string queryString = "select * from db_ExpenseReimbursement.users";

        SqlConnection connection = new SqlConnection(connectionString);
        
        SqlCommand command = new SqlCommand(queryString,connection);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //Console.WriteLine("\t{0}\t{1}\t{2}\t{3}",reader[0], reader[1], reader[2],reader[3]);
                users2.Add(new UserModel((int)reader[0], (string)reader[1], (string)reader[2],(string)reader[3]));
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return users2;
        
    }

    // public void DeleteOneUser(int userID)
    // {
    //     users = true;
    // }
}