namespace EF_CRUD
{
    public partial class Form1 : Form
    {
        // Context for database operations
        private AppDbContext dbContext;
        public Form1()
        {
            InitializeComponent();
            dbContext = new AppDbContext(); // Initialize EF Core context
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        private void RefreshGrid()
        {
            // Fetch all employees from the database and bind them to the grid
            dataGridView1.DataSource = dbContext.Employees.ToList();
        }

        private void clearBoxes()
        {
            txtBoxID.Text = txtBoxName.Text = txtBoxDept.Text = "";   // Clear all text boxes
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string name = txtBoxName.Text;
            string dept = txtBoxDept.Text;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(dept))
            {
                MessageBox.Show("Please enter both Name and Department.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Create a new Employee object
            Employee newEmployee = new Employee
            {
                Name = name,
                Dept = dept
            };
            // Add the object to the context and save changes
            // Note: We don't need GetLastInsertedID() anymore. EF handles Identity columns automatically.
            dbContext.Employees.Add(newEmployee);
            dbContext.SaveChanges();
            RefreshGrid();
            clearBoxes();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBoxID.Text, out int id))
            {
                // Find the employee by ID
                var employee = dbContext.Employees.Find(id);
                if (employee != null)
                {
                    dbContext.Employees.Remove(employee);
                    dbContext.SaveChanges(); // Execute the delete
                    RefreshGrid();
                }
                else
                {
                    MessageBox.Show("No record found with the specified ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid ID to delete.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            clearBoxes();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string dept = txtBoxDept.Text;
            if (int.TryParse(txtBoxID.Text, out int id) && !string.IsNullOrWhiteSpace(dept))
            {
                // Find the employee by ID
                var employee = dbContext.Employees.Find(id);
                if (employee != null)
                {
                    employee.Dept = dept; // Update the property
                    dbContext.SaveChanges(); // EF tracks changes, so saving updates the DB automatically
                    RefreshGrid();
                }
                else
                {
                    MessageBox.Show("No record found with the specified ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid ID and Department to update.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            clearBoxes();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBoxID.Text, out int id))
            {
                // Query the database using LINQ
                var result = dbContext.Employees.Where(emp => emp.ID == id).ToList();

                if (result.Any())
                {
                    dataGridView1.DataSource = result; // Bind grid to the search result
                }
                else
                {
                    MessageBox.Show("No record found with the specified ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid ID to search.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
