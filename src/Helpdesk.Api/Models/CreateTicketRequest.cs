using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Api.Models;

public class CreateTicketRequest
{
    [Required, MaxLength(200)]
    public string Title {get;set;}="";


    [Required, MaxLength(500)]
    public string Description {get;set;} ="";


}