using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models.Person
{
    public class Supplier : persons
    {
        public string name { get; private set; }
        public Supplier(int id, string email, string address, string name) : base(id, email, address)
        {
            this.name = name;
        }
        public Supplier(string email, string address, string name) : base(email, address)
        {
            {
                this.name = name;
            }
        }
    }
}