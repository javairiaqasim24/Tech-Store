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
    public class persons:Ipersons
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
            this.phone = phone;
        }
    }
}






