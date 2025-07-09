using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KIMS;
using MySql.Data.MySqlClient;
using static TechStore.BL.Models.ServicesInvo;

namespace TechStore.DL
{
    internal class ServiceDL
    {
        public int InsertInvoice(ServiceInvoice invoice)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand("INSERT INTO service_invoices (customer_name, service_name, invoice_date) VALUES (@customer, @service, @date); SELECT LAST_INSERT_ID();", conn))
                {
                    cmd.Parameters.AddWithValue("@customer", invoice.CustomerName);
                    cmd.Parameters.AddWithValue("@service", invoice.ServiceName);
                    cmd.Parameters.AddWithValue("@date", invoice.InvoiceDate);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void InsertInvoiceItems(List<ServiceInvoiceItem> items)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                foreach (var item in items)
                {
                    using (var cmd = new MySqlCommand("INSERT INTO service_invoice_items (invoice_id, product_id, description, quantity, cost_price, total_price) VALUES (@invoiceId, @productId, @desc, @qty, @price, @total)", conn))
                    {
                        cmd.Parameters.AddWithValue("@invoiceId", item.InvoiceId);
                        cmd.Parameters.AddWithValue("@productId", item.ProductId);
                        cmd.Parameters.AddWithValue("@desc", item.Description);
                        cmd.Parameters.AddWithValue("@qty", item.Quantity);
                        cmd.Parameters.AddWithValue("@price", item.CostPrice);
                        cmd.Parameters.AddWithValue("@total", item.TotalPrice);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public int SaveInvoice(ServiceInvoice invoice)
        {
            int invoiceId = InsertInvoice(invoice);
            foreach (var item in invoice.Items)
            {
                item.InvoiceId = invoiceId;
            }
            InsertInvoiceItems(invoice.Items);
            return invoiceId;
        }

        public DataTable GetCustomers()
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                string query = "SELECT customer_id, first_name FROM customers";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetProducts()
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                
                string query = @"
            SELECT 
                p.product_id, 
                p.name, 
                p.description, 
                bd.sale_price
            FROM 
                products p
            LEFT JOIN 
                inventory bd ON p.product_id = bd.product_id
           
        ";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
}