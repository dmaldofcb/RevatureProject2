using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Layers.Models.Models;

namespace Layers.Models.Repository
{
    public interface IToppings
    {
        Task<Toppings> Get(int? id);
        Task<List<Toppings>> Get(string user);
    }
}
