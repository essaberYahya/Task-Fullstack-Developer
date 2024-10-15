using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Fullstack_Developer.Context;
using Task_Fullstack_Developer.Models;

namespace Task_Fullstack_Developer.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly TicketContext _ticketContext;

        public TicketController(TicketContext ticketContext) => _ticketContext = ticketContext;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets(int page = 1, int pageSize = 10)
        {
          return await _ticketContext.Tickets.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var result = await _ticketContext.Tickets.FindAsync(id);

            return result != null ? Ok(result) : NotFound(); 

        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> CreateTicket(Ticket ticket)
        {
            _ticketContext.Tickets.Add(ticket);
            await _ticketContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTicket), new { id = ticket.TicketId }, ticket);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, Ticket ticket)
        {
            if (id != ticket.TicketId) return BadRequest();
            _ticketContext.Entry(ticket).State = EntityState.Modified;
            await _ticketContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _ticketContext.Tickets.FindAsync(id);
            if (ticket == null) return NotFound();
            _ticketContext.Tickets.Remove(ticket);
            await _ticketContext.SaveChangesAsync();
            return NoContent();
        }

    }
}
