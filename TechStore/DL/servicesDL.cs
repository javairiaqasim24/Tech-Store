using System;
using System.Data;
using System.Windows;
using KIMS;
using MySql.Data.MySqlClient;

namespace TechStore.DL
{
    public static class servicesDL
    {
        //public static int? GetCustomerIdByName(string customerName)
        //{
        //    string query = "SELECT customer_id FROM customers WHERE CONCAT(first_name, ' ', last_name) = @name LIMIT 1";

        //    using (var conn = DatabaseHelper.Instance.GetConnection())
        //    {
        //        conn.Open();
        //        using (var cmd = new MySqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@name", customerName);
        //            var result = cmd.ExecuteScalar();
        //            return result != null ? Convert.ToInt32(result) : (int?)null;
        //        }
        //    }
        //}

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

        public static DataTable GetAllCustomers()
        {
            string query = "SELECT CONCAT(first_name, ' ', last_name) AS name, address FROM customers";
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static int GetCustomerIdByName(string name)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = @"SELECT customer_id FROM customers
                         WHERE CONCAT(first_name, ' ', last_name) = @name";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return Convert.ToInt32(reader["customer_id"]);
                    }
                }
            }
            return -1; // Not found
        }

        //public static int InsertNewWalkInCustomer(string name)
        //{
        //    string[] parts = name.Split(' ');
        //    string firstName = parts[0];
        //    string lastName = parts.Length > 1 ? parts[1] : "";

        //    using (var conn = DatabaseHelper.Instance.GetConnection())
        //    {
        //        conn.Open();

        //        // 🔍 Step 1: Try to find the customer
        //        string checkQuery = @"SELECT customer_id FROM customers 
        //                      WHERE type = 'Walk-in' AND first_name = @first AND last_name = @last";

        //        using (var checkCmd = new MySqlCommand(checkQuery, conn))
        //        {
        //            checkCmd.Parameters.AddWithValue("@first", firstName);
        //            checkCmd.Parameters.AddWithValue("@last", lastName);

        //            object result = checkCmd.ExecuteScalar();
        //            if (result != null)
        //            {
        //                return Convert.ToInt32(result);  // ✅ Customer already exists
        //            }
        //        }

        //        // 🧾 Step 2: Insert if not found
        //        string insertQuery = @"INSERT INTO customers (type, first_name, last_name)
        //                       VALUES ('Walk-in', @first, @last);";

        //        using (var insertCmd = new MySqlCommand(insertQuery, conn))
        //        {
        //            insertCmd.Parameters.AddWithValue("@first", firstName);
        //            insertCmd.Parameters.AddWithValue("@last", lastName);
        //            insertCmd.ExecuteNonQuery();
        //        }

        //        // 🔁 Step 3: Return new inserted ID
        //        string idQuery = "SELECT LAST_INSERT_ID();";
        //        using (var idCmd = new MySqlCommand(idQuery, conn))
        //        {
        //            return Convert.ToInt32(idCmd.ExecuteScalar());
        //        }
        //    }
        //}

        // In your servicesDL class
        public static int InsertNewWalkInCustomer(string customerName)
        {
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = @"
                INSERT INTO customers (first_name, type) 
                VALUES (@name, 'Walk-in');
                SELECT LAST_INSERT_ID();";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", customerName);
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error
                MessageBox.Show("Error creating walk-in customer: " + ex.Message);
                Console.ReadKey();
                return -1;
            }
        }

    }
}
