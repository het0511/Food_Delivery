using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Web;
using System.Web.UI;

namespace Food_Delivery.pages.admin
{
    public partial class AdminLogin : Page
    {
        // Connection string to MySQL database
        private string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is already logged in and redirect to the dashboard
            if (Session["AdminUsername"] != null)
            {
                Response.Redirect("~/pages/admin/AdminDashboard.aspx");
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string username = TextBoxUsername.Text;
            string password = TextBoxPassword.Text;

            if (AuthenticateAdmin(username, password))
            {
                // Store username in session variable
                Session["AdminUsername"] = username;

                // Redirect to Admin Dashboard
                Response.Redirect("~/pages/admin/AdminDashboard.aspx");
            }
            else
            {
                // Show error message
                LabelMessage.Text = "Invalid username or password!";
            }
        }

        private bool AuthenticateAdmin(string username, string password)
        {
            // Parameterized query to prevent SQL Injection
            string query = "SELECT COUNT(1) FROM adminusers WHERE Username = @Username AND Password = @Password";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Add parameters to the query
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        conn.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // If count is 1, the admin exists
                        return count == 1;
                    }
                    catch (Exception ex)
                    {
                        // Display the error message
                        LabelMessage.Text = "Error: " + ex.Message;
                        return false;
                    }
                }
            }
        }
    }
}
