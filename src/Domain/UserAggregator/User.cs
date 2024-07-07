using Microsoft.AspNetCore.Identity;

namespace DocumentArchive.Domain.UserAggregator;

public class User  : IdentityUser<int>
{
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
}
