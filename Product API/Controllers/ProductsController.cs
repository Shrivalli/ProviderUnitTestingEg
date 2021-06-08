using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Product_API.Models;
using Product_API.Provider;

namespace Product_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct<Product> _prov;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProductsController));

       // public ProductsController()
       // {

        //}
        public ProductsController(IProduct<Product> prov)
        {
            // _log4net = logger;
            _prov = prov;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            _log4net.Info("Get Products is invoked");
            // return _context.Products.ToListAsync();
            return _prov.GetProducts();
        }

        public int add(int x,int y)
        {
            return x + y;
        }
        public Product getprbyid(int id)
        {
            //  Product p = _context.Products.Where(x => x.Id == id).Select(x=>x).SingleOrDefault();
            Product p = _prov.GetProductByID(id);
            return p;
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public  ActionResult<Product> GetProduct(int id)
        {
            _log4net.Info("Get Product by " +id +" is invoked");
            //  var product = await _context.Products.FindAsync(id);
            var product =  _prov.GetProductByID(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public ActionResult<Product> PutProduct(int id,Product product)
        {
            _log4net.Info("Put Product is invoked for the id "+id);
            if (id != product.Id)
            {
                return BadRequest();
            }

            //_context.Entry(product).State = EntityState.Modified;

            try
            {
                _prov.UpdateProduct(id, product);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public  IActionResult PostProduct(Product product)
        {
            _log4net.Info("Post Product is invoked to add "+product.Name);
           // _context.Products.Add(product);
            try
            {

                return Ok(_prov.AddProduct(product));
                
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            //return CreatedAtAction("GetProduct", new { id = product.Id }, product);
           
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public  ActionResult<Product> DeleteProduct(int id)
        {
            _log4net.Info("Delete Product is invoked to delete product with Id: "+id);
            _log4net.Error(id + " not found");
            //var product = await _context.Products.FindAsync(id);
            var product = _prov.GetProductByID(id);
            if (product == null)
            {
                return NotFound();
            }

            //_context.Products.Remove(product);
            //await _context.SaveChangesAsync();
             _prov.DeleteProduct(id);
            return product;
        }

        private bool ProductExists(int id)
        {
            _log4net.Info("Product Exists method is invoked");
            //  return _context.Products.Any(e => e.Id == id);
             Product p=_prov.GetProductByID(id);
            if(p!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
