using System.Net;
using System.Net.Http.Json;
using Helpdesk.Api.Models;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Helpdesk.Tests.Integration;


public class TicketsApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public TicketsApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Post_WithEmptyTitle_Returns400()
    {
        var response = await _client.PostAsJsonAsync("/api/tickets",
            new { title = "", description = "Saknar titel" });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    
    [Fact]
    public async Task Post_WithClientSuppliedId_IgnoresIt()
    {
        var response = await _client.PostAsJsonAsync("/api/tickets",
            new { id = 999, title = "Eget id", description = "Mass assignment-test" });

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        var ticket = await response.Content.ReadFromJsonAsync<Ticket>();
        Assert.NotNull(ticket);
        Assert.NotEqual(999, ticket.Id);
    }
}