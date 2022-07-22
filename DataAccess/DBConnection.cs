
using Sensitive;
using Models;
using System.Data.SqlClient;
namespace DataAccess;
public class DBConnection
{
        private static DBConnection? _instance;
        private readonly string _connectionString;

        private DBConnection(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        public DBConnection()
        {
            _connectionString = File.ReadAllText("../DataAccess/connectionstring.txt");
        }
    //getter for one and only instance of dbconnection
    public static DBConnection GetInstance(string connectionstring)
    {
        //chek if its already made
        if(_instance == null)
        {
            _instance = new DBConnection(connectionstring);
        }  
        
        return _instance;
    }

    public SqlConnection GetConnection()
    {
        
        return new SqlConnection(_connectionString);
        
    }
}
