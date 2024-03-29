﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaOrder.Data;
using Layers.Models.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Layers.Models.Repository
{
    public class OrderDetailsRepo : IOrderDetails
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailsRepo(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public async Task<bool> Create(OrderDetails orderDetails)
        {
            _context.Add(orderDetails);
            await _context.SaveChangesAsync();

            return true;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(int id, OrderDetails orderDetails)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderDetails> Get(int? id)
        {
            var orderDet = await _context.OrdersDetails.FirstOrDefaultAsync(x => x.Id == id);
            return orderDet;
        }

        public async Task<List<OrderDetails>> Get()
        {
            var orderDet = await _context.OrdersDetails.ToListAsync();
            return orderDet;
        }

        public async Task<List<OrderDetails>> GetByOrderID(int orderId)
        {
            var orderDet = await _context.OrdersDetails.Where(d=> d.OrderID == orderId).ToListAsync();
            return orderDet;
        }

        public bool OrderExists(int id)
        {
            throw new NotImplementedException();
        }

    }
}
