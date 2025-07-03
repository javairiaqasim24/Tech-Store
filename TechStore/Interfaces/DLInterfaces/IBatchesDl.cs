using System.Collections.Generic;
using TechStore.BL.Models;

namespace TechStore.DL
{
    public interface IBatchesDl
    {
        bool addbatches(Batches b);
        List<string> getsuppliernames(string name);
    }
}