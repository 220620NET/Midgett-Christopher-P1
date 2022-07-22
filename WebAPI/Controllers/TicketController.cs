using Models;
using Services;
using CustomExceptions;

namespace WebAPI.Controllers;

public class TicketController
{
    private readonly TicketService _service;
    public TicketController(TicketService service)
    {
        _service = service;
    }

    public TicketModel TicketByID(int? ID)
    {
        return _service.TicketByID(ID);
    }
    public TicketModel TicketByAuthor(string Author)
    {
        return _service.TicketByAuthor(Author);
    }
    public TicketModel TicketByStatus(string Status)
    {
        return _service.TicketByStatus(Status);
    }
    public bool CreateTicket(TicketModel newTicket)
    {
        return _service.CreateTicket(newTicket);
    }
    public bool UpdateTicket(TicketModel updateTicket)
    {
        return _service.UpdateTicket(updateTicket);
    }
}