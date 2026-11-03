using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Api.Models;

public class CreateTicketRequest
{
    [Required, MaxLength(200)]
    public string Title {get;set;}="";

    public string Description {get;set;} ="";


}