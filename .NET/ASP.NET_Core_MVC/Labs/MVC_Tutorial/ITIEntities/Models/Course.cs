using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIEntities
{
    public class Course
    {   // Configure column properties using fluent API in the DbContext's OnModelCreating method (e.g., setting the primary key, column types, etc.)
        public int CrsId { get; set; }          // Primary key for the Course entity
        public string Name { get; set; }        // Name of the course
        public string Duration { get; set; }    // Duration of the course (e.g., "3 months", "1 year")
        public virtual List<Department> Departments { get; set; }  // Navigation property to the related Department entities (a course can be offered by multiple departments)
        public virtual List<StudentCourse> StudentCourses { get; set; }  // Navigation property to the related StudentCourse entities (a course can have multiple students enrolled)
    }
}
