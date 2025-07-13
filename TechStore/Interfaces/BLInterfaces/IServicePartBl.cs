using System.Collections.Generic;
using TechStore.BL.Models;

namespace TechStore.BL.BL
{
    public interface IServicePartBl
    {
        bool AddPartsAndUpdateCharges(List<service_parts> parts, decimal laborCharge, out string message);
        bool FinalizeReceipt(int receiptId, decimal paidAmount, out string message);
        List<servicedevices> SearchDevices(int receiptId);
    }
}