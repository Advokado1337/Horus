using Helpdesk.Api.Models;

namespace Helpdesk.Api.Services;

public class InMemoryTicketService : ITicketService       
{
    private readonly Lock _lock = new();                   
    private int _nextId = 3;
    private readonly List<Ticket> _tickets =
    [
        new Ticket { Id = 1, Title = "Fel vara", Description = "Fick en blå tröja, beställde röd", CreatedAt = DateTime.UtcNow },
        new Ticket { Id = 2, Title = "Ingen leverans", Description = "Order 1234 har inte kommit", CreatedAt = DateTime.UtcNow },
    ];

    public List<Ticket> GetAll()
    {
        lock (_lock)                                      
        {
            return _tickets.ToList();                      
        }
    }

    public Ticket? GetById(int id)
    {
        lock (_lock)
        {
            return _tickets.FirstOrDefault(t => t.Id == id);
        }
    }

    public Ticket Create(CreateTicketRequest request)
    {
        lock (_lock)
        {
            var ticket = new Ticket
            {
                Id = _nextId++,                            
                Title = request.Title,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow,               
            };
            _tickets.Add(ticket);
            return ticket;
        }
    }
}