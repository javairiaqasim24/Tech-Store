using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TechStore.DL
{
    public class service_partsDl : Iservice_partsDl
    {
        public List<servicedevices> search_device(int receipt_id)
        {
            return DatabaseHelper.Instance.search_device(receipt_id);
        }

        public bool InsertServicePartsAndUpdateCharges(List<service_parts> parts, decimal laborCharge)
        {
            if (parts == null || parts.Count == 0)
                return false;
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        int deviceId = parts[0].device_id;
                        decimal totalPartsCost = 0;

                        foreach (var part in parts)
                        {
                            totalPartsCost += part.price;
                            int productid = DatabaseHelper.Instance.getproductid(part.product_name);

                            string insertPartQuery = @"INSERT INTO service_parts 
                        (device_id, product_id, quantity, price) 
                        VALUES (@device_id, @product_id, @quantity, @price);";

                            using (var cmd = new MySqlCommand(insertPartQuery, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@device_id", part.device_id);
                                cmd.Parameters.AddWithValue("@product_id",productid);
                                cmd.Parameters.AddWithValue("@quantity", part.quantity);
                                cmd.Parameters.AddWithValue("@price", part.price);
                                cmd.ExecuteNonQuery();
                            }

                            // Update inventory
                            string updateInventoryQuery = @"UPDATE inventory SET quantity_in_stock = quantity_in_stock - @qty 
                        WHERE product_id = @product_id;";

                            using (var cmd = new MySqlCommand(updateInventoryQuery, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@qty", part.quantity);
                                cmd.Parameters.AddWithValue("@product_id", productid);
                                cmd.ExecuteNonQuery();
                            }

                            // Log inventory change
                            string logQuery = @"INSERT INTO inventory_log 
                        (product_id, change_type, quantity_change, log_date, remarks) 
                        VALUES 
                        (@product_id, 'used_in_service', -@qty, NOW(), 'Used in service device ID: @device_id');";

                            using (var cmd = new MySqlCommand(logQuery, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@product_id", productid);
                                cmd.Parameters.AddWithValue("@qty", part.quantity);
                                cmd.Parameters.AddWithValue("@device_id", part.device_id);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Update service_charge and labor_charge in service_devices
                        string updateDeviceQuery = @"UPDATE service_devices 
                        SET service_charge = @parts_charge, labor_charge = @labor_charge 
                        WHERE device_id = @device_id;";

                        using (var cmd = new MySqlCommand(updateDeviceQuery, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@parts_charge", totalPartsCost == 0 ? (object)DBNull.Value : totalPartsCost);
                            cmd.Parameters.AddWithValue("@labor_charge", laborCharge);
                            cmd.Parameters.AddWithValue("@device_id", deviceId);
                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving service parts: " + ex.Message, ex);
            }
        }
        public bool FinalizeReceiptBill(int receiptId, decimal paidAmount)
        {
            try
            {
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        // 1. Sum total charges from service_devices
                        string sumQuery = @"
                    SELECT COALESCE(SUM(service_charge + labor_charge), 0)
                    FROM service_devices
                    WHERE receipt_id = @receipt_id";

                        decimal totalAmount = 0;
                        using (var cmd = new MySqlCommand(sumQuery, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@receipt_id", receiptId);
                            totalAmount = Convert.ToDecimal(cmd.ExecuteScalar());
                        }

                        // 2. Update service_receipts with total & paid amount
                        string updateReceipt = @"
                    UPDATE service_receipts
                    SET total_amount = @total, amount_paid = @paid, payment_status = @status
                    WHERE receipt_id = @receipt_id;";

                        using (var cmd = new MySqlCommand(updateReceipt, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@total", totalAmount);
                            cmd.Parameters.AddWithValue("@paid", paidAmount);
                            cmd.Parameters.AddWithValue("@status", paidAmount >= totalAmount ? "Paid" : "Due");
                            cmd.Parameters.AddWithValue("@receipt_id", receiptId);
                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error finalizing receipt bill: " + ex.Message);
            }
        }


    }
}
