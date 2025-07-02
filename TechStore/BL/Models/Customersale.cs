using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;

namespace TechStore.BL.Models.Person
{
    public class Customersale : Products
    {
        public string sku { get; private set; }
        public int? quantity { get; private set; }
        public double? price { get; private set; }

        // Constructor: With ID and all fields
        public Customersale(int id, string name, string sku, string description, string category, int? quantity , double? price)
            : base(id, name, description, category)
        {
            this.sku = sku;
            this.quantity = quantity;
            this.price = price;
        }

        // Constructor: Without ID (for inserting new sale)
        public Customersale(string name, string sku, string description, string category, int? quantity, double? price)
            : base(name, description, category)
        {
            this.sku = sku;
            this.quantity = quantity;
            this.price = price;
        }

        // Constructor: Tuple-based
        public Customersale((int, string, string, string, int?, double?) value)
            : base(value)
        {
            this.quantity = value.Item5 ?? 0;
            this.price = value.Item6 ?? 0;
        }
    }
}
