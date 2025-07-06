using System.Data;
using TechStore.DL;

namespace TechStore.BL
{
    public static class SupplierBillingRecordsOverviewBL
    {
        public static DataTable GetSupplierBills(string searchTerm = "")
        {
            return SupplierBillingRecordsOverviewDL.GetSupplierBills(searchTerm);
        }

        public static DataTable GetBillDetails(int billId)
        {
            return SupplierBillingRecordsOverviewDL.GetBillDetails(billId);
        }

        public static DataTable GetPaymentHistory(int billId)
        {
            return SupplierBillingRecordsOverviewDL.GetPaymentHistory(billId);
        }

        public static decimal CalculatePendingAmount(decimal totalPrice, decimal paidAmount)
        {
            return totalPrice - paidAmount;
        }
    }
}