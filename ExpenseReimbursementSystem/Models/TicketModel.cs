
namespace Models
{
    public class TicketModel
    {
        public TicketModel(int userID,string userAuthor,string userDescription,decimal ticketAmount)
        {
            ID = userID;
            Author = userAuthor;
            Resolver = " ";
            Description = userDescription;
            Status = "Pending";
            Amount = ticketAmount;
        }

        public int ID{get;set;}
        public string Author{get;set;}
        public string Resolver{get;set;}
        public string Description{get;set;}
        public string Status{get;set;}
        public decimal Amount{get;set;}
    }
}