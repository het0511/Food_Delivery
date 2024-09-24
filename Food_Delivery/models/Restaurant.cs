using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Food_Delivery.models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string CuisineType { get; set; }
    }
}