using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BL.Models
{
    public class Products
    {
       

        public int id { get;  set; }
        public string name { get;  set; }
        public string description { get;  set; }
        public string category { get; private set; }
        

        public Products(int id, string name, string description, string category)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.category = category;
        
        }
        public Products(string name, string description, string category)
        {
            this.name = name;
            this.description = description;
            this.category = category;
 
        }
        public Products(int id,string name,string descp)
        {
            this.id = id;
            this.name = name;
            this.description = descp;
        }
        public Products((int, string, string, string, int?, double?) value)
        {
        }

       
    }
}
