using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models
{
    public class TempInvoiceData
    {
        public string SupplierName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public List<InvoiceItem> Items { get; set; }
    }

    public class InvoiceItem
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
