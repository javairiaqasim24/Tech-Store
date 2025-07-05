using System.Collections.Generic;
using TechStore.BL.Models;

namespace TechStore.DL
{
    public interface ISreturnsDl
    {
        bool AddSupplierReturns(List<Supplierreturn> returns);
        List<Supplierreturn> GetBillDetailsByBillId(int billId);
        Products GetProductBySku(string sku);
    }
}