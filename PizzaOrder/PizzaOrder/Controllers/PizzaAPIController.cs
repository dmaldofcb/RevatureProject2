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
    
    public class PizzaAPIController : ControllerBase
    {
       // private readonly PizzaPieRepo _pizzaRepo;
        private readonly IPizza _pizzaRepo;
        public PizzaAPIController(IPizza pizzarepo)
        {
            _pizzaRepo = pizzarepo;
        }



        [HttpGet]
        public async Task<PizzaMenuVM> Get()
        {
            var pizzaMenu = await _pizzaRepo.Get();
            var sizes = await _pizzaRepo.GetSizes();
            var toppings = await _pizzaRepo.GetToppings();
            var menu = await _pizzaRepo.GetPizzaToppings();
            PizzaMenuVM pizzaMenuModel = new PizzaMenuVM();
            pizzaMenuModel.PizzaPies = pizzaMenu;
            pizzaMenuModel.PremadePizzas = menu;
            pizzaMenuModel.Size = sizes;
            pizzaMenuModel.Toppings = toppings;
            return pizzaMenuModel;
        }

        [HttpGet("{id}")]
        public async Task<Size> GetSizes(int id)
        {
            var sizes = await _pizzaRepo.GetSizes();
            var getSize = sizes.FirstOrDefault(x => x.Id == id);
            return getSize;
        }

        //[HttpGet("{name}")]
        //public async Task<List<PizzaToppings>> GetToppings(string name)
        //{
        //    var pizzas = await _pizzaRepo.Get();

        //    var pizzaToppings = await _pizzaRepo.GetPizzaToppings();
        //    var getPie = pizzas.FirstOrDefault(x => x.Type == name);
        //    var toppings = pizzaToppings.Where(x => x.PizzaID == getPie.Id).ToList();
        //    return toppings;
        //}

    }
}
