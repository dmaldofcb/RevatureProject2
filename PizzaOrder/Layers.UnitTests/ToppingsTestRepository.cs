using Layers.Models.Models;
using Layers.Models.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layers.UnitTests
{
    public class ToppingsTestRepository : IToppings
    {
        public Task<Toppings> Get(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Toppings>> Get()
        {
            throw new NotImplementedException();
        }
    }
}
