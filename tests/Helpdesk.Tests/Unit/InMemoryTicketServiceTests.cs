using Helpdesk.Api.Models;
using Helpdesk.Api.Services;

namespace Helpdesk.Tests.Unit;

public class InMemoryTicketServiceTests
{
    [Fact]
    public void Create_AddsTicket_ThatCanBeFetchedById()
    {
        
        var service = new InMemoryTicketService();          
        var request = new CreateTicketRequest { Title = "Test", Description = "Beskrivning" };

        
        Ticket created = service.Create(request);

        
        Ticket? fetched = service.GetById(created.Id);
        Assert.NotNull(fetched);
        Assert.Equal("Test", fetched.Title);
    }

    [Fact]
    public void GetById_UnknownId_ReturnsNull()
    {
        var service = new InMemoryTicketService();

        Assert.Null(service.GetById(999));
    }
}