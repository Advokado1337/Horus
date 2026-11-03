using Helpdesk.Api.Models;
using Helpdesk.Api.Services;
using Microsoft.AspNetCore.Mvc;


namespace Helpdesk.Api.Controllers;

[ApiController]
[Route("api/tickets")]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }
    // private static readonly List<Ticket> Tickets =
    // [
    //     new Ticket { Id = 1, Title = "Fel vara", Description = "Fick en blå tröja, beställde röd", CreatedAt = DateTime.UtcNow },
    //     new Ticket { Id = 2, Title = "Ingen leverans", Description = "Order 1234 har inte kommit", CreatedAt = DateTime.UtcNow },
    // ];

    // GET /api/tickets
    [HttpGet]
    public List<Ticket> GetTickets()
    {
        return _ticketService.GetAll();
    }

    // GET /api/tickets/{id}
    [HttpGet("{id}")]
    public ActionResult<Ticket> GetTicket(int id)
    {
        Ticket? ticket = _ticketService.GetById(id);
        if (ticket == null)
        {
            return NotFound();
        }

        return Ok(ticket);
    }

    [HttpPost]
    public ActionResult<Ticket> CreateTicket(CreateTicketRequest request)
    {
        Ticket ticket = _ticketService.Create(request);
        return CreatedAtAction(nameof(GetTicket), new {id = ticket.Id}, ticket);
    }
}
