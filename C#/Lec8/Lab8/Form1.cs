using System.Windows.Forms.DataVisualization.Charting;

namespace Lab8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 1. Enable KeyPreview so the Form catches key presses globally
            this.KeyPreview = true;
            // 2. Subscribe to the KeyDown event
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            // Attach the Load event handler
            this.Resize += new EventHandler(Form1_Resize);
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            // We need to check if chart exists and has series to avoid errors
            if (chart1.Series.IndexOf("LineSeries") != -1)
            {
                Series lineSeries = chart1.Series["LineSeries"];
                // Check if Control key is held down AND the specific key is pressed
                if (e.Control && e.KeyCode == Keys.R) // Ctrl + R
                {
                    lineSeries.Color = Color.Red;
                }
                else if (e.Control && e.KeyCode == Keys.G) // Ctrl + G
                {
                    lineSeries.Color = Color.Green;
                }
                else if (e.Control && e.KeyCode == Keys.B) // Ctrl + B
                {
                    lineSeries.Color = Color.Blue;
                }
            }
        }
        private void DisplayGridData(int[] years, int[] revenues)
        {
            // Label Fonts
            companyName.Font = new Font("Arial", 16, FontStyle.Bold);
            description.Font = new Font("Arial", 12, FontStyle.Bold);
            //int[] years = { 1988, 1989, 1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997 };
            //int[] revenues = { 150, 170, 180, 175, 200, 250, 210, 240, 280, 140 };
            dataGrid.ColumnHeadersVisible = false;
            // Make the columns fill the grid width
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Set the number of columns
            dataGrid.ColumnCount = years.Length + 1;

            // Create the first row with years
            string[] rowYears = new string[years.Length + 1];
            rowYears[0] = "Year";
            for (int i = 0; i < years.Length; i++)
            {
                rowYears[i + 1] = years[i].ToString();
            }
            // Create the second row with revenues
            string[] rowRevenues = new string[revenues.Length + 1];
            rowRevenues[0] = "Revenue";
            for (int i = 0; i < revenues.Length; i++)
            {
                rowRevenues[i + 1] = revenues[i].ToString();
            }
            // Add the rows to the data grid
            dataGrid.Rows.Add(rowYears);
            dataGrid.Rows.Add(rowRevenues);
            // Make the grid height fit the content
            dataGrid.Height = dataGrid.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + dataGrid.ColumnHeadersHeight;
        }

        private void DisplayChartData(int[] years, int[] revenues)
        {
            // Clear existing series
            chart1.Series.Clear();
            // Configure the Chart Area (optional but good for clean look)
            chart1.ChartAreas[0].AxisX.Title = "Year";
            chart1.ChartAreas[0].AxisY.Title = "Revenue";
            chart1.ChartAreas[0].AxisX.Interval = 1; // Show every year on axis
            //Series 1: The Red Bar Chart
            Series barSeries = new Series("BarSeries");
            barSeries.ChartType = SeriesChartType.Column; // Column = Vertical Bar
            barSeries.Color = Color.Red;
            barSeries.BackHatchStyle = ChartHatchStyle.BackwardDiagonal;
            // Series 2: The Blue Line Chart (Required: Blue & Solid)
            Series lineSeries = new Series("LineSeries");
            lineSeries.ChartType = SeriesChartType.Line;    // Line Chart 
            lineSeries.Color = Color.Blue;
            lineSeries.BorderWidth = 3;     // Make the line thicker/visible
            lineSeries.BorderDashStyle = ChartDashStyle.Solid;
            // Add Data Points: Loop through arrays years & revenues and add data to both series
            for (int i = 0; i < years.Length; i++)
            {
                // Add point (X, Y) -> (Year, Revenue)
                barSeries.Points.AddXY(years[i], revenues[i]);
                lineSeries.Points.AddXY(years[i], revenues[i]);
            }
            // Add the series to the Chart Control
            chart1.Series.Add(barSeries);
            chart1.Series.Add(lineSeries);
        }
        // Form Load event handler to initialize data and configurations
        private void Form1_Load(object sender, EventArgs e)
        {
            int[] years = { 1988, 1989, 1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997 };
            int[] revenues = { 150, 170, 180, 175, 200, 250, 210, 240, 280, 140 };
            // --- Data Grid Configurations ---
            DisplayGridData(years, revenues);
            // --- Chart Configurations ---
            DisplayChartData(years, revenues);
            // Center the elements initially
            CenterElements();
        }

        // Method listening to the Resize event
        private void Form1_Resize(object? sender, EventArgs e)
        {
            CenterElements();
        }

        // Method to center the elements
        private void CenterElements()
        {
            // Center the company name label
            companyName.Left = (this.ClientSize.Width - companyName.Width) / 2;
            // Center the description label
            description.Left = (this.ClientSize.Width - description.Width) / 2;
            // Put the data grid at the right side
            dataGrid.Size = new Size(this.ClientSize.Width / 3 + 50, dataGrid.Height);
            dataGrid.Left = (this.ClientSize.Width - dataGrid.Width) / (3/2) - 50;
            // Put the chart at the left side
            chart1.Size = new Size(this.ClientSize.Width / 2 - 50, this.ClientSize.Height / 2);
            chart1.Left = (this.ClientSize.Width - chart1.Width) / 6 - 20;
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            // Get the coordinates of the mouse click
            HitTestResult result = chart1.HitTest(e.X, e.Y);
            // Check if the click was on a data point
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                var prop = result.Series.Points[result.PointIndex];
                // Show a message with the year and revenue of the clicked data point
                MessageBox.Show($"Year: {prop.XValue}, Revenue: {prop.YValues[0]}");
            }
        }
    }
}
