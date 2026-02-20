
namespace Lab9
{
    partial class FormatDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            Font = new TabPage();
            rbCourier = new RadioButton();
            rbArial = new RadioButton();
            rbTimes = new RadioButton();
            btnCancel = new Button();
            btnOK = new Button();
            Size = new TabPage();
            rb24 = new RadioButton();
            rb20 = new RadioButton();
            rb16 = new RadioButton();
            Color = new TabPage();
            btnColor = new Button();
            Text = new TabPage();
            newValue = new Label();
            txtNew = new TextBox();
            oldValue = new Label();
            txtOld = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            tabControl1.SuspendLayout();
            Font.SuspendLayout();
            Size.SuspendLayout();
            Color.SuspendLayout();
            Text.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Font);
            tabControl1.Controls.Add(Size);
            tabControl1.Controls.Add(Color);
            tabControl1.Controls.Add(Text);
            tabControl1.Location = new Point(176, 63);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(394, 277);
            tabControl1.TabIndex = 0;
            // 
            // Font
            // 
            Font.Controls.Add(rbCourier);
            Font.Controls.Add(rbArial);
            Font.Controls.Add(rbTimes);
            Font.Controls.Add(btnCancel);
            Font.Controls.Add(btnOK);
            Font.Location = new Point(4, 24);
            Font.Name = "Font";
            Font.Padding = new Padding(3);
            Font.Size = new Size(386, 249);
            Font.TabIndex = 0;
            Font.Text = "Font";
            Font.UseVisualStyleBackColor = true;
            // 
            // rbCourier
            // 
            rbCourier.AutoSize = true;
            rbCourier.Location = new Point(71, 112);
            rbCourier.Name = "rbCourier";
            rbCourier.Size = new Size(64, 19);
            rbCourier.TabIndex = 4;
            rbCourier.TabStop = true;
            rbCourier.Text = "Courier";
            rbCourier.UseVisualStyleBackColor = true;
            // 
            // rbArial
            // 
            rbArial.AutoSize = true;
            rbArial.Location = new Point(71, 74);
            rbArial.Name = "rbArial";
            rbArial.Size = new Size(49, 19);
            rbArial.TabIndex = 3;
            rbArial.TabStop = true;
            rbArial.Text = "Arial";
            rbArial.UseVisualStyleBackColor = true;
            // 
            // rbTimes
            // 
            rbTimes.AutoSize = true;
            rbTimes.Location = new Point(71, 39);
            rbTimes.Name = "rbTimes";
            rbTimes.Size = new Size(124, 19);
            rbTimes.TabIndex = 2;
            rbTimes.TabStop = true;
            rbTimes.Text = "Times New Roman";
            rbTimes.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(240, 190);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(71, 190);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // Size
            // 
            Size.Controls.Add(button1);
            Size.Controls.Add(button2);
            Size.Controls.Add(rb24);
            Size.Controls.Add(rb20);
            Size.Controls.Add(rb16);
            Size.Location = new Point(4, 24);
            Size.Name = "Size";
            Size.Padding = new Padding(3);
            Size.Size = new Size(386, 249);
            Size.TabIndex = 1;
            Size.Text = "Size";
            Size.UseVisualStyleBackColor = true;
            // 
            // rb24
            // 
            rb24.AutoSize = true;
            rb24.Location = new Point(68, 107);
            rb24.Name = "rb24";
            rb24.Size = new Size(37, 19);
            rb24.TabIndex = 7;
            rb24.TabStop = true;
            rb24.Text = "24";
            rb24.UseVisualStyleBackColor = true;
            // 
            // rb20
            // 
            rb20.AutoSize = true;
            rb20.Location = new Point(68, 69);
            rb20.Name = "rb20";
            rb20.Size = new Size(37, 19);
            rb20.TabIndex = 6;
            rb20.TabStop = true;
            rb20.Text = "20";
            rb20.UseVisualStyleBackColor = true;
            // 
            // rb16
            // 
            rb16.AutoSize = true;
            rb16.Location = new Point(68, 34);
            rb16.Name = "rb16";
            rb16.Size = new Size(37, 19);
            rb16.TabIndex = 5;
            rb16.TabStop = true;
            rb16.Text = "16";
            rb16.UseVisualStyleBackColor = true;
            // 
            // Color
            // 
            Color.Controls.Add(button3);
            Color.Controls.Add(button4);
            Color.Controls.Add(btnColor);
            Color.Location = new Point(4, 24);
            Color.Name = "Color";
            Color.Size = new Size(386, 249);
            Color.TabIndex = 2;
            Color.Text = "Color";
            Color.UseVisualStyleBackColor = true;
            // 
            // btnColor
            // 
            btnColor.AutoSize = true;
            btnColor.ForeColor = SystemColors.ControlText;
            btnColor.Location = new Point(144, 70);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(89, 25);
            btnColor.TabIndex = 9;
            btnColor.Text = "Choose Color";
            btnColor.UseVisualStyleBackColor = true;
            btnColor.Click += btnColor_Click;
            // 
            // Text
            // 
            Text.Controls.Add(button5);
            Text.Controls.Add(button6);
            Text.Controls.Add(newValue);
            Text.Controls.Add(txtNew);
            Text.Controls.Add(oldValue);
            Text.Controls.Add(txtOld);
            Text.Location = new Point(4, 24);
            Text.Name = "Text";
            Text.Size = new Size(386, 249);
            Text.TabIndex = 3;
            Text.Text = "Text";
            Text.UseVisualStyleBackColor = true;
            // 
            // newValue
            // 
            newValue.AutoSize = true;
            newValue.Location = new Point(89, 121);
            newValue.Name = "newValue";
            newValue.Size = new Size(62, 15);
            newValue.TabIndex = 3;
            newValue.Text = "New Value";
            // 
            // txtNew
            // 
            txtNew.Location = new Point(184, 113);
            txtNew.Name = "txtNew";
            txtNew.Size = new Size(100, 23);
            txtNew.TabIndex = 2;
            // 
            // oldValue
            // 
            oldValue.AutoSize = true;
            oldValue.Location = new Point(89, 56);
            oldValue.Name = "oldValue";
            oldValue.Size = new Size(57, 15);
            oldValue.TabIndex = 1;
            oldValue.Text = "Old Value";
            // 
            // txtOld
            // 
            txtOld.Location = new Point(184, 48);
            txtOld.Name = "txtOld";
            txtOld.Size = new Size(100, 23);
            txtOld.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(237, 177);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 9;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnCancel_Click;
            // 
            // button2
            // 
            button2.Location = new Point(68, 177);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 8;
            button2.Text = "OK";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnOK_Click;
            // 
            // button3
            // 
            button3.Location = new Point(240, 175);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 11;
            button3.Text = "Cancel";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnCancel_Click;
            // 
            // button4
            // 
            button4.Location = new Point(71, 175);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 10;
            button4.Text = "OK";
            button4.UseVisualStyleBackColor = true;
            button4.Click += btnOK_Click;
            // 
            // button5
            // 
            button5.Location = new Point(245, 184);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 5;
            button5.Text = "Cancel";
            button5.UseVisualStyleBackColor = true;
            button5.Click += btnCancel_Click;
            // 
            // button6
            // 
            button6.Location = new Point(76, 184);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 4;
            button6.Text = "OK";
            button6.UseVisualStyleBackColor = true;
            button6.Click += btnOK_Click;
            // 
            // FormatDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "FormatDialog";
            tabControl1.ResumeLayout(false);
            Font.ResumeLayout(false);
            Font.PerformLayout();
            Size.ResumeLayout(false);
            Size.PerformLayout();
            Color.ResumeLayout(false);
            Color.PerformLayout();
            Text.ResumeLayout(false);
            Text.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage Font;
        private TabPage Size;
        private TabPage Color;
        private TabPage Text;
        private RadioButton rbCourier;
        private RadioButton rbArial;
        private RadioButton rbTimes;
        private Button btnCancel;
        private Button btnOK;
        private RadioButton rb24;
        private RadioButton rb20;
        private RadioButton rb16;
        private Button btnColor;
        private Label oldValue;
        private TextBox txtOld;
        private Label newValue;
        private TextBox txtNew;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}