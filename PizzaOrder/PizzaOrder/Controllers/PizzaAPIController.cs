using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Layers.Models.Models;
using Layers.Models.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaOrder.Data;

namespace PizzaOrderAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PizzaController : ControllerBase
    {
       // private readonly PizzaPieRepo _pizzaRepo;
        private readonly IPizza _pizzaRepo;
        public PizzaController(IPizza pizzarepo)
        {
            _pizzaRepo = pizzarepo;
        }

        public List<PizzaPie> pizzas = new List<PizzaPie>()
        {
            new PizzaPie() {Id = 1, CrustID = 1, IsCustom = false, SizeId = 1, Type = "Pepperoni"},
             new PizzaPie() {Id = 2, CrustID = 2, IsCustom = false, SizeId = 2, Type = "Meat Lovers"},
              new PizzaPie() {Id = 3, CrustID = 3, IsCustom = false, SizeId = 3, Type = "Sausage"},
        };


        [HttpGet]
        public async Task<IEnumerable<PizzaPie>> Get()
        {
            var pizzaMenu = await _pizzaRepo.Get();
            return pizzaMenu;
        }

    }
}
