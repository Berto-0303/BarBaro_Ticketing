using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/client")]
public class ClientController : ControllerBase
{
    private readonly TicketDbContext _context;

    public ClientController(TicketDbContext context)
    {
        _context = context;
    }

    // 1. CREEAZĂ UN TICKET
    [HttpPost("create")]
    public IActionResult CreateTicket([FromBody] Ticket ticket)
    {
        ticket.Status = "Open";
        _context.Tickets.Add(ticket);
        _context.SaveChanges();
        return Ok(ticket);
    }

    // 2. DETALIAZĂ PROBLEMA
    [HttpPut("update/{id}")]
    public IActionResult UpdateTicketDetails(int id, [FromBody] string description)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null) return NotFound("Ticket not found.");
        ticket.Description = description;
        ticket.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
        return Ok(ticket);
    }

    // 3. VERIFICĂ STAREA TICKETULUI
    [HttpGet("status/{id}")]
    public IActionResult GetTicketStatus(int id)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null) return NotFound("Ticket not found.");
        return Ok(new { ticket.Id, ticket.Status });
    }

    // 4. EDITARE TICKET
    [HttpPut("edit/{id}")]
    public IActionResult EditTicket(int id, [FromBody] Ticket updatedTicket)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null) return NotFound("Ticket not found.");
        ticket.Title = updatedTicket.Title ?? ticket.Title;
        ticket.Description = updatedTicket.Description ?? ticket.Description;
        ticket.Priority = updatedTicket.Priority ?? ticket.Priority;
        ticket.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
        return Ok(ticket);
    }

    // 5. ȘTERGE TICKETUL
    [HttpDelete("delete/{id}")]
    public IActionResult DeleteTicket(int id)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null) return NotFound("Ticket not found.");
        _context.Tickets.Remove(ticket);
        _context.SaveChanges();
        return Ok("Ticket deleted.");
    }

    // 5BIS. ELIMINĂ PROBLEMA DIN TICKET (UPDATE)
    [HttpPut("remove-problem/{id}")]
    public IActionResult RemoveProblem(int id)
    {
        var ticket = _context.Tickets.Find(id);
        if (ticket == null) return NotFound("Ticket not found.");
        ticket.Description = null;
        ticket.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
        return Ok(ticket);
    }
}
