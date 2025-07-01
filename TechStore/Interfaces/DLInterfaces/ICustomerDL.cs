using System.Collections.Generic;
using TechStore.BL.Models.Person;

namespace TechStore.DL
{
    public interface ICustomerDL
    {
        bool Addcustomer(Customer c);
        bool Deletecustomer(int id);
        List<Customer> GetCustomers();
        List<Customer> Searchcustomers(string text);
        bool Updatecustomer(Customer c);
    }
}