using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;
using TechStore.DL;
using TechStore.Interfaces.DLInterfaces;

namespace TechStore.BL.BL
{
    public class BatchesBl : IBatchesBl
    {
        private readonly IBatchesDl _batchesDl;
        public BatchesBl(IBatchesDl batchesDl)
        {
            _batchesDl = batchesDl;
        }
        public bool AddBatches(Batches b)
        {
            if (b == null)
                throw new ArgumentNullException(nameof(b), "Batch cannot be null");
            if (string.IsNullOrEmpty(b.supplier_name) || string.IsNullOrEmpty(b.batch_name))
            {
                throw new ArgumentException(nameof(b.supplier_name), "canot be empty");
            }
            return _batchesDl.addbatches(b);
        }
        public List<string> GetSupplierNames(string name)
        {

            return _batchesDl.getsuppliernames(name);
        }
        public List<Batches> getbatches()
        {
            return _batchesDl.getbatches();
        }
        public List<Batches> getbatchesbyname(string name)
        {
            return _batchesDl.GetBatches(name);
        }
    }
}
