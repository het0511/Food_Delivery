using Food_Delivery.models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

public class UserDataAccess
{
    private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

    public List<User> GetUsers()
    {
        List<User> users = new List<User>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string query = "SELECT * FROM users";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    User user = new User
                    {
                        UserId = reader.GetInt32("UserId"),
                        UserName = reader.GetString("UserName"),
                        Email = reader.GetString("Email"),
                        MobileNumber = reader.GetString("MobileNumber"),
                        PasswordHash = reader.GetString("PasswordHash"),
                        CreatedAt = reader.GetDateTime("CreatedAt")
                    };
                    users.Add(user);
                }
            }
        }

        return users;
    }
    public User GetUserByEmail(string email)
    {
        User user = null;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string query = "SELECT * FROM users WHERE Email = @Email";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);

            connection.Open();

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    user = new User
                    {
                        UserId = reader.GetInt32("UserId"),
                        UserName = reader.GetString("UserName"),
                        Email = reader.GetString("Email"),
                        MobileNumber = reader.GetString("MobileNumber"),
                        PasswordHash = reader.GetString("PasswordHash"),
                        CreatedAt = reader.GetDateTime("CreatedAt")
                    };
                }
            }
        }

        return user;
    }

    public void InsertUser(User user)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string query = "INSERT INTO users (UserName, Email, MobileNumber, PasswordHash, CreatedAt) VALUES (@UserName, @Email, @MobileNumber, @PasswordHash, @CreatedAt)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@MobileNumber", user.MobileNumber);
            command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            command.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void DeleteUser(int userId)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string query = "DELETE FROM users WHERE UserId = @UserId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", userId);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public User GetUserByEmailAndPassword(string email, string passwordHash)
    {
        User user = null;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string query = "SELECT * FROM users WHERE Email = @Email AND PasswordHash = @PasswordHash";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@PasswordHash", passwordHash);

            connection.Open();

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    user = new User
                    {
                        UserId = reader.GetInt32("UserId"),
                        UserName = reader.GetString("UserName"),
                        Email = reader.GetString("Email"),
                        MobileNumber = reader.GetString("MobileNumber"),
                        PasswordHash = reader.GetString("PasswordHash"),
                        CreatedAt = reader.GetDateTime("CreatedAt")
                    };
                }
            }
        }

        return user;
    }

    // New method to check if email exists
    public bool EmailExists(string email)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string query = "SELECT COUNT(*) FROM users WHERE Email = @Email";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);
            connection.Open();
            int count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;
        }
    }

    // New method to check if mobile number exists
    public bool MobileNumberExists(string mobileNumber)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string query = "SELECT COUNT(*) FROM users WHERE MobileNumber = @MobileNumber";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@MobileNumber", mobileNumber);
            connection.Open();
            int count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;
        }
    }
}
