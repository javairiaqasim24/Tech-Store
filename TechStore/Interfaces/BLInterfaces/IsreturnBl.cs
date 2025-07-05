using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;

namespace TechStore.Interfaces.BLInterfaces
{
    public  interface IsreturnBl
    {
        bool AddSupplierReturns(List<Supplierreturn> returns);
        List<Supplierreturn> GetBillDetailsByBillId(int billId);
        Products GetProductBySku(string sku);
    }
}
