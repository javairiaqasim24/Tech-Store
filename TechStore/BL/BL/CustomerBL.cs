using System;
using System.Collections.Generic;
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

        public bool AddCustomer(Customer c)
        {
            if (c == null)
                throw new ArgumentNullException(nameof(c), "Customer data cannot be null.");

            if (string.IsNullOrWhiteSpace(c.firstName))
                throw new ArgumentException("First name is required.");

            if (string.IsNullOrWhiteSpace(c.lastName))
                throw new ArgumentException("Last name is required.");

            if (string.IsNullOrWhiteSpace(c.type))
                throw new ArgumentException("Customer type is required.");

            if (string.IsNullOrWhiteSpace(c.phone))
                throw new ArgumentException("Phone number is required.");

            // Email and Address can be null or empty — allowed

            try
            {
                return customerDL.Addcustomer(c);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding customer: " + ex.Message, ex);
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

        public List<Customer> GetCustomers()
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

        public List<Customer> SearchCustomers(string text)
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

        public bool UpdateCustomer(Customer c)
        {
            if (c == null)
                throw new ArgumentNullException(nameof(c), "Customer data cannot be null.");

            if (c.id <= 0)
                throw new ArgumentException("Customer ID is invalid.");

            if (string.IsNullOrWhiteSpace(c.firstName))
                throw new ArgumentException("First name is required.");

            if (string.IsNullOrWhiteSpace(c.lastName))
                throw new ArgumentException("Last name is required.");

            if (string.IsNullOrWhiteSpace(c.type))
                throw new ArgumentException("Customer type is required.");

            if (string.IsNullOrWhiteSpace(c.phone))
                throw new ArgumentException("Phone number is required.");

            try
            {
                return customerDL.Updatecustomer(c);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating customer: " + ex.Message, ex);
            }
        }
    }
}
