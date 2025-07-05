using System;
using System.Data;
using KIMS;
using MySql.Data.MySqlClient;

namespace TechStore.DL
{
    public class CustomerReturnDL
    {
        public static DataTable GetBillDetailsById(int billId)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        cbd.Bill_detail_ID,
                        p.name AS Product,
                        p.description,
                        cbd.sku,
                        cbd.quantity,
                        cbd.discount,
                        cbd.warranty,
                        cbd.warranty_from,
                        cbd.warranty_till,
                        cbd.status,
                        CONCAT(c.first_name, ' ', c.last_name) AS CustomerName
                    FROM customer_bill_details cbd
                    JOIN products p ON cbd.product_id = p.product_id
                    JOIN customerbills cb ON cbd.Bill_id = cb.BillID
                    JOIN customers c ON cb.CustomerID = c.customer_id
                    WHERE cbd.Bill_id = @billId AND cbd.status = 'bill'";


                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@billId", billId);

                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static void SaveReturnToDatabase(int productId, int billId, DateTime returnDate, string reason, int quantityReturned, string actionTaken, int? amountReturned, string enteredSkus)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string insertQuery = @"INSERT INTO customer_returns 
            (product_id, bill_id, return_date, reason, quantity_returned, action_taken, amount_returned, sku)
            VALUES 
            (@pid, @bill, @date, @reason, @qty, @action, @amount, @sku);";

                using (var cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", productId);
                    cmd.Parameters.AddWithValue("@bill", billId);
                    cmd.Parameters.AddWithValue("@date", returnDate);
                    cmd.Parameters.AddWithValue("@reason", reason ?? "");
                    cmd.Parameters.AddWithValue("@qty", quantityReturned);
                    cmd.Parameters.AddWithValue("@action", actionTaken);
                    cmd.Parameters.AddWithValue("@amount", amountReturned.HasValue ? (object)amountReturned.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@sku", enteredSkus);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int? GetProductId(string productName, string productDescription)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = "SELECT product_id FROM products WHERE name = @name AND description = @desc LIMIT 1;";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", productName);
                    cmd.Parameters.AddWithValue("@desc", productDescription);

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : (int?)null;
                }
            }
        }

        public static int GetProductIdByName(string productName)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = "SELECT product_id FROM products WHERE name = @name LIMIT 1";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", productName);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        return Convert.ToInt32(result);
                    else
                        throw new Exception("Product not found in database.");
                }
            }
        }


    }
}
