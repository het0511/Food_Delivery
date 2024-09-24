using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Food_Delivery.models
{
    public class CartDetails
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int FoodItemId { get; set; }
        public int Quantity { get; set; }
        public string FoodItemName { get; set; }
        public decimal Price { get; set; }
    }
}