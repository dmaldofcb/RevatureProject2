using Layers.Models.Models;
using Layers.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.UnitTests
{
    public class OrdersTestRepository : IOrder
    {
        private static List<Order> orders = new List<Order>()
        {
            new Order
            {
                Id = 1,
                CustomerID = "abc",
               // OrderDate = DateTime.Now,
                Total = 1.5m
            },
              new Order
            {
                Id = 2,
                CustomerID = "bcd",
                OrderDate = DateTime.Now,
                Total = 2.7m
            },
                new Order
            {
                Id = 3,
                CustomerID = "cde",
                OrderDate = DateTime.Now,
                Total = 10.5m
            },
        };

        private List<Order> newList = new List<Order>();
        public async Task<bool> Create(Order order)
        {
            newList.Add(order);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var order = orders.FirstOrDefault(x => x.Id == id);
            orders.Remove(order);
            return true;
        }

        public Task<bool> Edit(int id, Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> Get(int? id, string userId)
        {
            var order = orders.FirstOrDefault(x => x.Id == id && x.CustomerID == userId);
            return order;
        }

        public async Task<List<Order>> Get(string userID)
        {
            var listOfOrders = orders.Where(d => d.CustomerID == userID).ToList();
            return listOfOrders;
        }

        public bool OrderExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
