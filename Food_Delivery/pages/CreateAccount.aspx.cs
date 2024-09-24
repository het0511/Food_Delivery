using System;
using System.Web.UI;
using Food_Delivery.models;
using Food_Delivery.data_access;

namespace Food_Delivery
{
    public partial class CreateAccount : Page
    {
        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                UserDataAccess userDataAccess = new UserDataAccess();

                // Check if email or mobile number already exists
                if (userDataAccess.EmailExists(txtEmail.Text))
                {
                    lblMessage.Text = "The email address is already in use.";
                    return;
                }

                if (userDataAccess.MobileNumberExists(txtMobileNumber.Text))
                {
                    lblMessage.Text = "The mobile number is already in use.";
                    return;
                }

                // Create new user
                User user = new User
                {
                    UserName = txtUserName.Text,
                    Email = txtEmail.Text,
                    MobileNumber = txtMobileNumber.Text,
                    PasswordHash = GenerateHash(txtPassword.Text),
                    CreatedAt = DateTime.Now
                };

                userDataAccess.InsertUser(user);
                lblMessage.Text = "Account created successfully!";
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
