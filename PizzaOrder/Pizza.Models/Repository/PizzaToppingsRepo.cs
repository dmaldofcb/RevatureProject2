using Layers.Models.Models;
using Microsoft.EntityFrameworkCore;
using PizzaOrder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<PizzaToppings>> GetPizzaToppings(int? id)
        {
            var toppings = await _context.PizzasToppings.Where(d => d.PizzaID == id).ToListAsync();
            return toppings;
        }
    }
}
