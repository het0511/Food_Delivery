using Food_Delivery.data_access;
using Food_Delivery.models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Food_Delivery.pages.admin
{
    public partial class AddFoodItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminUsername"] == null)
            {
                // If not logged in, redirect to the admin login page
                Response.Redirect("~/pages/admin/AdminLogin.aspx");
            }
            if (!IsPostBack)
            {
                LoadRestaurants();
            }
        }

        private void LoadRestaurants()
        {
            RestaurantDataAccess restaurantDataAccess = new RestaurantDataAccess();
            List<Restaurant> restaurants = restaurantDataAccess.GetRestaurants();
            DropDownListRestaurants.DataSource = restaurants;
            DropDownListRestaurants.DataTextField = "Name"; // Display name of the restaurant
            DropDownListRestaurants.DataValueField = "RestaurantId"; // Value of the selected item
            DropDownListRestaurants.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            FoodItemDataAccess foodItemDataAccess = new FoodItemDataAccess();
            FoodItem foodItem = new FoodItem
            {
                Name = TextBoxName.Text,
                Description = TextBoxDescription.Text,
                Price = decimal.Parse(TextBoxPrice.Text),
                RestaurantId = int.Parse(DropDownListRestaurants.SelectedValue)
            };
            foodItemDataAccess.InsertFoodItem(foodItem);

            // Optionally, redirect or display a success message
            Response.Redirect("~/pages/admin/ViewFoodItems.aspx");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            // Redirect back to the food items view or dashboard
            Response.Redirect("~/pages/admin/ViewFoodItems.aspx");
        }
    }
}
