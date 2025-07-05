using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;
using TechStore.DL;
using TechStore.Interfaces.BLInterfaces;

namespace TechStore.BL.BL
{
    public  class SreturnBl:IsreturnBl
    {
        private readonly ISreturnsDl ibl;
        public SreturnBl(ISreturnsDl ibl)
        {
            this.ibl = ibl;
        }

        public bool AddSupplierReturns(List<Supplierreturn> returns)
        {
            return ibl.AddSupplierReturns(returns);
        }

        public List<Supplierreturn> GetBillDetailsByBillId(int billId)
        {
            return ibl.GetBillDetailsByBillId(billId);
        }

        public Products GetProductBySku(string sku)
        {
            return ibl.GetProductBySku(sku);
        }
    }
}
