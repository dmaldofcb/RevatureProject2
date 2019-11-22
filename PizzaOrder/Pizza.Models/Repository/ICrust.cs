using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Layers.Models.Models;

namespace Layers.Models.Repository
{
    public interface ICrust
    {
        Task<Crust> Get(int? id);
        Task<List<Crust>> Get(string user);
    }
}
