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
        public bool AddBatchDetailsWithSerial(Batchdetails b, List<string> serialNumbers, decimal price,bool isSerialized)
        {
            int batch_id = DatabaseHelper.Instance.getbatchid(b.batch_name);

            // 🧠 Check whether the product requires serial numbers
            //bool isSerialized = DatabaseHelper.Instance.IsProductSerialized(b.product_id);

            if (isSerialized && (serialNumbers == null || serialNumbers.Count != b.quantity))
                throw new ArgumentException("Number of serial numbers must match the quantity received for serialized product.");

            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        try
                        {
                            string query1 = "INSERT INTO batch_details (batch_id, product_id, quantity_recived, cost_price) " +
                                            "VALUES (@batch_id, @product_id, @quantity, @price);";
                            using (var cmd1 = new MySqlCommand(query1, conn, tran))
                            {
                                cmd1.Parameters.AddWithValue("@batch_id", batch_id);
                                cmd1.Parameters.AddWithValue("@product_id", b.product_id);
                                cmd1.Parameters.AddWithValue("@quantity", b.quantity);
                                cmd1.Parameters.AddWithValue("@price", b.price);
                                cmd1.ExecuteNonQuery();
                            }

                            if (isSerialized)
                            {
                                string query2 = "INSERT INTO productsserial (product_id, sku, status) VALUES (@product_id, @serial_number, 'in_stock');";
                                using (var cmd2 = new MySqlCommand(query2, conn, tran))
                                {
                                    foreach (var serial in serialNumbers)
                                    {
                                        cmd2.Parameters.Clear();
                                        cmd2.Parameters.AddWithValue("@product_id", b.product_id);
                                        cmd2.Parameters.AddWithValue("@serial_number", serial.Trim());
                                        cmd2.ExecuteNonQuery();
                                    }
                                }
                            }

                            string query3 = "UPDATE inventory SET sale_price = @sale_price WHERE product_id = @product_id;";
                            using (var cmd3 = new MySqlCommand(query3, conn, tran))
                            {
                                cmd3.Parameters.AddWithValue("@sale_price", price);
                                cmd3.Parameters.AddWithValue("@product_id", b.product_id);
                                cmd3.ExecuteNonQuery();
                            }

                            tran.Commit();
                            return true;
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding batch details with serials: " + ex.Message, ex);
            }
        }


        public bool deletebatchdetails(int batch_details_id)
        {
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM batch_details WHERE batch_detail_id = @batch_detail_id;";
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
                int product_id = DatabaseHelper.Instance.getproductid(b.product_name);
                int batch_id = DatabaseHelper.Instance.getbatchid(b.batch_name);
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE batch_details SET batch_id = @batch_id, product_id = @product_id, quantity_recived = @quantity, cost_price = @price WHERE batch_detail_id = @batch_details_id;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@batch_details_id", b.batch_details_id);
                        cmd.Parameters.AddWithValue("@batch_id", batch_id);
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
                    string query = "SELECT bd.batch_detail_id, bd.batch_id, bd.product_id, p.name AS product_name, bd.quantity_recived AS quantity, bd.cost_price AS price, b.batch_name FROM batch_details bd JOIN batches b ON bd.batch_id = b.batch_id JOIN products p ON bd.product_id = p.product_id;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
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
