using System.ComponentModel.DataAnnotations;

namespace IspProject.DTOs
{
    public class JWTLoginRequest
    {
        [Required]
        public string login { get; set; }
        [Required]
        public string password { get; set; }
    }
}
