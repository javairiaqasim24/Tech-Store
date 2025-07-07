using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;
using TechStore.BL.Models.Person;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TechStore.DL
{
    public class CustomerDL : ICustomerDL
    {
        public bool Addcustomer(Ipersons c)
        {
            try
            {
                Customer customer = c as Customer;
                if (customer == null)
                    throw new ArgumentException("Expected Customer object.");


                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO customers (first_name, last_name, type, email, phone, address) VALUES (@first, @last, @type, @email, @phone, @address);";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@first", customer._firstName);
                        cmd.Parameters.AddWithValue("@last", customer._lastName);
                        cmd.Parameters.AddWithValue("@type", customer._type);
                        cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(customer.email) ? (object)DBNull.Value : customer.email);
                        cmd.Parameters.AddWithValue("@phone", customer.phone);
                        cmd.Parameters.AddWithValue("@address", string.IsNullOrEmpty(customer.address) ? (object)DBNull.Value : customer.address);

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

        public bool Updatecustomer(Ipersons c)
        {
            try
            {
                Customer customer = c as Customer;
                if (customer == null)
                    throw new ArgumentException("Expected Customer object.");

                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE customers SET first_name = @first_name, last_name = @last_name, type = @type, email = @email, phone = @phone, address = @address WHERE customer_id = @id;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@first_name",customer._firstName);
                        cmd.Parameters.AddWithValue("@last_name", customer._lastName);
                        cmd.Parameters.AddWithValue("@type", customer._type);
                        cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(customer.email) ? (object)DBNull.Value : customer.email);
                        cmd.Parameters.AddWithValue("@phone", c.phone);
                        cmd.Parameters.AddWithValue("@address", string.IsNullOrEmpty(customer.address) ? (object)DBNull.Value : customer.address);
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
        public List<Ipersons> GetCustomers()
        {
            List<Ipersons> customers = new List<Ipersons>();
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
                                Ipersons customer = new Customer
                                (
                                     reader.GetInt32("customer_id"),
                                    reader.IsDBNull(reader.GetOrdinal("email")) ? "" : reader.GetString("email"),
                                 reader.IsDBNull(reader.GetOrdinal("address")) ? "" : reader.GetString("address"),

                                reader.GetString("first_name"),
                                    reader.GetString("last_name"),
                                    reader.GetString("type"),
                                    reader.IsDBNull(reader.GetOrdinal("phone"))?"":reader.GetString("phone")
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
        public List<Ipersons> Searchcustomers(string keyword)
        {
            List<Ipersons> customers = new List<Ipersons>();
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
                                var customer = new Customer
                                (
                                    reader.GetInt32("customer_id"),
                                        reader.IsDBNull(reader.GetOrdinal("email")) ? "" : reader.GetString("email"),
                                 reader.IsDBNull(reader.GetOrdinal("address")) ? "" : reader.GetString("address"),
                                    reader.GetString("first_name"),
                                    reader.GetString("last_name"),
                                    reader.GetString("type"),
                                    reader.IsDBNull(reader.GetOrdinal("phone")) ? "" : reader.GetString("phone")
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
