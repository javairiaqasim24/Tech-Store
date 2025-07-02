using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;

namespace TechStore.Interfaces.BLInterfaces
{
    public interface ICustomerSaleBL
    {
        Products GetProductBySku(string sku);
        List<Products> SearchProductsByName(string name);
    }
}
