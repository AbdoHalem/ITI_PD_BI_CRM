namespace Lab9
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            companyName = new Label();
            description = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            menuStrip1 = new MenuStrip();
            formatToolStripMenuItem = new ToolStripMenuItem();
            companyNameToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // companyName
            // 
            companyName.AutoSize = true;
            companyName.Location = new Point(391, 26);
            companyName.Name = "companyName";
            companyName.Size = new Size(85, 15);
            companyName.TabIndex = 0;
            companyName.Text = "ABC Company";
            companyName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // description
            // 
            description.AutoSize = true;
            description.Location = new Point(391, 53);
            description.Name = "description";
            description.Size = new Size(93, 15);
            description.TabIndex = 1;
            description.Text = "Annual Revenue";
            description.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(41, 92);
            chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart1.Series.Add(series2);
            chart1.Size = new Size(300, 259);
            chart1.TabIndex = 2;
            chart1.Text = "chart1";
            chart1.MouseClick += chart1_MouseClick;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { formatToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(859, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // formatToolStripMenuItem
            // 
            formatToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { companyNameToolStripMenuItem });
            formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            formatToolStripMenuItem.Size = new Size(57, 20);
            formatToolStripMenuItem.Text = "Format";
            // 
            // companyNameToolStripMenuItem
            // 
            companyNameToolStripMenuItem.Name = "companyNameToolStripMenuItem";
            companyNameToolStripMenuItem.Size = new Size(180, 22);
            companyNameToolStripMenuItem.Text = "Company Name";
            companyNameToolStripMenuItem.Click += companyNameToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(859, 450);
            Controls.Add(chart1);
            Controls.Add(description);
            Controls.Add(companyName);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label companyName;
        private Label description;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem formatToolStripMenuItem;
        private ToolStripMenuItem companyNameToolStripMenuItem;
    }
}
