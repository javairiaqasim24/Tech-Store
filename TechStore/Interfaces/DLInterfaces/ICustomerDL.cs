using System.Collections.Generic;
using TechStore.BL.Models;
using TechStore.BL.Models.Person;

namespace TechStore.DL
{
    public interface ICustomerDL
    {
        bool Addcustomer(persons c);
        bool Deletecustomer(int id);
        List<persons> GetCustomers();
        List<persons> Searchcustomers(string text);
        bool Updatecustomer(persons c);
    }
}