using System;
using System.Collections.Generic;
using System.Web.UI;
using Food_Delivery.models;
using Food_Delivery.data_access;
using System.Web.UI.WebControls;

namespace Food_Delivery
{
    public partial class RestaurantMenu : Page
    {
        protected string RestaurantName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int restaurantId;
                if (int.TryParse(Request.QueryString["restaurantId"], out restaurantId))
                {
                    LoadRestaurantMenu(restaurantId);
                }
                else
                {
                    // Handle case where restaurantId is not valid
                    Response.Redirect("dashboard.aspx");
                }
            }
        }

        private void LoadRestaurantMenu(int restaurantId)
        {
            RestaurantDataAccess restaurantDataAccess = new RestaurantDataAccess();
            FoodItemDataAccess foodItemDataAccess = new FoodItemDataAccess();

            // Get the restaurant name
            Restaurant restaurant = restaurantDataAccess.GetRestaurantById(restaurantId);
            if (restaurant != null)
            {
                RestaurantName = restaurant.Name;
                lblRestaurantName.Text = RestaurantName;  // Set the restaurant name to the Label control
            }

            // Get the food items for the restaurant
            List<FoodItem> foodItems = foodItemDataAccess.GetFoodItemsByRestaurantId(restaurantId);
            FoodItemGridView.DataSource = foodItems;
            FoodItemGridView.DataBind();
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            // Get the FoodItemId from the CommandArgument of the LinkButton
            LinkButton btn = (LinkButton)sender;
            int foodItemId = Convert.ToInt32(btn.CommandArgument);

            // Redirect to the SelectQuantity page with the foodItemId as a query string
            Response.Redirect($"SelectQuantity.aspx?foodItemId={foodItemId}");
        }
    }
}
