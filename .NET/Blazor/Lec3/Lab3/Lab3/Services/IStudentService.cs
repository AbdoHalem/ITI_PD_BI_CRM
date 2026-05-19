using Lab3.Models;

namespace Lab3.Services
{
    public interface IStudentService
    {
        // Fetch all students
        Task<List<DisplayStudentDTO>> GetAllStudentsAsync();

        // Fetch a single student by ID
        Task<DisplayStudentDTO> GetStudentByIdAsync(int id);

        // Update an existing student
        Task UpdateStudentAsync(int id, EditStudentDTO student);
    }
}
