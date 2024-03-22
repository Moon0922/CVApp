using System.ComponentModel.DataAnnotations;

namespace CVApp.Server.Dtos.Requests
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "The email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
