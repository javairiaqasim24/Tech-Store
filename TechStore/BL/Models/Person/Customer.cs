using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models.Person
{
    public class Customer : Ipersons
    {
        public string _firstName { get; private set; }
        public string _lastName { get; private set; }
        public string _type { get; private set; }

        public Customer(int id,string email,string address, string firstName, string lastName, string type,string phone) 
        {
            this.id = id;

            this._firstName = firstName;
            this._lastName = lastName;
            this._type = type;
            this.email = email;
            this.address = address;
            this.phone = phone;


        }

        public string address { get; private set; }

        public string email { get; private set; }

        public int id { get; private set; }

        public string phone { get; private set; }
    }

}