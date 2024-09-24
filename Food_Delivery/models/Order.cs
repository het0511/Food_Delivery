using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Food_Delivery.models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
    }
}