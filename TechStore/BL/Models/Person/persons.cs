using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;
using TechStore.BL.Models.Person;
using TechStore.Interfaces;

namespace TechStore.BL.Models
{
    public  class persons
    {
        public int id {  get; private set; }
        public  string email { get; private set; }
        public string address { get; private set; }
        public string phone{ get; private set; }
        public persons(int id, string email, string address,string phone)
        {
            this.id = id;
            this.email = email;
            this.address = address;
            this.phone = phone;
        }
        public persons(string email, string address,string phone)
        {
            this.email = email;
            this.address = address;
            this.phone = phone;// Default value for phone if not provided
        }
    }
}
public enum PersonType
{
    Supplier,
    Customer
}


public class PersonFactory : IPersonFactory
{
    public persons CreatePerson(PersonType type, int id, string email, string address, string name,string phone)
    {
        switch (type)
        {
            case PersonType.Supplier:
                return new Supplier(id, email, address, name,phone);
            case PersonType.Customer:
                // return new Customer(id, email, address, name); // To be implemented later
                throw new NotImplementedException("Customer not yet implemented.");
            default:
                throw new ArgumentException("Invalid person type");
        }
    }
}
