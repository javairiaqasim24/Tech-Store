using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Interfaces.BLInterfaces;
using TechStore.BL.Models;
using TechStore.Interfaces.DLInterfaces;

namespace TechStore.BL.BL
{
    public class ProductBL : IproductBl
    {
        private readonly IproductDl _productDl;
        public ProductBL(IproductDl productDl)
        {
            _productDl = productDl;
        }
        public bool AddProduct(Products p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p), "Product cannot be null");
            }
            if (string.IsNullOrWhiteSpace(p.name) || string.IsNullOrWhiteSpace(p.description) || string.IsNullOrWhiteSpace(p.category))
            {
                throw new ArgumentException("Product properties cannot be null or empty");
            }

            try
            {
                return _productDl.AddProduct(p);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding product: " + ex.Message, ex);
            }
        }
        public bool UpdateProduct(Products p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p), "Product cannot be null");
            }
            if (string.IsNullOrWhiteSpace(p.name) || string.IsNullOrWhiteSpace(p.description) || string.IsNullOrWhiteSpace(p.category))
            {
                throw new ArgumentException("Product properties cannot be null or empty");
            }
            try
            {
                return _productDl.UpdateProduct(p);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating product: " + ex.Message, ex);
            }
        }
        public bool DeleteProduct(int id)
        {
            try
            {
                return _productDl.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting product: " + ex.Message, ex);
            }
        }
        public List<Products> getproducts()
        {
            try
            {
                return _productDl.getproducts();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving products: " + ex.Message, ex);
            }
        }
        public List<string> getcategories(string name)
        {
            try { return _productDl.getcategories(name); }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving categories: " + ex.Message, ex);
            }
        }
        public List<Products> searchproducts(string text)
        {
            //if (string.IsNullOrWhiteSpace(text))
            //{
            //    throw new ArgumentException("Search text cannot be null or empty", nameof(text));
            //}
            try
            {
                return _productDl.searchproducts(text);
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching products: " + ex.Message, ex);
            }
        }

        public bool addcategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Category name cannot be null or empty", nameof(name));
            }
            try
            {
                return _productDl.addcategory(name);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding category: " + ex.Message, ex);
            }
        }

        public List<Products> GetProductsByName(string name)

        {
            return _productDl.GetProductsByName(name);
        }
    }
}