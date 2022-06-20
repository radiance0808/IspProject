namespace IspProject.JWT
{
    public class RefreshTokenGenerator
    {
        public static string GenerateRefreshToken() => Guid.NewGuid().ToString();
    }
}
