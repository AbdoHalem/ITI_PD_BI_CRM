using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIEntities
{
    public class User
    {
        // Explicitly setting the Id as Primary Key and Identity (Auto-increment)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; } = string.Empty;
        public string Password { get; set; }
        // Navigation property to get the roles for this user easily
        public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
