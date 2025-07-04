using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.BL.Models;
using TechStore.BL.Models.Person;

namespace TechStore.Interfaces.DLInterfaces
{
    public interface Icustomersaledl
    {
        // ... existing methods ...
        Customersale GetProductBySku(string sku);
        List<Customersale> SearchProductsByName(string name);
        int GetCustomerIdByNameAndType(string name, string type);
        int InsertNewWalkInCustomer(string name);
        int SaveCustomerBill(int customerId, DateTime saleDate, decimal total, decimal paid, DataGridView cart);

    }
}