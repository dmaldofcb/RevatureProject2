﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Layers.Models.Models;

namespace Layers.Models.Repository
{
    public interface IOrder
    {
        Task<Order> Get(int? id, string user); 
        Task<List<Order>> Get(string user); 
        Task<bool> Create(Order order);
        Task<bool> Edit(int id, Order order);
        Task<bool> Delete(int id);
        bool OrderExists(int id);
    }
}
