using System.ComponentModel.DataAnnotations;

namespace CVApp.Server.Dtos.Requests
{
    public class RegisterRequest
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public required string UserName { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
