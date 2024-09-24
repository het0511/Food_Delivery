using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Food_Delivery.models
{
    public class FoodItem
    {
        public int FoodItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
    }
}