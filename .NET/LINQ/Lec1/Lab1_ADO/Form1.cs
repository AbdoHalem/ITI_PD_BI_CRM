using Microsoft.Data.SqlClient;
using System.Data;

namespace Lab1_ADO
{
    public partial class Form1 : Form
    {
        // Variables for database connection (Disconnected Model)
        SqlDataAdapter dataAdapter;
        SqlConnection conn;
        DataSet dataSet;
        SqlCommand selectCmd;
        SqlCommand insertCmd;
        SqlCommand updateCmd;
        SqlCommand deleteCmd;
        public Form1()
        {
            InitializeComponent();
            dataAdapter = new SqlDataAdapter();
            conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=ADO_Lab; Integrated Security=True; TrustServerCertificate=True;");
            dataSet = new DataSet();
            selectCmd = new SqlCommand("SELECT * FROM Employee", conn);
            dataAdapter.SelectCommand = selectCmd;
            // Insert command
            insertCmd = new SqlCommand("INSERT INTO Employee (Name, Dept) VALUES (@Name, @Dept)", conn);
            // Add the ID automatically as identity column, so we don't need to specify it in the insert command
            SqlParameter nameParam = new SqlParameter("@Name", SqlDbType.NVarChar, 0, "Name");
            SqlParameter deptParam = new SqlParameter("@Dept", SqlDbType.NVarChar, 0, "Dept");
            insertCmd.Parameters.Add(nameParam);
            insertCmd.Parameters.Add(deptParam);
            dataAdapter.InsertCommand = insertCmd;
            // Delete command
            deleteCmd = new SqlCommand("DELETE FROM Employee WHERE ID = @ID;", conn);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int, 0, "ID");
            deleteCmd.Parameters.Add(idParam);
            dataAdapter.DeleteCommand = deleteCmd;
            // Update command
            updateCmd = new SqlCommand("Update Employee SET Dept = @Dept WHERE ID = @ID;", conn);
            SqlParameter deptParamUpdate = new SqlParameter("@Dept", SqlDbType.NVarChar, 0, "Dept");
            SqlParameter idParamUpdate = new SqlParameter("@ID", SqlDbType.Int, 0, "ID");
            updateCmd.Parameters.Add(deptParamUpdate);
            updateCmd.Parameters.Add(idParamUpdate);
            dataAdapter.UpdateCommand = updateCmd;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            // Check if the Employee table already exists in the DataSet
            if (!dataSet.Tables.Contains("Employee"))
            {
                conn.Open();    // Open the connection to the database
                dataAdapter.Fill(dataSet, "Employee");   // Fill the DataSet with data from the Employees table
                conn.Close();   // Close the connection
                dataGridView1.DataSource = dataSet.Tables["Employee"];
            }
            else
            {
                dataGridView1.DataSource = dataSet.Tables["Employee"];
            }
        }

        private void clearBoxes()
        {
            txtBoxID.Text = txtBoxName.Text = txtBoxDept.Text = "";   // Clear all text boxes
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            // Get the values from the text boxes
            string name = txtBoxName.Text;
            string dept = txtBoxDept.Text;
            // Check if the name and department fields are not empty before inserting
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(dept))
            {
                MessageBox.Show("Please enter both Name and Department.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Ensure the Employee table exists in the DataSet before accessing it
            DataTable? employeeTable = dataSet.Tables["Employee"];
            if (employeeTable != null)
            {
                // Create a new DataRow for the Employee table
                DataRow dataRow = employeeTable.NewRow();
                dataRow["Name"] = name;
                dataRow["Dept"] = dept;
                dataRow["ID"] = GetLastInsertedID() + 1;   // Set the ID to the next value based on the last inserted ID
                employeeTable.Rows.Add(dataRow);   // Add the new DataRow to the Employee table in the DataSet
            }
            else
            {
                MessageBox.Show("Employee table not found in DataSet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            clearBoxes();  // Clear the text boxes after inserting the record
        }

        private int GetLastInsertedID()
        {
            int lastId = 0;
            try
            {
                // SQL to get the current identity value for the Employee table
                const string sql = "SELECT CAST(IDENT_CURRENT('Employee') AS INT)";
                conn.Open();    // Open connection 
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        lastId = Convert.ToInt32(result);   // Convert safely to int
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving last inserted ID: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return lastId;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = txtBoxID.Text != "" ? int.Parse(txtBoxID.Text) : 0;
            if (id == 0)
            {
                MessageBox.Show("Please enter a valid ID to delete.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Ensure the Employee table exists in the DataSet before accessing it
            DataTable? employeeTable = dataSet.Tables["Employee"];
            if (employeeTable != null)
            {
                DataRow[] rowsToDelete = employeeTable.Select($"ID = {id}");
                if (rowsToDelete.Length > 0)
                {
                    foreach (DataRow row in rowsToDelete)
                    {   // Delete the row from the DataTable, which will mark it for deletion in the DataSet  
                        row.Delete();  // Mark the row for deletion
                    }
                }
                else
                {
                    MessageBox.Show("No record found with the specified ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Employee table not found in DataSet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            clearBoxes();  // Clear the text boxes after attempting to delete the record
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            conn.Open();    // Open the connection to the database
            dataAdapter.Update(dataSet, "Employee");   // Update the database with changes made in the DataSet
            conn.Close();   // Close the connection
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = txtBoxID.Text != "" ? int.Parse(txtBoxID.Text) : 0;
            string dept = txtBoxDept.Text;
            if (id == 0 || string.IsNullOrWhiteSpace(dept))
            {
                MessageBox.Show("Please enter a valid ID and Department to update.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Ensure the Employee table exists in the DataSet before accessing it
            DataTable? employeeTable = dataSet.Tables["Employee"];
            if (employeeTable != null)
            {
                DataRow[] rowsToUpdate = employeeTable.Select($"ID = {id}");
                if (rowsToUpdate.Length > 0)
                {
                    foreach (DataRow row in rowsToUpdate)
                    {   // Update the Dept column for the matching ID
                        row["Dept"] = dept;   // Update the department for the specified ID
                    }
                }
                else
                {
                    MessageBox.Show("No record found with the specified ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Employee table not found in DataSet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            clearBoxes();  // Clear the text boxes after attempting to update the record
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int id = txtBoxID.Text != "" ? int.Parse(txtBoxID.Text) : 0;
            if (id == 0)
            {
                MessageBox.Show("Please enter a valid ID to search.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Ensure the Employee table exists in the DataSet before accessing it
            DataTable? employeeTable = dataSet.Tables["Employee"];
            if (employeeTable != null)
            {
                // Create a DataView to filter the local data without hitting the database
                DataView searchView = new DataView(employeeTable);
                searchView.RowFilter = $"ID = {id}";
                if (searchView.Count > 0)
                {
                    // Bind the grid to the filtered view
                    dataGridView1.DataSource = searchView;
                }
                else
                {
                    MessageBox.Show("No record found with the specified ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please display the data first before searching.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
