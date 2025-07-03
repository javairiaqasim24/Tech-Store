using System.Collections.Generic;
using TechStore.BL.Models;

namespace TechStore.BL.BL
{
    public interface IBatchDetailsBL
    {
        bool AddBatchDetails(Batchdetails batchDetails);
        bool DeleteBatchDetails(int batchDetailsId);
        List<Batchdetails> GetBatchDetails();
        List<Batchdetails> GetBatchDetailsByName(string text);
        List<string> GetBatches(string text);
        List<string> GetProductNames(string text);
        bool UpdateBatchDetails(Batchdetails batchDetails);
    }
}