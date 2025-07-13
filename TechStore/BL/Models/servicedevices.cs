using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models
{
    public  class servicedevices
    {
        public int DeviceId { get; set; }
        public int ReceiptId { get; set; }  // will be assigned when saving
        public string DeviceName { get; set; }
        public string Issue { get; set; }
        public DateTime ReportDate { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string Status { get; set; } = "Pending";
        public decimal ServiceCharge { get; set; } = 0;
    }
}
