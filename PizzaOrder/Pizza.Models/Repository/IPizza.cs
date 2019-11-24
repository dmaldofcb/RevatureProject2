using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Layers.Models.Models;

namespace Layers.Models.Repository
{
    public interface IPizza
    {
        Task<PizzaPie> Get(int? id); //get a particular Pizza
        Task<List<PizzaPie>> Get(); //get list of all pizzas 
        Task<bool> Create(PizzaPie pizza);
        Task<List<Crust>> GetCrust();

        Task<bool> Edit(int id, PizzaPie pizza);
        Task<bool> Delete(int id);
        bool PizzaExists(int id);

        Task<List<Toppings>> GetToppings();

        Task<List<PizzaToppings>> GetPizzaToppings();
        Task<List<Size>> GetSizes();
    }
}
