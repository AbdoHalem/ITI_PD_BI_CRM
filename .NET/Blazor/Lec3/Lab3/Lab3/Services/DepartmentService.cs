using Lab3.Models;
using System.Net.Http.Json;

namespace Lab3.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _httpClient;

        // Injecting HttpClient
        public DepartmentService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<List<DisplayDepartmemtDTO>> GetAllDepartmentsAsync()
        {
            // Calls the [HttpGet] endpoint in DepartmentsController
            return await _httpClient.GetFromJsonAsync<List<DisplayDepartmemtDTO>>("api/Departments")
                   ?? new List<DisplayDepartmemtDTO>();
        }
    }
}
