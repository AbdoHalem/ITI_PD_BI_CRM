using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace AdvancedChatLab.Desktop
{
    public partial class LoginForm : MaterialForm
    {
        public LoginForm()
        {
            InitializeComponent();

            // Apply Material Design styling
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200,
                TextShade.WHITE
            );
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter email and password.");
                return;
            }

            btnLogin.Enabled = false;

            try
            {
                using var client = new HttpClient();
                var url = "https://localhost:7255/api/auth/login";

                // Create the JSON payload
                var payload = new { Email = email, Password = password };
                var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

                // Call the API
                var response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    using var jsonDoc = JsonDocument.Parse(responseString);

                    // Extract the JWT Token from the response
                    var token = jsonDoc.RootElement.GetProperty("token").GetString();

                    if (!string.IsNullOrEmpty(token))
                    {
                        // Open MainChatForm and pass the token securely
                        var mainForm = new Form1(token);
                        mainForm.Show();
                        this.Hide(); // Hide the login screen
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Email or Password!", "Login Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}");
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }
    }
}
