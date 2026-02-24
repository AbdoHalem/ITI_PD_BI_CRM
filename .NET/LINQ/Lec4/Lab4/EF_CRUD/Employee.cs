using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CRUD
{
    public class Employee
    {
        // EF Core automatically makes a property named "ID" the Primary Key and Identity column
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Dept { get; set; }
    }
}
