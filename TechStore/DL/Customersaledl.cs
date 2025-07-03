using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIMS;
using MySql.Data.MySqlClient;
using TechStore.BL.Models;
using TechStore.Interfaces.DLInterfaces;

namespace TechStore.DL
{
    public class Customersaledl : Icustomersaledl
    {
        public Products GetProductBySku(string sku)
        {
            try
            {
                using (var reader = DatabaseHelper.Instance.ExecuteReader(
                    @"SELECT p.product_id, p.name, i.sku, p.description, 
                             c.name as category_name, p.category_id,
                             p.quantity_in_stock as total_quantity, 
                             i.sale_price
                      FROM products p
                      JOIN inventory i ON p.product_id = i.product_id
                      JOIN categories c ON p.category_id = c.category_id
                      WHERE i.sku = @sku
                      GROUP BY p.product_id, p.name, i.sku, p.description, 
                               c.name, p.category_id, i.sale_price",
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

                        return new Products(
                            reader.GetInt32(productIdOrdinal),
                            reader.GetString(nameOrdinal),
                            //reader.GetString(skuOrdinal),
                            reader.GetString(descriptionOrdinal),
                            reader.GetString(categoryOrdinal)
                            //reader.IsDBNull(totalQuantityOrdinal) ? (int?)null : reader.GetInt32(totalQuantityOrdinal),
                            //reader.IsDBNull(salePriceOrdinal) ? (double?)null : reader.GetDouble(salePriceOrdinal)
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

        public List<Products> SearchProductsByName(string name)
        {
            try
            {
                var products = new List<Products>();
                using (var reader = DatabaseHelper.Instance.ExecuteReader(
                    @"SELECT p.product_id, p.name, p.description, 
                             c.name as category_name, p.category_id,
                             p.quantity_in_stock as total_quantity, 
                             i.sale_price
                      FROM products p
                      JOIN inventory i ON p.product_id = i.product_id
                      JOIN categories c ON p.category_id = c.category_id
                      WHERE p.name LIKE @name
                      GROUP BY p.product_id, p.name, p.description, 
                               c.name, p.category_id, i.sale_price",
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
                        products.Add(new Products(
                            reader.GetInt32(productIdOrdinal),
                            reader.GetString(nameOrdinal),
                            //"", // SKU not needed in name-based search
                            reader.GetString(descriptionOrdinal),
                            reader.GetString(categoryOrdinal)
                            //reader.IsDBNull(totalQuantityOrdinal) ? (int?)null : reader.GetInt32(totalQuantityOrdinal),
                            //reader.IsDBNull(salePriceOrdinal) ? (double?)null : reader.GetDouble(salePriceOrdinal)
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
    }
}
