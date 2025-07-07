using System;
using System.Collections.Generic;
using TechStore.BL.Models;
using TechStore.BL.Models.Person;
using TechStore.DL;

namespace TechStore.BL.BL
{
    public class CustomerBL : ICustomerBL
    {
        private readonly ICustomerDL customerDL;

        public CustomerBL(ICustomerDL customerDL)
        {
            this.customerDL = customerDL ?? throw new ArgumentNullException(nameof(customerDL), "Data access layer cannot be null.");
        }

        public bool AddCustomer(Ipersons p)
        {
            var customer = p as Customer ?? throw new ArgumentException("Expected a Customer instance.", nameof(p));
            ValidateCustomer(customer, isUpdate: false);

            try
            {
                return customerDL.Addcustomer(customer);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding customer: " + ex.Message, ex);
            }
        }

        public bool UpdateCustomer(Ipersons p)
        {
            var customer = p as Customer ?? throw new ArgumentException("Expected a Customer instance.", nameof(p));
            ValidateCustomer(customer, isUpdate: true);

            try
            {
                return customerDL.Updatecustomer(customer);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating customer: " + ex.Message, ex);
            }
        }

        public bool DeleteCustomer(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid customer ID.");

            try
            {
                return customerDL.Deletecustomer(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting customer: " + ex.Message, ex);
            }
        }

        public List<Ipersons> GetCustomers()
        {
            try
            {
                return customerDL.GetCustomers();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while retrieving customers: " + ex.Message, ex);
            }
        }

        public List<Ipersons> SearchCustomers(string text)
        {
            try
            {
                return customerDL.Searchcustomers(text);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while searching customers: " + ex.Message, ex);
            }
        }

        // Helper: validate customer input
        private void ValidateCustomer(Customer customer, bool isUpdate)
        {
            if (isUpdate && customer.id <= 0)
                throw new ArgumentException("Customer ID is invalid.");

            if (string.IsNullOrWhiteSpace(customer._firstName))
                throw new ArgumentException("First name is required.");

            if (string.IsNullOrWhiteSpace(customer._lastName))
                throw new ArgumentException("Last name is required.");

            if (string.IsNullOrWhiteSpace(customer._type))
                throw new ArgumentException("Customer type is required.");

            //if (string.IsNullOrWhiteSpace(customer.phone))
            //    throw new ArgumentException("Phone number is required.");
        }
    }
}
