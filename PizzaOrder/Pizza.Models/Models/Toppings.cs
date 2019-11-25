using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Layers.Models.Models
{
    public class Toppings
    {
        public int Id { get; set; }

        public string Type { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Price { get; set; }

    }
}
