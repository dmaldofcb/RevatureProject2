using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Layers.Models.Models;
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
        //private readonly PizzaRepo _pizzaRepo;

        //public PizzaController(PizzaRepo pizzaRepo)
        //{
        //    _pizzaRepo = pizzaRepo;
        //}

        public PizzaController()
        {

        }

        public List<PizzaPie> pizzas = new List<PizzaPie>()
        {
            new PizzaPie() {Id = 1, CrustID = 1, IsCustom = false, SizeId = 1, Type = "Pepperoni"},
             new PizzaPie() {Id = 2, CrustID = 2, IsCustom = false, SizeId = 2, Type = "Meat Lovers"},
              new PizzaPie() {Id = 3, CrustID = 3, IsCustom = false, SizeId = 3, Type = "Sausage"},
        };


        [HttpGet]
        public IEnumerable<PizzaPie> Get()
        {
            return pizzas;
        }

    }
}
