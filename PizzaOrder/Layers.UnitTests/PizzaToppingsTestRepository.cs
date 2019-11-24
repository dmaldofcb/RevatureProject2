using Layers.Models.Models;
using Layers.Models.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layers.UnitTests
{
    public class PizzaToppingsTestRepository : IPizzaToppings
    {
        public Task<bool> AddPizzaToppings(PizzaToppings pizzaTopping)
        {
            throw new NotImplementedException();
        }

        public Task<List<PizzaToppings>> GetPizzaToppings()
        {
            throw new NotImplementedException();
        }
    }
}
