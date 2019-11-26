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
        private readonly IPizzaToppings _pizzaToppingsRepo;
        public ToppingsAPIController(IToppings repo, IPizzaToppings rep2)
        {
            _repo = repo;
            _pizzaToppingsRepo = rep2;
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
            return await _pizzaToppingsRepo.GetPizzaToppings(id);
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
