using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Layers.Models.Models;
using Layers.Models.ViewModels;
using Layers.Models.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaOrder.Data;

namespace PizzaOrderAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PizzaAPIController : ControllerBase
    {
        // private readonly PizzaPieRepo _pizzaRepo;
        private readonly IPizza _pizzaRepo;
        public PizzaAPIController(IPizza pizzarepo)
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
        public async Task<PizzaMenuVM> Get()
        {
            var pizzaMenu = await _pizzaRepo.Get();
            var sizes = await _pizzaRepo.GetSizes();
            var toppings = await _pizzaRepo.GetToppings();
            var menu = await _pizzaRepo.GetMenu();


            PizzaMenuVM pizzaMenuModel = new PizzaMenuVM();
            pizzaMenuModel.PizzaPies = pizzaMenu;
            pizzaMenuModel.PremadePizzas = menu;
            pizzaMenuModel.Size = sizes;
            pizzaMenuModel.Toppings = toppings;
            return pizzaMenuModel;
        }

        //[HttpGet]
        //public async Task<List<PizzaPie>> Get()
        //{
        //    var pizzaMenu = await _pizzaRepo.Get();
        //    return pizzaMenu;
        //}

    }
}
