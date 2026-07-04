using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AdvancedChatLab.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Message> Messages { get; set; } = new List<Message>();
        public ICollection<IdentityUser> Users { get; set; } = new List<IdentityUser>();
    }
}
