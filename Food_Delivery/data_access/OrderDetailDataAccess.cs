using Food_Delivery.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Food_Delivery.data_access
{
    public class OrderDetailDataAccess
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        // Retrieve all order details
        public List<OrderDetail> GetOrderDetails()
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM orderdetails";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderDetail orderDetail = new OrderDetail
                            {
                                OrderDetailId = reader.GetInt32("OrderDetailId"),
                                OrderId = reader.GetInt32("OrderId"),
                                FoodItemId = reader.GetInt32("FoodItemId"),
                                Quantity = reader.GetInt32("Quantity"),
                                Price = reader.GetDecimal("Price")
                            };
                            orderDetails.Add(orderDetail);
                        }
                    }
                }
            }
            return orderDetails;
        }

        // Insert a new order detail
        public void InsertOrderDetail(OrderDetail orderDetail)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO orderdetails (OrderId, FoodItemId, Quantity, Price) VALUES (@OrderId, @FoodItemId, @Quantity, @Price)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderDetail.OrderId);
                    cmd.Parameters.AddWithValue("@FoodItemId", orderDetail.FoodItemId);
                    cmd.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);
                    cmd.Parameters.AddWithValue("@Price", orderDetail.Price);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Update an order detail
        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "UPDATE orderdetails SET OrderId = @OrderId, FoodItemId = @FoodItemId, Quantity = @Quantity, Price = @Price WHERE OrderDetailId = @OrderDetailId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderDetail.OrderId);
                    cmd.Parameters.AddWithValue("@FoodItemId", orderDetail.FoodItemId);
                    cmd.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);
                    cmd.Parameters.AddWithValue("@Price", orderDetail.Price);
                    cmd.Parameters.AddWithValue("@OrderDetailId", orderDetail.OrderDetailId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete an order detail
        public void DeleteOrderDetail(int orderDetailId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM orderdetails WHERE OrderDetailId = @OrderDetailId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderDetailId", orderDetailId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}