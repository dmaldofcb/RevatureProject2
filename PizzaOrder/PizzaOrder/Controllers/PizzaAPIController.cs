using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Layers.Models.Models;
using Layers.Models.Repository;
using Layers.Models.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaOrder.Data;

namespace PizzaOrderAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("_myAllowSpecificOrigins")]
    public class PizzaAPIController : ControllerBase
    {
       // private readonly PizzaPieRepo _pizzaRepo;
        private readonly IPizza _pizzaRepo;
        public PizzaAPIController(IPizza pizzarepo)
        {
            _pizzaRepo = pizzarepo;
        }

        [HttpGet]
        public async Task<PizzaPie> Get()
        {
            PizzaPie pizza = new PizzaPie();
            var toppings = await _pizzaRepo.GetToppings();
            pizza.Toppings = toppings;
            return pizza;
        }


        [HttpGet]
        [Route("GetPizza/{id}")]

        public async Task<PizzaPie> Get(int? id)
        {
            var pizza = await _pizzaRepo.Get(id);
            return pizza;
        }

        [HttpGet("{id}")]

        public async Task<Size> GetSizes(int id)
        {
            var sizes = await _pizzaRepo.GetSizes();
            var getSize = sizes.FirstOrDefault(x => x.Id == id);
            return getSize;
        }


        [HttpGet]
        [Route("GetCrust/{crustID}")]
        public async Task<Crust> GetCrust(int crustID)
        {
            var crusts = await _pizzaRepo.GetCrust();
            var getCrust = crusts.FirstOrDefault(x => x.Id == crustID);
            return getCrust;
        }

        [HttpPost]
        [Route("AddToCart")]
        public async Task<PizzaPie> AddToCart(PizzaPie pizza)
        {
            //var pizzas = await _pizzaRepo.Get();

            // searches our middle table
            //searches our pizza menu to link the name in .cshtml to the name in our database table
            //var getPie = pizzas.FirstOrDefault(x => x.Type == pizza.Type); // returns a single item
            //searches middle table for where our PizzaID matches the pizza id in our menu table 
            //returns list of toppings and its associated pizza id
            PizzaPie createPizza = new PizzaPie()
            {
                Type = pizza.Type,
                CrustID = pizza.CrustID,
                SizeId = pizza.SizeId,
                ToppingByID = pizza.ToppingByID        
            };
            await _pizzaRepo.Create(createPizza);

            //var addToOrders = await _pizzaRepo.AddPizzaToOrder(getPie);
            return createPizza;
        }



    }
}
