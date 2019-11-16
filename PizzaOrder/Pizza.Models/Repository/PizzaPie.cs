using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Models.Repository
{
    public class PizzaPie : IPizza
    {
        public Task<bool> Create(PizzaPie pizza)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(int id, PizzaPie pizza)
        {
            throw new NotImplementedException();
        }

        public Task<PizzaPie> Get(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PizzaPie>> Get()
        {
            throw new NotImplementedException();
        }

        public bool PizzaExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
