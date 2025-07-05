using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models
{
    public class SupplierBillDetail
    {
        public int BillDetailId { get; set; }
        public int SupplierBillId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
