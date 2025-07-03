using System.Collections.Generic;
using TechStore.BL.Models;

namespace TechStore.BL.BL
{
    public interface IBatchesBl
    {
        bool AddBatches(Batches b);
        List<string> GetSupplierNames(string name);
    }
}