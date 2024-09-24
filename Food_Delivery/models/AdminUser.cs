using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Food_Delivery.models
{
    public class AdminUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}