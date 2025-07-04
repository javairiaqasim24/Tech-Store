using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models
{
    public class Batches
    {
        public int batch_id { get; private set; }
        public string batch_name { get; private set; }
        public string supplier_name{ get; private set; }
        public DateTime batch_date { get; private set; }
        public Batches(int batch_id, string batch_name, string supplier_name, DateTime batch_date)
        {
            this.batch_id = batch_id;
            this.batch_name = batch_name;
            this.supplier_name = supplier_name;
            this.batch_date = batch_date;
        }

    }
}
