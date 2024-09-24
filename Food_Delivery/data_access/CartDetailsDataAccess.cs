using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using Food_Delivery.models;

namespace Food_Delivery.data_access
{
    public class CartDetailsDataAccess
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        // Retrieve all cart items for a specific user
        public List<CartDetails> GetCartItemsByUserId(int userId)
        {
            List<CartDetails> cartItems = new List<CartDetails>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                    SELECT CartId, UserId, FoodItemId, FoodItemName, Quantity, Price
                    FROM cart
                    WHERE UserId = @UserId";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CartDetails cartItem = new CartDetails
                            {
                                CartId = reader.GetInt32("CartId"),
                                UserId = reader.GetInt32("UserId"),
                                FoodItemId = reader.GetInt32("FoodItemId"),
                                FoodItemName = reader.GetString("FoodItemName"),
                                Quantity = reader.GetInt32("Quantity"),
                                Price = reader.GetDecimal("Price")
                            };
                            cartItems.Add(cartItem);
                        }
                    }
                }
            }
            return cartItems;
        }

        // Insert a new cart item
        public void InsertCartItem(CartDetails cart)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO cart (UserId, FoodItemId, Quantity, FoodItemName, Price) 
            VALUES (@UserId, @FoodItemId, @Quantity, @FoodItemName, @Price)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", cart.UserId);
                    cmd.Parameters.AddWithValue("@FoodItemId", cart.FoodItemId);
                    cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
                    cmd.Parameters.AddWithValue("@FoodItemName", cart.FoodItemName);
                    cmd.Parameters.AddWithValue("@Price", cart.Price);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Update a cart item
        public void UpdateCartItem(CartDetails cart)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
            UPDATE cart 
            SET Quantity = @Quantity, FoodItemName = @FoodItemName, Price = @Price
            WHERE UserId = @UserId AND FoodItemId = @FoodItemId";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
                    cmd.Parameters.AddWithValue("@FoodItemName", cart.FoodItemName);
                    cmd.Parameters.AddWithValue("@Price", cart.Price);
                    cmd.Parameters.AddWithValue("@UserId", cart.UserId);
                    cmd.Parameters.AddWithValue("@FoodItemId", cart.FoodItemId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete a cart item
        public void DeleteCartItem(int userId, int foodItemId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM cart WHERE UserId = @UserId AND FoodItemId = @FoodItemId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@FoodItemId", foodItemId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
