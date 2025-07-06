using System.Collections.Generic;
using TechStore.BL.Models;

namespace TechStore.DL
{
    public interface ISbilldetailsDl
    {
        bool addrecord(Spricerecord s);
        List<Supplierpayment> getdetails(int billid);
    }
}