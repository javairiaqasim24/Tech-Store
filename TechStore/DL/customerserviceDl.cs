using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;

namespace TechStore.DL
{
    public class CustomerserviceDl : ICustomerserviceDl
    {
        public bool SaveReceipt(customerservicerecipt receipt)
        {
            try
            {
                int customer_id = DatabaseHelper.Instance.getcustid(receipt.CustomerName);
                using (var conn = DatabaseHelper.Instance.GetConnection())
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        // 1. Insert into service_receipts
                        string insertReceiptQuery = @"
                            INSERT INTO service_receipts (customer_id, remarks, receipt_date)
                            VALUES (@customer_id, @remarks, NOW());
                            SELECT LAST_INSERT_ID();";

                        int receiptId;
                        using (var cmd = new MySqlCommand(insertReceiptQuery, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@customer_id", customer_id);
                            cmd.Parameters.AddWithValue("@remarks", receipt.Remarks ?? "");

                            receiptId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 2. Insert devices
                        foreach (var device in receipt.Devices)
                        {
                            string insertDeviceQuery = @"
                                INSERT INTO service_devices 
                                (receipt_id, device_name, issue_description, received_date, expected_return_date, status, service_charge)
                                VALUES 
                                (@receipt_id, @device_name, @issue, @report_date, @expected_date, @status, @service_charge);";

                            using (var cmd = new MySqlCommand(insertDeviceQuery, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@receipt_id", receiptId);
                                cmd.Parameters.AddWithValue("@device_name", device.DeviceName);
                                cmd.Parameters.AddWithValue("@issue", device.Issue ?? "");
                                cmd.Parameters.AddWithValue("@report_date", device.ReportDate);
                                cmd.Parameters.AddWithValue("@expected_date", device.ExpectedDate);
                                cmd.Parameters.AddWithValue("@status", device.Status ?? "Pending");
                                cmd.Parameters.AddWithValue("@service_charge", device.ServiceCharge);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving service receipt: " + ex.Message, ex);
            }
        }
    }
}
