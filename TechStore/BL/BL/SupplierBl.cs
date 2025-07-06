using System;
using System.Collections.Generic;
using TechStore.BL.Models;
using TechStore.BL.Models.Person;
using TechStore.Interfaces.BLInterfaces;
using TechStore.Interfaces.DLInterfaces;

namespace TechStore.BL.BL
{
    public class SupplierBl :ISupplierBL
    {
        private readonly IsupplierDl _supplierDL;

        public SupplierBl(IsupplierDl supplierDL)
        {
            _supplierDL = supplierDL ?? throw new ArgumentNullException(nameof(supplierDL), "Supplier data layer cannot be null.");
        }

        public bool addsupplier(Ipersons p)
        {
            var supplier = p as Supplier ?? throw new ArgumentException("Expected a Supplier instance.", nameof(p));
            ValidateSupplier(supplier, isUpdate: false);

            try
            {
                return _supplierDL.addsupplier(supplier);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding supplier: " + ex.Message, ex);
            }
        }

        public bool updatesupplier(Ipersons p)
        {
            var supplier = p as Supplier ?? throw new ArgumentException("Expected a Supplier instance.", nameof(p));
            ValidateSupplier(supplier, isUpdate: true);

            try
            {
                return _supplierDL.updatesupplier(supplier);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating supplier: " + ex.Message, ex);
            }
        }

        public bool deletesupplier(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid supplier ID.");

            try
            {
                return _supplierDL.deletesupplier(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting supplier: " + ex.Message, ex);
            }
        }

        public List<Ipersons> getsuppliers()
        {
            try
            {
                return _supplierDL.getsuppliers();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving suppliers: " + ex.Message, ex);
            }
        }

        public List<string> getsuppliernames(string name)
        {
            try
            {
                return _supplierDL.getsuppliernames(name);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving supplier names: " + ex.Message, ex);
            }
        }

        public List<Ipersons> searchsuppliers(string text)
        {
            try
            {
                return _supplierDL.searchsuppliers(text);
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching suppliers: " + ex.Message, ex);
            }
        }

        private void ValidateSupplier(Supplier supplier, bool isUpdate)
        {
            if (isUpdate && supplier.id <= 0)
                throw new ArgumentException("Supplier ID is invalid.");

            if (string.IsNullOrWhiteSpace(supplier._name))
                throw new ArgumentException("Supplier name is required.");

            if (string.IsNullOrWhiteSpace(supplier.email))
                throw new ArgumentException("Supplier email is required.");

            if (string.IsNullOrWhiteSpace(supplier.address))
                throw new ArgumentException("Supplier address is required.");
        }

        public object GetSupplierById(int supplierId)
        {
            throw new NotImplementedException();
        }
    }
}
