using System.ComponentModel.DataAnnotations;

namespace DocumentArchive.APIs.Endpoints.Auth.Login
{
    public class TokenRequest
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string RefreshToken { get; set; }
    }
}
