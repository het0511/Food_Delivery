using System;
using System.Collections.Generic;
using Food_Delivery.models;
using Food_Delivery.data_access;
using System.Web.UI.WebControls;

namespace Food_Delivery
{
    public partial class Cart : System.Web.UI.Page
    {
        private CartDetailsDataAccess cartDataAccess = new CartDetailsDataAccess();
        private UserDataAccess userDataAccess = new UserDataAccess();
        private FoodItemDataAccess foodItemDataAccess = new FoodItemDataAccess();

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
                LoadCartItems();
            }
        }

        private void LoadCartItems()
        {
            // Get the current user's email from the session
            string userEmail = Session["UserEmail"].ToString();

            // Retrieve the user by email
            User user = userDataAccess.GetUsers().Find(u => u.Email == userEmail);

            if (user != null)
            {
                // Retrieve cart items for the current user
                List<CartDetails> cartItems = cartDataAccess.GetCartItemsByUserId(user.UserId);

                if (cartItems.Count > 0)
                {
                    // Bind the data to the GridView
                    CartGridView.DataSource = cartItems;
                    CartGridView.DataBind();
                }
                else
                {
                    // Display a message if the cart is empty
                    lblEmptyCart.Text = "Looks like your cart is empty.";
                    lblEmptyCart.Visible = true;

                    // Disable the Order Now button
                    btnOrderNow.Enabled = false;
                }
            }
        }
        private int GetCurrentUserId()
        {
            string userEmail = Session["UserEmail"] as string; // Get email from session
            if (userEmail != null)
            {
                User user = userDataAccess.GetUserByEmail(userEmail);
                if (user != null)
                {
                    return user.UserId; // Return the user's ID
                }
            }
            throw new Exception("User not found or not logged in.");
        }
        protected void CartGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int foodItemId = Convert.ToInt32(e.CommandArgument);
            int userId = GetCurrentUserId();

            if (e.CommandName == "EditItem")
            {
                // Fetch the cart item by FoodItemId to allow editing (you could redirect to an edit page instead)
                Response.Redirect($"~/pages/EditCartItem.aspx?FoodItemId={foodItemId}");
            }
            else if (e.CommandName == "DeleteItem")
            {
                // Call data access layer to delete the item
                cartDataAccess.DeleteCartItem(userId, foodItemId);
                LoadCartItems(); // Reload the cart after deletion
                CartGridView.DataBind();
            }
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

        protected void btnOrderNow_Click(object sender, EventArgs e)
        {
            // Logic to handle the order process
            // You can implement the functionality as needed here
        }
    }
}
