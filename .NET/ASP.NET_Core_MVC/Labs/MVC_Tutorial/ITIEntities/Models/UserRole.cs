using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIEntities
{
    public class UserRole
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public String Role { get; set; } = String.Empty;
        // Navigation property back to the User
        public virtual User User { get; set; }
    }
}
