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

        public DbSet<Layers.Models.Models.Pizza> Pizzas { get; set; }
        public DbSet<Crust> Crusts { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrdersDetails { get; set; }
        public DbSet<PizzaToppings> PizzasToppings { get; set; }
        public DbSet<Toppings> Toppings { get; set; }




    }
}
