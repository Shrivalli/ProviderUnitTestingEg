using Product_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_API.Repo
{
    public class Prodrepo : IProduct
    {
        private readonly OrganizationContext _context;
        public Prodrepo(OrganizationContext context)
        {
            _context = context;
        }
        public Product AddProduct(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges();
            return p;
        }

        public Product DeleteProduct(int id)
        {
            Product p = GetProductByID(id);
            _context.Products.Remove(p);
            _context.SaveChanges();
            return p;
        }

        public Product GetProductByID(int id)
        {
            Product p=_context.Products.Find(id);
            return p;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product UpdateProduct(int id, Product p)
        {
            //int id = p.Id;
            _context.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return p;
        }
    }
}
