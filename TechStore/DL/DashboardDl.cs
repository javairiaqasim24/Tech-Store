using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.DL
{
    public class DashboardDl
    {
        public string bestproduct()
        {
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    p.name
                FROM 
                    customer_bill_details s
                JOIN 
                    products p ON p.product_id = s.product_id
                JOIN 
                    customerbills cb ON cb.billid = s.bill_id
                WHERE 
                    MONTH(cb.Saledate) = MONTH(CURRENT_DATE())
                    AND YEAR(cb.Saledate) = YEAR(CURRENT_DATE())
                GROUP BY 
                    s.product_id
                ORDER BY 
                    SUM(s.quantity) DESC
                LIMIT 1;
            ";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetString("name");
                            }
                        }
                    }
                }

                return "No product sold this month";
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message, ex);
            }
        }
        public int totalproducts()
        {
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = @"select Sum(quantity_in_stock) as quantity_in_stock from inventory;";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetInt32("quantity_in_stock");
                            }
                        }
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message, ex);
            }
        }
        public int totalsuppliers()
        {
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = @"select Sum(supplier_id) as Total_Suppliers from suppliers;";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetInt32("Total_Suppliers");
                            }
                        }
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message, ex);
            }
        }
        public int totalcustomers()
        {
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = @"select Sum(customer_id) customers from customers where type='regular';";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetInt32("customers");
                            }
                        }
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message, ex);
            }
        }
        public int salestoday()
        {
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT COUNT(*) as total_sales FROM customerbills WHERE DATE(SaleDate) = CURDATE();";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetInt32("total_sales");
                            }
                        }
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message, ex);
            }
        }
        public int totalreturns()
        {
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT COUNT(*) AS total_returns FROM customer_returns WHERE MONTH(Return_Date) = MONTH(CURDATE()) AND YEAR(Return_Date) = YEAR(CURDATE());
";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetInt32("total_returns");
                            }
                        }
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message, ex);
            }
        }
    }
}
