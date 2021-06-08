using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_API
{
    public class Employee
    {
        private static Employee e;

        private Employee()
        {

        }

        public static Employee getEmployeeobj()
        {
            if(e==null)
            {
                e = new Employee();
            }
            return e;
        }
    }
}
