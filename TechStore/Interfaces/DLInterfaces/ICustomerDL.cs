using System.Collections.Generic;
using TechStore.BL.Models;
using TechStore.BL.Models.Person;

namespace TechStore.DL
{
    public interface ICustomerDL
    {
        bool Addcustomer(Ipersons c);
        bool Deletecustomer(int id);
        List<Ipersons> GetCustomers();
        List<Ipersons> Searchcustomers(string text);
        bool Updatecustomer(Ipersons c);
    }
}