namespace Lab1_ADO
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
            btnDelete = new Button();
            btnUpdate = new Button();
            btnSearch = new Button();
            btnSync = new Button();
            txtBoxID = new TextBox();
            txtBoxName = new TextBox();
            txtBoxDept = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(422, 46);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(340, 249);
            dataGridView1.TabIndex = 0;
            // 
            // btnDisplay
            // 
            btnDisplay.Location = new Point(85, 46);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(75, 23);
            btnDisplay.TabIndex = 1;
            btnDisplay.Text = "Dispaly";
            btnDisplay.UseVisualStyleBackColor = true;
            btnDisplay.Click += btnDisplay_Click;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(85, 101);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(75, 23);
            btnInsert.TabIndex = 2;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(85, 161);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(85, 218);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(85, 272);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnSync
            // 
            btnSync.Location = new Point(235, 353);
            btnSync.Name = "btnSync";
            btnSync.Size = new Size(75, 23);
            btnSync.TabIndex = 6;
            btnSync.Text = "Sync DB";
            btnSync.UseVisualStyleBackColor = true;
            btnSync.Click += btnSync_Click;
            // 
            // txtBoxID
            // 
            txtBoxID.Location = new Point(235, 47);
            txtBoxID.Name = "txtBoxID";
            txtBoxID.PlaceholderText = "Enter ID";
            txtBoxID.Size = new Size(100, 23);
            txtBoxID.TabIndex = 7;
            // 
            // txtBoxName
            // 
            txtBoxName.Location = new Point(235, 101);
            txtBoxName.Name = "txtBoxName";
            txtBoxName.PlaceholderText = "Enter Name";
            txtBoxName.Size = new Size(100, 23);
            txtBoxName.TabIndex = 8;
            // 
            // txtBoxDept
            // 
            txtBoxDept.Location = new Point(235, 161);
            txtBoxDept.Name = "txtBoxDept";
            txtBoxDept.PlaceholderText = "Enter Department";
            txtBoxDept.Size = new Size(100, 23);
            txtBoxDept.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtBoxDept);
            Controls.Add(txtBoxName);
            Controls.Add(txtBoxID);
            Controls.Add(btnSync);
            Controls.Add(btnSearch);
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
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnSearch;
        private Button btnSync;
        private TextBox txtBoxID;
        private TextBox txtBoxName;
        private TextBox txtBoxDept;
    }
}
