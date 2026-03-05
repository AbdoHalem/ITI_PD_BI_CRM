using System.ComponentModel.DataAnnotations;

namespace Day1.Models.ViewModel
{
    public class LoginVM
    {
        public String UserName { get; set; }
        [DataType(DataType.Password)] 
        public String Password { get; set; }
    }
}
