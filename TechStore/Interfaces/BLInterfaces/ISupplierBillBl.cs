using System.Collections.Generic;
using TechStore.BL.Models;

namespace TechStore.BL.BL
{
    public interface ISupplierBillBl
    {
        Supplierbill getbills(string batchname);
        bool updateamount(Supplierbill b);
        List<Supplierbill> getbillbyname(string text);
        List<Supplierbill> getbill();
        List<Supplierbill> getbills(int billid);
    }
}