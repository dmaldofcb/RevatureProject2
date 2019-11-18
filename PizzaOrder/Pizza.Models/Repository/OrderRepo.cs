using Layers.Models.Models;
using Microsoft.EntityFrameworkCore;
using PizzaOrder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Models.Repository
{
    public class OrderRepo : IOrder
    {
        private ApplicationDbContext _context;
        //private readonly HttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
        public OrderRepo(ApplicationDbContext ctx)
        {
            
            _context = ctx;
        }


        public async Task<bool> Create(Order order)
        {
            
            _context.Add(order);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Edit(int id, Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> Get(int? id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(m => m.Id == id);

            return order;
        }

        public async Task<List<Order>> Get()
        {

            //var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier); //get customer Identity class id
            //var orders = await _context.Orders.Where(d => d.CustomerID == userId).ToListAsync(); 
            var orders = await _context.Orders.ToListAsync();
            return orders;
        }

        public bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }

        //public async Task<List<Order>> OrderOfCustomer()
        //{
        //    //var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    // var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier); //get customer Identity class id
        //    //var orders = await _context.Orders.Where(d => d.CustomerID == userId).ToListAsync(); 
        //    var orders = await _context.Orders.ToListAsync();
        //    return orders;
        //}

    }
}
