using ITIEntities.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIEntities
{
    public class StudentCourse
    {
        [ForeignKey(nameof(Student))]  // Specifies that StudentId is a foreign key referencing the Student entity]
        public int StudentId { get; set; } // Foreign key property to link to the Student entity
        [ForeignKey(nameof(Course))]   // Specifies that CrsNo is a foreign key referencing the Course entity
        public int CrsNo { get; set; }     // Foreign key property to link to the Course entity
        public int? Degree { get; set; }    // Property to store the degree or grade achieved by the student in the course
        public virtual Student Student { get; set; }  // Navigation property to the related Student entity (virtual for lazy loading)
        public virtual Course Course { get; set; }    // Navigation property to the related Course entity (virtual for lazy loading)
    }
}
