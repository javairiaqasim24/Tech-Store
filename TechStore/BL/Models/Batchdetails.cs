using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models { 
    public class Batchdetails
    {
        public int batch_details_id { get;private set; }
        public int batch_id { get; private set; }
        public int product_id { get; private set; }
        public string product_name { get;private set; }
        public int  quantity { get; private set; }
        public decimal price { get; private set; }
        public string batch_name { get; private set; }
        public Batchdetails(int batch_details_id, int batch_id, int product_id, string product_name, int quantity, decimal price, string batch_name)
        {
            this.batch_details_id = batch_details_id;
            this.batch_id = batch_id;
            this.product_id = product_id;
            this.product_name = product_name;
            this.quantity = quantity;
            this.price = price;
            this.batch_name = batch_name;
        }
    }
}
