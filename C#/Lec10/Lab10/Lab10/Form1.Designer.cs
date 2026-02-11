namespace Lab10
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
            txtLeftPath = new TextBox();
            txtRightPath = new TextBox();
            btnCopy = new Button();
            btnDelete = new Button();
            btnNew = new Button();
            btnMoveRight = new Button();
            btnMoveLeft = new Button();
            btnGoLeft = new Button();
            btnGoRight = new Button();
            listBoxLeft = new ListBox();
            listBoxRight = new ListBox();
            btnBack = new Button();
            SuspendLayout();
            // 
            // txtLeftPath
            // 
            txtLeftPath.Location = new Point(115, 55);
            txtLeftPath.Name = "txtLeftPath";
            txtLeftPath.Size = new Size(100, 23);
            txtLeftPath.TabIndex = 0;
            // 
            // txtRightPath
            // 
            txtRightPath.Location = new Point(538, 55);
            txtRightPath.Name = "txtRightPath";
            txtRightPath.Size = new Size(100, 23);
            txtRightPath.TabIndex = 1;
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(115, 346);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(75, 23);
            btnCopy.TabIndex = 2;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(388, 346);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(662, 346);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(75, 23);
            btnNew.TabIndex = 4;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnMoveRight
            // 
            btnMoveRight.Location = new Point(388, 151);
            btnMoveRight.Name = "btnMoveRight";
            btnMoveRight.Size = new Size(75, 23);
            btnMoveRight.TabIndex = 5;
            btnMoveRight.Text = ">>";
            btnMoveRight.UseVisualStyleBackColor = true;
            btnMoveRight.Click += btnMoveRight_Click;
            // 
            // btnMoveLeft
            // 
            btnMoveLeft.Location = new Point(388, 208);
            btnMoveLeft.Name = "btnMoveLeft";
            btnMoveLeft.Size = new Size(75, 23);
            btnMoveLeft.TabIndex = 6;
            btnMoveLeft.Text = "<<";
            btnMoveLeft.UseVisualStyleBackColor = true;
            btnMoveLeft.Click += btnMoveLeft_Click;
            // 
            // btnGoLeft
            // 
            btnGoLeft.Location = new Point(239, 54);
            btnGoLeft.Name = "btnGoLeft";
            btnGoLeft.Size = new Size(75, 23);
            btnGoLeft.TabIndex = 7;
            btnGoLeft.Text = "Go";
            btnGoLeft.UseVisualStyleBackColor = true;
            btnGoLeft.Click += btnGoLeft_Click;
            // 
            // btnGoRight
            // 
            btnGoRight.Location = new Point(662, 54);
            btnGoRight.Name = "btnGoRight";
            btnGoRight.Size = new Size(75, 23);
            btnGoRight.TabIndex = 8;
            btnGoRight.Text = "Go";
            btnGoRight.UseVisualStyleBackColor = true;
            btnGoRight.Click += btnGoRight_Click;
            // 
            // listBoxLeft
            // 
            listBoxLeft.FormattingEnabled = true;
            listBoxLeft.ItemHeight = 15;
            listBoxLeft.Location = new Point(115, 105);
            listBoxLeft.Name = "listBoxLeft";
            listBoxLeft.Size = new Size(199, 214);
            listBoxLeft.TabIndex = 9;
            listBoxLeft.DoubleClick += listBoxLeft_DoubleClick;
            listBoxLeft.Enter += listBoxLeft_Enter;
            // 
            // listBoxRight
            // 
            listBoxRight.FormattingEnabled = true;
            listBoxRight.ItemHeight = 15;
            listBoxRight.Location = new Point(538, 105);
            listBoxRight.Name = "listBoxRight";
            listBoxRight.Size = new Size(199, 214);
            listBoxRight.TabIndex = 10;
            listBoxRight.DoubleClick += listBoxRight_DoubleClick;
            listBoxRight.Enter += listBoxRight_Enter;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 11;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(listBoxRight);
            Controls.Add(listBoxLeft);
            Controls.Add(btnGoRight);
            Controls.Add(btnGoLeft);
            Controls.Add(btnMoveLeft);
            Controls.Add(btnMoveRight);
            Controls.Add(btnNew);
            Controls.Add(btnDelete);
            Controls.Add(btnCopy);
            Controls.Add(txtRightPath);
            Controls.Add(txtLeftPath);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLeftPath;
        private TextBox txtRightPath;
        private Button btnCopy;
        private Button btnDelete;
        private Button btnNew;
        private Button btnMoveRight;
        private Button btnMoveLeft;
        private Button btnGoLeft;
        private Button btnGoRight;
        private ListBox listBoxLeft;
        private ListBox listBoxRight;
        private Button btnBack;
    }
}
