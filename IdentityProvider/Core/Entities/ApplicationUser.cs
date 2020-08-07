using Microsoft.AspNetCore.Identity;
using System;

namespace Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
    }
}
