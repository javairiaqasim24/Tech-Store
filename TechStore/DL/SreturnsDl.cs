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
    public class SreturnsDl : ISreturnsDl
    {
        public bool AddSupplierReturns(List<Supplierreturn> returns)
        {
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        Dictionary<int, decimal> refundTotals = new Dictionary<int, decimal>();

                        foreach (var sr in returns)
                        {
                            string insertQuery = @"
                        INSERT INTO supplier_returns 
                        (supplier_bill_detail_id, product_id, sku, return_date, action_taken, amount_refunded, quantity_returned) 
                        VALUES (@bill_detail_id, @product_id, @sku, @return_date, @action_taken, @amount, @quantity);";

                            using (var cmd = new MySqlCommand(insertQuery, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@bill_detail_id", sr.bill_detail_id);
                                cmd.Parameters.AddWithValue("@product_id", sr.p.id);
                                cmd.Parameters.AddWithValue("@sku", (object)sr.sku ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@return_date", sr.return_date);
                                cmd.Parameters.AddWithValue("@action_taken", sr.action_taken);
                                cmd.Parameters.AddWithValue("@amount", sr.action_taken.ToLower() == "refunded" ? (object)sr.amount : DBNull.Value);
                                cmd.Parameters.AddWithValue("@quantity", sr.quantity);
                                cmd.ExecuteNonQuery();
                            }

                            if (!string.IsNullOrEmpty(sr.sku))
                            {
                                string updateStatus = "UPDATE productsserial SET status='returned' WHERE sku = @sku;";
                                using (var cmdDelete = new MySqlCommand(updateStatus, conn, tran))
                                {
                                    cmdDelete.Parameters.AddWithValue("@sku", sr.sku);
                                    cmdDelete.ExecuteNonQuery();
                                }
                            }
                            if (sr.action_taken.ToLower() == "refunded")
                            {
                                if (!refundTotals.ContainsKey(sr.bill_detail_id))
                                    refundTotals[sr.bill_detail_id] = 0;

                                refundTotals[sr.bill_detail_id] += sr.amount;
                            }
                        }

                        // Now update supplier_bills total_price
                        foreach (var kvp in refundTotals)
                        {
                            int billDetailId = kvp.Key;
                            decimal refundAmount = kvp.Value;

                            string updateBillQuery = @"
                        UPDATE supplierbills sb
                        JOIN supplier_bill_details bd ON sb.supplier_bill_id = bd.supplier_bill_id
                        SET sb.total_price = sb.total_price - @refund
                        WHERE bd.s_bill_detail_id = @billDetailId;";

                            using (var cmd = new MySqlCommand(updateBillQuery, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@refund", refundAmount);
                                cmd.Parameters.AddWithValue("@billDetailId", billDetailId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting supplier returns: " + ex.Message, ex);
            }
        }


        public List<Supplierreturn> GetBillDetailsByBillId(int billId)
        {
            var list = new List<Supplierreturn>();

            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT cbd.s_bill_detail_id, p.name, cbd.product_id, p.description, cbd.quantity 
            FROM supplier_bill_details cbd
            JOIN products p ON cbd.product_id = p.product_id
            WHERE cbd.supplier_bill_id = @billId;";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@billId", billId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int billDetailId = reader.GetInt32("s_bill_detail_id");
                            string name = reader.GetString("name");
                            string description = reader.GetString("description");
                            int quantity = reader.GetInt32("quantity");
                            int productId = reader.GetInt32("product_id");

                            // Pass null for SKU since it's removed
                            list.Add(new Supplierreturn(
                                billDetailId,
                                DateTime.Now,
                                "",               // action_taken default
                                null,             // sku
                                name,
                                description,
                                0,                // amount refunded default
                                quantity,
                                productId));
                        }
                    }
                }
            }

            return list;
        }

        public Products GetProductBySku(string sku)
        {
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT p.product_id, p.name, p.description 
                             FROM productsserial ps
                             JOIN products p ON ps.product_id = p.product_id
                             WHERE ps.sku = @sku";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sku", sku);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32("product_id");
                                string name = reader.GetString("name");
                                string description = reader.GetString("description");
                                return new Products(id, name, description); // ✅ use constructor with id
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting product by SKU: " + ex.Message, ex);
            }
            return null;
        }
        public static  string GetSampleSkuForProduct(int productId)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = "SELECT sku FROM productsserial WHERE product_id = @pid LIMIT 1";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", productId);
                    return cmd.ExecuteScalar()?.ToString();
                }
            }
        }

    }
}
