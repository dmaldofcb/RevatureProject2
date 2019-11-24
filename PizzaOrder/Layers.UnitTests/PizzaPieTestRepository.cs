using Layers.Models.Models;
using Layers.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.UnitTests
{
    public class PizzaPieTestRepository : IPizza
    {

        private static List<PizzaPie> pizzaPies = new List<PizzaPie>()
        {
            new PizzaPie()
            {
                Id = 101,
                SizeId = 2,
                CrustID = 3,
                Type = "pepperoni",
            },
               new PizzaPie()
            {
                Id = 102,
                SizeId = 1,
                CrustID = 1,
                Type = "sausage",
            },
                  new PizzaPie()
            {
                Id = 103,
                SizeId = 3,
                CrustID = 2,
                Type = "hawaiian",
            },

        };
        public Task<bool> AddPizzaToppings(PizzaToppings pizzaTopping)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Create(PizzaPie pizza)
        {
            pizzaPies.Add(pizza);
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

        public async Task<PizzaPie> Get(int? id)
        {
            var pizza = pizzaPies.Where(x => x.Id == (int)id).SingleOrDefault<PizzaPie>();
            return pizza;
        }

        public Task<List<PizzaPie>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<List<Crust>> GetCrust()
        {
            throw new NotImplementedException();
        }

        public Task<List<PizzaToppings>> GetPizzaToppings()
        {
            throw new NotImplementedException();
        }

        public Task<List<Size>> GetSizes()
        {
            throw new NotImplementedException();
        }

        public Task<List<Toppings>> GetToppings()
        {
            throw new NotImplementedException();
        }

        public bool PizzaExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
