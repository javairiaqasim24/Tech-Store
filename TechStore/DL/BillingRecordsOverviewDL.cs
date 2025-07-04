using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace TechStore.DL
{
    public class BillingRecordsOverviewDL
    {
        private readonly DatabaseHelper _dbHelper;

        public BillingRecordsOverviewDL()
        {
            _dbHelper = DatabaseHelper.Instance;
        }

        public DataTable GetCustomerBillingRecords(string searchTerm = "")
        {
            DataTable dt = new DataTable();

            try
            {
                string query = @"
            SELECT 
                cb.BillID,
                CONCAT(c.first_name, ' ', c.last_name) AS CustomerName,
                c.phone AS CustomerPhone,
                DATE_FORMAT(cb.SaleDate, '%d-%m-%Y %h:%i %p') AS SaleDate,
                CAST(cb.total_price AS DECIMAL(12,2)) AS TotalAmount,
                CAST(IFNULL(cb.paid_amount, 0) AS DECIMAL(12,2)) AS PaidAmount,
                CAST((cb.total_price - IFNULL(cb.paid_amount, 0)) AS DECIMAL(12,2)) AS DueAmount,
                CASE 
                    WHEN (cb.total_price - IFNULL(cb.paid_amount, 0)) <= 0 THEN 'Paid'
                    ELSE 'Due'
                END AS payment_status
            FROM 
                customerbills cb
            JOIN 
                customers c ON cb.CustomerID = c.customer_id
            WHERE 
                cb.BillID LIKE @searchTerm OR
                CONCAT(c.first_name, ' ', c.last_name) LIKE @searchTerm OR
                c.phone LIKE @searchTerm OR
                cb.SaleDate LIKE @searchTerm
            ORDER BY 
                cb.SaleDate DESC";

                using (var conn = _dbHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving billing records: " + ex.Message);
            }

            return dt;
        }

        public DataTable GetBillDetails(int billId)
        {
            DataTable dt = new DataTable();

            try
            {
                string query = @"
                    SELECT 
                        p.name AS ProductName,
                        cbd.quantity,
                        p.description AS ProductDescription,
                        (i.sale_price * cbd.quantity) AS TotalPrice,
                        cbd.discount,
                        cbd.status,
                        cbd.warranty,
                        cbd.warranty_from,
                        cbd.warranty_till
                    FROM 
                        customer_bill_details cbd
                    JOIN 
                        products p ON cbd.product_id = p.product_id
                    JOIN 
                        inventory i ON p.product_id = i.product_id
                    WHERE 
                        cbd.Bill_id = @billId";

                using (var conn = _dbHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@billId", billId);

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving bill details: " + ex.Message);
            }

            return dt;
        }

        public DataTable GetPaymentHistory(int billId)
        {
            DataTable dt = new DataTable();

            try
            {
                string query = @"
                    SELECT 
                        date AS PaymentDate,
                        payment AS Amount,
                        BillID
                    FROM 
                        customerpricerecord
                    WHERE 
                        BillID = @billId
                    ORDER BY 
                        date DESC";

                using (var conn = _dbHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@billId", billId);

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving payment history: " + ex.Message);
            }

            return dt;
        }
    }
}