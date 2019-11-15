using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Models.Models
{
    class Order
    {
        public int ID { get; set; }

        public int UserID {get;set;}

        public DateTime OrderDate { get; set; }

        public double Total { get; set; }
    }
}
