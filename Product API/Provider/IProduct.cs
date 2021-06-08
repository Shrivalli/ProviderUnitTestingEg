using Product_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_API.Provider
{
    public interface IProduct<Product>
    {
        public List<Product> GetProducts();
        public Product AddProduct(Product p);
        public Product UpdateProduct(int id, Product p);
        public Product DeleteProduct(int id);
        public Product GetProductByID(int id);
    }
}
