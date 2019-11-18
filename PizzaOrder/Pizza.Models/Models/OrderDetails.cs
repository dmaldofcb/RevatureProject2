using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Layers.Models.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }

        public int OrderID { get; set; }

        public int PizzaID { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
