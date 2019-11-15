using System;
using System.Collections.Generic;
using System.Text;

namespace Layers.Models.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public int CrustID { get; set; }

        public int SizeId { get; set; }

        public bool IsCustom { get; set; }
    }
}
