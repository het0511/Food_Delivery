using System;
using System.Collections.Generic;
using Food_Delivery.models;
using Food_Delivery.data_access;
using System.Web.UI.WebControls;

namespace Food_Delivery
{
    public partial class dashboard : System.Web.UI.Page
    {
        private RestaurantDataAccess restaurantDataAccess = new RestaurantDataAccess();
        private UserDataAccess userDataAccess = new UserDataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is logged in
            if (Session["UserEmail"] == null)
            {
                // If not logged in, redirect to the login page
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadRestaurants();
                SetWelcomeMessage();
            }
        }

        private void LoadRestaurants()
        {
            // Use the RestaurantDataAccess class to retrieve the list of restaurants
            List<Restaurant> restaurants = restaurantDataAccess.GetRestaurants();

            // Bind the data to the GridView
            RestaurantGridView.DataSource = restaurants;
            RestaurantGridView.DataBind();
        }

        private void SetWelcomeMessage()
        {
            // Get the user's email from the session
            string userEmail = Session["UserEmail"].ToString();

            // Fetch user details
            User user = userDataAccess.GetUsers().Find(u => u.Email == userEmail);

            // Display a welcome message with the user's name
            if (user != null)
            {
                lblWelcomeMessage.Text = $"Welcome, {user.UserName}!";
            }
        }

        protected void btnViewMenu_Click(object sender, EventArgs e)
        {
            // Get the restaurant ID from the CommandArgument of the LinkButton
            LinkButton btn = (LinkButton)sender;
            int restaurantId = Convert.ToInt32(btn.CommandArgument);

            // Redirect to the RestaurantMenu page with the restaurant ID as a query string
            Response.Redirect($"RestaurantMenu.aspx?restaurantId={restaurantId}");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear the session
            Session.Clear();

            // Optionally, abandon the session
            Session.Abandon();

            // Redirect to the login page
            Response.Redirect("Login.aspx");
        }

        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            // Redirect to the Cart page
            Response.Redirect("Cart.aspx");
        }
    }
}
