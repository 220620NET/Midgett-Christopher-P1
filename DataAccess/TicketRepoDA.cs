using Models;
using CustomExceptions;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess;

public class TicketRepoDA : ITicketRepoDA
{

    private readonly DBConnection _connectionFactory;
    public TicketRepoDA(DBConnection factory)
    {
        _connectionFactory = factory;
    }
    public TicketModel TicketByID(int? ID)
    {
        SqlConnection connection = _connectionFactory.GetConnection();

        string sqlString = "Select * from db_ExpenseReimbursement.tickets where ID = @id";

        SqlCommand command = new SqlCommand(sqlString,connection);

        command.Parameters.AddWithValue("@id",ID);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                return new TicketModel
                {
                    ID =(int)reader["ID"], 
                    Author =(string)reader["Author"], 
                    Resolver =(string)reader["Resolver"],
                    Description =(string)reader["Description"],
                    Status =(string)reader["Status"],
                    Amount =(decimal)reader["Amount"]
                };
            }
            reader.Close();
            connection.Close();
        }
        catch (ResourceNotFoundExceptions)
        {
            Console.WriteLine("Ticket not found by ID");
        }
        throw new ResourceNotFoundExceptions("Ticket not found by ID");
    }
    public TicketModel TicketByAuthor(string Author)
    {
        SqlConnection connection = _connectionFactory.GetConnection();

        string sqlString = "Select * from db_ExpenseReimbursement.tickets where Author = @author";

        SqlCommand command = new SqlCommand(sqlString,connection);

        command.Parameters.AddWithValue("@author",Author);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                return new TicketModel
                {
                    ID =(int)reader["ID"], 
                    Author =(string)reader["Author"], 
                    Resolver =(string)reader["Resolver"],
                    Description =(string)reader["Description"],
                    Status =(string)reader["Status"],
                    Amount =(decimal)reader["Amount"]
                };
            }
            reader.Close();
            connection.Close();
        }
        catch (ResourceNotFoundExceptions)
        {
            Console.WriteLine("Ticket not found by Author");
        }
        throw new ResourceNotFoundExceptions("Ticket not found by Author");
    }
    public TicketModel TicketByStatus(string Status)
    {
        SqlConnection connection = _connectionFactory.GetConnection();

        string sqlString = "Select * from db_ExpenseReimbursement.tickets where Status = @status";

        SqlCommand command = new SqlCommand(sqlString,connection);

        command.Parameters.AddWithValue("@status",Status);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                return new TicketModel
                {
                    ID =(int)reader["ID"], 
                    Author =(string)reader["Author"], 
                    Resolver =(string)reader["Resolver"],
                    Description =(string)reader["Description"],
                    Status =(string)reader["Status"],
                    Amount =(decimal)reader["Amount"]
                };
            }
            reader.Close();
            connection.Close();
        }
        catch (ResourceNotFoundExceptions)
        {
            Console.WriteLine("Ticket not found by Status");
        }
        throw new ResourceNotFoundExceptions("Ticket not found by Status");
    }
    public bool CreateTicket(TicketModel newTicket)
    {
    string queryString = "insert into db_ExpenseReimbursement.tickets (author,resolver,description,status,amount) values(@author,@resolver,@description,@status,@amount)";

        SqlConnection connection = _connectionFactory.GetConnection(); 

        SqlCommand command = new SqlCommand(queryString,connection);
        command.Parameters.AddWithValue("@author",newTicket.Author);
        command.Parameters.AddWithValue("@resolver",newTicket.Resolver);
        command.Parameters.AddWithValue("@description",newTicket.Description);
        command.Parameters.AddWithValue("@status",newTicket.Status);
        command.Parameters.AddWithValue("@amount",newTicket.Amount);

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
    public bool UpdateTicket(TicketModel updateTicket)
    {
        SqlConnection connection = _connectionFactory.GetConnection(); 

        string sqlString = "Update db_ExpenseReimbursement.tickets set resolver = @resolver where Status = @status";

        SqlCommand command = new SqlCommand(sqlString,connection);
        command.Parameters.AddWithValue("@resolver",updateTicket.Resolver);
        command.Parameters.AddWithValue("@status",updateTicket.Status);

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