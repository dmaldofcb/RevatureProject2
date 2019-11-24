using Layers.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Models.Repository
{
    public interface IPizzaToppings
    {
        Task<bool> AddPizzaToppings(PizzaToppings pizzaTopping);
        Task<List<PizzaToppings>> GetPizzaToppings();

    }
}
