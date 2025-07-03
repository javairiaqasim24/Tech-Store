using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;
using TechStore.DL;

namespace TechStore.BL.BL
{
    public class SupplierBillBl : ISupplierBillBl
    {
        private readonly ISupplierbillDl ibl;
        public SupplierBillBl(ISupplierbillDl ibl)
        {
            this.ibl = ibl;
        }
        public bool updateamount(Supplierbill b)
        {
            try
            {
                return ibl.UpdateBill(b);
            }
            catch (Exception e)
            {
                throw new Exception("error" + e.Message);
            }
        }
        public Supplierbill getbills(string batchname)
        {
            try
            {
                return ibl.GetSupplierBillByBatchName(batchname);

            }
            catch (Exception e)
            {
                throw new Exception("error" + e.Message);
            }
        }
    }
}
