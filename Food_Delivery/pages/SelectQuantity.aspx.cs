using System;
using System.Web.UI;
using Food_Delivery.models;
using Food_Delivery.data_access;

namespace Food_Delivery
{
    public partial class SelectQuantity : Page
    {
        private int foodItemId
        {
            get
            {
                if (ViewState["FoodItemId"] != null)
                {
                    return (int)ViewState["FoodItemId"];
                }
                return 0; // Default value if not set
            }
            set
            {
                ViewState["FoodItemId"] = value;
            }
        }

        private decimal food_price
        {
            get
            {
                if (ViewState["FoodPrice"] != null)
                {
                    return (decimal)ViewState["FoodPrice"];
                }
                return 0.0m; // Default value if not set
            }
            set
            {
                ViewState["FoodPrice"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.TryParse(Request.QueryString["foodItemId"], out int id))
                {
                    foodItemId = id; // Store foodItemId in ViewState
                    LoadFoodItemDetails(foodItemId);
                }
                else
                {
                    // Handle case where foodItemId is not valid
                    Response.Redirect("dashboard.aspx");
                }
            }
        }

        private void LoadFoodItemDetails(int foodItemId)
        {
            FoodItemDataAccess foodItemDataAccess = new FoodItemDataAccess();
            FoodItem foodItem = foodItemDataAccess.GetFoodItemById(foodItemId);
            if (foodItem != null)
            {
                lblFoodItemName.Text = foodItem.Name;
                food_price = foodItem.Price; // Store price in ViewState
                lblPrice.Text = $"Price per item: {food_price:C}";
                lblDescription.Text = foodItem.Description;
            }
        }

        protected void btnConfirmAddToCart_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0)
            {
                string userEmail = Session["UserEmail"]?.ToString();
                if (string.IsNullOrEmpty(userEmail))
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                UserDataAccess userDataAccess = new UserDataAccess();
                User user = userDataAccess.GetUserByEmail(userEmail);

                if (user != null)
                {
                    decimal totalPrice = quantity * food_price;
                    // Debugging information
                    //System.Diagnostics.Debug.WriteLine($"Price before multiplication: {food_price}");
                    //System.Diagnostics.Debug.WriteLine($"Quantity: {quantity}");
                    //System.Diagnostics.Debug.WriteLine($"Total Price to be inserted: {totalPrice}");
                    //System.Diagnostics.Debug.WriteLine($"Food Item to be inserted: {foodItemId}");

                    CartDetails cartItem = new CartDetails
                    {
                        UserId = user.UserId,
                        FoodItemId = foodItemId,
                        Quantity = quantity,
                        Price = totalPrice,
                        FoodItemName = lblFoodItemName.Text
                    };

                    CartDetailsDataAccess cartDataAccess = new CartDetailsDataAccess();
                    cartDataAccess.InsertCartItem(cartItem);

                    Response.Redirect("Cart.aspx");
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}
