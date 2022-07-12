using Models;
using CustomExceptions;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess;

public class UserRepoDA : IUserRepoDA
{

    
    public UserModel GetUserByID(int userID)
    {
        UserModel lsit = new UserModel();
        return lsit;
    }

     public UserModel GetUserByUsername(string Username)
     {
        UserModel foundUser;
        SqlConnection connection = DBConnection.GetInstance().GetConnection();
        
        string sqlString = "Select * from db_ExpenseReimbursement.users where username = @name";

        SqlCommand command = new SqlCommand(sqlString,connection);

        command.Parameters.AddWithValue("@name",Username);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                return new UserModel
                {
                    UserId =(int)reader["ID"], 
                    Username =(string)reader["Username"], 
                    Password =(string)reader["Password"],
                    Role =(string)reader["User_Role"]
                };
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        throw new ResourceNotFoundExceptions("User not found");
     }

    public bool CreateUser(UserModel newUser)
    {
        string queryString = "insert into db_ExpenseReimbursement.users (username,password,User_Role) values(@username,@password,@User_Role)";

            SqlConnection connection = DBConnection.GetInstance().GetConnection(); 

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
    
    public List<UserModel> GetAllUsers()
    {
        List<UserModel> users = new List<UserModel>();
        DataSet UserSet = new DataSet();
        SqlDataAdapter UserAdapter = new SqlDataAdapter("select * from db_ExpenseReimbursement.users", DBConnection.GetInstance().GetConnection());

        UserAdapter.Fill(UserSet,"UserTable");

        DataTable? UserTable = UserSet.Tables["UserTable"];

        try
        {
            if(UserTable != null)
            {
                foreach(DataRow row in UserTable.Rows)
                {
                    UserModel temp = new UserModel();
                    temp.UserId = Convert.ToInt32(row["ID"]);
                    temp.Username = row["Username"].ToString();
                    temp.Password = row["Password"].ToString();
                    temp.Role = row["User_Role"].ToString();

                    users.Add(temp);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return users;
        
    }

    public void DeleteOneUser(int userID)
    {
        
    }
}