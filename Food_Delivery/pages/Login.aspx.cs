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
    public partial class Login : Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string email = txtEmail.Text;
                string passwordHash = GenerateHash(txtPassword.Text);

                UserDataAccess userDataAccess = new UserDataAccess();
                User user = userDataAccess.GetUserByEmailAndPassword(email, passwordHash);

                if (user != null)
                {
                    // Store the user's email in a session variable
                    Session["UserEmail"] = user.Email;

                    // Redirect to the dashboard page
                    Response.Redirect("dashboard.aspx");
                }
                else
                {
                    lblMessage.Text = "Invalid email or password.";
                }
            }
        }

        private string GenerateHash(string password)
        {
            // Use a proper hashing method for production
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}