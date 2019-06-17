﻿using ApplicationDomianEntity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R2H.Models
{
    public class ApplicationUser : IdentityUser
    {
        public  ApplicationUser():base(){}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
    }
}
