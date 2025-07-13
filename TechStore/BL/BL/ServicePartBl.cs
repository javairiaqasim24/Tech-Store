using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;
using TechStore.DL;

namespace TechStore.BL.BL
{
    public class ServicePartBl : IServicePartBl
    {
        private readonly Iservice_partsDl idl;
        public ServicePartBl(Iservice_partsDl idl)
        {
            this.idl = idl;
        }
        public List<servicedevices> SearchDevices(int receiptId)
        {
            if (receiptId <= 0)
                throw new ArgumentException("Invalid receipt ID.");

            return idl.search_device(receiptId);
        }

        public bool AddPartsAndUpdateCharges(List<service_parts> parts, decimal laborCharge, out string message)
        {
            message = string.Empty;

            if (parts == null || parts.Count == 0)
            {
                message = "No service parts provided.";
                return false;
            }

            if (laborCharge < 0)
            {
                message = "Labor charge cannot be negative.";
                return false;
            }

            foreach (var part in parts)
            {
                

                if (part.quantity <= 0)
                {
                    message = "Part quantity must be greater than zero.";
                    return false;
                }

                if (part.price < 0)
                {
                    message = "Part price cannot be negative.";
                    return false;
                }
            }

            try
            {
                return idl.InsertServicePartsAndUpdateCharges(parts, laborCharge);
            }
            catch (Exception ex)
            {
                message = "Error: " + ex.Message;
                return false;
            }
        }

        public bool FinalizeReceipt(int receiptId, decimal paidAmount, out string message)
        {
            message = string.Empty;

            if (receiptId <= 0)
            {
                message = "Invalid receipt ID.";
                return false;
            }

            if (paidAmount < 0)
            {
                message = "Paid amount cannot be negative.";
                return false;
            }

            try
            {
                return idl.FinalizeReceiptBill(receiptId, paidAmount);
            }
            catch (Exception ex)
            {
                message = "Error finalizing bill: " + ex.Message;
                return false;
            }
        }
    }
}
