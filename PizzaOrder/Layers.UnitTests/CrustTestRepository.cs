using Layers.Models.Models;
using Layers.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.UnitTests
{
    public class CrustTestRepository : ICrust
    {
        private static List<Crust> crusts = new List<Crust>()
        {
            new Crust()
            {
                Id = 1,
                Price = 20,
                Type = "Thin Crust"
            },
             new Crust()
            {
                Id = 2,
                Price = 10,
                Type = "Thick Crust"
            },
              new Crust()
            {
                Id = 3,
                Price = 5,
                Type = "Stuffed Crust"
            },
        };
        public async Task<Crust> Get(int? id)
        {
            var crust = crusts.FirstOrDefault(x => x.Id == id);
            return crust;
        }

        public Task<List<Crust>> Get()
        {
            throw new NotImplementedException();
        }

       
    }
}
