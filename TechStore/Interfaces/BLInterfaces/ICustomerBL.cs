using System.Collections.Generic;
using TechStore.BL.Models.Person;
using TechStore.BL.Models;
namespace TechStore.BL.BL
{
    public interface ICustomerBL
    {
        bool AddCustomer(persons c);
        bool DeleteCustomer(int id);
        List<persons> GetCustomers();
        List<persons> SearchCustomers(string text);
        bool UpdateCustomer(persons c);
    }
}