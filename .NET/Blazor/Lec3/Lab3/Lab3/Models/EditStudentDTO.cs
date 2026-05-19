using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    // DTO for editing a student, includes validation rules
    public class EditStudentDTO
    {
        public int St_Id { get; set; }

        // Enforce required field and string length limits
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "First name must be between 3 and 20 characters")]
        public string? St_Fname { get; set; }

        // Enforce required field and string length limits
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Last name must be between 3 and 20 characters")]
        public string? St_Lname { get; set; }

        public string? St_Address { get; set; }

        // Validate age boundaries logically
        [Required(ErrorMessage = "Age is required")]
        [Range(18, 60, ErrorMessage = "Age must be between 18 and 60")]
        public int? St_Age { get; set; }

        // Ensure a valid department is selected from the dropdown
        [Required(ErrorMessage = "Please select a department")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid department")]
        public int? Dept_Id { get; set; }

        public int? Supervisor_Id { get; set; }
    }
}
