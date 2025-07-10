using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;

namespace TechStore.Interfaces
{
    public interface Idashboard
    {
        DashboardModel GetDashboardSummary();
        List<(DateTime Day, decimal TotalSales)> GetMonthlySalesTrend();
        List<(string Category, int ProductCount)> GetProductCategoryDistribution();
        List<(string SupplierName, int TotalBatches)> GetTopSupplierContributions();
        List<(string MonthName, decimal TotalSales)> GetMonthlySalesComparison();
        List<Products> outofstock();
        List<inventorylog> recentlogs();
    }
}