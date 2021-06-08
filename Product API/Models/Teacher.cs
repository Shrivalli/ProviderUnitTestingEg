using System;
using System.Collections.Generic;

#nullable disable

namespace Product_API.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Students = new HashSet<Student>();
        }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
