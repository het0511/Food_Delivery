using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food_Delivery.pages.admin
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminUsername"] == null)
            {
                // Redirect to login if session does not exist
                Response.Redirect("~/pages/admin/AdminLogin.aspx");
            }
            else
            {
                // Display welcome message with admin's username
                LabelWelcome.Text = "Welcome, " + Session["AdminUsername"];
            }
        }
        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            // Clear the session and redirect to login page
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/pages/admin/AdminLogin.aspx");
        }
        protected void ButtonViewUsers_Click(object sender, EventArgs e)
        {
            // Redirect to View Users page
            Response.Redirect("~/pages/admin/ViewUsers.aspx");
        }

        protected void ButtonViewRestaurants_Click(object sender, EventArgs e)
        {
            // Redirect to View Restaurants page
            Response.Redirect("~/pages/admin/ViewRestaurants.aspx");
        }

        protected void ButtonViewFoodItems_Click(object sender, EventArgs e)
        {
            // Redirect to View Food Items page
            Response.Redirect("~/pages/admin/ViewFoodItems.aspx");
        }
    }
}