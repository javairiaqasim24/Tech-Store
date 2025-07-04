using System.Collections.Generic;
using TechStore.BL.Models;

namespace TechStore.BL.BL
{
    public interface IBatchDetailsBL
    {
        bool AddBatchDetailsWithSerial(Batchdetails batchDetails, List<string> serialNumbers, decimal salePrice, bool isSerialized);
        bool DeleteBatchDetails(int batchDetailsId);
        List<Batchdetails> GetBatchDetails();
        List<Batchdetails> GetBatchDetailsByName(string text);
        List<string> GetBatches(string text);
        List<string> GetProductNames(string text);
        bool UpdateBatchDetails(Batchdetails batchDetails);
    }
}