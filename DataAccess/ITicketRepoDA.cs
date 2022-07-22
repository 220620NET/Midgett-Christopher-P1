using Models;

namespace DataAccess;

public interface ITicketRepoDA
{
    TicketModel TicketByID(int? ID);
    TicketModel TicketByAuthor(string Author);
    TicketModel TicketByStatus(string Status);
    bool CreateTicket(TicketModel newTicket);
    bool UpdateTicket(TicketModel updateTicket);
}