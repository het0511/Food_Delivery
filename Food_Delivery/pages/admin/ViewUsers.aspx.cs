using Food_Delivery.models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Food_Delivery.pages.admin
{
    public partial class ViewUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if admin is logged in
            if (Session["AdminUsername"] == null)
            {
                // If not logged in, redirect to the admin login page
                Response.Redirect("~/pages/admin/AdminLogin.aspx");
            }

            if (!IsPostBack)
            {
                BindUsers();
            }
        }

        // Method to bind users to the GridView
        private void BindUsers()
        {
            UserDataAccess userDataAccess = new UserDataAccess();
            List<User> users = userDataAccess.GetUsers();
            GridViewUsers.DataSource = users;
            GridViewUsers.DataBind();
        }

        // Method to handle row commands (e.g., delete)
        protected void GridViewUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteUser")
            {
                // Retrieve the UserId from the CommandArgument
                int userId = Convert.ToInt32(e.CommandArgument);

                // Call the DeleteUser method to delete the user from the database
                UserDataAccess userDataAccess = new UserDataAccess();
                userDataAccess.DeleteUser(userId);

                // Rebind the users to refresh the GridView
                BindUsers();
            }
        }
    }
}
