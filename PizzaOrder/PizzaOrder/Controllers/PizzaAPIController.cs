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
        private readonly ISize _sizeRepo;
        private readonly IToppings _toppingsRepo;
        private readonly ICrust _crustRepo;
        private readonly IPizzaToppings _pizzaToppingsRepo;

        public PizzaAPIController(IPizza pizzaRepo, ISize sizeRepo, IToppings toppingsRepo, ICrust crustRepo, IPizzaToppings pizzaToppings)
        {
            _pizzaRepo = pizzaRepo;
            _sizeRepo = sizeRepo;
            _toppingsRepo = toppingsRepo;
            _crustRepo = crustRepo;
            _pizzaToppingsRepo = pizzaToppings;
        }

        [HttpGet]
        public async Task<PizzaPie> Get()
        {
            PizzaPie pizza = new PizzaPie();
            var toppings = await _toppingsRepo.Get();
            pizza.Toppings = toppings;
            return pizza;
        }

        [HttpGet("{id}")]

        public async Task<Size> GetSize(int id)
        {
            var getSize = await _sizeRepo.Get(id);
            return getSize;
        }


        [HttpGet]
        [Route("GetCrust/{crustID}")]
        public async Task<Crust> GetCrust(int crustID)
        {
            var crust = await _crustRepo.Get(crustID);
            return crust;
        }

        [HttpPost]
        [Route("AddToCart")]
        public async Task<PizzaPie> AddToCart(PizzaPie pizza)
        {
            PizzaPie createPizza = new PizzaPie()
            {
                Type = pizza.Type,
                CrustID = pizza.CrustID,
                SizeId = pizza.SizeId,
                ToppingByID = pizza.ToppingByID        
            };
            await _pizzaRepo.Create(createPizza);
            for(int i = 0; i < pizza.ToppingByID.Length; i++)
            {
                PizzaToppings pizzaToppings = new PizzaToppings();
                pizzaToppings.PizzaID = createPizza.Id;
                pizzaToppings.ToppingsID = pizza.ToppingByID[i];
                await _pizzaToppingsRepo.AddPizzaToppings(pizzaToppings);
            }
            //var addToOrders = await _pizzaRepo.AddPizzaToOrder(getPie);
            return createPizza;
        }



    }
}
