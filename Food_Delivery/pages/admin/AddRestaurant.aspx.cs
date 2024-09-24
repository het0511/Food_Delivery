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
    public partial class AddRestaurant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminUsername"] == null)
            {
                // Redirect to admin login if not logged in
                Response.Redirect("~/pages/admin/AdminLogin.aspx");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate the input
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtLocation.Text) || string.IsNullOrEmpty(txtCuisineType.Text))
            {
                lblMessage.Text = "Please fill in all fields.";
                lblMessage.CssClass = "msg error";
                return;
            }

            // Create a new Restaurant object
            Restaurant newRestaurant = new Restaurant
            {
                Name = txtName.Text.Trim(),
                Location = txtLocation.Text.Trim(),
                CuisineType = txtCuisineType.Text.Trim()
            };

            // Insert into the database using RestaurantDataAccess
            RestaurantDataAccess restaurantDataAccess = new RestaurantDataAccess();
            restaurantDataAccess.InsertRestaurant(newRestaurant);

            // Display success message
            lblMessage.Text = "Restaurant added successfully!";
            lblMessage.CssClass = "msg";

            // Clear input fields
            txtName.Text = "";
            txtLocation.Text = "";
            txtCuisineType.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Redirect back to the restaurant listing page
            Response.Redirect("~/pages/admin/ViewRestaurants.aspx");
        }
    }
}