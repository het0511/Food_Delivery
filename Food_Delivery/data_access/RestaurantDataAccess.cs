using Food_Delivery.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Food_Delivery.data_access
{
    public class RestaurantDataAccess
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        // Retrieve all restaurants
        public List<Restaurant> GetRestaurants()
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM restaurants";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Restaurant restaurant = new Restaurant
                            {
                                RestaurantId = reader.GetInt32("RestaurantId"),
                                Name = reader.GetString("Name"),
                                Location = reader.GetString("Location"),
                                CuisineType = reader.GetString("CuisineType")
                            };
                            restaurants.Add(restaurant);
                        }
                    }
                }
            }
            return restaurants;
        }

        public Restaurant GetRestaurantById(int restaurantId)
        {
            Restaurant restaurant = null;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT RestaurantId, Name, Location, CuisineType FROM restaurants WHERE RestaurantId = @RestaurantId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RestaurantId", restaurantId);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        restaurant = new Restaurant
                        {
                            RestaurantId = reader.GetInt32("RestaurantId"),
                            Name = reader.GetString("Name"),
                            Location = reader.GetString("Location"),
                            CuisineType = reader.GetString("CuisineType")
                        };
                    }
                }
            }
            return restaurant;
        }

        // Insert a new restaurant
        public void InsertRestaurant(Restaurant restaurant)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO restaurants (Name, Location, CuisineType) VALUES (@Name, @Location, @CuisineType)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", restaurant.Name);
                    cmd.Parameters.AddWithValue("@Location", restaurant.Location);
                    cmd.Parameters.AddWithValue("@CuisineType", restaurant.CuisineType);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Update a restaurant
        public void UpdateRestaurant(Restaurant restaurant)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "UPDATE restaurants SET Name = @Name, Location = @Location, CuisineType = @CuisineType WHERE RestaurantId = @RestaurantId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", restaurant.Name);
                    cmd.Parameters.AddWithValue("@Location", restaurant.Location);
                    cmd.Parameters.AddWithValue("@CuisineType", restaurant.CuisineType);
                    cmd.Parameters.AddWithValue("@RestaurantId", restaurant.RestaurantId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete a restaurant
        public void DeleteRestaurant(int restaurantId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM restaurants WHERE RestaurantId = @RestaurantId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RestaurantId", restaurantId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}