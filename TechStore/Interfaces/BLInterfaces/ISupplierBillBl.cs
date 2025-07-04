using TechStore.BL.Models;

namespace TechStore.BL.BL
{
    public interface ISupplierBillBl
    {
        Supplierbill getbills(string batchname);
        bool updateamount(Supplierbill b);
    }
}