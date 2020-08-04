using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class DeviceAuthorizationInputModel : ConsentInputModel
    {
        public string UserCode { get; set; }
    }
}
