using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AdvancedChatLab.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;
        [Required]
        public string SenderId { get; set; }
        public IdentityUser Sender { get; set; }

        // If message is sent to a specific room, RoomId will be set
        public int? RoomId { get; set; }
        public Room Room { get; set; }
        // If message is sent to a specific user, ReceiverId will be set
        public string? ReceiverId { get; set; }
        public IdentityUser Receiver { get; set; }
    }
}
