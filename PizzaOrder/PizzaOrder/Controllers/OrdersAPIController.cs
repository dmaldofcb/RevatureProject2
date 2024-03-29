﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Layers.Models.Models;
using Layers.Models.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using PizzaOrder.Data;

namespace PizzaOrderAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrder _repo;
        // GET: api/Orders

        public OrdersController(IOrder repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("GetOrders/{userId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders(string userId)
        {           
            return await _repo.Get(userId);
        }

        // GET: api/Orders/5
        //[HttpGet("{id}")]
        [HttpGet]
        [Route("GetOrder/{userId}/{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id, string userId)
        {

            var order = await _repo.Get(id, userId);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOrder(int id, Order order)
        //{
        //    if (id != order.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(order).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Orders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            await _repo.Create(order);

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Order>> DeleteOrder(int id)
        //{
        //    var order = await _context.Orders.FindAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Orders.Remove(order);
        //    await _context.SaveChangesAsync();

        //    return order;
        //}

    
    }
}
