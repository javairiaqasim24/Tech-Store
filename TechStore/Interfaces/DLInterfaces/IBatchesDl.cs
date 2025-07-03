using System.Collections.Generic;
using TechStore.BL.Models;

namespace TechStore.DL
{
    public interface IBatchesDl
    {
        bool addbatches(Batches b);
        List<Batches> getbatches();
        List<Batches> GetBatches(string searchTerm);
        List<string> getsuppliernames(string name);
    }
}