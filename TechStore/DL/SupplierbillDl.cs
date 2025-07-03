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
    public class SupplierbillDl : ISupplierbillDl
    {
        public Supplierbill GetSupplierBillByBatchName(string batchName)
        {
            if (string.IsNullOrWhiteSpace(batchName))
                throw new ArgumentException("Batch name is required", nameof(batchName));

            int batchId = DatabaseHelper.Instance.getbatchid(batchName);

            string query = @"
        SELECT 
            sb.supplier_bill_id,
            s.name AS supplier_name,
            b.batch_name,
            sb.total_price,
            sb.date,
            sb.paid_amount
        FROM 
            supplierbills sb
        JOIN batches b ON sb.batch_id = b.batch_id
        JOIN suppliers s ON b.supplier_id = s.supplier_id
        WHERE sb.batch_id = @batch_id;
    ";

            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@batch_id", batchId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Supplierbill
                            (
                                Convert.ToInt32(reader["supplier_bill_id"]),
                               reader["supplier_name"].ToString(),
                             reader["batch_name"].ToString(),
                               Convert.ToDecimal(reader["total_price"]),
                             Convert.ToDateTime(reader["date"]),
                               Convert.ToDecimal(reader["paid_amount"])
                            );
                        }
                        else
                        {
                            return null; 
                        }
                    }
                }
            }
        }
        public bool UpdateBill(Supplierbill s)
        {
            try
            {
                int batch_id = DatabaseHelper.Instance.getbatchid(s.batch_name);
                int supplier_id = DatabaseHelper.Instance.getsuppierid(s.supplier_name);

                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();

                    using (var tran = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Update the supplier bill
                            string updateQuery = @"UPDATE supplierbills 
                                           SET paid_amount = @paid_amount 
                                           WHERE batch_id = @batch_id AND supplier_id = @supplier_id";
                            using (var cmd = new MySqlCommand(updateQuery, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@paid_amount", s.paid_price);
                                cmd.Parameters.AddWithValue("@batch_id", batch_id);
                                cmd.Parameters.AddWithValue("@supplier_id", supplier_id);
                                cmd.ExecuteNonQuery();
                            }

                            // 2. Get the supplier_bill_id
                            string selectBillId = @"SELECT supplier_bill_id FROM supplierbills 
                                            WHERE batch_id = @batch_id AND supplier_id = @supplier_id LIMIT 1";
                            int billId;
                            using (var cmd = new MySqlCommand(selectBillId, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@batch_id", batch_id);
                                cmd.Parameters.AddWithValue("@supplier_id", supplier_id);
                                var result = cmd.ExecuteScalar();
                                if (result == null)
                                    throw new Exception("No matching bill found.");
                                billId = Convert.ToInt32(result);
                            }

                            // 3. Insert into supplierpricerecord
                            string insertRecord = @"INSERT INTO supplierpricerecord 
                                            (supplier_id, supplier_bill_id, date, payment, remarks)
                                            VALUES (@supplier_id, @bill_id, CURRENT_DATE(), @payment, 'Initial Payment')";
                            using (var cmd = new MySqlCommand(insertRecord, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@supplier_id", supplier_id);
                                cmd.Parameters.AddWithValue("@bill_id", billId);
                                cmd.Parameters.AddWithValue("@payment", s.paid_price);
                                cmd.ExecuteNonQuery();
                            }

                            tran.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw new Exception("Failed during transaction: " + ex.Message, ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update bill: " + ex.Message, ex);
            }
        }


    }
}
