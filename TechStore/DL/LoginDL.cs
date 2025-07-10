﻿using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using TechStore.BL.Models;

namespace TechStore.DL
{
    public static class LoginDL
    {
        public static bool ValidateUser(string username, string password)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                const string query = @"
                SELECT role, full_name 
                FROM users 
                WHERE username = @username AND password_hash = @password
                LIMIT 1;";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password); // You should hash this if you're using hash in DB

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                         Usersession.Role = reader.GetString("role");
                           Usersession.FullName = reader.GetString("full_name");
                            return true;
                        }
                        return false;
                    }
                }
            }
        }
    }

}
