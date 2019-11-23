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
    public class SizeRepo : ISize
    {
        private readonly ApplicationDbContext _context;

        public SizeRepo(ApplicationDbContext ctx)
        {

            _context = ctx;
        }
        public async Task<Size> Get(int? id)
        {
            var size = await _context.Sizes.FirstOrDefaultAsync(x => x.Id == id);
            return size;
        }
        public async Task<List<Size>> Get()
        {
            var size = await _context.Sizes.ToListAsync();
            return size;
        }
    }
}
