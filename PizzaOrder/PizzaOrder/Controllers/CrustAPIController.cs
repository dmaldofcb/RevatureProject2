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
    public class CrustAPIController : ControllerBase
    {
        private readonly ICrust _repo;

        public CrustAPIController(ICrust repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crust>>> GetSizes()
        {
            return await _repo.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Crust>> GetCrust(int id)
        {

            var crust = await _repo.Get(id);

            if (crust == null)
            {
                return NotFound();
            }

            return crust;
        }
    }
}
