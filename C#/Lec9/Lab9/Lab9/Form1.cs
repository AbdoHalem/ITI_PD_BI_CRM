using System.Windows.Forms.DataVisualization.Charting;

namespace Lab9
{
    public partial class Form1 : Form
    {
        // Company data for the table
        private int[] years = { 1988, 1989, 1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997 };
        private int[] revenues = { 150, 170, 180, 175, 200, 250, 210, 240, 280, 140 };
        // Variables for drawing the table
        private float tableX;
        private float tableY;
        private float cellWidth = 60;
        private float cellHeight = 30;
        public Form1()
        {
            InitializeComponent();
            // Enable double buffering to reduce flickering
            this.DoubleBuffered = true;
            this.KeyPreview = true; // Allow the form to capture key events
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.Resize += new EventHandler(Form1_Resize);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Change font to Arial, Size 16, Bold style
            companyName.Font = new Font("Arial", 16, FontStyle.Bold);
            // Change font to Arial, Size 12, Bold style
            description.Font = new Font("Arial", 12, FontStyle.Bold);
            // --- Chart Configurations ---
            DisplayChartData(years, revenues);
            // Initialize table position
            CenterElements();
        }
        /**
         * Method to display the data in a manual table 
         */
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);    // Call the base class's OnPaint method to draw the background
            Graphics g = e.Graphics; // Get the Graphics object to draw on the form
            // Drawing tools
            Pen borderPen = new Pen(Color.Black, 1);
            Brush textBrush = new SolidBrush(Color.Black);
            Font cellFont = new Font("Arial", 10);
            // Center text alignment for the cells
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center; // Center text horizontally
            stringFormat.LineAlignment = StringAlignment.Center;

            // Draw header of first row (years)
            float currentX = tableX;
            float currentY = tableY;
            RectangleF headerRect1 = new RectangleF(currentX, currentY, cellWidth, cellHeight);
            g.FillRectangle(Brushes.LightGray, headerRect1); // Fill header cell with light gray
            g.DrawRectangle(borderPen, currentX, currentY, cellWidth, cellHeight); // Draw cell border
            g.DrawString("Year", cellFont, textBrush, headerRect1, stringFormat); // Draw header text
            currentX += cellWidth; // Move to the next cell  
            // Draw the years data in the first row
            for (int i = 0; i < years.Length; i++)
            {
                RectangleF cellRect = new RectangleF(currentX, currentY, cellWidth, cellHeight);
                g.FillRectangle(Brushes.White, cellRect); // Fill cell with white
                g.DrawRectangle(borderPen, currentX, currentY, cellWidth, cellHeight); // Draw cell border
                g.DrawString(years[i].ToString(), cellFont, textBrush, cellRect, stringFormat); // Draw year value
                currentX += cellWidth; // Move to the next cell
            }

