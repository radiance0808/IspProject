using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace IspProject.JWT
{
    public class TokenGenerator
    {
        public static JwtSecurityToken GenerateToken(int userId, string role, string firstName, string lastName, SigningCredentials credentials)
        {

            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(userId)),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.Name, firstName),
                new Claim(ClaimTypes.Surname, lastName)
            };

            var token = new JwtSecurityToken(
                issuer: "ispproject",
                audience: "ispproject",
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );

            return token;
        }
    }
}
