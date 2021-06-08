using Product_API.Models;
using Product_API.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_API.Provider
{
    public class ProdProv : IProduct<Product>
    {
        private readonly Prodrepo repo;
        public ProdProv(Prodrepo _repo)
        {
            repo = _repo;
        }
        public Product AddProduct(Product p)
        {
            repo.AddProduct(p);
            return p;
        }

        public Product DeleteProduct(int id)
        {
           Product p= repo.DeleteProduct(id);
            return p;
        }

        public Product GetProductByID(int id)
        {
            Product p = repo.GetProductByID(id);
                return p;
        }

        public List<Product> GetProducts()
        {
            return repo.GetProducts();
        }

        public Product UpdateProduct(int id, Product p)
        {
            Product p1=repo.UpdateProduct(id, p);
            return p1;
        }
    }
}
