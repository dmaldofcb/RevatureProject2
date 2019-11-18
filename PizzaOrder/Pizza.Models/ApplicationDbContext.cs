using Layers.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PizzaOrder.Data
{
    public class ApplicationDbContext : IdentityDbContext<Customer>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server = tcp:pizzaserver2019.database.windows.net, 1433; Initial Catalog = PizzaDb; Persist Security Info = False; User ID = pizzauser; Password = Pizzaparty2019; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30");
            }
        }
        public DbSet<PizzaPie> Pizzas { get; set; }
        public DbSet<Crust> Crusts { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrdersDetails { get; set; }
        public DbSet<PizzaToppings> PizzasToppings { get; set; }
        public DbSet<Toppings> Toppings { get; set; }
        public DbSet<Size> Sizes { get; set; }




    }
}
