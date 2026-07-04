using Microsoft.AspNetCore.SignalR.Client;
using System.Data.Common;
using MaterialSkin;           // Required for Material Design
using MaterialSkin.Controls;  // Required for Material Controls

namespace AdvancedChatLab.Desktop
{
    public partial class Form1 : MaterialForm
    {
        // Define the connection object at the class level
        private HubConnection _connection;
        // Dictionary to store users: Key = UserId, Value = UserName
        private Dictionary<string, string> _usersList = new Dictionary<string, string>();

        //Store the JWT Token
        private readonly string _jwtToken;

        //Modify Constructor to receive the token
        public Form1(string jwtToken)
        {
            InitializeComponent();

            _jwtToken = jwtToken; // Save the token securely in memory
            this.AutoScroll = true;

            btnJoinRoom.Click += btnJoinRoom_Click;
            btnSendPublic.Click += btnSendPublic_Click;
            btnSendPrivate.Click += btnSendPrivate_Click;
            btnCreateRoom.Click += btnCreateRoom_Click;

            // Initialize MaterialSkinManager
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            // Set the theme (LIGHT or DARK)
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema to match modern web apps (e.g., Indigo/Blue style)
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800,   
                Primary.BlueGrey900,
                Primary.BlueGrey500,
                Accent.LightBlue200,
                TextShade.WHITE
            );
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                // 1. Build the connection using the Bearer Token automatically
                _connection = new HubConnectionBuilder()
                    .WithUrl("https://localhost:7255/chatHub", options =>
                    {
                        // Pass the JWT token automatically in the headers
                        options.AccessTokenProvider = () => Task.FromResult((string?)_jwtToken);
                    })
                    .Build();

                // 2. Setup Listeners
                _connection.On<string>("ReceiveNotification", (notification) =>
                {
                    Invoke((Action)(() => rtbChatBoard.AppendText($"[System]: {notification}\n")));
                });

                _connection.On<string, string, string>("ReceiveRoomMessage", (senderName, roomName, message) =>
                {
                    Invoke((Action)(() => rtbChatBoard.AppendText($"[{roomName}] {senderName}: {message}\n")));
                });

                _connection.On<string, string>("ReceivePrivateMessage", (senderName, message) =>
                {
                    Invoke((Action)(() => rtbChatBoard.AppendText($"[Private from {senderName}]: {message}\n")));
                });

                _connection.On<string>("RoomCreatedNotification", (roomName) =>
                {
                    Invoke((Action)(() =>
                    {
                        rtbChatBoard.AppendText($"[Alert]: A new room '{roomName}' was just created!\n");
                        cmbRooms.Items.Add(roomName);
                    }));
                });

                // 3. Start the connection instantly
                await _connection.StartAsync();
                rtbChatBoard.AppendText("Connected to SignalR securely using JWT!\n");

                // 4. Fetch initial data from server (Rooms and Users)
                await LoadInitialData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect to server: {ex.Message}", "Connection Error");
            }
        }

        // Helper method to load Dropdowns
        private async Task LoadInitialData()
        {
            try
            {
                // Fetch and populate Rooms
                var rooms = await _connection.InvokeAsync<List<string>>("GetRooms");
                Invoke((Action)(() =>
                {
                    cmbRooms.Items.Clear();
                    foreach (var room in rooms)
                    {
                        cmbRooms.Items.Add(room);
                    }
                }));

                // Fetch and populate Users
                _usersList = await _connection.InvokeAsync<Dictionary<string, string>>("GetUsers");
                Invoke((Action)(() =>
                {
                    cmbUsers.Items.Clear();
                    foreach (var user in _usersList)
                    {
                        cmbUsers.Items.Add(user.Value); // Display the UserName
                    }
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dropdown data: {ex.Message}");
            }
        }

        private async void btnSendPublic_Click(object sender, EventArgs e)
        {
            var roomName = cmbRooms.SelectedItem?.ToString();
            var message = txtMessage.Text.Trim();

            if (!string.IsNullOrEmpty(roomName) && !string.IsNullOrEmpty(message))
            {
                try
                {
                    // Call SendMessageToRoom method in ChatHub
                    await _connection.InvokeAsync("SendMessageToRoom", roomName, message);
                    txtMessage.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error sending public message: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a room and type a message!");
            }
        }

        private async void btnSendPrivate_Click(object sender, EventArgs e)
        {
            var selectedUserName = cmbUsers.SelectedItem?.ToString();
            var message = txtMessage.Text.Trim();

            if (!string.IsNullOrEmpty(selectedUserName) && !string.IsNullOrEmpty(message))
            {
                // Find the UserId based on the selected UserName
                string receiverId = null;
                foreach (var kvp in _usersList)
                {
                    if (kvp.Value == selectedUserName)
                    {
                        receiverId = kvp.Key;
                        break;
                    }
                }

                if (receiverId != null)
                {
                    try
                    {
                        // Call SendPrivateMessage method in ChatHub
                        await _connection.InvokeAsync("SendPrivateMessage", receiverId, message);
                        txtMessage.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error sending private message: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user and type a message!");
            }
        }

        private async void btnJoinRoom_Click(object sender, EventArgs e)
        {
            var roomName = cmbRooms.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(roomName))
            {
                try
                {
                    // Call JoinRoom method in ChatHub
                    await _connection.InvokeAsync("JoinRoom", roomName);

                    // Show a local success message
                    rtbChatBoard.AppendText($"[System]: You have successfully joined the room '{roomName}'\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error joining room: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a room to join first!");
            }
        }

        private async void btnCreateRoom_Click(object sender, EventArgs e)
        {
            var roomName = txtNewRoomName.Text.Trim();

            if (!string.IsNullOrEmpty(roomName))
            {
                try
                {
                    // Invoke the CreateRoom method on the SignalR Server
                    await _connection.InvokeAsync("CreateRoom", roomName);

                    // Clear the text box after successfully sending the request
                    txtNewRoomName.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating room: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please enter a room name first!");
            }
        }
    }
}
