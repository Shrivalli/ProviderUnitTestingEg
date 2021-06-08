using System;
using System.Collections.Generic;

#nullable disable

namespace Product_API.Models
{
    public partial class Empl
    {
        public int Empid { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Newcity { get; set; }
        public int? Deptid { get; set; }
    }
}
