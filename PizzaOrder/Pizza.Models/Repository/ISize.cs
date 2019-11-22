using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Layers.Models.Models;

namespace Layers.Models.Repository
{
    public interface ISize
    {
        Task<Size> Get(int? id);
        Task<List<OrderDetails>> Get();
    }
}
