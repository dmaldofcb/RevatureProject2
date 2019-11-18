using System;
using System.Collections.Generic;
using System.Text;

namespace Layers.Models.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string CustomerID {get;set;}

        public DateTime OrderDate { get; set; }

        public decimal Total { get; set; }
    }
}
