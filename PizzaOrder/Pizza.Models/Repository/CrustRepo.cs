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
    public class CrustRepo : ICrust
    {
        private readonly ApplicationDbContext _context;

        public CrustRepo(ApplicationDbContext ctx)
        {

            _context = ctx;
        }

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
