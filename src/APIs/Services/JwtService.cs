using DocumentArchive.APIs.Endpoints.Auth.Login;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DocumentArchive.APIs.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSetting jwtSetting;
        private readonly TokenValidationParameters _tokenValidationParameters;


        public Task<LoginResponse> GenerateToken(IdentityUser user)
        {
            JwtSecurityTokenHandler? jwtTokenHandler = new JwtSecurityTokenHandler();

            Byte[] key = Encoding.ASCII.GetBytes(jwtSetting.Secret);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
                Expires = DateTime.UtcNow.AddSeconds(35),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            // Create token
            SecurityToken? token = jwtTokenHandler.CreateToken(tokenDescriptor);
            string jwtToken = jwtTokenHandler.WriteToken(token);

            // Create refresh token
            RefreshToken refreshToken = new RefreshToken()
            {
                JwtId = token.Id,
                IsUsed = false,
                IsRevoked = false,
                UserId = user.Id,
                CreatedAt = DateTime.UtcNow,
                ExpiredAt = DateTime.UtcNow.AddMonths(1),
                Token = GetRandomString() + Guid.NewGuid()
            };

        }

        public Task<RefreshTokenResponse> VerifyToken(TokenRequest tokenRequest)
        {
            throw new NotImplementedException();
        }
    }
}
