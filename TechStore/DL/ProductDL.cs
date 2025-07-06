using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using TechStore.BL.Models;
using TechStore.Interfaces.DLInterfaces;

public class ProductDL : IproductDl
{
    public bool AddProduct(Products p)
    {
        int categoryid = DatabaseHelper.Instance.GetCategoryId(p.category);

        try
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO products (name, description, category_id) VALUES (@name, @description, @category_id);";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", p.name);
                    cmd.Parameters.AddWithValue("@description", p.description);
                    cmd.Parameters.AddWithValue("@category_id", categoryid);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error adding product: " + ex.Message, ex);
        }
    }

    public bool UpdateProduct(Products p)
    {
        int categoryid = DatabaseHelper.Instance.GetCategoryId(p.category);

        try
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = "UPDATE products SET name = @name, description = @description, category_id = @category_id WHERE product_id = @id;";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", p.name);
                    cmd.Parameters.AddWithValue("@description", p.description);
                    cmd.Parameters.AddWithValue("@category_id", categoryid);
                    cmd.Parameters.AddWithValue("@id", p.id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error updating product: " + ex.Message, ex);
        }
    }

    public bool DeleteProduct(int id)
    {
        using (var conn = DatabaseHelper.Instance.GetConnection())
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
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = "SELECT p.product_id, p.name, p.description, c.name AS category_name FROM products p JOIN categories c ON p.category_id = c.category_id;";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Products product = new Products(
                            reader.GetInt32("product_id"),
                            reader.GetString("name"),
                            reader.GetString("description"),
                            reader.GetString("category_name")

                        );
                        products.Add(product);
                    }
                }
            }

            return products;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving products: " + ex.Message, ex);
        }
    }

    public List<Products> searchproducts(string search)
    {
        List<Products> products = new List<Products>();

        try
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = @"SELECT p.product_id, p.name, p.description, c.name AS category_name
                                 FROM products p
                                 JOIN categories c ON p.category_id = c.category_id
                                 WHERE p.name LIKE @search OR c.name LIKE @search;";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products product = new Products(
                                reader.GetInt32("product_id"),
                                reader.GetString("name"),
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
        catch (Exception ex)
        {
            throw new Exception("Error searching products: " + ex.Message, ex);
        }
    }

    public List<string> getcategories(string name)
    {
        try
        {
            return DatabaseHelper.Instance.GetCategories(name);
        }
        catch
        {
            throw new Exception("Error retrieving categories.");
        }
    }
    public bool addcategory(string name)
    {
        try
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO categories (name) VALUES (@name);";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error adding category: " + ex.Message, ex);
        }
    }

    public List<Products> GetProductsByName(string name)

    {
        try
        {
            return DatabaseHelper.Instance.GetProductsByName(name);
        }
        catch
        {
            throw new Exception();
        }
    }
   

} 
