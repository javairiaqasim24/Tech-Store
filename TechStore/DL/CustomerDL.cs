using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models.Person;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TechStore.DL
{
    public class CustomerDL : ICustomerDL
    {
        public bool Addcustomer(Customer c)
        {
            try
            {
                using(var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO customers (first_name, last_name, type, email, phone, address) VALUES (@first, @last, @type, @email, @phone, @address);";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@first", c.firstName);
                        cmd.Parameters.AddWithValue("@last", c.lastName);
                        cmd.Parameters.AddWithValue("@type", c.type);
                        cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(c.email) ? (object)DBNull.Value : c.email);
                        cmd.Parameters.AddWithValue("@phone", c.phone);
                        cmd.Parameters.AddWithValue("@address", string.IsNullOrEmpty(c.address) ? (object)DBNull.Value : c.address);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Database error occurred while adding customer: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding customer: " + ex.Message, ex);
            }
        }
        public bool Updatecustomer(Customer c)
        {
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE customers SET first_name = @first_name, last_name = @last_name, type = @type, email = @email, phone = @phone, address = @address WHERE customer_id = @id;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@first_name", c.firstName);
                        cmd.Parameters.AddWithValue("@last_name", c.lastName);
                        cmd.Parameters.AddWithValue("@type", c.type);
                        cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(c.email) ? (object)DBNull.Value : c.email);
                        cmd.Parameters.AddWithValue("@phone", c.phone);
                        cmd.Parameters.AddWithValue("@address", string.IsNullOrEmpty(c.address) ? (object)DBNull.Value : c.address);
                        cmd.Parameters.AddWithValue("@id", c.id);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Database error occurred while updating customer: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating customer: " + ex.Message, ex);
            }
        }
        public bool Deletecustomer(int id)
        {
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM customers WHERE customer_id = @id;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Database error occurred while deleting customer: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting customer: " + ex.Message, ex);
            }
        }
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                 
                    conn.Open();
                    string query = "SELECT * FROM customers;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer
                                (
                                     reader.GetInt32("customer_id"),
                                    reader.IsDBNull(reader.GetOrdinal("email")) ? "" : reader.GetString("email"),
                                 reader.IsDBNull(reader.GetOrdinal("address")) ? "" : reader.GetString("address"),

                                reader.GetString("first_name"),
                                    reader.GetString("last_name"),
                                    reader.GetString("type"),
                                    reader.GetString("phone")
                                );
                                customers.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving customers: " + ex.Message, ex);
            }
            return customers;
        }
        public List<Customer> Searchcustomers(string keyword)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT * FROM customers 
                WHERE first_name LIKE @keyword 
                   OR last_name LIKE @keyword 
                   OR type LIKE @keyword;
            ";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer
                                (
                                    reader.GetInt32("customer_id"),
                                        reader.IsDBNull(reader.GetOrdinal("email")) ? "" : reader.GetString("email"),
                                 reader.IsDBNull(reader.GetOrdinal("address")) ? "" : reader.GetString("address"),
                                    reader.GetString("first_name"),
                                    reader.GetString("last_name"),
                                    reader.GetString("type"),
                                    reader.GetString("phone")
                                );
                                customers.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching customers: " + ex.Message, ex);
            }
            return customers;
        }

    }
}
