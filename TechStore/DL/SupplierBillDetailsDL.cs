using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace TechStore
{
    public static class SupplierBillDetailsDL
    {
        public static DataTable GetSupplierBillProducts(int supplierBillId)
        {
            DataTable dt = new DataTable();

            try
            {
                string query = @"
                    SELECT p.product_id, p.name, sbd.quantity 
                    FROM supplier_bill_details sbd
                    JOIN products p ON sbd.product_id = p.product_id
                    WHERE sbd.supplier_Bill_ID = @supplierBillId";

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@supplierBillId", supplierBillId)
                };

                using (var reader = DatabaseHelper.Instance.ExecuteReader(query, parameters))
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving bill products: {ex.Message}");
            }

            return dt;
        }

        public static DataTable GetSupplierPaymentHistory(int supplierBillId)
        {
            DataTable dt = new DataTable();

            try
            {
                string query = @"
                    SELECT date, payment, remarks 
                    FROM supplierpricerecord
                    WHERE supplier_Bill_ID = @supplierBillId
                    ORDER BY date DESC";

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@supplierBillId", supplierBillId)
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

        public static decimal GetSupplierBillTotalAmount(int supplierBillId)
        {
            try
            {
                string query = "SELECT total_price FROM supplierbills WHERE supplier_Bill_ID = @supplierBillId";

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@supplierBillId", supplierBillId)
                };

                using (var reader = DatabaseHelper.Instance.ExecuteReader(query, parameters))
                {
                    if (reader.Read())
                    {
                        return reader["total_price"] != DBNull.Value ? Convert.ToDecimal(reader["total_price"]) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving total amount: {ex.Message}");
            }

            return 0;
        }

        public static decimal GetSupplierBillPaidAmount(int supplierBillId)
        {
            try
            {
                string query = "SELECT paid_amount FROM supplierbills WHERE supplier_Bill_ID = @supplierBillId";

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@supplierBillId", supplierBillId)
                };

                using (var reader = DatabaseHelper.Instance.ExecuteReader(query, parameters))
                {
                    if (reader.Read())
                    {
                        return reader["paid_amount"] != DBNull.Value ? Convert.ToDecimal(reader["paid_amount"]) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving paid amount: {ex.Message}");
            }

            return 0;
        }
    }
}