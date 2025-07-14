using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models
{
    public class Inventory
    {

        public int InventoryId { get; private set; }
        public decimal SalePrice { get; private set; }
        public int Stock { get; private set; }

        // Expose only what you want
        public int ProductId {get;set;}
        public string ProductName {  get; set;}
        public string description { get; set;}

        // Constructor
        public Inventory(int inventoryId, decimal salePrice, int stock, int productId, string productName,string description)
        {
            this.InventoryId = inventoryId;
            this.SalePrice = salePrice;
            this.Stock = stock;
            this.ProductId = productId;
            this.ProductName= productName;
            this.description = description;

        }

      
    }

}
