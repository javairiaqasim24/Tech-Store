using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace TechStore.DL
{
    public static class SupplierBillingRecordsOverviewDL
    {
        public static DataTable GetSupplierBills(string searchTerm = "")
        {
            DataTable dt = new DataTable();

            try
            {
                string query = @"
                    SELECT 
                        sb.supplier_Bill_ID,
                        s.name AS supplier_name,
                        sb.Date,
                        sb.total_price,
                        sb.paid_amount,
                        (sb.total_price - IFNULL(sb.paid_amount, 0)) AS pending_amount,
                        sb.payment_status
                    FROM supplierbills sb
                    JOIN suppliers s ON sb.supplier_id = s.supplier_id
                    WHERE s.name LIKE @searchTerm
                    ORDER BY sb.Date DESC";

                MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@searchTerm", $"%{searchTerm}%")
                };

                using (var reader = DatabaseHelper.Instance.ExecuteReader(query, parameters))
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving supplier bills: {ex.Message}");
            }

            return dt;
        }

        public static DataTable GetBillDetails(int billId)
        {
            DataTable dt = new DataTable();

            try
            {
                string query = @"
                    SELECT 
                        p.name AS product_name,
                        sbd.quantity,
                        (sbd.quantity * bd.cost_price) AS total_price
                    FROM supplier_bill_details sbd
                    JOIN products p ON sbd.product_id = p.product_id
                    JOIN batch_details bd ON bd.product_id = p.product_id
                    JOIN supplierbills sb ON sb.supplier_Bill_ID = sbd.supplier_Bill_ID
                    WHERE sbd.supplier_Bill_ID = @billId";

                MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@billId", billId)
                };

                using (var reader = DatabaseHelper.Instance.ExecuteReader(query, parameters))
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving bill details: {ex.Message}");
            }

            return dt;
        }

        public static DataTable GetPaymentHistory(int billId)
        {
            DataTable dt = new DataTable();

            try
            {
                string query = @"
                    SELECT 
                        date,
                        payment,
                        remarks
                    FROM supplierpricerecord
                    WHERE supplier_Bill_ID = @billId
                    ORDER BY date";

                MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@billId", billId)
                };

                using (var reader = DatabaseHelper.Instance.ExecuteReader(query, parameters))
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving payment history: {ex.Message}");
            }

            return dt;
        }
    }
}