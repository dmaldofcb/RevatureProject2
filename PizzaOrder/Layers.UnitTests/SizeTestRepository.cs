using Layers.Models.Models;
using Layers.Models.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layers.UnitTests
{
    public class SizeTestRepository : ISize
    {
        public Task<Size> Get(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Size>> Get()
        {
            throw new NotImplementedException();
        }
    }
}
