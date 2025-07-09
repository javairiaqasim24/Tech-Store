using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models
{
    internal class ServicesInvo
    {
        public class ServiceInvoice
        {
            public int InvoiceId { get; set; }
            public string CustomerName { get; set; }
            public string ServiceName { get; set; }
            public DateTime InvoiceDate { get; set; }
            public List<ServiceInvoiceItem> Items { get; set; } = new List<ServiceInvoiceItem>();
        }

        public class ServiceInvoiceItem
        {
            public int ItemId { get; set; }
            public int InvoiceId { get; set; }
            public int ProductId { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
            public int CostPrice { get; set; }
            public int TotalPrice => CostPrice * Quantity;
        }
    }
}
