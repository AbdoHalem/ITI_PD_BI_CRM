using System.Net.Http.Json;

namespace CourseDesktopClient
{
    public partial class Form1 : Form
    {
        // HttpClient instance to make API requests
        private static readonly HttpClient client = new HttpClient();
        private string apiUrl = "https://localhost:7232/api/Courses";
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            btnAdd.Click += btnAdd_Click;
            txtName.PlaceholderText = "Course Name";
            txtDesc.PlaceholderText = "Course Description";
            txtDuration.PlaceholderText = "Duration";
        }

        // Event handler for Form Load to fetch data when the app starts
        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadCourses();
        }

        // Method to Read courses from the API (GET Action)
        private async Task LoadCourses()
        {
            try
            {
                // Call the GET endpoint
                List<Course>? courses = await client.GetFromJsonAsync<List<Course>>(apiUrl);

                // Bind the returned data to the DataGridView
                dataGridViewCourses.DataSource = courses;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
            }
        }

        // Event handler for the Add button (Create Action)
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // Create a new course object from the text boxes
            Course newCourse = new Course
            {
                Crs_name = txtName.Text,
                Crs_desc = txtDesc.Text,
                Duration = int.Parse(txtDuration.Text)
            };

            try
            {
                // Call the POST endpoint
                HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl, newCourse);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Course added successfully!");

                    // Clear the text boxes
                    txtName.Clear();
                    txtDesc.Clear();
                    txtDuration.Clear();

                    // Refresh the grid to show the new course
                    await LoadCourses();
                }
                else
                {
                    MessageBox.Show("Failed to add course. Status Code: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding course: " + ex.Message);
            }
        }
    }
}
