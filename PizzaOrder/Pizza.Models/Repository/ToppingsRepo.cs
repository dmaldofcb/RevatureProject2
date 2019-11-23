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
    public class ToppingsRepo : IToppings    {

        private readonly ApplicationDbContext _context;

        public ToppingsRepo(ApplicationDbContext ctx)
        {

            _context = ctx;
        }

        public async Task<Toppings> Get(int? id)
        {
            var toppings = await _context.Toppings.FirstOrDefaultAsync(x => x.Id == id);
            return toppings;
        }
        public async Task<List<Toppings>> Get()
        {
            var toppings = await _context.Toppings.ToListAsync();
            return toppings;
        }
    }
}
