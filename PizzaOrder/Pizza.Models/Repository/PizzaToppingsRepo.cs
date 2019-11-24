using Layers.Models.Models;
using PizzaOrder.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Models.Repository
{
    public class PizzaToppingsRepo : IPizzaToppings
    {

        private readonly ApplicationDbContext _context;

        public PizzaToppingsRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddPizzaToppings(PizzaToppings pizzaTopping)
        {
            _context.PizzasToppings.Add(pizzaTopping);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<PizzaToppings>> GetPizzaToppings()
        {
            var pizzaToppings = await _context.PizzasToppings.ToListAsync();
            return pizzaToppings;
        }
    }
}
