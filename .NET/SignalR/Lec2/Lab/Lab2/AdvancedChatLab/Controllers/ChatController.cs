using AdvancedChatLab.Data;
using AdvancedChatLab.Hubs;
using AdvancedChatLab.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace AdvancedChatLab.Controllers
{
    // Ensure only logged-in users can access the chat
    [Authorize]
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatController(ApplicationDbContext context, IHubContext<ChatHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Index()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Fetch all users except the current one (for private messaging)
            ViewBag.Users = await _context.Users
                .Where(u => u.Id != currentUserId).ToListAsync();

            // Fetch all available rooms
            ViewBag.Rooms = await _context.Rooms.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(string roomName)
        {
            if (!string.IsNullOrWhiteSpace(roomName))
            {
                // Check if room already exists
                var exists = await _context.Rooms.AnyAsync(r => r.Name == roomName);
                if (!exists)
                {
                    // Save new room to the database
                    var room = new Room { Name = roomName };
                    _context.Rooms.Add(room);
                    await _context.SaveChangesAsync();

                    // Trigger Real-time Notification to all connected clients via HubContext
                    await _hubContext.Clients.All.SendAsync("RoomCreatedNotification", roomName);

                    return Ok();
                }
            }
            return BadRequest("Room creation failed or room already exists.");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
