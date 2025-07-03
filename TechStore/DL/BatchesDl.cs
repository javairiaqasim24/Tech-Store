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
    }
}
