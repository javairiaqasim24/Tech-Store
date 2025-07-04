using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;

namespace TechStore.Interfaces.BLInterfaces
{
    public interface IproductBl
    {
        bool AddProduct(Products p);
        bool UpdateProduct(Products p);
        bool DeleteProduct(int id);
        List<Products> getproducts();
        List<string> getcategories(string name);
        List<Products> searchproducts(string text);
        bool addcategory(string name);
        List<Products> GetProductsByName(string name);
    }
}
