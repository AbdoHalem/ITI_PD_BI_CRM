using System.ComponentModel.DataAnnotations;

namespace Lab1.Models
{
    public class Course
    {
        // Primary key for the database table
        [Key]
        public int ID { get; set; }

        // Course name with a maximum length of 50 characters
        [Required]
        [MaxLength(50)]
        public string Crs_name { get; set; }

        // Course description with a maximum length of 150 characters
        [MaxLength(150)]
        public string Crs_desc { get; set; }

        // Course duration in hours or days
        public int Duration { get; set; }
    }
}
