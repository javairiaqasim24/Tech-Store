using System;
using System.Data;
using KIMS;
using MySql.Data.MySqlClient;

namespace TechStore.DAL
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
    }
}
