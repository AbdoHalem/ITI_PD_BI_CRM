using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Day1.Models.ViewModel
{
    public class StudentVM
    {
        public int Id { get; set; }
        [Required, MaxLength(30), MinLength(3)]
        public string Name { get; set; }
        [Range(22, 30)]
        public int Age { get; set; }
        [Required, StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]*.[a-zA-Z]{2,4}")]
        [Remote(action: "CheckEmail", controller: "Student", AdditionalFields = nameof(Id))]
        public string Email { get; set; }
        public int DeptNo { get; set; }
        [Required, StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string CPassword { get; set; }
    }
}
