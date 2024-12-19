using Microsoft.EntityFrameworkCore;
using TicketingAPI.Models;

namespace TicketingAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurarea tabelelor
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Ticket>().ToTable("Ticket");

            // Configurări specifice pentru `Category`
            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}