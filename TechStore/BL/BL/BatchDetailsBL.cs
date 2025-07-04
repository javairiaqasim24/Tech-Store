using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.DL;
using TechStore.Interfaces.DLInterfaces;
using TechStore.Interfaces.BLInterfaces;
using TechStore.BL.Models;
namespace TechStore.BL.BL
{
    public class BatchDetailsBL : IBatchDetailsBL
    {
        private readonly IBatchdetailsDl ibl;

        public BatchDetailsBL(IBatchdetailsDl ibl)
        {
            this.ibl = ibl ?? throw new ArgumentNullException(nameof(ibl), "Batch details data layer cannot be null");
        }

        public bool AddBatchDetailsWithSerial(Batchdetails batchDetails, List<string> serialNumbers, decimal salePrice, bool isSerialized)
        {
            if (batchDetails == null)
                throw new ArgumentNullException(nameof(batchDetails), "Batch details cannot be null");

            if (string.IsNullOrWhiteSpace(batchDetails.batch_name))
                throw new ArgumentException("Batch name cannot be null or empty", nameof(batchDetails.batch_name));

            if (batchDetails.quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(batchDetails.quantity), "Quantity must be greater than 0");

            if (batchDetails.price < 0)
                throw new ArgumentOutOfRangeException(nameof(batchDetails.price), "Cost price must be non-negative");

            if (salePrice < 0)
                throw new ArgumentOutOfRangeException(nameof(salePrice), "Sale price must be non-negative");

            if (isSerialized)
            {
                if (serialNumbers == null || serialNumbers.Count != batchDetails.quantity)
                    throw new ArgumentException("Number of serial numbers must match the quantity");

                if (serialNumbers.Any(sn => string.IsNullOrWhiteSpace(sn)))
                    throw new ArgumentException("Serial numbers cannot contain empty or null values");
            }

            // pass empty list if not serialized
            var serials = isSerialized ? serialNumbers : new List<string>();
            return ibl.AddBatchDetailsWithSerial(batchDetails, serials, salePrice,isSerialized);
        }


        public bool DeleteBatchDetails(int batchDetailsId)
        {
            if (batchDetailsId <= 0)
                throw new ArgumentOutOfRangeException(nameof(batchDetailsId), "Batch details ID must be greater than 0");

            return ibl.deletebatchdetails(batchDetailsId);
        }

        public List<Batchdetails> GetBatchDetails()
        {
            return ibl.getbatchdetails();
        }

        public List<string> GetBatches(string text)
        {


            return ibl.getbatches(text);
        }

        public List<string> GetProductNames(string text)
        {
         

            return ibl.getproductnames(text);
        }

        public bool UpdateBatchDetails(Batchdetails batchDetails)
        {
            if (batchDetails == null)
                throw new ArgumentNullException(nameof(batchDetails), "Batch details cannot be null");

            if (string.IsNullOrWhiteSpace(batchDetails.batch_name))
                throw new ArgumentException("Batch name cannot be null or empty", nameof(batchDetails.batch_name));

            if (string.IsNullOrWhiteSpace(batchDetails.product_name))
                throw new ArgumentException("Product name cannot be null or empty", nameof(batchDetails.product_name));

            if (batchDetails.quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(batchDetails.quantity), "Quantity must be greater than 0");

            if (batchDetails.price < 0)
                throw new ArgumentOutOfRangeException(nameof(batchDetails.price), "Price must be non-negative");

            return ibl.updatebatchdetails(batchDetails);
        }

        public List<Batchdetails> GetBatchDetailsByName(string text)
        {
           

            return ibl.getbatchdetailsbyname(text);
        }
    }
    }