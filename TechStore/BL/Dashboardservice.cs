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
                returns = idl.totalreturns()


            };
        }
    }
}
