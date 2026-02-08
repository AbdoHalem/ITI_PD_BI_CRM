using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab9
{
    public partial class FormatDialog : Form
    {
        // Properties to hold the new values selected by the user
        public Font SelectedFont { get; private set; }
        public Color SelectedColor { get; private set; }
        public string NewText { get; private set; }
        /**
         * Constructor receives the CURRENT state of the label
         */
        public FormatDialog(Font currentFont, Color currentColor, string currentText)
        {
            InitializeComponent();
            // --- Initialize UI with Current Values ---
            // Set Font Family Radio Buttons
            if (currentFont.Name == "Times New Roman")
                rbTimes.Checked = true;
            else if (currentFont.Name == "Courier New")
                rbCourier.Checked = true;
            else
                rbArial.Checked = true;

            // Set Font Size Radio Buttons
            int size = (int)currentFont.Size;
            if (size == 16)
                rb16.Checked = true;
            else if (size == 20)
                rb20.Checked = true;
            else
                rb24.Checked = true;

            // Set Color
            SelectedColor = currentColor;
            // We change the button color to show current selection
            btnColor.ForeColor = currentColor;

            // Set Text
            txtOld.Text = currentText;
            txtOld.ReadOnly = true;     // Old text should not be editable
            txtNew.Text = currentText;

            // Initialize Properties
            SelectedFont = currentFont;
            NewText = currentText;
        }
        /**
         * Event Handler for 'OK' btn
         */
        private void btnOK_Click(object sender, EventArgs e)
        {
            // 1. Determine Font Family
            string fontFamily = "Times New Roman";
            if (rbArial.Checked) { fontFamily = "Arial"; }
            else if (rbCourier.Checked) { fontFamily = "Courier New"; }

            // 2. Determine Font Size
            float fontSize = 16f;
            if (rb20.Checked) { fontSize = 20f; }
            else if (rb24.Checked) { fontSize = 24f; }

            // Create the new Font object (Keep existing style like Bold)
            SelectedFont = new Font(fontFamily, fontSize, FontStyle.Bold);

            // 3. Get New Text
            NewText = txtNew.Text;
            // Set Dialog Result to OK so the main form knows to proceed
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        /**
         * Event Handler for 'Close' btn
         */
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = SelectedColor;
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedColor = colorDialog.Color;
                btnColor.ForeColor = SelectedColor;
            }
        }
    }
}
