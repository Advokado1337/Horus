using Helpdesk.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Api.Controllers;

[ApiController]
[Route("api/tickets")]
public class TicketController : ControllerBase
{
    
    private static readonly List<Ticket> Tickets =
    [
        new Ticket { Id = 1, Title = "Fel vara", Description = "Fick en blå tröja, beställde röd", CreatedAt = DateTime.UtcNow },
        new Ticket { Id = 2, Title = "Ingen leverans", Description = "Order 1234 har inte kommit", CreatedAt = DateTime.UtcNow },
    ];

    // GET /api/tickets
    [HttpGet]
    public List<Ticket> GetTickets()
    {
        return Tickets;
    }

    // GET /api/tickets/{id}
    [HttpGet("{id}")]
    public ActionResult<Ticket> GetTicket(int id)
    {
        Ticket? ticket = Tickets.FirstOrDefault(t => t.Id == id);

        if (ticket == null)
        {
            return NotFound();
        }

        return Ok(ticket);
    }
}
