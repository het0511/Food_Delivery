using Food_Delivery.data_access;
using Food_Delivery.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food_Delivery.pages
{
    public partial class EditCartItem : System.Web.UI.Page
    {
        private CartDetailsDataAccess cartDataAccess = new CartDetailsDataAccess();
        private UserDataAccess userDataAccess = new UserDataAccess();
        private FoodItemDataAccess foodItemDataAccess = new FoodItemDataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserEmail"] == null)
                {
                    Response.Redirect("~/pages/Login.aspx");
                }

                int foodItemId = Convert.ToInt32(Request.QueryString["FoodItemId"]);
                int userId = GetCurrentUserId(); // Fetch current logged-in user's ID

                LoadCartItem(userId, foodItemId);
            }
        }
        private void LoadCartItem(int userId, int foodItemId)
        {
            CartDetails cartItem = cartDataAccess.GetCartItemsByUserId(userId).Find(item => item.FoodItemId == foodItemId);
            FoodItem foodItem = foodItemDataAccess.GetFoodItemById(foodItemId);
            if (cartItem != null)
            {
                lblFoodItemName.Text = cartItem.FoodItemName;
                txtQuantity.Text = cartItem.Quantity.ToString();
                lblPrice.Text = foodItem.Price.ToString("C");
                lblTotalPrice.Text = (foodItem.Price * cartItem.Quantity).ToString("C");
            }
            else
            {
                lblMessage.Text = "Cart item not found!";
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int foodItemId = Convert.ToInt32(Request.QueryString["FoodItemId"]);
            int userId = GetCurrentUserId();

            if (int.TryParse(txtQuantity.Text, out int newQuantity) && newQuantity > 0)
            {
                // Fetch the item from the cart again
                CartDetails cartItem = cartDataAccess.GetCartItemsByUserId(userId).Find(item => item.FoodItemId == foodItemId);

                if (cartItem != null)
                {
                    FoodItem foodItem = foodItemDataAccess.GetFoodItemById(foodItemId);
                    // Update the quantity
                    cartItem.Quantity = newQuantity;
                    cartItem.Price = (newQuantity * foodItem.Price);

                    // Update the cart item in the database
                    cartDataAccess.UpdateCartItem(cartItem);

                    // Redirect to cart page after successful update
                    Response.Redirect("~/pages/Cart.aspx");
                }
            }
            else
            {
                lblMessage.Text = "Please enter a valid quantity.";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Redirect to the cart page without making any changes
            Response.Redirect("~/pages/Cart.aspx");
        }

        private int GetCurrentUserId()
        {
            string userEmail = Session["UserEmail"].ToString();
            var currentUser = userDataAccess.GetUserByEmail(userEmail);
            return currentUser != null ? currentUser.UserId : -1;
        }
    }
}