using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;
using TechStore.Interfaces.BLInterfaces;
using TechStore.Interfaces.DLInterfaces;

namespace TechStore.BL.BL
{
    public class CustomerSaleBL : ICustomerSaleBL
    {
        private readonly Icustomersaledl _productDL; 

        public CustomerSaleBL(Icustomersaledl productDL)
        {
            _productDL = productDL;
        }

        public Products GetProductBySku(string sku)
        {
            try
            {
                return _productDL.GetProductBySku(sku);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting product by SKU: " + ex.Message, ex);
            }
        }

        public List<Products> SearchProductsByName(string name)
        {
            try
            {
                return _productDL.SearchProductsByName(name);
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching products by name: " + ex.Message, ex);
            }
        }
    }
}
