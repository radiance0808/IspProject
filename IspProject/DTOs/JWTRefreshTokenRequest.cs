using System.ComponentModel.DataAnnotations;

namespace IspProject.DTOs
{
    public class JWTRefreshTokenRequest
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
