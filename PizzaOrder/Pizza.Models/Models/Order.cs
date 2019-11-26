using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Layers.Models.Models
{
    public class Order
    {
        [DisplayName("Order Number")]

        public int Id { get; set; }

        public string CustomerID {get;set;}

        [DisplayName("Date/Time Order")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm:ss}")]
        public DateTime OrderDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [DisplayName("Total Amount")]
        public decimal Total { get; set; }
    }
}
