using System.Collections.Generic;
using TechStore.BL.Models;

namespace TechStore.DL
{
    public interface ISupplierbillDl
    {
        Supplierbill GetSupplierBillByBatchName(string batchName);
        bool UpdateBill(Supplierbill s);
        List<Supplierbill> getbills(string text);
        List<Supplierbill> getbill();
        List<Supplierbill> getbills(int billid);
    }
}