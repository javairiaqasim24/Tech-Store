using System.Collections.Generic;
using TechStore.BL.Models.Person;

namespace TechStore.BL.BL
{
    public interface ICustomerBL
    {
        bool AddCustomer(Customer c);
        bool DeleteCustomer(int id);
        List<Customer> GetCustomers();
        List<Customer> SearchCustomers(string text);
        bool UpdateCustomer(Customer c);
    }
}