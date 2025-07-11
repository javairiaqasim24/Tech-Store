using System;
using System.Data;
using KIMS;
using MySql.Data.MySqlClient;

namespace TechStore.DL
{
    public static class servicesDL
    {
        public static int? GetCustomerIdByName(string customerName)
        {
            string query = "SELECT customer_id FROM customers WHERE CONCAT(first_name, ' ', last_name) = @name LIMIT 1";

            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", customerName);
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : (int?)null;
                }
            }
        }

        public static bool InsertService(int customerId, string itemName, string description, DateTime receiveDate, DateTime deliveryDate)
        {
            string query = @"INSERT INTO service_line (customer_id, nameofitem, description, recievedate, deliverydate)
                             VALUES (@customer_id, @item, @desc, @rec, @deliv)";

            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customer_id", customerId);
                    cmd.Parameters.AddWithValue("@item", itemName);
                    cmd.Parameters.AddWithValue("@desc", description);
                    cmd.Parameters.AddWithValue("@rec", receiveDate);
                    cmd.Parameters.AddWithValue("@deliv", deliveryDate);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
