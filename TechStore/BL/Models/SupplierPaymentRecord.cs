using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models
{
    public class SupplierPaymentRecord
    {
        public int RecordId { get; set; }
        public int SupplierId { get; set; }
        public int SupplierBillId { get; set; }
        public DateTime Date { get; set; }
        public decimal Payment { get; set; }
        public string Remarks { get; set; }
    }
}
