using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Models.Models
{
    class Pizza
    {
        public int ID { get; set; }

        public String Type { get; set; }

        public int CrustID { get; set; }

        public int SizeId { get; set; }

        public bool IsCustom { get; set; }
    }
}
