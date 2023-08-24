﻿using Microsoft.AspNetCore.Identity;

namespace SchoolProject.Data.Models.Identity
{
    public class User : IdentityUser<int>
    {
        public string Address { get; set; }
        public string Country { get; set; }


    }
}
