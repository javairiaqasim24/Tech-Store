using System.Configuration; // Required for reading from App.config
using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Windows;
using System.Collections.Generic;

namespace KIMS
{
    public class DatabaseHelper
    {
        public static MySqlConnection GetConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            return new MySqlConnection(connStr);
        }

        public static MySqlDataReader ExecuteReader(string query, MySqlParameter[] parameters = null)
        {
            var conn = GetConnection();
            conn.Open();
            var cmd = new MySqlCommand(query, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static int GetLastInsertId()
        {
            string query = "SELECT LAST_INSERT_ID();";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static int ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static int getcategoryid(string name)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT category_id FROM categories WHERE name = @name;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
throw new Exception("Error retrieving category ID: " + ex.Message);
            }
        }
        public static List<string> GetCategories(string keyword)
        {
            List<string> categories = new List<string>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT name FROM categories WHERE name LIKE @keyword;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categories.Add(reader.GetString("name"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving categories: " + ex.Message);
            }
            return categories;
        }
        public static List<string> Getsuppliers(string keyword)
        {
            List<string> categories = new List<string>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT name FROM suppliers WHERE name LIKE @keyword;";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categories.Add(reader.GetString("name"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving categories: " + ex.Message);
            }
            return categories;
        }

    }
}