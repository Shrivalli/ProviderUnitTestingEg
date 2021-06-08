using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Product_API.Controllers;
using Product_API.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Product_API.Provider;

namespace ProductunitTest
{
    public class Tests
    {
        //Arrange
        List<Product> Products = new List<Product>();
        IQueryable<Product> billingdata;
        Mock<DbSet<Product>> mockSet;
        Mock<OrganizationContext> billcontextmock;
        Mock<IProduct<Product>> prodprov;
        
        [SetUp]
        public void Setup()
        {
            Products = new List<Product>()
            {
                new Product{Id=1,Name="Toy",Category="Stationery",Price=34 },
                new Product{Id=2,Name="Biscuits",Category="Stationery",Price=34 },
                new Product{Id=3,Name="Pencil",Category="Stationery",Price=34 },
             };

            billingdata = Products.AsQueryable();
            mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(billingdata.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(billingdata.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(billingdata.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(billingdata.GetEnumerator());
            var p = new DbContextOptions<OrganizationContext>();
            billcontextmock = new Mock<OrganizationContext>(p);
            billcontextmock.Setup(x => x.Products).Returns(mockSet.Object);
            prodprov = new Mock<IProduct<Product>>();

        }

        [Test]
        public void TestAdd()
        {
           //// ProductsController obj = new ProductsController();
            //Act
           // int x=obj.add(5, 4);
            //Assert
            //Assert.AreEqual(9, x);
        }

        [Test]
        public void CheckProductID()
        {
            ProductsController obj = new ProductsController(prodprov.Object);
            var result = obj.getprbyid(1);
            string pname = result.Name;
            //int price = (int)result.Price;
           // Assert.Less(price, 40);
            Assert.AreEqual("Toy", pname);

        }

        [Test]
        public void AddProduct()
        {
            Product p = new Product();
            p.Id = 400;
            p.Price = 340;
            p.Name = "abcd";
            p.Category = "Food";
            // prodprov.Setup(prov => prov.AddProduct(p)).Returns(new Product 
            //{
            //    Id = 1,
            //    Price = 400,
            //    Name = "abcd",
            //    Category = "Food"

            //} );
            prodprov.Setup(x => x.AddProduct(p)).Returns(p);
            ProductsController obj = new ProductsController(prodprov.Object);
            var res = obj.PostProduct(p);
            Assert.That(res, Is.InstanceOf<OkObjectResult>());
           

        }
    }
}