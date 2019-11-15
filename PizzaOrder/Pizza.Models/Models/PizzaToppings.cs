using System;
using System.Collections.Generic;
using System.Text;

namespace Layers.Models.Models
{
    public class PizzaToppings
    {
        public int Id { get; set; }
        public int ToppingsID { get; set; }

        public int PizzaID { get; set; }
    }
}
