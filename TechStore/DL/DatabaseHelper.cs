﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Input;
using System.Xml.Linq;
using TechStore.BL.Models;

namespace KIMS
{
    public sealed class DatabaseHelper
    {
        // Singleton instance
        private static readonly Lazy<DatabaseHelper> _instance = new Lazy<DatabaseHelper>(() => new DatabaseHelper());

        // Private constructor
        private DatabaseHelper() { }

        // Public accessor
        public static DatabaseHelper Instance => _instance.Value;

        // Methods
        public MySqlConnection GetConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            return new MySqlConnection(connStr);
        }

        public MySqlDataReader ExecuteReader(string query, MySqlParameter[] parameters = null)
        {
            var conn = GetConnection();
            conn.Open();
            var cmd = new MySqlCommand(query, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public int GetLastInsertId()
        {
            string query = "SELECT LAST_INSERT_ID();";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public int ExecuteNonQueryTransaction(string query, MySqlParameter[] parameters, MySqlTransaction transaction)
        {
            using (var cmd = new MySqlCommand(query, transaction.Connection, transaction))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                LogCommand(cmd);
                return cmd.ExecuteNonQuery();
            }
        }

        public int ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    // Log the command being executed
                    LogCommand(cmd);

                    try
                    {
                        int result = cmd.ExecuteNonQuery();
                        Console.WriteLine($"Rows affected: {result}");
                        return result;
                    }
                    catch (MySqlException ex)
                    {
                        LogMySqlError(ex, cmd);
                        throw; // Re-throw to let caller handle
                    }
                }
            }
        }

        private void LogCommand(MySqlCommand cmd)
        {
            Console.WriteLine("Executing command:");
            Console.WriteLine($"SQL: {cmd.CommandText}");
            foreach (MySqlParameter p in cmd.Parameters)
            {
                Console.WriteLine($"{p.ParameterName} = {p.Value} (Type: {p.MySqlDbType})");
            }
        }

        private void LogMySqlError(MySqlException ex, MySqlCommand cmd)
        {
            Console.WriteLine("MySQL Error occurred:");
            Console.WriteLine($"Error Code: {ex.Number}");
            Console.WriteLine($"Message: {ex.Message}");
            Console.WriteLine("Command that failed:");
            Console.WriteLine(cmd.CommandText);
            foreach (MySqlParameter p in cmd.Parameters)
            {
                Console.WriteLine($"{p.ParameterName} = {p.Value}");
            }
        }

        public int GetCategoryId(string name)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT category_id FROM categories WHERE name = @name;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving category ID: " + ex.Message);
            }
        }

        public List<string> GetCategories(string keyword)
        {
            List<string> categories = new List<string>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT name FROM categories WHERE name LIKE @keyword;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categories.Add(reader.GetString("name"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving categories: " + ex.Message);
            }
            return categories;
        }

        public List<string> GetSuppliers(string keyword)
        {
            List<string> suppliers = new List<string>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT name FROM suppliers WHERE name LIKE @keyword;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                suppliers.Add(reader.GetString("name"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving suppliers: " + ex.Message);
            }
            return suppliers;
        }
        internal int getsuppierid(string text)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT supplier_id FROM suppliers WHERE name = @name;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", text);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving category ID: " + ex.Message);
            }
        }
        internal int getcustid(string fullName)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT customer_id 
                FROM customers 
                WHERE CONCAT(first_name, ' ', last_name) = @fullName;";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fullName", fullName.Trim());
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving customer ID: " + ex.Message);
            }
        }

        public List<string> Getproducts(string keyword)
        {
            List<string> products = new List<string>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT name FROM products WHERE name LIKE @keyword;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(reader.GetString("name"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving suppliers: " + ex.Message);
            }
            return products;
        }
        internal int getproductid(string text)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT product_id FROM products WHERE name = @name;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", text);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving category ID: " + ex.Message);
            }
        }
        public List<string> Getbatches(string keyword)
        {
            List<string> suppliers = new List<string>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT batch_name FROM batches WHERE batch_name LIKE @keyword;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                suppliers.Add(reader.GetString("batch_name"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving batches: " + ex.Message);
            }
            return suppliers;
        }
        public List<string> getAllCustomers()
        {
            var names = new List<string>();
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT CONCAT(first_name, ' ', last_name) FROM customers", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        names.Add(reader.GetString(0));
                }
            }
            return names;
        }

        internal int getbatchid(string text)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT batch_id FROM batches WHERE batch_name = @name;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", text);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving batch ID: " + ex.Message);
            }
        }
        //internal bool IsProductSerialized(int productId)
        //{
        //    using (var conn = GetConnection())
        //    {
        //        conn.Open();
        //        string query = "SELECT is_serialized FROM products WHERE product_id = @id;";
        //        using (var cmd = new MySqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@id", productId);
        //            var result = cmd.ExecuteScalar();
        //            return Convert.ToBoolean(result);
        //        }
        //    }
        //}

        internal List<Products> GetProductsByName(string name)
        {
            var products = new List<Products>();

            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = "SELECT product_id, name, description FROM products WHERE name = @name";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Products
                            (
                                 Convert.ToInt32(reader["product_id"]),
                                 reader["name"].ToString(),
                                 reader["description"].ToString()));
                            
                        }
                    }
                }
            }

            return products;
        }
        public List<Products> GetProductsByNames(string name)
        {
            var products = new List<Products>();

            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = "SELECT product_id, name, description FROM products WHERE name like @name";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", $"%{name}%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Products
                            (
                                 Convert.ToInt32(reader["product_id"]),
                                 reader["name"].ToString(),
                                 reader["description"].ToString()));

                        }
                    }
                }
            }

            return products;
        }
        internal List<servicedevices> search_device(int receipt_id)
        {
            List<servicedevices> search_devices = new List<servicedevices>();

            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM service_devices WHERE receipt_id = @receipt_id;";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@receipt_id", receipt_id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var device = new servicedevices
                                {
                                    DeviceId = Convert.ToInt32(reader["device_id"]),
                                    ReceiptId = Convert.ToInt32(reader["receipt_id"]),
                                    DeviceName = reader["device_name"].ToString(),
                                    Issue = reader["issue_description"].ToString(),
                                    ReportDate = Convert.ToDateTime(reader["received_date"]),
                                    ExpectedDate = Convert.ToDateTime(reader["expected_return_date"]),
                                    Status = reader["status"].ToString(),
                                    ServiceCharge = reader["service_charge"] != DBNull.Value
                                                    ? Convert.ToDecimal(reader["service_charge"])
                                                    : 0
                                };

                                search_devices.Add(device);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching devices: " + ex.Message, ex);
            }

            return search_devices;
        }

        public DataTable ExecuteDataTable(string query, MySqlParameter[] parameters = null)
        {
            var dt = new DataTable();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }





    }

}
