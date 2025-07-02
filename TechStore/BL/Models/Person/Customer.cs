using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models.Person
{
    public class Customer : persons
    {
        private string _firstName;
        private string _lastName;
        private string _type;

        public override string firstName => _firstName;
        public override string lastName => _lastName;
        public override string type => _type;
        public Customer(int id,string email,string address, string firstName, string lastName, string type,string phone) : base(id,email,address,phone)
        {

            _firstName = firstName;
            _lastName = lastName;
            _type = type;
        }
        public override string getpersontype()
        {
            return "Customer";
        }

    }

}