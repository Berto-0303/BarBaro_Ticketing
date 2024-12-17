using Microsoft.EntityFrameworkCore;

public class TicketDbContext : DbContext
{
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=tickets.db");
    }
}