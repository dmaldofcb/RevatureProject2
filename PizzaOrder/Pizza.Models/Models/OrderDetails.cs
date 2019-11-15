using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Models.Models
{
    class OrderDetails
    {
        public int ID { get; set; }

        public int OrderID { get; set; }

        public int PizzaID { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}
