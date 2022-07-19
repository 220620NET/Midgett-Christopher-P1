using Models;

namespace DataAccess;

public interface ITicketRepoDA
{
    TicketModel TicketByID(string ID);
    TicketModel TicketByAuthor(string Author);
    TicketModel TicketByStatus(string Status);
    bool CreateTicket(TicketModel newTicket);
}