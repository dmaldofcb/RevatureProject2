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
    public class SizeAPIController : ControllerBase
    {
        private readonly ISize _repo;

        public SizeAPIController(ISize repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Size>>> GetOrdersDetails()
        {
            return await _repo.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Size>> GetSize(int id)
        {

            var size = await _repo.Get(id);

            if (size == null)
            {
                return NotFound();
            }

            return size;
        }
    }
}
