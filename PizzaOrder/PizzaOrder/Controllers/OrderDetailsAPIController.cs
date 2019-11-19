//Using statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Layers.Models.Models;
using PizzaOrder.Data;
using Layers.Models.Repository;

namespace PizzaOrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetails _repo;

        public OrderDetailsController(IOrderDetails repo)
        {
            _repo = repo;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrdersDetails()
        {
            return await _repo.Get();
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetails>> GetOrderDetails(int id)
        {
            var orderDetails = await _repo.Get(id);

            if (orderDetails == null)
            {
                return NotFound();
            }

            return orderDetails;
        }

        // PUT: api/OrderDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOrderDetails(int id, OrderDetails orderDetails)
        //{
        //    if (id != orderDetails.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _repo.Entry(orderDetails).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderDetailsExists(id))
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

        //// POST: api/OrderDetails
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<OrderDetails>> PostOrderDetails(OrderDetails orderDetails)
        //{
        //    _context.OrdersDetails.Add(orderDetails);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetOrderDetails", new { id = orderDetails.Id }, orderDetails);
        //}

        //// DELETE: api/OrderDetails/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<OrderDetails>> DeleteOrderDetails(int id)
        //{
        //    var orderDetails = await _context.OrdersDetails.FindAsync(id);
        //    if (orderDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.OrdersDetails.Remove(orderDetails);
        //    await _context.SaveChangesAsync();

        //    return orderDetails;
        //}

        //private bool OrderDetailsExists(int id)
        //{
        //    return _context.OrdersDetails.Any(e => e.Id == id);
        //}
    }
}
