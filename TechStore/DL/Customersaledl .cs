﻿using System;
using System.Collections.Generic;
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
                      WHERE p.name LIKE @name
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

        public int InsertNewWalkInCustomer(string name)
        {
            string[] parts = name.Split(' ');
            string firstName = parts[0];
            string lastName = parts.Length > 1 ? parts[1] : "";

            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open(); // ✅ Must open the connection

                string insertQuery = @"INSERT INTO customers (type, first_name, last_name)
                               VALUES ('Walk-in', @first, @last);";

                using (var cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@first", firstName);
                    cmd.Parameters.AddWithValue("@last", lastName);
                    cmd.ExecuteNonQuery();
                }

                string idQuery = "SELECT LAST_INSERT_ID();";
                using (var idCmd = new MySqlCommand(idQuery, conn))
                {
                    return Convert.ToInt32(idCmd.ExecuteScalar());
                }
            }
        }


        public bool SaveCustomerBill(int customerId, DateTime saleDate, decimal total, decimal paid, DataGridView cart)
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

                        // 2. Insert products from cart
                        foreach (DataGridViewRow row in cart.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string insertDetail = @"INSERT INTO customer_bill_details 
                                            (Bill_id, product_id, quantity, discount, status, warranty, warranty_from)
                                            VALUES (@bill, @pid, @qty, @disc, 'bill', @warranty, @warrantyFrom);";

                            using (var cmd = new MySqlCommand(insertDetail, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@bill", billId);

                                // 🔍 Get SKU(s) and lookup product_id
                                string serialList = row.Cells["Sku"].Value?.ToString()?.Trim();
                                string[] serials = serialList.Split(',');
                                string firstSerial = serials[0].Trim();

                                string lookupQuery = "SELECT product_id FROM productsserial WHERE sku = @sku LIMIT 1;";
                                string productId = null;

                                using (var lookup = new MySqlCommand(lookupQuery, conn, tran))
                                {
                                    lookup.Parameters.AddWithValue("@sku", firstSerial);
                                    object result = lookup.ExecuteScalar();

                                    if (result != null)
                                    {
                                        productId = result.ToString();
                                    }
                                    else
                                    {
                                        throw new Exception($"Product not found for SKU '{firstSerial}'");
                                    }
                                }

                                cmd.Parameters.AddWithValue("@pid", productId);

                                // Quantity
                                if (!int.TryParse(row.Cells["Quantity"].Value?.ToString(), out int qty))
                                    throw new Exception("Invalid quantity for product.");

                                cmd.Parameters.AddWithValue("@qty", qty);

                                // Discount
                                decimal.TryParse(row.Cells["Discount"].Value?.ToString(), out decimal discount);
                                cmd.Parameters.AddWithValue("@disc", discount);

                                // Warranty
                                string warranty = row.Cells["Warranty"]?.Value?.ToString();
                                cmd.Parameters.AddWithValue("@warranty", string.IsNullOrWhiteSpace(warranty) ? DBNull.Value : (object)warranty);

                                // Warranty date
                                cmd.Parameters.AddWithValue("@warrantyFrom", saleDate);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Sale Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }



    }
}