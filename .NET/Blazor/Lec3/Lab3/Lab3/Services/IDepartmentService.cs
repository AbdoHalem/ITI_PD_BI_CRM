using Lab3.Models;

namespace Lab3.Services
{
    public interface IDepartmentService
    {
        // Fetch all departments to populate the dropdown
        Task<List<DisplayDepartmemtDTO>> GetAllDepartmentsAsync();
    }
}
