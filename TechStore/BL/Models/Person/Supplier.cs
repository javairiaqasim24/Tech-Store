using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models.Person
{
    public class Supplier : persons
    {
        private string _name;
        public override string name => _name;
        public Supplier(int id, string email, string address, string name,string phone) : base(id, email, address,phone)
        {
            this._name = name;
        }
        public Supplier(string email, string address, string phone,string name) : base(email, address,phone)
        {
            {
                this._name = name;
            }
        }
        public override string getpersontype()
        {
            return "Supplier";
        }
    }
}