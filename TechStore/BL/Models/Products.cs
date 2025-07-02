using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models
{
    public class Products
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public string sku { get; private set; }
        public string description { get; private set; }
        public string category { get; private set; }
        public  int? quantity { get;  private set; } 
        public double? price { get; private set; }
        public Products(int id, string name, string sku, string description, string category, int? quantity, double? price)
        {
            this.id = id;
            this.name = name;
            this.sku = sku;
            this.description = description;
            this.category = category;
            this.quantity = quantity;
            this.price = price;
        }
        public Products(string name, string sku, string description, string category,int? quantity,double? price)
        {
            this.name = name;
            this.sku = sku;
            this.description = description;
            this.category = category;
            this.quantity = quantity;
            this.price = price;
        }
        public Products((int, string, string, string, int?, double?) value)
        {
        }
    }
}
