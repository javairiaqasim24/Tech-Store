using System;
using System.Data;
using System.Linq;
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
                p.name AS Product,
                p.description,
                GROUP_CONCAT(bds.serial_number ORDER BY bds.serial_number SEPARATOR ', ') AS SerialNumbers,
                cbd.quantity,
                cbd.discount,
                cbd.warranty,
                cbd.warranty_from,
                cbd.warranty_till,
                cbd.status,
                CONCAT(c.first_name, ' ', c.last_name) AS CustomerName
            FROM customer_bill_details cbd
            JOIN products p ON cbd.product_id = p.product_id
            LEFT JOIN bill_detail_serials bds ON cbd.Bill_detail_ID = bds.bill_detail_id
            JOIN customerbills cb ON cbd.Bill_id = cb.BillID
            JOIN customers c ON cb.CustomerID = c.customer_id
            WHERE cbd.Bill_id = @billId AND cbd.status = 'bill'
            GROUP BY 
                cbd.Bill_detail_ID, p.name, p.description, cbd.quantity, cbd.discount, 
                cbd.warranty, cbd.warranty_from, cbd.warranty_till, cbd.status, c.first_name, c.last_name
            ORDER BY p.name;
        ";

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

        public static int GetBillDetailIdForNonSerial(int billId, int productId)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT cbd.Bill_detail_ID
            FROM customer_bill_details cbd
            WHERE cbd.Bill_id = @billId AND cbd.product_id = @pid
              AND NOT EXISTS (
                  SELECT 1 FROM bill_detail_serials s
                  WHERE s.bill_detail_id = cbd.Bill_detail_ID
              )
            LIMIT 1;";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@billId", billId);
                    cmd.Parameters.AddWithValue("@pid", productId);

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result)
                                          : throw new Exception("Bill detail not found for non-serial product.");
                }
            }
        }



        public static void SaveReturnToDatabase(
     int productId,
     int billDetailId,
     DateTime returnDate,
     string reason,
     int quantityReturned,
     string actionTaken,
     int? amountReturned,
     string enteredSkus)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // Step 1: Insert into customer_returns
                        string insertQuery = @"
                    INSERT INTO customer_returns 
                    (product_id, bill_detail_id, return_date, reason, quantity_returned, action_taken, amount_returned, sku)
                    VALUES 
                    (@pid, @billDetailId, @date, @reason, @qty, @action, @amount, @sku);";

                        using (var cmd = new MySqlCommand(insertQuery, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@pid", productId);
                            cmd.Parameters.AddWithValue("@billDetailId", billDetailId);
                            cmd.Parameters.AddWithValue("@date", returnDate);
                            cmd.Parameters.AddWithValue("@reason", reason ?? "");
                            cmd.Parameters.AddWithValue("@qty", quantityReturned);
                            cmd.Parameters.AddWithValue("@action", actionTaken);
                            cmd.Parameters.AddWithValue("@amount", amountReturned.HasValue ? (object)amountReturned.Value : DBNull.Value);
                            cmd.Parameters.AddWithValue("@sku", enteredSkus);

                            cmd.ExecuteNonQuery();
                        }

                        // Step 2: Update each serial to status = 'Return'
                        string[] serials = enteredSkus.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                      .Select(s => s.Trim())
                                                      .ToArray();

                        foreach (string serial in serials)
                        {
                            // Step 1: Update status to 'Return'
                            string updateQuery = @"
        UPDATE bill_detail_serials
        SET status = 'Return'
        WHERE serial_number = @serial AND bill_detail_id = @billDetailId";

                            using (var updateCmd = new MySqlCommand(updateQuery, conn, tran))
                            {
                                updateCmd.Parameters.AddWithValue("@serial", serial);
                                updateCmd.Parameters.AddWithValue("@billDetailId", billDetailId);
                                updateCmd.ExecuteNonQuery();
                            }

                            // Step 2: Delete the row after updating status
                            string deleteQuery = @"
        DELETE FROM bill_detail_serials 
        WHERE serial_number = @serial AND bill_detail_id = @billDetailId";

                            using (var deleteCmd = new MySqlCommand(deleteQuery, conn, tran))
                            {
                                deleteCmd.Parameters.AddWithValue("@serial", serial);
                                deleteCmd.Parameters.AddWithValue("@billDetailId", billDetailId);
                                deleteCmd.ExecuteNonQuery();
                            }
                        }


                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw; // re-throw for UI to handle
                    }
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

        public static int GetBillDetailId(int billId, int productId, string sku)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT cbd.Bill_detail_ID
            FROM customer_bill_details cbd
            JOIN bill_detail_serials s ON s.bill_detail_id = cbd.Bill_detail_ID
            WHERE cbd.Bill_id = @billId AND cbd.product_id = @pid AND s.serial_number = @sku
            LIMIT 1;";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@billId", billId);
                    cmd.Parameters.AddWithValue("@pid", productId);
                    cmd.Parameters.AddWithValue("@sku", sku);

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : throw new Exception("Bill detail not found for the given serial and product.");
                }
            }
        }


    }
}
