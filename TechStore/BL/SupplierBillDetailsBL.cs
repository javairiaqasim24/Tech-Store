using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using TechStore.BL.Models;

namespace TechStore
{
    public static class SupplierBillDetailsBL
    {
        public static List<SupplierBillProduct> GetBillProducts(int supplierBillId)
        {
            var products = new List<SupplierBillProduct>();

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
                    while (reader.Read())
                    {
                        products.Add(new SupplierBillProduct
                        {
                            ProductId = Convert.ToInt32(reader["product_id"]),
                            ProductName = reader["name"].ToString(),
                            Quantity = Convert.ToInt32(reader["quantity"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving bill products: {ex.Message}");
            }

            return products;
        }

        public static List<SupplierPayment> GetPaymentHistory(int supplierBillId)
        {
            var payments = new List<SupplierPayment>();

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
                    while (reader.Read())
                    {
                        payments.Add(new SupplierPayment
                        {
                            Date = Convert.ToDateTime(reader["date"]),
                            Amount = Convert.ToDecimal(reader["payment"]),
                            Remarks = reader["remarks"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving payment history: {ex.Message}");
            }

            return payments;
        }

        public static BillAmountInfo GetBillAmounts(int supplierBillId)
        {
            var billInfo = new BillAmountInfo();

            try
            {
                string query = @"
                    SELECT total_price, paid_amount, (total_price - paid_amount) as pending_amount
                    FROM supplierbills
                    WHERE supplier_Bill_ID = @supplierBillId";

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@supplierBillId", supplierBillId)
                };

                using (var reader = DatabaseHelper.Instance.ExecuteReader(query, parameters))
                {
                    if (reader.Read())
                    {
                        billInfo.TotalAmount = reader["total_price"] != DBNull.Value ? Convert.ToDecimal(reader["total_price"]) : 0;
                        billInfo.PaidAmount = reader["paid_amount"] != DBNull.Value ? Convert.ToDecimal(reader["paid_amount"]) : 0;
                        billInfo.PendingAmount = reader["pending_amount"] != DBNull.Value ? Convert.ToDecimal(reader["pending_amount"]) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error calculating bill amounts: {ex.Message}");
            }

            return billInfo;
        }
    }

    public class SupplierBillProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }

    public class SupplierPayment
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
    }

    public class BillAmountInfo
    {
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal PendingAmount { get; set; }
    }
}