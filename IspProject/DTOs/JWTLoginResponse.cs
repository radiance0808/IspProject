namespace IspProject.DTOs
{
    public class JWTLoginResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }

        public string Role { get; set; }

        public string expiresIn { get; set; }
    }
}
