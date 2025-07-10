using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models
{
    public class Inventory
    {
        private readonly Products product; 

        public int InventoryId { get; private set; }
        public decimal SalePrice { get; private set; }
        public int Stock { get; private set; }

        // Expose only what you want
        public int ProductId => product.id;
        public string ProductName => product.name;
        public string description=> product.description;

        // Constructor
        public Inventory(int inventoryId, decimal salePrice, int stock, int productId, string productName,string description)
        {
            this.InventoryId = inventoryId;
            this.SalePrice = salePrice;
            this.Stock = stock;

            this.product = new Products(productId, productName,description);
        }

      
    }

}
