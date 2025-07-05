using System;

namespace TechStore.BL.Models
{
    public class Supplierreturn
    {
        public int bill_detail_id { get; private set; }
        public Products p { get; private set; }
        public DateTime return_date { get; private set; }
        public string action_taken { get; private set; }
        public string sku { get; private set; }
        public decimal amount { get;set; }
        public int quantity { get; set; }

        // These are derived properties, no need to store separately
        public string name => p?.name;
        public string description => p?.description;
        public int product_id => p?.id ?? -1;

        public Supplierreturn(
            int bill_detail_id,
            DateTime return_date,
            string action_taken,
            string sku,
            string name,
            string description,
            decimal amount,
            int quantity,
            int id)
        {
            this.bill_detail_id = bill_detail_id;
            this.return_date = return_date;
            this.action_taken = action_taken;
            this.sku = sku;
            this.amount = amount;
            this.quantity = quantity;

            // Correctly create and assign the Products object
            this.p = new Products(id, name, description);
        }
    }
}
