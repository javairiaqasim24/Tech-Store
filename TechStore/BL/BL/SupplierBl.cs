using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Interfaces.BLInterfaces;
using TechStore.BL.Models;
using TechStore.Interfaces.DLInterfaces;
using TechStore.BL.Models.Person;
namespace TechStore.BL.BL
{
    public class SupplierBl:ISupplierBL
    {
        private readonly IsupplierDl _supplierDL;
        public SupplierBl(IsupplierDl supplierDL)
        {
            _supplierDL = supplierDL;
        }
        public bool addsupplier(Supplier s)
        {

            if (s == null)
            {
                throw new ArgumentNullException(nameof(s), "Supplier cannot be null");
            }
            if (string.IsNullOrWhiteSpace(s.name) || string.IsNullOrWhiteSpace(s.email) || string.IsNullOrWhiteSpace(s.address))
            {
                throw new ArgumentException("Supplier properties cannot be null or empty");
            }
            try { return _supplierDL.addsupplier(s); }
            catch (Exception ex)
            {
                throw new Exception("Error adding supplier: " + ex.Message, ex);
            }
        }
        public bool updatesupplier(Supplier s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s), "Supplier cannot be null");
            }
            if (string.IsNullOrWhiteSpace(s.name) || string.IsNullOrWhiteSpace(s.email) || string.IsNullOrWhiteSpace(s.address))
            {
                throw new ArgumentException("Supplier properties cannot be null or empty");
            }
            try { return _supplierDL.updatesupplier(s); }
            catch (Exception ex)
            {
                throw new Exception("Error updating supplier: " + ex.Message, ex);
            }
        }
        public bool deletesupplier(int id)
        {
            return _supplierDL.deletesupplier(id);
        }
        public List<Supplier> getsuppliers()
        {
            return _supplierDL.getsuppliers();
        }
        public List<string> getsuppliernames(string name)
        {
            return _supplierDL.getsuppliernames(name);
        }
        public List<Supplier> searchsuppliers(string text)
        {
            return _supplierDL.searchsuppliers(text);
        }
    }
}
