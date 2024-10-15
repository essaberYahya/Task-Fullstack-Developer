using Microsoft.EntityFrameworkCore;
using Task_Fullstack_Developer.Models;

namespace Task_Fullstack_Developer.Context
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base (options) { }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
