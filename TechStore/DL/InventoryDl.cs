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
                    string query = "UPDATE inventory SET quantity_in_stock = @quantity, sale_price = @price WHERE inventory_id = @id;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@quantity", i.Stock);
                        cmd.Parameters.AddWithValue("@price", i.SalePrice);
                        cmd.Parameters.AddWithValue("@id", i.InventoryId); // <- FIXED HERE
                        cmd.ExecuteNonQuery();
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


                                // Assuming Inventory constructor takes these values
                                Inventory inv = new Inventory(inventoryId, salePrice, quantity, productId, productName,desc);
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
