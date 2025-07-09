using System;
using System.Data;
using KIMS;
using MySql.Data.MySqlClient;

namespace TechStore.DL
{
    public static class LoginDL
    {
        public static string ValidateUser(string username, string password)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                const string query = @"
    SELECT role 
    FROM users 
    WHERE username = @username
    LIMIT 1;";


                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password); 

                    object result = cmd.ExecuteScalar();

                    return result != null ? result.ToString() : null;
                }
            }
        }
    }
}
