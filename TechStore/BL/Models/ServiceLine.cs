using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models
{
    public class ServiceLine
    {
        public int ServiceId { get; set; }
        public int CustomerId { get; set; }
        public string NameOfItem { get; set; }
        public string Description { get; set; }
        public DateTime RecieveDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }

}
