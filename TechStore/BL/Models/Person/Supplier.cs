using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models.Person
{
    public class Supplier : Ipersons
    {
        public string _name { get; private set; }

        public string address { get; private set; }

        public string email { get; private set; }

        public int id { get; private set; }

        public string phone { get; private set; }

        public Supplier(int id, string email, string address, string name,string phone) 
        {
            this.id = id;

            this._name = name;
            this.email = email;
            this.address = address;
            this.phone = phone;

        }
        public Supplier(string email, string address, string phone,string name) 
        {
            
                this._name = name;
            this.email = email;
            this.address = address;
            this.phone = phone;

        }

    }
}