using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;
using TechStore.Interfaces.BLInterfaces;

namespace TechStore.Interfaces.DLInterfaces
{
    public class FinancialReportDL : IFinancialReportDL
    {
        public FinancialReportModel FetchReport(int? month, int year)
        {
            var report = new FinancialReportModel();

            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();

                string dateCondition = month.HasValue
                    ? "MONTH(saledate) = @month AND YEAR(saledate) = @year"
                    : "YEAR(saledate) = @year";

                // Total Revenue
                using (var cmd = new MySqlCommand($"SELECT IFNULL(SUM(total_price), 0) FROM customerbills WHERE {dateCondition}", conn))
                {
                    if (month.HasValue) cmd.Parameters.AddWithValue("@month", month.Value);
                    cmd.Parameters.AddWithValue("@year", year);
                    report.TotalRevenue = Convert.ToDecimal(cmd.ExecuteScalar());
                }

                // Customer Received
                using (var cmd = new MySqlCommand($"SELECT IFNULL(SUM(paid_amount), 0) FROM customerbills WHERE {dateCondition}", conn))
                {
                    if (month.HasValue) cmd.Parameters.AddWithValue("@month", month.Value);
                    cmd.Parameters.AddWithValue("@year", year);
                    report.CustomerReceived = Convert.ToDecimal(cmd.ExecuteScalar());
                }

                // Customer Dues
                using (var cmd = new MySqlCommand($"SELECT IFNULL(SUM(total_price - paid_amount), 0) FROM customerbills WHERE payment_status != 'Paid' AND {dateCondition}", conn))
                {
                    if (month.HasValue) cmd.Parameters.AddWithValue("@month", month.Value);
                    cmd.Parameters.AddWithValue("@year", year);
                    report.CustomerDues = Convert.ToDecimal(cmd.ExecuteScalar());
                }

                // Total Purchases
                dateCondition = month.HasValue
                    ? "MONTH(date) = @month AND YEAR(date) = @year"
                    : "YEAR(date) = @year";

                using (var cmd = new MySqlCommand($"SELECT IFNULL(SUM(total_price), 0) FROM supplierbills WHERE {dateCondition}", conn))
                {
                    if (month.HasValue) cmd.Parameters.AddWithValue("@month", month.Value);
                    cmd.Parameters.AddWithValue("@year", year);
                    report.TotalPurchases = Convert.ToDecimal(cmd.ExecuteScalar());
                }

                // Supplier Paid
                using (var cmd = new MySqlCommand($"SELECT IFNULL(SUM(paid_amount), 0) FROM supplierbills WHERE {dateCondition}", conn))
                {
                    if (month.HasValue) cmd.Parameters.AddWithValue("@month", month.Value);
                    cmd.Parameters.AddWithValue("@year", year);
                    report.SupplierPaid = Convert.ToDecimal(cmd.ExecuteScalar());
                }

                // Supplier Dues
                using (var cmd = new MySqlCommand($"SELECT IFNULL(SUM(total_price - paid_amount), 0) FROM supplierbills WHERE payment_status != 'Paid' AND {dateCondition}", conn))
                {
                    if (month.HasValue) cmd.Parameters.AddWithValue("@month", month.Value);
                    cmd.Parameters.AddWithValue("@year", year);
                    report.SupplierDues = Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }

            return report;
        }
    }

    }

