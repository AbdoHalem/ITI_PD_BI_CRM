using System.ComponentModel.DataAnnotations;

namespace Lab3.DTO.AccountDTO
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
