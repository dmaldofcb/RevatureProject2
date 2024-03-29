﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Layers.Models.Models
{
    public class Customer : IdentityUser
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
