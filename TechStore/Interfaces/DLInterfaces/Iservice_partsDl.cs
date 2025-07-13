using System.Collections.Generic;
using TechStore.BL.Models;

namespace TechStore.DL
{
    public interface Iservice_partsDl
    {
        bool FinalizeReceiptBill(int receiptId, decimal paidAmount);
        bool InsertServicePartsAndUpdateCharges(List<service_parts> parts, decimal laborCharge);
        List<servicedevices> search_device(int receipt_id);
    }
}