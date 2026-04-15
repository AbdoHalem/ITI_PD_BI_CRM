namespace Lab2.DTO.DepartmentsDTO
{
    public class EditDepartmentDTO
    {
        public int Dept_Id { get; set; }

        public string? Dept_Name { get; set; }

        public string? Dept_Desc { get; set; }

        public string? Dept_Location { get; set; }

        public int? Dept_Manager { get; set; }

        public DateOnly? Manager_hiredate { get; set; }
    }
}
