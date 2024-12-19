using Microsoft.AspNetCore.Mvc;
using TicketingAPI.Data;
using TicketingAPI.Models;

namespace TicketingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/tickets
        [HttpGet]
        public IActionResult GetTickets()
        {
            var tickets = _context.Tickets.ToList();
            return Ok(tickets);
        }

        // POST: api/tickets
        [HttpPost]
        public IActionResult CreateTicket([FromBody] Ticket ticket)
        {
            if (ticket == null) return BadRequest("Invalid data");

            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return Ok("Ticket created successfully");
        }

        // PUT: api/tickets/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTicket(int id, [FromBody] Ticket updatedTicket)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket == null) return NotFound("Ticket not found");

            ticket.Title = updatedTicket.Title;
            ticket.Description = updatedTicket.Description;
            ticket.Status = updatedTicket.Status;

            _context.SaveChanges();
            return Ok("Ticket updated successfully");
        }

        // DELETE: api/tickets/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTicket(int id)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket == null) return NotFound("Ticket not found");

            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
            return Ok("Ticket deleted successfully");
        }
    }
}