using Layers.Models.Models;
using Layers.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.UnitTests
{
    public class SizeTestRepository : ISize
    {
        private static List<Size> sizes = new List<Size>()
        {
            new Size()
            {
                Id = 1,
                Price = 20,
                Type = "small"
            },
             new Size()
            {
                Id = 2,
                Price = 10,
                Type = "medium"
            },
              new Size()
            {
                Id = 3,
                Price = 5,
                Type = "large"
            },
        };
        public async Task<Size> Get(int? id)
        {
           var size = sizes.FirstOrDefault(x => x.Id == id);
            return size;
        }
        
        public Task<List<Size>> Get()
        {
            throw new NotImplementedException();
        }
    }
}
