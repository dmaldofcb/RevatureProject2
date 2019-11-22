using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaOrder.Data;
using Layers.Models.Repository;
using Layers.Models.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Layers.Models.Repository
{
    class ToppingsRepo : IToppings    {
        private readonly ApplicationDbContext _context;
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
