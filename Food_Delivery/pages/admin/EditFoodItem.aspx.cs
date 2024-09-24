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
    public partial class EditFoodItem : System.Web.UI.Page
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
                // Check if FoodItemId is provided in query string
                if (Request.QueryString["FoodItemId"] != null)
                {
                    int foodItemId = Convert.ToInt32(Request.QueryString["FoodItemId"]);
                    LoadFoodItem(foodItemId);
                }
                LoadRestaurants(); // Load restaurant list in dropdown
            }
        }
        private void LoadFoodItem(int foodItemId)
        {
            FoodItemDataAccess foodItemDataAccess = new FoodItemDataAccess();
            FoodItem foodItem = foodItemDataAccess.GetFoodItemById(foodItemId);

            if (foodItem != null)
            {
                hfFoodItemId.Value = foodItem.FoodItemId.ToString();
                txtName.Text = foodItem.Name;
                txtDescription.Text = foodItem.Description;
                txtPrice.Text = foodItem.Price.ToString();
                ddlRestaurant.SelectedValue = foodItem.RestaurantId.ToString();
            }
        }
        private void LoadRestaurants()
        {
            RestaurantDataAccess restaurantDataAccess = new RestaurantDataAccess();
            ddlRestaurant.DataSource = restaurantDataAccess.GetRestaurants();
            ddlRestaurant.DataTextField = "Name";
            ddlRestaurant.DataValueField = "RestaurantId";
            ddlRestaurant.DataBind();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int foodItemId = Convert.ToInt32(hfFoodItemId.Value);
            FoodItem foodItem = new FoodItem
            {
                FoodItemId = foodItemId,
                Name = txtName.Text,
                Description = txtDescription.Text,
                Price = decimal.Parse(txtPrice.Text),
                RestaurantId = int.Parse(ddlRestaurant.SelectedValue)
            };

            FoodItemDataAccess foodItemDataAccess = new FoodItemDataAccess();
            foodItemDataAccess.UpdateFoodItem(foodItem);
            lblMessage.Text = "Food item updated successfully!";
            lblMessage.ForeColor = System.Drawing.Color.Green;
        }
    }
}