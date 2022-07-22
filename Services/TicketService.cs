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

    public TicketModel TicketByID(int? ID)
    {
        return _repo.TicketByID(ID);
    }
    public TicketModel TicketByAuthor(string Author)
    {
        return _repo.TicketByAuthor(Author);
    }
    public TicketModel TicketByStatus(string Status)
    {
        return _repo.TicketByStatus(Status);
    }
    public bool CreateTicket(TicketModel newTicket)
    {
        return _repo.CreateTicket(newTicket);
    }
    public bool UpdateTicket(TicketModel updateTicket)
    {
        return _repo.UpdateTicket(updateTicket);
    }
}