using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using AdvancedChatLab.Data;
using AdvancedChatLab.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedChatLab.Hubs
{
    // Allow both Web Users (Identity.Application Cookies) and Desktop Users (Bearer JWT)
    [Authorize(AuthenticationSchemes = "Identity.Application,Bearer")]
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;
        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task JoinRoom(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            // Notify all users that a new user has joined the room
            await Clients.Group(roomName).SendAsync("ReceiveNotification", $"{Context.User.Identity.Name} joined {roomName}");
        }

        public async Task LeaveRoom(string roomName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
            await Clients.Group(roomName).SendAsync("ReceiveNotification", $"{Context.User.Identity.Name} left {roomName}");
        }

        public async Task SendMessageToRoom(string roomName, string message)
        {
            var senderId = Context.UserIdentifier;
            if (senderId == null) throw new HubException("Unauthorized Access!");

            var senderUser = _context.Users.Find(senderId);
            var senderName = senderUser?.UserName ?? "Desktop User";

            // Save the message in DB for history
            var room = _context.Rooms.FirstOrDefault(r => r.Name == roomName);
            if (room != null)
            {
                var newMessage = new Message
                {
                    Content = message,
                    SenderId = senderId,
                    RoomId = room.Id,
                    Timestamp = DateTime.Now
                };
                _context.Messages.Add(newMessage);
                await _context.SaveChangesAsync();
            }

            await Clients.Group(roomName).SendAsync("ReceiveRoomMessage", senderName, roomName, message);
        }

        public async Task SendPrivateMessage(string receiverId, string message)
        {
            var senderId = Context.UserIdentifier;
            if (senderId == null) throw new HubException("Unauthorized Access!");

            var senderUser = _context.Users.Find(senderId);
            var senderName = senderUser?.UserName ?? "Desktop User";

            var newMessage = new Message
            {
                Content = message,
                SenderId = senderId,
                ReceiverId = receiverId,
                Timestamp = DateTime.Now
            };
            _context.Messages.Add(newMessage);
            await _context.SaveChangesAsync();

            await Clients.User(receiverId).SendAsync("ReceivePrivateMessage", senderName, message);

            // Send the message for the sender too to appear in his chat
            await Clients.User(senderId).SendAsync("ReceivePrivateMessage", senderName, message);
        }

        // Notify all users when a new room is created
        public async Task NotifyRoomCreated(string roomName)
        {
            await Clients.All.SendAsync("RoomCreatedNotification", roomName);
        }

        // Fetch all rooms for the ComboBox
        public async Task<List<string>> GetRooms()
        {
            return await _context.Rooms.Select(r => r.Name).ToListAsync();
        }

        // Fetch all users (except the current one) for Private Messages
        public async Task<Dictionary<string, string>> GetUsers()
        {
            var currentUserId = Context.UserIdentifier;

            // Return a dictionary of [UserId -> UserName]
            return await _context.Users
                .Where(u => u.Id != currentUserId)
                .ToDictionaryAsync(u => u.Id, u => u.UserName);
        }

        // Create a new room directly via SignalR Hub
        public async Task CreateRoom(string roomName)
        {
            if (!string.IsNullOrWhiteSpace(roomName))
            {
                // Check if the room already exists in the database to prevent duplicates
                var exists = await _context.Rooms.AnyAsync(r => r.Name == roomName);

                if (!exists)
                {
                    // Save the new room to the database
                    var room = new Room { Name = roomName };
                    _context.Rooms.Add(room);
                    await _context.SaveChangesAsync();

                    // Notify all connected clients (Web and Desktop) in real-time
                    await Clients.All.SendAsync("RoomCreatedNotification", roomName);
                }
            }
        }
    }
}
