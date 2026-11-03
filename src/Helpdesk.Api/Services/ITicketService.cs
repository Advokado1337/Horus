using Helpdesk.Api.Models;

namespace Helpdesk.Api.Services;

public interface ITicketService
{
    List<Ticket> GetAll();
    Ticket? GetById(int id);
    Ticket Create(CreateTicketRequest request);
}