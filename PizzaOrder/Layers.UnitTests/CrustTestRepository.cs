using Layers.Models.Models;
using Layers.Models.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layers.UnitTests
{
    public class CrustTestRepository : ICrust
    {
        public Task<Crust> Get(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Crust>> Get()
        {
            throw new NotImplementedException();
        }
    }
}
