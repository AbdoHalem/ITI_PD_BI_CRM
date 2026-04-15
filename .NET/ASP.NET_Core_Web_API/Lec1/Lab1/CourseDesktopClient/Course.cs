using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDesktopClient
{
    public class Course
    {
        public int ID { get; set; }
        public string? Crs_name { get; set; }
        public string? Crs_desc { get; set; }
        public int Duration { get; set; }
    }
}
