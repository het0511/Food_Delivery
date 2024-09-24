using Food_Delivery.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Food_Delivery.data_access
{
    public class FoodItemDataAccess
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        // Retrieve all food items
        public List<FoodItem> GetFoodItems()
        {
            List<FoodItem> foodItems = new List<FoodItem>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM fooditems";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FoodItem foodItem = new FoodItem
                            {
                                FoodItemId = reader.GetInt32("FoodItemId"),
                                Name = reader.GetString("Name"),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString("Description"),
                                Price = reader.GetDecimal("Price"),
                                RestaurantId = reader.GetInt32("RestaurantId")
                            };
                            foodItems.Add(foodItem);
                        }
                    }
                }
            }
            return foodItems;
        }

        // Retrieve food items by restaurant ID
        public List<FoodItem> GetFoodItemsByRestaurantId(int restaurantId)
        {
            List<FoodItem> foodItems = new List<FoodItem>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT FoodItemId, Name, Description, Price FROM fooditems WHERE RestaurantId = @RestaurantId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RestaurantId", restaurantId);

                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FoodItem foodItem = new FoodItem
                            {
                                FoodItemId = reader.GetInt32("FoodItemId"),
                                Name = reader.GetString("Name"),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString("Description"),
                                Price = reader.GetDecimal("Price")
                            };
                            foodItems.Add(foodItem);
                        }
                    }
                }
            }
            return foodItems;
        }

        // Insert a new food item
        public void InsertFoodItem(FoodItem foodItem)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO fooditems (Name, Description, Price, RestaurantId) VALUES (@Name, @Description, @Price, @RestaurantId)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", foodItem.Name);
                    cmd.Parameters.AddWithValue("@Description", foodItem.Description);
                    cmd.Parameters.AddWithValue("@Price", foodItem.Price);
                    cmd.Parameters.AddWithValue("@RestaurantId", foodItem.RestaurantId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Update a food item
        public void UpdateFoodItem(FoodItem foodItem)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "UPDATE fooditems SET Name = @Name, Description = @Description, Price = @Price, RestaurantId = @RestaurantId WHERE FoodItemId = @FoodItemId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", foodItem.Name);
                    cmd.Parameters.AddWithValue("@Description", foodItem.Description);
                    cmd.Parameters.AddWithValue("@Price", foodItem.Price);
                    cmd.Parameters.AddWithValue("@RestaurantId", foodItem.RestaurantId);
                    cmd.Parameters.AddWithValue("@FoodItemId", foodItem.FoodItemId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public FoodItem GetFoodItemById(int foodItemId)
        {
            FoodItem foodItem = null;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
            SELECT fi.FoodItemId, fi.Name, fi.Description, fi.Price, fi.RestaurantId, r.Name as RestaurantName
            FROM fooditems fi
            JOIN restaurants r ON fi.RestaurantId = r.RestaurantId
            WHERE fi.FoodItemId = @FoodItemId";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FoodItemId", foodItemId);

                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            foodItem = new FoodItem
                            {
                                FoodItemId = reader.GetInt32("FoodItemId"),
                                Name = reader.GetString("Name"),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString("Description"),
                                Price = reader.GetDecimal("Price"),
                                RestaurantId = reader.GetInt32("RestaurantId")
                            };
                        }
                    }
                }
            }
            return foodItem;
        }

        // Delete a food item
        public void DeleteFoodItem(int foodItemId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM fooditems WHERE FoodItemId = @FoodItemId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FoodItemId", foodItemId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}