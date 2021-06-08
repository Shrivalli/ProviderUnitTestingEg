using System;
using System.Collections.Generic;

#nullable disable

namespace Product_API.Models
{
    public partial class Image
    {
        public string RollNo { get; set; }
        public byte[] Img { get; set; }
        public DateTime? ImgDate { get; set; }
    }
}
