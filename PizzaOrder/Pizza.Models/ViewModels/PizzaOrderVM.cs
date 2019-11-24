using Layers.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layers.Models.ViewModels
{
    public class PizzaOrderVM
    {
        public Order CurrOrder { get; set; }
        public List<OrderDetails> OrderDetailsList { get; set; } = new List<OrderDetails>();
        public List<PizzaPie> PizzaPieList { get; set; } = new List<PizzaPie>();
        public List<Size> SizesList { get; set; }
        public List<Crust> CrustList { get; set; }
        public Dictionary<int, List<PizzaToppings>> PizzaToppingsList { get; set; } = new Dictionary<int, List<PizzaToppings>>();
        public Dictionary<int, List<Toppings>> ToppingsList { get; set; } = new Dictionary<int, List<Toppings>>();

    }
}
