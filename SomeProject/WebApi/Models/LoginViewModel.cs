using System.ComponentModel.DataAnnotations;

namespace WebApi.Models{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}