using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class InputModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }
    }
}
