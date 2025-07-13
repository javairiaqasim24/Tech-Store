using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;
using TechStore.DL;

namespace TechStore.BL
{
    public class Customer_serviceBl : ICustomer_serviceBl
    {
        private readonly ICustomerserviceDl idl;
        public Customer_serviceBl(ICustomerserviceDl idl)
        {
            this.idl = idl;
        }
        public bool savereceipt(customerservicerecipt r)
        {
            return idl.SaveReceipt(r);
        }
    }
}
