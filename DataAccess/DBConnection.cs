
using Sensitive;
using Models;
using System.Data.SqlClient;
namespace DataAccess;
public class DBConnection
{
        private static DBConnection? _instance;
        private readonly static string _connectionString = File.ReadAllText("../DataAccess/connectionstring.txt");

        private DBConnection(){}

    //getter for one and only instance of dbconnection
    public static DBConnection GetInstance()
    {
        //chek if its already made
        if(_instance == null)
        {
            _instance = new DBConnection();
        }  
        
        return _instance;
    }

    public SqlConnection GetConnection()
    {
        
        return new SqlConnection(_connectionString);
        
    }
}
