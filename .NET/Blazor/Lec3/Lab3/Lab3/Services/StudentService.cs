using Lab3.Models;
using System.Net.Http.Json;

namespace Lab3.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;

        // Injecting HttpClient into the constructor
        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DisplayStudentDTO>> GetAllStudentsAsync()
        {
            // Calls the [HttpGet] endpoint in StudentsController
            return await _httpClient.GetFromJsonAsync<List<DisplayStudentDTO>>("api/Students")
                   ?? new List<DisplayStudentDTO>();
        }

        public async Task<DisplayStudentDTO> GetStudentByIdAsync(int id)
        {
            // Calls the [HttpGet("{id}")] endpoint in StudentsController
            return await _httpClient.GetFromJsonAsync<DisplayStudentDTO>($"api/Students/{id}");
        }

        public async Task UpdateStudentAsync(int id, EditStudentDTO student)
        {
            // Calls the [HttpPut("{id}")] endpoint in StudentsController
            await _httpClient.PutAsJsonAsync($"api/Students/{id}", student);
        }
    }
}
