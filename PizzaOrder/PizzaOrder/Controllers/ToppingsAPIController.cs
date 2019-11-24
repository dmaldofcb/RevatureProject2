using System;
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

namespace PizzaOrder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToppingsAPIController : ControllerBase
    {
        private readonly IToppings _repo;
       
        public ToppingsAPIController(IToppings repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Toppings>>> GetToppings()
        {
            return await _repo.Get();
        }

        [HttpGet]
        [Route("GetPizzaToppings/{id}")]
        public async Task<ActionResult<IEnumerable<PizzaToppings>>> GetPizzaToppings(int id)
        {
            return await _repo.GetPizzaToppings(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Toppings>> GetToppings(int id)
        {

            var toppings = await _repo.Get(id);

            if (toppings == null)
            {
                return NotFound();
            }

            return toppings;
        }
    }
}
