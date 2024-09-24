using Food_Delivery.data_access;
using Food_Delivery.models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food_Delivery.pages.admin
{
    public partial class ViewRestaurants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminUsername"] == null)
            {
                // Redirect to admin login if not logged in
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
            List<Restaurant> restaurants = restaurantDataAccess.GetRestaurants(); // Ensure this method returns full restaurant data
            GridViewRestaurants.DataSource = restaurants;
            GridViewRestaurants.DataBind();
        }

        protected void GridViewRestaurants_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            RestaurantDataAccess restaurantDataAccess = new RestaurantDataAccess();

            if (e.CommandName == "DeleteRestaurant")
            {
                int restaurantId = Convert.ToInt32(e.CommandArgument);
                restaurantDataAccess.DeleteRestaurant(restaurantId);
                LoadRestaurants(); // Reload the grid after deletion
            }
            else if (e.CommandName == "EditRestaurant")
            {
                int restaurantId = Convert.ToInt32(e.CommandArgument);
                // Redirect to the edit page with the restaurant ID in query string
                Response.Redirect("~/pages/admin/EditRestaurant.aspx?RestaurantId=" + restaurantId);
            }
        }

        protected void ButtonAddRestaurant_Click(object sender, EventArgs e)
        {
            // Redirect to the add restaurant page
            Response.Redirect("~/pages/admin/AddRestaurant.aspx");
        }

        protected void ButtonBackToDashboard_Click(object sender, EventArgs e)
        {
            // Redirect to the admin dashboard
            Response.Redirect("~/pages/admin/AdminDashboard.aspx");
        }
    }
}
