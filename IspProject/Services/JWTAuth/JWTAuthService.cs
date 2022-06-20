﻿using IspProject.DTOs;

using IspProject.JWT;
using IspProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace IspProject.Settings
{
    public class JWTAuthService : IJWTAuthService
    {
        private readonly AccountDbContext _context;
        private readonly IConfiguration _configuration;

        public JWTAuthService(AccountDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<JWTLoginResponse> Login(JWTLoginRequest request)
        {
            var user = await _context.users.FirstOrDefaultAsync(e => e.login.ToLower() == request.login);
            if (user == null) throw new Exception("No such user");
            if (request.password != user.password) throw new Exception("Wrong password");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var Token = TokenGenerator.GenerateToken(user.idUser, user.Role, user.firstName, user.lastName, credentials);
            var refreshToken = RefreshTokenGenerator.GenerateRefreshToken();
            user.Refreshtoken = refreshToken;
            user.Refreshtokenexp = DateTime.Now.AddDays(2);
            await _context.SaveChangesAsync();

            return new JWTLoginResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(Token),
                RefreshToken = refreshToken
            };
        }

        public async Task<JWTRefreshTokenResponse> RefreshToken(JWTRefreshTokenRequest request)
        {
            var user = await _context.users.FirstOrDefaultAsync(e => e.Refreshtoken == request.RefreshToken);
            if (user == null) throw new Exception();
            if (user.Refreshtokenexp < DateTime.Now) throw new Exception();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var Token = TokenGenerator.GenerateToken(user.idUser, user.Role, user.firstName, user.lastName, creds);

            await _context.SaveChangesAsync();

            return new JWTRefreshTokenResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(Token),
                RefreshToken = user.Refreshtoken
            };
        }
    }
}