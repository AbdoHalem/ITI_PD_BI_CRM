using Lab3.Models;
using Microsoft.AspNetCore.Components;

namespace Lab3.Pages
{
    public partial class EditStudent
    {
        [Parameter]
        public int Id { get; set; }

        // Model bound to the form
        private EditStudentDTO studentToEdit = new EditStudentDTO();

        // List to populate the dropdown
        private List<DisplayDepartmemtDTO> departments = new();

        // Flag to ensure form only renders after data is fully loaded
        private bool isLoaded = false;

        protected override async Task OnInitializedAsync()
        {
            // 1. Fetch all departments for the dropdown
            departments = await DepartmentService.GetAllDepartmentsAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            // 2. Fetch the specific student details (returns DisplayStudentDTO)
            var displayStudent = await StudentService.GetStudentByIdAsync(Id);

            if (displayStudent != null)
            {
                // 3. Map the retrieved Display DTO to the Edit DTO
                studentToEdit.St_Id = displayStudent.St_Id;
                studentToEdit.St_Fname = displayStudent.St_Fname;
                studentToEdit.St_Lname = displayStudent.St_Lname;
                studentToEdit.St_Address = displayStudent.St_Address;
                studentToEdit.St_Age = displayStudent.St_Age;

                // 4. Workaround: Find Dept_Id by matching Dept_Name
                var matchingDept = departments.FirstOrDefault(d => d.Dept_Name == displayStudent.Dept_Name);
                if (matchingDept != null)
                {
                    studentToEdit.Dept_Id = matchingDept.Dept_Id;
                }

                isLoaded = true;
            }
        }

        private async Task HandleValidSubmit()
        {
            // Send PUT request via the service
            await StudentService.UpdateStudentAsync(Id, studentToEdit);

            // Navigate back on success
            NavManager.NavigateTo("/students");
        }

        private void CancelEdit()
        {
            NavManager.NavigateTo("/students");
        }
    }
}
