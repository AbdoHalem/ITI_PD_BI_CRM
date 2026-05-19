using Lab3.Models;

namespace Lab3.Pages
{
    public partial class ShowAllStudents
    {
        // List to hold the data coming from the API
        private List<DisplayStudentDTO>? studentsList;

        // This lifecycle method is async because we are making an HTTP call
        protected override async Task OnInitializedAsync()
        {
            // Fetch data using our injected service
            studentsList = await StudentService.GetAllStudentsAsync();
        }

        private void GoToEdit(int id)
        {
            // Programmatic navigation to the edit component
            NavManager.NavigateTo($"/edit-student/{id}");
        }
    }
}
