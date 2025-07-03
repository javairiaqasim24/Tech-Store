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
        public bool AddBatchDetails(Batchdetails batchDetails)
        {
            if (batchDetails == null)
                throw new ArgumentNullException(nameof(batchDetails), "Batch details cannot be null");
            if (string.IsNullOrEmpty(batchDetails.batch_name) || string.IsNullOrEmpty(batchDetails.product_name))
            {
                throw new ArgumentException("Batch name and product name cannot be empty", nameof(batchDetails));
            }
            if (batchDetails.quantity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(batchDetails.quantity), "Quantity must be greater than zero");
            }
            if (batchDetails.price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(batchDetails.price), "Price must be greater than zero");
            }

            return ibl.addbatchdetails(batchDetails);
        }
        public bool DeleteBatchDetails(int batchDetailsId)
        {
            if (batchDetailsId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(batchDetailsId), "Batch details ID must be greater than zero");
            }
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
            if (string.IsNullOrEmpty(batchDetails.batch_name) || string.IsNullOrEmpty(batchDetails.product_name))
            {
                throw new ArgumentException("Batch name and product name cannot be empty", nameof(batchDetails));
            }
            if (batchDetails.quantity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(batchDetails.quantity), "Quantity must be greater than zero");
            }
            if (batchDetails.price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(batchDetails.price), "Price must be greater than zero");
            }
            return ibl.updatebatchdetails(batchDetails);
        }
        public List<Batchdetails> GetBatchDetailsByName(string text)
        {

            return ibl.getbatchdetailsbyname(text);
        }
    }
}