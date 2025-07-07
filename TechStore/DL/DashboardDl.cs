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
        public List<(DateTime Day, decimal TotalSales)> GetMonthlySalesTrend()
        {
            var result = new List<(DateTime, decimal)>();

            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    DATE(Saledate) AS sale_day,
                    SUM(total_price) AS total_sales
                FROM 
                    customerbills
                WHERE 
                    MONTH(Saledate) = MONTH(CURDATE())
                    AND YEAR(Saledate) = YEAR(CURDATE())
                GROUP BY 
                    sale_day
                ORDER BY 
                    sale_day;
            ";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var date = reader.GetDateTime("sale_day");
                            var total = reader.GetDecimal("total_sales");
                            result.Add((date, total));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting sales trends: " + ex.Message, ex);
            }

            return result;
        }
        public List<(string Category, int ProductCount)> GetProductCategoryDistribution()
        {
            var result = new List<(string, int)>();

            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = @"SELECT c.name, COUNT(*) AS total_products 
                         FROM products p 
                         JOIN categories c ON c.category_id = p.category_id 
                         GROUP BY c.name;";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string category = reader.GetString("name");
                        int count = reader.GetInt32("total_products");
                        result.Add((category, count));
                    }
                }
            }

            return result;
        }

        public List<(string MonthName, decimal TotalSales)> GetMonthlySalesComparison()
        {
            var result = new List<(string, decimal)>();

            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT 
                DATE_FORMAT(Saledate, '%b') AS month_name,
                MONTH(Saledate) AS month_number,
                SUM(total_price) AS total_sales
            FROM 
                customerbills
            WHERE 
                YEAR(Saledate) = YEAR(CURDATE())
            GROUP BY 
                month_name, month_number
            ORDER BY 
                month_number;";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string month = reader.GetString("month_name");
                        decimal total = reader.GetDecimal("total_sales");
                        result.Add((month, total));
                    }
                }
            }

            return result;
        }


        public List<(string SupplierName, int TotalBatches)> GetTopSupplierContributions()
        {
            var result = new List<(string, int)>();

            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT 
                s.name AS supplier_name,
                COUNT(*) AS total_batches
            FROM 
                batches b
            JOIN 
                suppliers s ON s.supplier_id = b.supplier_id
            GROUP BY 
                s.supplier_id
            ORDER BY 
                total_batches DESC
            LIMIT 5;";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string supplier = reader.GetString("supplier_name");
                        int batches = reader.GetInt32("total_batches");
                        result.Add((supplier, batches));
                    }
                }
            }

            return result;
        }
        public int getpendingbills()
        {
            try
            {
                using(var conn=DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = "select count(*) as pending from supplierbills where payment_status='Due';";
                    using (var cmd=new MySqlCommand(query,conn))
                    {
                        using (var reader=cmd.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                return reader.GetInt32("pending");
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting sales trends: " + ex.Message, ex);
            }
        }
    }
}
