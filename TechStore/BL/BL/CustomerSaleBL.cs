using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.BL.Models;
using TechStore.BL.Models.Person;
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

        public int GetCustomerIdByNameAndType(string name, string type)
        {
            try
            {
                return _productDL.GetCustomerIdByNameAndType(name, type);
            }
            catch(Exception ex)
            {
                throw new Exception("Error getting customer-id by name " + ex.Message, ex);

            }
        }

        public Customersale GetProductBySku(string sku)
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

        public int InsertNewWalkInCustomer(string name)
        {
            try
            {
                return _productDL.InsertNewWalkInCustomer(name);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting walk-in customer: "+ex.Message, ex);
            }
        }

        public int SaveCustomerBill(int customerId, DateTime saleDate, decimal total, decimal paid, DataGridView cart)
        {
            try
            {
                return _productDL.SaveCustomerBill(customerId, saleDate, total, paid, cart);
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving bills: "+ex.Message, ex);
            }
        }

        public List<Customersale> SearchProductsByName(string name)
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
