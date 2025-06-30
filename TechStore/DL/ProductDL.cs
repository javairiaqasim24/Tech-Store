using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;
using TechStore.Interfaces.DLInterfaces;

namespace TechStore.DL
{
    public class ProductDL : IproductDl
    {
        public bool AddProduct(Products p)
        {
            int categoryid = DatabaseHelper.getcategoryid(p.category);
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO products (name, sku, description, category_id) VALUES (@name, @sku, @description, @category_id);";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", p.name);
                        cmd.Parameters.AddWithValue("@sku", p.sku);
                        cmd.Parameters.AddWithValue("@description", p.description);
                        cmd.Parameters.AddWithValue("@category_id", categoryid);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch(MySqlException ex)
            {
                throw new Exception("Database error occurred while adding product."+ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding product: " + ex.Message, ex);
            }
        }
        public bool UpdateProduct(Products p)
        {
            int categoryid = DatabaseHelper.getcategoryid(p.category);
            try
            {
                using (var conn=DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE products SET name = @name, sku = @sku, description = @description, category_id = @category_id WHERE product_id = @id;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", p.name);
                        cmd.Parameters.AddWithValue("@sku", p.sku);
                        cmd.Parameters.AddWithValue("@description", p.description);
                        cmd.Parameters.AddWithValue("@category_id", categoryid);
                        cmd.Parameters.AddWithValue("@id", p.id);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Database error occurred while updating product." + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating product: " + ex.Message, ex);
            }
        }
        public bool DeleteProduct(int id)
        {
            using (var conn=DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM products WHERE product_id = @id;";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public List<Products> getproducts()
        {
           List<Products> products = new List<Products>();
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT p.product_id, p.name, p.sku, p.description, c.name as category_name FROM products p JOIN categories c ON p.category_id = c.category_id;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Products product = new Products
                                (
                                     reader.GetInt32("product_id"),
                                    reader.GetString("name"),
                                     reader.GetString("sku"),
                                     reader.GetString("description"),
                                   reader.GetString("category_name")
                                 );
                                products.Add(product);
                            }
                        }
                    }
                }
                return products;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Database error occurred while retrieving products." + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving products: " + ex.Message, ex);
            }

        }
        public List<string> getcategories()
        {
            try
            {
                return DatabaseHelper.GetCategories();
            }
            catch
            {
                throw new Exception("Error retrieving categories.");    
            }
        }

    }
}