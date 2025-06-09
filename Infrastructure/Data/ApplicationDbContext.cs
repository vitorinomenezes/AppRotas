using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }

        public DbSet<Route> Routes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Route>().HasKey(r => r.Id);
            modelBuilder.Entity<Route>().Property(r => r.Origin).IsRequired().HasMaxLength(3);
            modelBuilder.Entity<Route>().Property(r => r.Destination).IsRequired().HasMaxLength(3);

            // Fix for CS1061: Use the correct extension method for setting column type
            modelBuilder.Entity<Route>().Property(r => r.Value).HasPrecision(18, 2);

            // Seed inicial para testes
            modelBuilder.Entity<Route>().HasData(
                new Route { Id = 1, Origin = "GRU", Destination = "BRC", Value = 10m },
                new Route { Id = 2, Origin = "BRC", Destination = "SCL", Value = 5m },
                new Route { Id = 3, Origin = "GRU", Destination = "CDG", Value = 75m },             
                new Route { Id = 4, Origin = "GRU", Destination = "SCL", Value = 20m },
                new Route { Id = 5, Origin = "GRU", Destination = "ORL", Value = 56m },
                new Route { Id = 6, Origin = "ORL", Destination = "CDG", Value = 5m },
                new Route { Id = 7, Origin = "SCL", Destination = "ORL", Value = 20m },
                new Route { Id = 8, Origin = "GRU", Destination = "CDG", Value = 40m }
            );

            modelBuilder.Entity<Users>().HasData(
               new Users { Id = 1, Email = "master@gmail.com", Password = "1234" }
            );
        }
    }
}
