using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Layers.Models.Models
{
    public class PizzaPie
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public int CrustID { get; set; }

        public int SizeId { get; set; }

        [NotMapped]
        public List<Toppings> Toppings { get; set; } 

        [NotMapped]
        public int[] ToppingByID { get; set; }
    }
}
