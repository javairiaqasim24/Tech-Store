using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;
using TechStore.DL;
using TechStore.Interfaces;

namespace TechStore.BL
{
    public class Dashboardservice : Idashboard
    {
        private readonly DashboardDl idl;
        public Dashboardservice(DashboardDl idl)
        {
            this.idl = idl;
        }
        public DashboardModel GetDashboardSummary()
        {
            return new DashboardModel
            {
                totalproducts = idl.totalproducts(),
                totalcustomers = idl.totalcustomers(),
                totalsuppliers = idl.totalsuppliers(),
                bestproduct = idl.bestproduct(),
                salestodays = idl.salestoday(),
                returns = idl.totalreturns(),
                pendingbills=idl.getpendingbills()
                

            };
        }

        public List<(string MonthName, decimal TotalSales)> GetMonthlySalesComparison()
        {
            return idl.GetMonthlySalesComparison();
        }

        public List<(DateTime Day, decimal TotalSales)> GetMonthlySalesTrend()
        {
            return idl.GetMonthlySalesTrend();
        }

        public List<(string Category, int ProductCount)> GetProductCategoryDistribution()
        {
            return idl.GetProductCategoryDistribution();        
        }

        public List<(string SupplierName, int TotalBatches)> GetTopSupplierContributions()
        {
            return idl.GetTopSupplierContributions();
        }

        public List<Products> outofstock()
        {
            return idl.outofstock();
        }

        public List<inventorylog> recentlogs()
        {
            return idl.recentlogs();
        }
    }
}
