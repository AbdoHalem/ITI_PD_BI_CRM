namespace EF_CRUD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnDisplay = new Button();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            txtBoxID = new TextBox();
            txtBoxName = new TextBox();
            txtBoxDept = new TextBox();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(522, 46);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(240, 254);
            dataGridView1.TabIndex = 0;
            // 
            // btnDisplay
            // 
            btnDisplay.Location = new Point(105, 46);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(75, 23);
            btnDisplay.TabIndex = 1;
            btnDisplay.Text = "Display";
            btnDisplay.UseVisualStyleBackColor = true;
            btnDisplay.Click += btnDisplay_Click;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(105, 105);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(75, 23);
            btnInsert.TabIndex = 2;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(105, 217);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(105, 158);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtBoxID
            // 
            txtBoxID.Location = new Point(282, 46);
            txtBoxID.Name = "txtBoxID";
            txtBoxID.PlaceholderText = "Enter ID";
            txtBoxID.Size = new Size(131, 23);
            txtBoxID.TabIndex = 5;
            // 
            // txtBoxName
            // 
            txtBoxName.Location = new Point(282, 106);
            txtBoxName.Name = "txtBoxName";
            txtBoxName.PlaceholderText = "Enter Name";
            txtBoxName.Size = new Size(131, 23);
            txtBoxName.TabIndex = 6;
            // 
            // txtBoxDept
            // 
            txtBoxDept.Location = new Point(282, 164);
            txtBoxDept.Name = "txtBoxDept";
            txtBoxDept.PlaceholderText = "Enter Department ID";
            txtBoxDept.Size = new Size(131, 23);
            txtBoxDept.TabIndex = 7;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(105, 277);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSearch);
            Controls.Add(txtBoxDept);
            Controls.Add(txtBoxName);
            Controls.Add(txtBoxID);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnInsert);
            Controls.Add(btnDisplay);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnDisplay;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox txtBoxID;
        private TextBox txtBoxName;
        private TextBox txtBoxDept;
        private Button btnSearch;
    }
}
