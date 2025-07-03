using TechStore.BL.Models;

namespace TechStore.DL
{
    public interface ISupplierbillDl
    {
        Supplierbill GetSupplierBillByBatchName(string batchName);
        bool UpdateBill(Supplierbill s);
    }
}