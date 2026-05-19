namespace Lab3.Models
{
    // DTO for displaying department data in dropdowns
    public class DisplayDepartmemtDTO
    {
        public int Dept_Id { get; set; }
        public string? Dept_Name { get; set; }
        public string? Dept_Desc { get; set; }
        public string? Dept_Location { get; set; }
        public int? Dept_Manager { get; set; }
        public string? Manager_Name { get; set; }
        public int Students_Count { get; set; }
    }
}
