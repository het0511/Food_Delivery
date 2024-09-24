using Food_Delivery.data_access;
using Food_Delivery.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food_Delivery.pages.admin
{
    public partial class EditRestaurant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminUsername"] == null)
            {
                // Redirect to admin login page if not logged in
                Response.Redirect("~/pages/admin/AdminLogin.aspx");
            }

            if (!IsPostBack)
            {
                // Check if there is a RestaurantId in the query string
                if (Request.QueryString["RestaurantId"] != null)
                {
                    int restaurantId;
                    if (int.TryParse(Request.QueryString["RestaurantId"], out restaurantId))
                    {
                        // Load restaurant data to be edited
                        LoadRestaurantDetails(restaurantId);
                    }
                    else
                    {
                        lblMessage.Text = "Invalid restaurant ID.";
                    }
                }
                else
                {
                    lblMessage.Text = "No restaurant ID provided.";
                }
            }
        }
        private void LoadRestaurantDetails(int restaurantId)
        {
            RestaurantDataAccess restaurantDataAccess = new RestaurantDataAccess();
            Restaurant restaurant = restaurantDataAccess.GetRestaurantById(restaurantId);

            if (restaurant != null)
            {
                hfRestaurantId.Value = restaurant.RestaurantId.ToString();
                txtName.Text = restaurant.Name;
                txtLocation.Text = restaurant.Location;
                txtCuisineType.Text = restaurant.CuisineType;
            }
            else
            {
                lblMessage.Text = "Restaurant not found.";
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hfRestaurantId.Value))
            {
                int restaurantId = Convert.ToInt32(hfRestaurantId.Value);

                Restaurant restaurant = new Restaurant
                {
                    RestaurantId = restaurantId,
                    Name = txtName.Text,
                    Location = txtLocation.Text,
                    CuisineType = txtCuisineType.Text
                };

                RestaurantDataAccess restaurantDataAccess = new RestaurantDataAccess();
                restaurantDataAccess.UpdateRestaurant(restaurant);

                // Redirect to ViewRestaurants page after update
                Response.Redirect("~/pages/admin/ViewRestaurants.aspx");
            }
            else
            {
                lblMessage.Text = "Restaurant ID is missing.";
            }
        }
    }
}