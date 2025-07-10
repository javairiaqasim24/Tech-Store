﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KIMS;
using MySql.Data.MySqlClient;
using TechStore.BL.Models;
using TechStore.BL.Models.Person;
using TechStore.Interfaces.DLInterfaces;

namespace TechStore.DL
{
    public class Customersaledl:  Icustomersaledl
    {
        public Customersale GetProductBySku(string sku)
        {
            try
            {
                using (var reader = DatabaseHelper.Instance.ExecuteReader(
                    @"SELECT 
                    p.product_id, 
                    p.name, 
                    ps.sku, 
                    p.description, 
                    c.name AS category_name, 
                    p.category_id,
                    i.quantity_in_stock AS total_quantity, 
                    i.sale_price
                FROM products p
                JOIN productsserial ps ON p.product_id = ps.product_id
                JOIN inventory i ON p.product_id = i.product_id
                JOIN categories c ON p.category_id = c.category_id
                WHERE ps.sku = @sku
                GROUP BY 
                p.product_id, p.name, ps.sku, p.description, 
                c.name, p.category_id, i.quantity_in_stock, i.sale_price;
                ",
                    new MySqlParameter[] { new MySqlParameter("@sku", sku) }))
                {
                    if (reader.Read())
                    {
                        int productIdOrdinal = reader.GetOrdinal("product_id");
                        int nameOrdinal = reader.GetOrdinal("name");
                        int skuOrdinal = reader.GetOrdinal("sku");
                        int descriptionOrdinal = reader.GetOrdinal("description");
                        int categoryOrdinal = reader.GetOrdinal("category_name");
                        int totalQuantityOrdinal = reader.GetOrdinal("total_quantity");
                        int salePriceOrdinal = reader.GetOrdinal("sale_price");

                        return new Customersale(
                            reader.GetInt32(productIdOrdinal),
                            reader.GetString(nameOrdinal),
                            reader.GetString(skuOrdinal),
                            reader.GetString(descriptionOrdinal),
                            reader.GetString(categoryOrdinal),
                            reader.IsDBNull(totalQuantityOrdinal) ? (int?)null : reader.GetInt32(totalQuantityOrdinal),
                            reader.IsDBNull(salePriceOrdinal) ? (double?)null : reader.GetDouble(salePriceOrdinal)
                        );
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("DB Error: " + ex.Message, ex);
            }
        }

        public static int? GetQuantityInStock(string productName)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                string query = @"
            SELECT i.quantity_in_stock
            FROM inventory i
            JOIN products p ON i.product_id = p.product_id
            WHERE p.name = @productName
            LIMIT 1;
        ";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@productName", productName);

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    conn.Close();

                    return result != null && result != DBNull.Value
                        ? Convert.ToInt32(result)
                        : (int?)null; // Return null if not found
                }
            }
        }


        public List<Customersale> SearchProductsByName(string name)
        {
            try
            {
                var products = new List<Customersale>();
                using (var reader = DatabaseHelper.Instance.ExecuteReader(
                    @"SELECT p.product_id, p.name, p.description, 
                     c.name as category_name, p.category_id,
                     i.quantity_in_stock as total_quantity, 
                     i.sale_price
              FROM products p
              JOIN inventory i ON p.product_id = i.product_id
              JOIN categories c ON p.category_id = c.category_id
              LEFT JOIN productsserial ps ON p.product_id = ps.product_id
              WHERE p.name LIKE @name AND ps.sku IS NULL
              GROUP BY p.product_id, p.name, p.description, 
                       c.name, p.category_id, i.quantity_in_stock, i.sale_price",
                    new MySqlParameter[] { new MySqlParameter("@name", $"%{name}%") }))
                {
                    int productIdOrdinal = reader.GetOrdinal("product_id");
                    int nameOrdinal = reader.GetOrdinal("name");
                    int descriptionOrdinal = reader.GetOrdinal("description");
                    int categoryOrdinal = reader.GetOrdinal("category_name");
                    int totalQuantityOrdinal = reader.GetOrdinal("total_quantity");
                    int salePriceOrdinal = reader.GetOrdinal("sale_price");

                    while (reader.Read())
                    {
                        products.Add(new Customersale(
                            reader.GetInt32(productIdOrdinal),                    // id
                            reader.GetString(nameOrdinal),                        // name
                            reader.GetInt32(productIdOrdinal).ToString(),         // sku (from id)
                            reader.GetString(descriptionOrdinal),                 // description
                            reader.GetString(categoryOrdinal),                    // category
                            reader.IsDBNull(totalQuantityOrdinal) ? (int?)null : reader.GetInt32(totalQuantityOrdinal),
                            reader.IsDBNull(salePriceOrdinal) ? (double?)null : reader.GetDouble(salePriceOrdinal)
                        ));
                    }
                }
                return products;
            }
            catch (Exception ex)
            {
                throw new Exception("DB Error: " + ex.Message, ex);
            }
        }


        public int GetCustomerIdByNameAndType(string name, string type)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = @"SELECT customer_id FROM customers
                         WHERE CONCAT(first_name, ' ', last_name) = @name AND type = @type";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@type", type);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return Convert.ToInt32(reader["customer_id"]);
                    }
                }
            }
            return -1; // Not found
        }

        public static DataTable GetCustomersByType(string customerType)
        {
            string query = "SELECT CONCAT(first_name, ' ', last_name) AS name, address FROM customers WHERE type = @type";
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@type", customerType);
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public int InsertNewWalkInCustomer(string name)
        {
            string[] parts = name.Split(' ');
            string firstName = parts[0];
            string lastName = parts.Length > 1 ? parts[1] : "";

            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();

                // 🔍 Step 1: Try to find the customer
                string checkQuery = @"SELECT customer_id FROM customers 
                              WHERE type = 'Walk-in' AND first_name = @first AND last_name = @last";

                using (var checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@first", firstName);
                    checkCmd.Parameters.AddWithValue("@last", lastName);

                    object result = checkCmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);  // ✅ Customer already exists
                    }
                }

                // 🧾 Step 2: Insert if not found
                string insertQuery = @"INSERT INTO customers (type, first_name, last_name)
                               VALUES ('Walk-in', @first, @last);";

                using (var insertCmd = new MySqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@first", firstName);
                    insertCmd.Parameters.AddWithValue("@last", lastName);
                    insertCmd.ExecuteNonQuery();
                }

                // 🔁 Step 3: Return new inserted ID
                string idQuery = "SELECT LAST_INSERT_ID();";
                using (var idCmd = new MySqlCommand(idQuery, conn))
                {
                    return Convert.ToInt32(idCmd.ExecuteScalar());
                }
            }
        }

        public static bool IsProductSold(string sku)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                string query = @"
            SELECT status 
            FROM productsserial 
            WHERE sku = @sku
            LIMIT 1;
        ";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@sku", sku);
                    conn.Open();

                    object result = cmd.ExecuteScalar();
                    conn.Close();

                    if (result == null)
                    {
                        MessageBox.Show("Serial number not found.");
                        return true; // Treat as blocked
                    }

                    string status = result.ToString();

                    if (status == "sold")
                    {
                        //MessageBox.Show("Product is already sold.");
                        return true; // Block operation
                    }

                    return false; // Safe to proceed
                }
            }
        }


        public int SaveCustomerBill(int customerId, DateTime saleDate, decimal total, decimal paid, DataGridView cart)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();

                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert into customerbills
                        string billQuery = @"INSERT INTO customerbills (CustomerID, SaleDate, total_price, paid_amount)
                                     VALUES (@cust, @date, @total, @paid);
                                     SELECT LAST_INSERT_ID();";

                        int billId;
                        using (var cmd = new MySqlCommand(billQuery, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@cust", customerId);
                            cmd.Parameters.AddWithValue("@date", saleDate);
                            cmd.Parameters.AddWithValue("@total", total);
                            cmd.Parameters.AddWithValue("@paid", paid);
                            billId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 1.1 Insert into customerpricerecord (new addition)
                        string priceRecordQuery = @"INSERT INTO customerpricerecord 
                            (customer_id, BillID, date, payment, remarks)
                            VALUES (@cust, @bill, @date, @payment, @remarks);";

                        using (var priceCmd = new MySqlCommand(priceRecordQuery, conn, tran))
                        {
                            priceCmd.Parameters.AddWithValue("@cust", customerId);
                            priceCmd.Parameters.AddWithValue("@bill", billId);
                            priceCmd.Parameters.AddWithValue("@date", saleDate);
                            priceCmd.Parameters.AddWithValue("@payment", paid);
                            priceCmd.Parameters.AddWithValue("@remarks", DBNull.Value); // Or you can insert custom remarks here
                            priceCmd.ExecuteNonQuery();
                        }


                        // 2. Process cart rows
                        foreach (DataGridViewRow row in cart.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string productId = null;
                            string sku = row.Cells["Sku"]?.Value?.ToString()?.Trim();

                            // Step 1: Try to resolve product ID using SKU
                            if (!string.IsNullOrWhiteSpace(sku))
                            {
                                string[] serials = sku.Split(',');
                                string firstSerial = serials[0].Trim();

                                string lookupQuery = "SELECT product_id FROM productsserial WHERE sku = @sku LIMIT 1;";
                                using (var lookup = new MySqlCommand(lookupQuery, conn, tran))
                                {
                                    lookup.Parameters.AddWithValue("@sku", firstSerial);
                                    object result = lookup.ExecuteScalar();
                                    if (result != null)
                                        productId = result.ToString();
                                }
                            }

                            // Step 2: Fallback to Name + Description
                            if (string.IsNullOrEmpty(productId))
                            {
                                string name = row.Cells["Name"]?.Value?.ToString()?.Trim();
                                string desc = row.Cells["Description"]?.Value?.ToString()?.Trim();

                                if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(desc))
                                {
                                    string nameQuery = "SELECT product_id FROM products WHERE name = @name AND description = @desc LIMIT 1;";
                                    using (var cmdName = new MySqlCommand(nameQuery, conn, tran))
                                    {
                                        cmdName.Parameters.AddWithValue("@name", name);
                                        cmdName.Parameters.AddWithValue("@desc", desc);
                                        object result = cmdName.ExecuteScalar();
                                        if (result != null)
                                            productId = result.ToString();
                                    }
                                }
                            }

                            if (string.IsNullOrEmpty(productId))
                                continue;

                            // Step 3: Insert into customer_bill_details
                            string insertDetail = @"INSERT INTO customer_bill_details 
                                            (Bill_id, product_id, quantity, discount, status, warranty, warranty_from)
                                            VALUES (@bill, @pid, @qty, @disc, 'bill', @warranty, @warrantyFrom);
                                            SELECT LAST_INSERT_ID();";

                            int billDetailId;
                            using (var cmd = new MySqlCommand(insertDetail, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@bill", billId);
                                cmd.Parameters.AddWithValue("@pid", productId);

                                if (!int.TryParse(row.Cells["Quantity"].Value?.ToString(), out int qty))
                                    throw new Exception("Invalid quantity for product.");
                                cmd.Parameters.AddWithValue("@qty", qty);

                                decimal.TryParse(row.Cells["Discount"].Value?.ToString(), out decimal discount);
                                cmd.Parameters.AddWithValue("@disc", discount);

                                string warranty = row.Cells["Warranty"]?.Value?.ToString();
                                cmd.Parameters.AddWithValue("@warranty", string.IsNullOrWhiteSpace(warranty) ? DBNull.Value : (object)warranty);
                                cmd.Parameters.AddWithValue("@warrantyFrom", saleDate);

                                billDetailId = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            // Step 4: Insert each serial into bill_detail_serials
                            if (!string.IsNullOrWhiteSpace(sku))
                            {
                                string[] serials = sku.Split(',');
                                foreach (string serial in serials)
                                {
                                    string trimmedSerial = serial.Trim();
                                    if (string.IsNullOrWhiteSpace(trimmedSerial)) continue;

                                    string insertSerial = @"INSERT INTO bill_detail_serials 
                                                    (bill_detail_id, product_id, serial_number, status)
                                                    VALUES (@detailId, @pid, @serial, 'sold');";

                                    using (var cmdSerial = new MySqlCommand(insertSerial, conn, tran))
                                    {
                                        cmdSerial.Parameters.AddWithValue("@detailId", billDetailId);
                                        cmdSerial.Parameters.AddWithValue("@pid", productId);
                                        cmdSerial.Parameters.AddWithValue("@serial", trimmedSerial);
                                        cmdSerial.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        tran.Commit();
                        return billId;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Sale Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                }
            }
        }
    }
}