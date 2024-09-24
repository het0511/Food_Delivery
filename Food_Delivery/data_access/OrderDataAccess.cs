using Food_Delivery.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Food_Delivery.data_access
{
    public class OrderDataAccess
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        // Retrieve all orders
        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM orders";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order
                            {
                                OrderId = reader.GetInt32("OrderId"),
                                CustomerName = reader.GetString("CustomerName"),
                                OrderDate = reader.GetDateTime("OrderDate"),
                                UserId = reader.GetInt32("UserId")
                            };
                            orders.Add(order);
                        }
                    }
                }
            }
            return orders;
        }

        // Insert a new order
        public void InsertOrder(Order order)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO orders (CustomerName, OrderDate, UserId) VALUES (@CustomerName, @OrderDate, @UserId)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@UserId", order.UserId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Update an order
        public void UpdateOrder(Order order)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "UPDATE orders SET CustomerName = @CustomerName, OrderDate = @OrderDate, UserId = @UserId WHERE OrderId = @OrderId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@UserId", order.UserId);
                    cmd.Parameters.AddWithValue("@OrderId", order.OrderId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete an order
        public void DeleteOrder(int orderId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM orders WHERE OrderId = @OrderId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}