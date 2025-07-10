using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;

namespace TechStore.DL
{
    public class InventoryDl : IInventoryDl
    {
        public bool UpdateInventory(Inventory i)
        {
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();

                    using (var transaction = conn.BeginTransaction())
                    {
                        // Step 1: Get old stock and product_id
                        int oldStock = 0;
                        int productId = 0;

                        string getQuery = "SELECT quantity_in_stock, product_id FROM inventory WHERE inventory_id = @id";
                        using (var getCmd = new MySqlCommand(getQuery, conn, transaction))
                        {
                            getCmd.Parameters.AddWithValue("@id", i.InventoryId);
                            using (var reader = getCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    oldStock = Convert.ToInt32(reader["quantity_in_stock"]);
                                    productId = Convert.ToInt32(reader["product_id"]);
                                }
                                else
                                {
                                    throw new Exception("Inventory record not found.");
                                }
                            }
                        }

                        int quantityChange = i.Stock - oldStock;

                        // Step 2: Update inventory
                        string updateQuery = "UPDATE inventory SET quantity_in_stock = @quantity, sale_price = @price WHERE inventory_id = @id";
                        using (var updateCmd = new MySqlCommand(updateQuery, conn, transaction))
                        {
                            updateCmd.Parameters.AddWithValue("@quantity", i.Stock);
                            updateCmd.Parameters.AddWithValue("@price", i.SalePrice);
                            updateCmd.Parameters.AddWithValue("@id", i.InventoryId);
                            updateCmd.ExecuteNonQuery();
                        }

                        // Step 3: Insert log (without inventory_id)
                        string logQuery = @"INSERT INTO inventory_log 
                    (product_id, change_type, quantity_change, log_date, remarks)
                    VALUES (@productId, @changeType, @quantityChange, @logDate, @remarks)";
                        using (var logCmd = new MySqlCommand(logQuery, conn, transaction))
                        {
                            logCmd.Parameters.AddWithValue("@productId", productId);
                            logCmd.Parameters.AddWithValue("@changeType", "manual_adjustment");
                            logCmd.Parameters.AddWithValue("@quantityChange", quantityChange);
                            logCmd.Parameters.AddWithValue("@logDate", DateTime.Now);
                            logCmd.Parameters.AddWithValue("@remarks", "Manual adjustment of inventory");
                            logCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating inventory: " + ex.Message, ex);
            }
        }

        public List<Inventory> GetInventoryByProductName()
        {
            var inventoryList = new List<Inventory>();
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT i.inventory_id, i.sale_price, i.quantity_in_stock, 
                       p.product_id, p.name ,p.description
                FROM inventory i
                JOIN products p ON i.product_id = p.product_id;";

                    using (var cmd = new MySqlCommand(query, conn))
                    {

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int invId = reader.GetInt32("inventory_id");
                                decimal salePrice = reader.GetDecimal("sale_price");
                                int stock = reader.GetInt32("quantity_in_stock");
                                int productId = reader.GetInt32("product_id");
                                string name = reader.GetString("name");
                                string desc= reader.GetString("description");

                                var inv = new Inventory(invId, salePrice, stock, productId, name,desc);
                                inventoryList.Add(inv);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving inventory by product name: " + ex.Message, ex);
            }
            return inventoryList;
        }
        public List<Inventory> SearchInventoryByProductName(string name)
        {
            var inventoryList = new List<Inventory>();

            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT i.inventory_id,
                       i.sale_price,
                       i.quantity_in_stock,
                       p.product_id,
                       p.name,
                       p.description
                FROM inventory i
                JOIN products p ON i.product_id = p.product_id
                WHERE p.name LIKE CONCAT('%', @name, '%');";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int inventoryId = reader.GetInt32("inventory_id");
                                decimal salePrice = reader.GetDecimal("sale_price");
                                int quantity = reader.GetInt32("quantity_in_stock");
                                int productId = reader.GetInt32("product_id");
                                string productName = reader.GetString("name");
                                string desc = reader.GetString("description");

                                Inventory inv = new Inventory(inventoryId, salePrice, quantity, productId, productName, desc);
                                inventoryList.Add(inv);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching inventory by product name: " + ex.Message, ex);
            }

            return inventoryList;
        }


    }
}
