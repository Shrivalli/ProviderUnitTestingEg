using System;
using System.Collections.Generic;

#nullable disable

namespace Product_API.Models
{
    public partial class Ajaxproduct
    {
        public int Pid { get; set; }
        public string Pname { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public string Cid { get; set; }
    }
}
