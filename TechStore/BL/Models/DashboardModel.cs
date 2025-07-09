using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models
{
    public  class DashboardModel
    {
        public int totalproducts { get; set; }
        public int totalcustomers {  get; set; }
        public int salestodays { get; set; }
        //public int repairs { get; set; }
        public int totalsuppliers { get; set; }
        public string bestproduct { get; set; }
        public int returns{ get; set; }
        public int pendingbills { get; set; }
        public DashboardModel() { }
    }
}
