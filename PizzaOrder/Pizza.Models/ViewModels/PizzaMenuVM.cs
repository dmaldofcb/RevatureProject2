using Layers.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layers.Models.ViewModels
{
    public class PizzaMenuVM 
    {
        public List<PizzaPie> PizzaPies { get; set; }
        public List<Size> Size { get; set; }
        public List<Toppings> Toppings { get; set; }
        public List<PizzaToppings> PremadePizzas { get; set; }
    }
}
