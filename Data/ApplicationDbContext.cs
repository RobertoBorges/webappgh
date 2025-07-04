using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Models;

namespace TicketSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Show> Shows { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Show)
                .WithMany(s => s.Tickets)
                .HasForeignKey(t => t.ShowId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed data for shows
            modelBuilder.Entity<Show>().HasData(
                new Show
                {
                    Id = 1,
                    Title = "Concert in the Park",
                    Description = "Enjoy live music under the stars with local bands.",
                    DateTime = new DateTime(2025, 8, 15, 19, 0, 0),
                    Venue = "Central Park Amphitheater",
                    Price = 25.00m,
                    TotalTickets = 500,
                    AvailableTickets = 500
                },
                new Show
                {
                    Id = 2,
                    Title = "Comedy Night Special",
                    Description = "Laugh out loud with our featured comedians.",
                    DateTime = new DateTime(2025, 7, 25, 20, 0, 0),
                    Venue = "Comedy Club Downtown",
                    Price = 35.00m,
                    TotalTickets = 200,
                    AvailableTickets = 200
                },
                new Show
                {
                    Id = 3,
                    Title = "Classical Music Evening",
                    Description = "Experience beautiful classical music performed by the city orchestra.",
                    DateTime = new DateTime(2025, 8, 30, 18, 30, 0),
                    Venue = "Grand Concert Hall",
                    Price = 50.00m,
                    TotalTickets = 300,
                    AvailableTickets = 300
                }
            );
        }
    }
}