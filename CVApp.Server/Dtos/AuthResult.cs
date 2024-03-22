using System.Collections.Generic;

namespace CVApp.Server.Dtos
{
    public class AuthResult
    {
        public string? Token { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
