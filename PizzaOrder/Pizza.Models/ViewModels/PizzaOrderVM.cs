using Layers.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layers.Models.ViewModels
{
    public class PizzaOrderVM
    {
        public Order CurrOrder { get; set; }
        public List<OrderDetails> OrderDetailsList { get; set; }
        public List<PizzaPie> PizzaPieList { get; set; } = new List<PizzaPie>();
        public List<PizzaToppings> ToppingsList { get; set; }
    }
}
