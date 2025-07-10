using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models
{
    public class FinancialReportModel
    {
        public decimal TotalRevenue { get; set; }
        public decimal CustomerReceived { get; set; }
        public decimal CustomerDues { get; set; }
        public decimal TotalPurchases { get; set; }
        public decimal SupplierPaid { get; set; }
        public decimal SupplierDues { get; set; }
        public decimal GrossProfit => TotalRevenue - TotalPurchases;
    }
}
