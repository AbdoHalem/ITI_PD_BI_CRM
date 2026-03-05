using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace ITIEntities
{
    public class Student
    {
        public int Id { get; set; }     // Primary key for the Student entity (By convention, EF Core will treat this as the primary key)
        
        [StringLength(50), Required]    // Data annotations for validation: Name is required and has a maximum length of 50 characters
        public string Name { get; set; }
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }  // Email property to store the student's email address 

        [ForeignKey(nameof(Department))]  // Specifies that Deptno is a foreign key referencing the Department entity
        public int Deptno { get; set; }   // Foreign key property to link to the Department entity (the name "Deptno" is used here, but it could be named differently as long as it matches the foreign key relationship)

        public virtual Department Department { get; set; }  // Navigation property to the related Department entity (virtual for lazy loading)
        public virtual List<StudentCourse> StudentCourses { get; set; }  // Navigation property to the related StudentCourse entities (a student can be enrolled in multiple courses)
        override public string ToString()
        {
            return $"Student: Id={Id}, Name={Name}, Age={Age}";
        }
    }
}
