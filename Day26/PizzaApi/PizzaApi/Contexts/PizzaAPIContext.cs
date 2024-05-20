using Microsoft.EntityFrameworkCore;
using PizzaApi.Models;

namespace PizzaApi.Contexts
{
    public class PizzaAPIContext: DbContext
    {
        public PizzaAPIContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Authentication> Authentications{ get; set; }

        public DbSet<Pizza> Pizzas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pizza>().HasData(

                new Pizza() { Id = 101, Name = "Peppy Paneer",  Price = 400, StockAvailable= 10 },
                new Pizza() { Id = 102, Name = "Mozeralla", Price = 500, StockAvailable= 15},
                new Pizza() { Id = 103, Name = "Indie Paneer",  Price = 800, StockAvailable= 20 }
                );




        }
    }
}
