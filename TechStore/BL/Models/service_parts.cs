using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models
{
    public class service_parts
    {
        public int part_id { get; set; }
        public int product_id { get; set; }
public string product_name { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public int device_id{get;set;}
    }
}
