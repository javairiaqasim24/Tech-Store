using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace TechStore.DL
{
    public class CustomerBill_SpecificProductsDL
    {
        private readonly DatabaseHelper _dbHelper;

        public CustomerBill_SpecificProductsDL()
        {
            _dbHelper = DatabaseHelper.Instance;
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
                i.sale_price AS UnitPrice,
                (i.sale_price * cbd.quantity) AS TotalPrice,
                cbd.discount,
                cbd.status,
                cbd.warranty,
                DATE_FORMAT(cbd.warranty_from, '%d-%m-%Y') AS WarrantyStart,
                DATE_FORMAT(cbd.warranty_till, '%d-%m-%Y') AS WarrantyEnd
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

        public DataTable GetBillSummary(int billId)
        {
            DataTable dt = new DataTable();

            try
            {
                string query = @"
                    SELECT 
                        cb.BillID,
                        CONCAT(c.first_name, ' ', c.last_name) AS CustomerName,
                        cb.SaleDate,
                        cb.total_price AS TotalAmount,
                        cb.paid_amount AS PaidAmount,
                        (cb.total_price - IFNULL(cb.paid_amount, 0)) AS PendingAmount,
                        cb.payment_status
                    FROM 
                        customerbills cb
                    JOIN 
                        customers c ON cb.CustomerID = c.customer_id
                    WHERE 
                        cb.BillID = @billId";

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
                throw new Exception("Error retrieving bill summary: " + ex.Message);
            }

            return dt;
        }
    }
}