            // Draw header of second row (Revenues)
            currentX = tableX;          // Reset X to the start of the table
            currentY += cellHeight;     // Move to the next row
            RectangleF headerRect2 = new RectangleF(currentX, currentY, cellWidth, cellHeight);
            g.FillRectangle(Brushes.LightGray, headerRect2);    // Fill header cell with light gray
            g.DrawRectangle(borderPen, currentX, currentY, cellWidth, cellHeight);      // Draw cell border
            g.DrawString("Revenue", cellFont, textBrush, headerRect2, stringFormat);    // Draw header text
            currentX += cellWidth;      // Move to the next cell
            // Draw the revenues data in the first row
            for (int i = 0; i < revenues.Length; i++)
            {
                RectangleF cellRect = new RectangleF(currentX, currentY, cellWidth, cellHeight);
                g.DrawRectangle(borderPen, currentX, currentY, cellWidth, cellHeight);
                g.DrawString(revenues[i].ToString(), cellFont, textBrush, cellRect, stringFormat);
                currentX += cellWidth;
            }
        }
        /**
         * Method to recenter the table on the form
         */
        private void Form1_Resize(object? sender, EventArgs e)
        {
            CenterElements();  // Recalculate positions when the form is resized
            this.Invalidate(); // Redraw the form
        }
        /**
         * Method to center the elements on window resizing
         */
        private void CenterElements()
        {
            // Center the labels
            companyName.Left = (this.ClientSize.Width - companyName.Width) / 2;
            description.Left = (this.ClientSize.Width - description.Width) / 2;
            // Claculate the dimensions of the chart on left side
            chart1.Size = new Size(this.ClientSize.Width / 2 - 50, this.ClientSize.Height / 2);
            chart1.Left = (this.ClientSize.Width - chart1.Width) / 6 - 50;
            // Calculate the position of the table on the right side
            float totalTableWidth = cellWidth * (years.Length + 1); // Total width of the table
            tableX = (this.ClientSize.Width / 2) + 100;
            tableY = 120;
        }
        /**
         * Method to handle key presses for changing the line color in the chart
         */
        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (chart1.Series.IndexOf("LineSeries") != -1)
            {
                Series lineSeries = chart1.Series["LineSeries"];
                if (e.Control && e.KeyCode == Keys.R) lineSeries.Color = Color.Red;
                else if (e.Control && e.KeyCode == Keys.G) lineSeries.Color = Color.Green;
                else if (e.Control && e.KeyCode == Keys.B) lineSeries.Color = Color.Blue;
            }
        }
        /**
         * Method to display the data in the chart
         */
        private void DisplayChartData(int[] years, int[] revenues)
        {
            chart1.Series.Clear(); // Clear any existing series
            chart1.ChartAreas[0].AxisX.Title = "Year";
            chart1.ChartAreas[0].AxisY.Title = "Revenue";
            chart1.ChartAreas[0].AxisX.Interval = 1; // Set X-axis interval to 1 for better readability
            // Create a new series for the bar chart
            Series barSeries = new Series("BarSeries");
            barSeries.ChartType = SeriesChartType.Column; // Set the chart type to Column (Bar)
            barSeries.Color = Color.Red;
            barSeries.BackHatchStyle = ChartHatchStyle.BackwardDiagonal;
            // Create a new series for the line chart
            Series lineSeries = new Series("LineSeries");
            lineSeries.ChartType = SeriesChartType.Line;
            lineSeries.Color = Color.Blue;
            lineSeries.BorderWidth = 3;
            lineSeries.BorderDashStyle = ChartDashStyle.Solid;

            // Add data points to both series
            for (int i = 0; i < years.Length; i++)
            {
                barSeries.Points.AddXY(years[i], revenues[i]);
                lineSeries.Points.AddXY(years[i], revenues[i]);
            }
            chart1.Series.Add(barSeries);  // Add the bar series to the chart
            chart1.Series.Add(lineSeries); // Add the line series to the chart
        }
        /**
         * Method to handle mouse clicks on the chart and display the corresponding data point values
         */
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            // Get the clicked point on the chart
            HitTestResult result = chart1.HitTest(e.X, e.Y);
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                var prop = result.Series.Points[result.PointIndex];
                MessageBox.Show($"Year: {prop.XValue}, Revenue: {prop.YValues[0]}");
            }
        }
        // This is the NEW part for Lab 9
        /**
         * Handle the menu click: Format -> Company Name
         */
        private void companyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Create instance of FormatDialog
            FormatDialog dlg = new FormatDialog(companyName.Font, companyName.ForeColor, companyName.Text);
            // 2. Show the dialog and wait for result
            if(dlg.ShowDialog() == DialogResult.OK )
            {
                // 3. If User clicked OK, apply the new values
                companyName.Font = dlg.SelectedFont;
                companyName.ForeColor = dlg.SelectedColor;
                companyName.Text = dlg.NewText;
                // Re-center elements in case the text length changed
                CenterElements();
            }
        }
    }
}
