using Models;
using DataAccess;
using CustomExceptions;

namespace Services;

public class TicketService
{
    private readonly ITicketRepoDA _repo;

    public TicketService(ITicketRepoDA repo)
    {
        _repo = repo;
    }

    public TicketModel TicketByID(string ID)
    {
        return _repo.TicketByID();
    }
    public TicketModel TicketByAuthor(string Author)
    {
        return _repo.TicketByAuthor();
    }
    public TicketModel TicketByStatus(string Status)
    {
        return _repo.TicketByStatus();
    }
    public bool CreateTicket(TicketModel newTicket)
    {
        return _repo.CreateTicket();
    }
    public bool UpdateTicket(TicketModel updateTicket, string resolver, string status)
    {
        return _repo.UpdateTicket();
    }
}