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
    public class PizzaPieRepo : IPizza
    {
        private readonly ApplicationDbContext _context;

        public PizzaPieRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(PizzaPie pizza)
        {
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(int id, PizzaPie pizza)
        {
            throw new NotImplementedException();
        }

        //Get a specific pizza
        public async Task<PizzaPie> Get(int? id)
        {
            var pizza = await _context.Pizzas.FirstOrDefaultAsync(x => x.Id == id);
            return pizza;
        }

        //Get all pies on our menu
        public async Task<List<PizzaPie>> Get()
        {
            var pizzas = await _context.Pizzas.ToListAsync();
            return pizzas;
        }

        //Check to see if we have a particular pizza in the DB
        public bool PizzaExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Toppings>> GetToppings()
        {
            var toppings = await _context.Toppings.ToListAsync();
            return toppings;
        }
        public async Task<List<PizzaToppings>> GetPizzaToppings()
        {
            var pizzaToppings = await _context.PizzasToppings.ToListAsync();
            return pizzaToppings;
        }
        public async Task<List<Size>> GetSizes()
        {
            var sizes = await _context.Sizes.ToListAsync();
            return sizes;
        }

        public async Task<List<Crust>> GetCrust()
        {
            var crust = await _context.Crusts.ToListAsync();
            return crust;
        }
    }
}
