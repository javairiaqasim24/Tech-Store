using System.Collections.Generic;
using TechStore.BL.Models.Person;
using TechStore.BL.Models;
namespace TechStore.BL.BL
{
    public interface ICustomerBL
    {
        bool AddCustomer(Ipersons c);
        bool DeleteCustomer(int id);
        List<Ipersons> GetCustomers();
        List<Ipersons> SearchCustomers(string text);
        bool UpdateCustomer(Ipersons c);
    }
}