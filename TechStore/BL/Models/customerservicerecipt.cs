using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models
{
    public  class customerservicerecipt
    {
        public int ReceiptId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } // optional, just for display
        public string Remarks { get; set; }
        public List<servicedevices> Devices { get; set; } = new List<servicedevices>();
    }
}
