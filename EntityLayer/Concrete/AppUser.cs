﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        [Required(ErrorMessage = "Can't be blank.")]
        public string? fullName { get; set; }
        public string? UserImage { get; set; }
    }
}
