using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class LogoutViewModel : LogoutInputModel
    {
        public bool ShowLogoutPrompt { get; set; } = true;
    }
}
