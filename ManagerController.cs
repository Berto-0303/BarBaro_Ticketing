using Microsoft.AspNetCore.Mvc;
using System.Linq;

[ApiController]
[Route("api/manager")]
public class ManagerController : ControllerBase
{
    private readonly TicketDbContext _context;

    public ManagerController(TicketDbContext context)
    {
        _context = context;
    }

    // 1. LISTA TICKETELOR
    [HttpGet("list")]
    public IActionResult GetAllTickets()
    {
        var tickets = _context.Tickets.ToList();
        return Ok(tickets);
    }

    // 2. VIZUALIZARE UN TICKET
    [HttpGet("view/{id}")]
    public IActionResult ViewTicket(int id)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null) return NotFound("Ticket not found.");
        return Ok(ticket);
    }

    // 3. ACTUALIZAREA STATUS-ULUI
    [HttpPut("update-status/{id}")]
    public IActionResult UpdateStatus(int id, [FromBody] string status)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null) return NotFound("Ticket not found.");
        ticket.Status = status;
        ticket.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
        return Ok(ticket);
    }

    // 4. ACTUALIZARE INFORMAȚII TICKET
    [HttpPut("update-info/{id}")]
    public IActionResult UpdateTicketInfo(int id, [FromBody] Ticket updatedTicket)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null) return NotFound("Ticket not found.");
        ticket.Title = updatedTicket.Title ?? ticket.Title;
        ticket.Description = updatedTicket.Description ?? ticket.Description;
        ticket.Priority = updatedTicket.Priority ?? ticket.Priority;
        ticket.Status = updatedTicket.Status ?? ticket.Status;
        ticket.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
        return Ok(ticket);
    }
}