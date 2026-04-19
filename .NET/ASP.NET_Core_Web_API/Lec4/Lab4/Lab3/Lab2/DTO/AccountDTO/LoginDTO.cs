using System.ComponentModel.DataAnnotations;

namespace Lab4.DTO.AccountDTO
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
