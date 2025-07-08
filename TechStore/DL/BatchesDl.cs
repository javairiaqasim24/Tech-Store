using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;

namespace TechStore.DL
{
    public class BatchesDl : IBatchesDl
    {
        public bool addbatches(Batches b)
        {
            int supplier_id = DatabaseHelper.Instance.getsuppierid(b.supplier_name);
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO batches (batch_name, supplier_id, recieved_date) VALUES (@batch_name, @supplier_id, @batch_date);";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@batch_name", b.batch_name);
                        cmd.Parameters.AddWithValue("@supplier_id", supplier_id);
                        cmd.Parameters.AddWithValue("@batch_date", b.batch_date);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding batch: " + ex.Message, ex);
            }

        }
        public List<string> getsuppliernames(string name)
        {
            try
            {
                return DatabaseHelper.Instance.GetSuppliers(name);
            }
            catch
            {
                throw new ArgumentException("error getting suppliers");
            }
        }
        public List<Batches> getbatches()
        {
            var list = new List<Batches>();
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = "select b.batch_id ,b.batch_name,b.recieved_date,s.name from batches b join suppliers s on s.supplier_id=b.supplier_id; ";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var batches = new Batches(reader.GetInt32("batch_id"), reader.GetString("batch_name"), reader.GetString("name"), reader.GetDateTime("recieved_date"));
                                list.Add(batches);
                            }

                        }
                    }
                    return list;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }
        public List<Batches> GetBatches(string searchTerm)
        {
            var list = new List<Batches>();

            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT b.batch_id, b.batch_name, b.recieved_date, s.name
                FROM batches b
                JOIN suppliers s ON s.supplier_id = b.supplier_id
                WHERE b.batch_name LIKE @search OR s.name LIKE @search;";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var batch = new Batches(
                                    reader.GetInt32("batch_id"),
                                    reader.GetString("batch_name"),
                                    reader.GetString("name"),
                                    reader.GetDateTime("recieved_date")
                                );
                                list.Add(batch);
                            }
                        }
                    }
                }

                return list;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error retrieving batches: " + ex.Message, ex);
            }
        }

    }
}
