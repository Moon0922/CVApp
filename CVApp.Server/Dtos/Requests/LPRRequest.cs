using System.ComponentModel.DataAnnotations;

namespace CVApp.Server.Dtos.Requests
{
    public class LPRRequest
    {
        public required string image_base64 { get; set; }
        public required string country { get; set; }
    }
}
