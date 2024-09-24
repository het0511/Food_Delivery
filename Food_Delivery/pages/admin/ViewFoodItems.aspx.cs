using Food_Delivery.data_access;
using Food_Delivery.models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food_Delivery.pages.admin
{
    public partial class ViewFoodItems : System.Web.UI.Page
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
                LoadFoodItems();
            }
        }

        private void LoadFoodItems()
        {
            FoodItemDataAccess foodItemDataAccess = new FoodItemDataAccess();
            var foodItems = foodItemDataAccess.GetFoodItems(); // Assuming this returns a list with RestaurantName included
            GridViewFoodItems.DataSource = foodItems;
            GridViewFoodItems.DataBind();
        }

        protected void GridViewFoodItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            FoodItemDataAccess foodItemDataAccess = new FoodItemDataAccess();
            if (e.CommandName == "DeleteFoodItem")
            {
                int foodItemId = Convert.ToInt32(e.CommandArgument);
                foodItemDataAccess.DeleteFoodItem(foodItemId);
                LoadFoodItems(); // Reload the food items after deletion
            }
            else if (e.CommandName == "EditFoodItem")
            {
                int foodItemId = Convert.ToInt32(e.CommandArgument);
                // Redirect to edit food item page with the food item ID as query string
                Response.Redirect("~/pages/admin/EditFoodItem.aspx?FoodItemId=" + foodItemId);
            }
        }

        protected void ButtonAddFoodItem_Click(object sender, EventArgs e)
        {
            // Redirect to add food item page
            Response.Redirect("~/pages/admin/AddFoodItem.aspx");
        }

        protected void ButtonBackToDashboard_Click(object sender, EventArgs e)
        {
            // Redirect to dashboard
            Response.Redirect("~/pages/admin/AdminDashboard.aspx");
        }
    }
}
