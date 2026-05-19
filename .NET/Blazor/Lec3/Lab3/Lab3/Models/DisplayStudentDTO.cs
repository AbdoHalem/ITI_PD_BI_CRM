namespace Lab3.Models
{
    // DTO for displaying student data received from the API
    public class DisplayStudentDTO
    {
        public int St_Id { get; set; }
        public string? St_Fname { get; set; }
        public string? St_Lname { get; set; }
        public string? St_Address { get; set; }
        public int? St_Age { get; set; }
        public string? Dept_Name { get; set; }
        public string? Supervisor_Name { get; set; }
    }
}
