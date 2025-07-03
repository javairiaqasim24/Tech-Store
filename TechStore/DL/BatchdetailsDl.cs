using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIMS;
using MySql.Data.MySqlClient;
using TechStore.BL.Models;
namespace TechStore.DL
{
    public class BatchdetailsDl : IBatchdetailsDl
    {
        public bool addbatchdetails(Batchdetails b)
        {
            int batch_details_id = DatabaseHelper.Instance.getbatchid(b.batch_name);
            int product_id = DatabaseHelper.Instance.getproductid(b.product_name);
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO batch_details (batch_id, product_id,  quantity_recived, cost_price) VALUES (@batch_id, @product_id, @quantity, @price);";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@batch_id", batch_details_id);
                        cmd.Parameters.AddWithValue("@product_id", product_id);
                        cmd.Parameters.AddWithValue("@quantity", b.quantity);
                        cmd.Parameters.AddWithValue("@price", b.price);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding batch details: " + ex.Message, ex);
            }
        }
        public bool deletebatchdetails(int batch_details_id)
        {
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM batch_details WHERE batch_details_id = @batch_details_id;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@batch_details_id", batch_details_id);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting batch details: " + ex.Message, ex);
            }
        }
        public bool updatebatchdetails(Batchdetails b)
        {
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE batch_details SET batch_id = @batch_id, product_id = @product_id, quantity_recived = @quantity, cost_price = @price WHERE batch_details_id = @batch_details_id;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@batch_details_id", b.batch_details_id);
                        cmd.Parameters.AddWithValue("@batch_id", b.batch_id);
                        cmd.Parameters.AddWithValue("@product_id", b.product_id);
                        cmd.Parameters.AddWithValue("@quantity", b.quantity);
                        cmd.Parameters.AddWithValue("@price", b.price);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating batch details: " + ex.Message, ex);
            }
        }
        public List<Batchdetails> getbatchdetails()
        {
            List<Batchdetails> batchDetailsList = new List<Batchdetails>();
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT bd.batch_details_id, bd.batch_id, bd.product_id, p.name AS product_name, bd.quantity_recived AS quantity, bd.cost_price AS price, b.batch_name FROM batch_details bd JOIN batches b ON bd.batch_id = b.batch_id JOIN products p ON bd.product_id = p.product_id;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int batchDetailsId = reader.GetInt32("batch_details_id");
                                int productId = reader.GetInt32("product_id");
                                string productName = reader.GetString("product_name");
                                int quantity = reader.GetInt32("quantity");
                                decimal price = reader.GetDecimal("price");
                                string batchName = reader.GetString("batch_name");
                                int batch_id = reader.GetInt32("batch_id");
                                Batchdetails batchDetails = new Batchdetails(batchDetailsId, batch_id, productId, productName, quantity, price, batchName);
                                batchDetailsList.Add(batchDetails);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving batch details: " + ex.Message);
            }
            return batchDetailsList;
        }
        public List<string> getproductnames(string text)
        {
            try
            {
                return DatabaseHelper.Instance.Getproducts(text);
            }
            catch
            {
                throw new ArgumentException("error getting products");
            }
        }
        public List<string> getbatches(string text)
        {
            try
            {
                return DatabaseHelper.Instance.Getbatches(text);
            }
            catch
            {
                throw new ArgumentException("error getting batches");
            }
        }
        public List<Batchdetails> getbatchdetailsbyname(string text)
        {
            List<Batchdetails> batchDetailsList = new List<Batchdetails>();
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    bd.batch_detail_id, bd.batch_id, bd.product_id, 
                    p.name AS product_name, 
                    bd.quantity_recived AS quantity, 
                    bd.cost_price AS price, 
                    b.batch_name 
                FROM batch_details bd 
                JOIN batches b ON bd.batch_id = b.batch_id 
                JOIN products p ON bd.product_id = p.product_id 
                WHERE b.batch_name LIKE @batch_name;
            ";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@batch_name", "%" + text + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int batchDetailsId = reader.GetInt32("batch_detail_id");
                                int productId = reader.GetInt32("product_id");
                                string productName = reader.GetString("product_name");
                                int quantity = reader.GetInt32("quantity");
                                decimal price = reader.GetDecimal("price");
                                string batchName = reader.GetString("batch_name");
                                int batch_id = reader.GetInt32("batch_id");

                                var batchDetails = new Batchdetails(batchDetailsId, batch_id, productId, productName, quantity, price, batchName);
                                batchDetailsList.Add(batchDetails);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving batch details: " + ex.Message);
            }

            return batchDetailsList;
        }


    }


}
