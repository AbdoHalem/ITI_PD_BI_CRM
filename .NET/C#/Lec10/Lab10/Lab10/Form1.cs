using System.Collections;
using System.IO; // Important for File and Directory handling
namespace Lab10
{
    public partial class Form1 : Form
    {
        // Variables to store the current paths for left and right directories
        private string leftPath = "DRIVES";
        private string rightPath = "DRIVES";
        // Variable to track which pane was last touched (for Copy/Delete buttons)
        ListBox? lastFocusedList = null;
        // Variable to track which list box is currently active (left or right)

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initial Load: Show drives in both lists
            LoadDrives(listBoxLeft);
            LoadDrives(listBoxRight);
            // Set initial tracking
            lastFocusedList = listBoxLeft;
        }
        /**
         * Method to load drives into a given ListBox
         */
        private void LoadDrives(ListBox listBox)
        {
            listBox.Items.Clear();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                listBox.Items.Add(drive.Name);
            }
        }
        /**
         * Method to load directories and files from a given path into a ListBox
         */
        private void LoadDirectory(string path, ListBox listBox)
        {
            try
            {
                listBox.Items.Clear();
                listBox.Items.Add(".");     // Go Up one level
                listBox.Items.Add("..");    // Go to Drives
                // 1. Add folders
                string[] dirs = Directory.GetDirectories(path);
                foreach (string dir in dirs)
                {
                    // GetFileName returns just the folder name, not full path
                    listBox.Items.Add(Path.GetFileName(dir));
                }
                // 2. Add files
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    listBox.Items.Add(Path.GetFileName(file));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading directory: {ex.Message}");
            }
        }
        /**
         * Event: Double Click on Left ListBox
         */
        private void listBoxLeft_DoubleClick(object sender, EventArgs e)
        {
            HandleNavigation(listBoxLeft, ref leftPath, txtLeftPath);
        }
        /**
        * Event: Double Click on Right ListBox
        */
        private void listBoxRight_DoubleClick(object sender, EventArgs e)
        {
            HandleNavigation(listBoxRight, ref rightPath, txtRightPath);
        }
        /**
         * Method to handle navigation when a ListBox item is double-clicked
         */
        private void HandleNavigation(ListBox listBox, ref string currentPath, TextBox txtPath)
        {
            // Check if nothing is selected
            if (listBox.SelectedItem == null) return;

            string selectedItem = listBox.SelectedItem.ToString() ?? "";
            // Case 1: We are currently looking at Drives
            if (currentPath == "DRIVES")
            {
                // Set the new path (e.g., "C:\")
                currentPath = selectedItem; // Update path to the selected drive
                txtPath.Text = currentPath; // Update the TextBox
                LoadDirectory(currentPath, listBox); // Load the drive's contents
            }
            else    // Case 2: We are inside a folder
            {
                if (selectedItem == "..")
                {
                    // Return to Drives
                    currentPath = "DRIVES";
                    txtPath.Text = "";
                    LoadDrives(listBox);
                }
                else if (selectedItem == ".")
                {
                    // Go up one level
                    DirectoryInfo? parent = Directory.GetParent(currentPath);
                    if (parent != null)
                    {
                        currentPath = parent.FullName;
                        txtPath.Text = currentPath;
                        LoadDirectory(currentPath, listBox);
                    }
                    else
                    {
                        // If no parent, we are at root, so go back to drives
                        currentPath = "DRIVES";
                        txtPath.Text = "";
                        LoadDrives(listBox);
                    }
                }
                else
                {
                    // Normal folder or file selected, navigate into it if it's a directory
                    string fullPath = Path.Combine(currentPath, selectedItem);
                    if (Directory.Exists(fullPath))
                    {
                        // It's a directory -> navigate into it
                        currentPath = fullPath;
                        txtPath.Text = currentPath;
                        LoadDirectory(currentPath, listBox);
                    }
                    else
                    {
                        // It's a file -> Show Message
                        MessageBox.Show("This is a file: " + selectedItem);
                    }
                }
            }
        }
        /**
         * Event: When a ListBox gets focus, update the lastFocusedList variable
         */
        private void listBoxLeft_Enter(object sender, EventArgs e)
        {
            lastFocusedList = listBoxLeft;
        }
        /**
         * Event: When a ListBox gets focus, update the lastFocusedList variable
         */
        private void listBoxRight_Enter(object sender, EventArgs e)
        {
            lastFocusedList = listBoxRight;
        }
        /**
         * Event: Delete Button Clicked Handler
         */
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lastFocusedList == null || lastFocusedList.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to delete.");
                return;
            }
            string currentPath = (lastFocusedList == listBoxLeft) ? leftPath : rightPath;
            if (currentPath == "DRIVES")
            {
                MessageBox.Show("Cannot delete items from the Drives.");
                return;
            }

            string selectedItem = lastFocusedList.SelectedItem.ToString() ?? "";
            if (selectedItem == "." || selectedItem == "..")
            {
                MessageBox.Show("Cannot delete navigation items.");
                return;
            }

            string fullPath = Path.Combine(currentPath, selectedItem);
            try
            {
                if (File.Exists(fullPath))
                {
                    // Delete file
                    File.Delete(fullPath);
                }
                else if (Directory.Exists(fullPath))
                {
                    Directory.Delete(fullPath, true);   // true to delete recursively
                }
                // Refresh the listbox
                LoadDirectory(currentPath, lastFocusedList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting: " + ex.Message);
            }
        }
        /**
         * Event: Move-to-Right Button Clicked Handler
         */
        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            MoveItem(leftPath, rightPath, listBoxLeft, listBoxRight);
        }
        /**
         * Event: Move-to-Left Button Clicked Handler
         */
        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            MoveItem(rightPath, leftPath, listBoxRight, listBoxLeft);
        }
        /**
         * Method to move an item from one pane to the other
         */
        private void MoveItem(string sourcePath, string destPath, ListBox sourceList, ListBox destList)
        {
            if (sourceList.SelectedItem == null || sourcePath == "DRIVES" || destPath == "DRIVES")
            {
                return;
            }
            string item = sourceList.SelectedItem.ToString() ?? "";
            if (item == "." || item == "..")
            {
                MessageBox.Show("Cannot move navigation items.");
                return;
            }
            string sourceFile = Path.Combine(sourcePath, item);
            string destFile = Path.Combine(destPath, item);

            try
            {
                if (File.Exists(sourceFile))
                {
                    // Move file
                    File.Move(sourceFile, destFile);
                }
                else if (Directory.Exists(sourceFile))
                {
                    // Move directory
                    Directory.Move(sourceFile, destFile);
                }
                // Refresh both lists
                LoadDirectory(sourcePath, sourceList);
                LoadDirectory(destPath, destList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error moving: " + ex.Message);
            }
        }
        /**
         * Event: Copy Button Clicked Handler
         */
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (lastFocusedList == null || lastFocusedList.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to copy.");
                return;
            }
            if (lastFocusedList == listBoxLeft)
            {
                CopyItem(leftPath, rightPath, listBoxLeft, listBoxRight);
            }
            else
            {
                CopyItem(rightPath, leftPath, listBoxRight, listBoxLeft);
            }
        }
        /**
         * Method to copy an item from one pane to the other
         */
        private void CopyItem(string sourcePath, string destPath, ListBox sourceList, ListBox destList)
        {
            if (sourceList.SelectedItem == null || sourcePath == "DRIVES" || destPath == "DRIVES")
            {
                return;
            }
            string item = sourceList.SelectedItem.ToString() ?? "";
            if (item == "." || item == "..")
            {
                MessageBox.Show("Cannot copy navigation items.");
                return;
            }
            string sourceFile = Path.Combine(sourcePath, item);
            string destFile = Path.Combine(destPath, item);
            try
            {
                if (File.Exists(sourceFile))
                {
                    // Copy file
                    File.Copy(sourceFile, destFile);
                }
                else if (Directory.Exists(sourceFile))
                {
                    // Copy directory (recursive)
                    CopyDirectory(sourceFile, destFile);
                }
                // Refresh destination list
                LoadDirectory(destPath, destList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error copying: " + ex.Message);
            }
        }
        /**
         * Method to recursively copy a directory and its contents
         */
        private void CopyDirectory(string sourceDir, string destDir, bool overWrite = true)
        {
            // Check if destination dir exists (if it exists -> replace it)
            if (Directory.Exists(destDir))
            {
                // If overwrite is true, delete the existing directory before copying
                if (overWrite)
                {
                    Directory.Delete(destDir, true);   // true to delete recursively
                }
                else
                {
                    MessageBox.Show($"Directory {destDir} already exists. Skipping copy.");
                    return;
                }
            }
            // 1. Create the destination directory
            Directory.CreateDirectory(destDir);
            // 2. Copy all files
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(destDir, Path.GetFileName(file));
                File.Copy(file, destFile, overWrite);
            }
            // Recursively copy subdirectories
            foreach (string dir in Directory.GetDirectories(sourceDir))
            {
                string destSubDir = Path.Combine(destDir, Path.GetFileName(dir));
                CopyDirectory(dir, destSubDir, overWrite);
            }
        }
        /**
         * Event: Back Button Clicked Handler
         * Go up one level
         */
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Determine which pane is active
            ListBox listBox = (lastFocusedList == listBoxLeft) ? listBoxLeft : listBoxRight;
            string currentPath = (lastFocusedList == listBoxLeft) ? leftPath : rightPath;
            if (currentPath == "DRIVES") return; // Can't go back from Drives

            TextBox txtPath = (lastFocusedList == listBoxLeft) ? txtLeftPath : txtRightPath;
            DirectoryInfo? parent = Directory.GetParent(currentPath);
            if (parent != null)
            {
                // Update the member variable and UI for the correct pane
                if (lastFocusedList == listBoxLeft)
                {
                    leftPath = parent.FullName;
                    txtLeftPath.Text = leftPath;
                }
                else
                {
                    rightPath = parent.FullName;
                    txtRightPath.Text = rightPath;
                }
                LoadDirectory(parent.FullName, listBox);
            }
            else
            {
                // If no parent, we are at root, so go back to drives
                if (lastFocusedList == listBoxLeft)
                {
                    leftPath = "DRIVES";
                    txtLeftPath.Text = "";
                }
                else
                {
                    rightPath = "DRIVES";
                    txtRightPath.Text = "";
                }
                LoadDrives(listBox);
            }
        }
        /**
         * Event: Go Left Button Clicked
         * Navigate to the path written in the left textbox manually
         */
        private void btnGoLeft_Click(object sender, EventArgs e)
        {
            string path = txtLeftPath.Text;
            if (Directory.Exists(path))
            {
                leftPath = path;    // Update the global variable
                LoadDirectory(leftPath, listBoxLeft);
            }
            else if (path == "" || path.ToUpper() == "DRIVES")
            {
                leftPath = "DRIVES";
                LoadDrives(listBoxLeft);
            }
            else
            {
                MessageBox.Show("This path not found!");
            }
            // Update focus
            lastFocusedList = listBoxLeft;
        }
        /**
         * Event: Go Right Button Clicked
         */
        private void btnGoRight_Click(object sender, EventArgs e)
        {
            string path = txtRightPath.Text;

            if (Directory.Exists(path))
            {
                rightPath = path; // Update the global variable
                LoadDirectory(rightPath, listBoxRight);
            }
            else if (path == "" || path.ToUpper() == "DRIVES")
            {
                rightPath = "DRIVES";
                LoadDrives(listBoxRight);
            }
            else
            {
                MessageBox.Show("Path not found!");
            }
            // Update focus
            lastFocusedList = listBoxRight;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // Check where to create the folder
            if (lastFocusedList == null)
            {
                MessageBox.Show("Please select a pane first.");
                return;
            }
            string currentPath = (lastFocusedList == listBoxLeft) ? leftPath : rightPath;
            if (currentPath == "DRIVES")
            {
                MessageBox.Show("Cannot create a folder in the Drives view.");
                return;
            }
            // Get folder name from user using our helper class
            string folderName = Prompt.ShowDialog("Enter new folder name:", "New Folder");
            if (!string.IsNullOrWhiteSpace(folderName))
            {
                string fullPath = Path.Combine(currentPath, folderName);
                try
                {
                    if (Directory.Exists(fullPath))
                    {
                        MessageBox.Show("Folder already exists!");
                    }
                    else
                    {
                        Directory.CreateDirectory(fullPath);
                        // Refresh the listbox
                        LoadDirectory(currentPath, lastFocusedList);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                }
            }
        }

        /**
         * Helper class to show an input dialog
         */
        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 300,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 20, Top = 20, Text = text, AutoSize = true };
                TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 240 };
                Button confirmation = new Button() { Text = "Ok", Left = 180, Width = 80, Top = 80, DialogResult = DialogResult.OK };

                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.AcceptButton = confirmation;
                textBox.Text = "New Folder";

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }
    }

}
