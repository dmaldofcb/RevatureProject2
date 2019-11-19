using Layers.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Models.Repository
{
    public interface IOrderDetails
    {
        Task<OrderDetails> Get(int? id);
        Task<List<OrderDetails>> Get();
        Task<bool> Create(OrderDetails orderDetails);
        Task<bool> Edit(int id, OrderDetails orderDetails);
        Task<bool> Delete(int id);
        bool OrderExists(int id);
    }
}
