using IspProject.DTOs;

namespace IspProject.Settings
{
    public interface IJWTAuthService
    {
        Task<JWTLoginResponse> Login(JWTLoginRequest request);
        Task<JWTRefreshTokenResponse> RefreshToken(JWTRefreshTokenRequest request);
        Task DeleteRefreshToken(int idUser);
    }
}
