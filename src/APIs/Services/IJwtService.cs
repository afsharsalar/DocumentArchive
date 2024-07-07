using DocumentArchive.APIs.Endpoints.Auth.Login;

using Microsoft.AspNetCore.Identity;

namespace DocumentArchive.APIs.Services
{
    public interface IJwtService
    {
        Task<LoginResponse> GenerateToken(IdentityUser user);
        Task<RefreshTokenResponse> VerifyToken(TokenRequest tokenRequest);

    }

}
