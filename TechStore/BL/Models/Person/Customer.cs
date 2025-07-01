using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models.Person
{
    public class Customer : persons
    {
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public string type { get; private set; }
        public Customer(int id,string email,string address, string firstName, string lastName, string type,string phone) : base(id,email,address,phone)
        {
          
            this.firstName = firstName;
            this.lastName = lastName;
            this.type = type;
        }


    }

}