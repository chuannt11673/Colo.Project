using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class InputModel
    {
        public string Name { get; set; }
        public DateTime? DOB { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }
    }
}
