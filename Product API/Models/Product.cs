using System;
using System.Collections.Generic;

#nullable disable

namespace Product_API.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int? Price { get; set; }

        public Product()
        {

        }
        public Product(int id,string name,string cat,int price)
        {
            Id = id;
            Name = name;
            Category = cat;
            Price = price;
        }
    }
}
