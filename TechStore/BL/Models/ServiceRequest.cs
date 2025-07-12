using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models
{
    public class ServiceRequest
    {
        public int ServiceRequestId { get; set; }
        public int ServiceId { get; set; }
        public string Status { get; set; }
        public string ProblemDescription { get; set; }
        public string Solution { get; set; }
        public decimal TotalCharge { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentStatus { get; set; }
        public ServiceLine ServiceLine { get; set; }
    }
}
