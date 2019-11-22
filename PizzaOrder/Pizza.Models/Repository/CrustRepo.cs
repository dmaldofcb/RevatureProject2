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
    class CrustRepo : ICrust
    {
        private readonly ApplicationDbContext _context;
        public async Task<Crust> Get(int? id)
        {
            var crust = await _context.Crusts.FirstOrDefaultAsync(x => x.Id == id);
            return crust;
        }
        public async Task<List<Crust>> Get()
        {
            var crust = await _context.Crusts.ToListAsync();
            return crust;
        }
    }
}
