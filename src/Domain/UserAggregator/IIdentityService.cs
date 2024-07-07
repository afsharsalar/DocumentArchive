
using DocumentArchive.Domain.UserAggregator;

namespace DocumentArchive.Application.Identity
{
    public interface IIdentityService
    {
        Task<bool> AuthorizeAsync(int userId, string policyName);
        Task<(Result Result, int UserId)> CreateUserAsync(string username, string password);
        Task<Result> DeleteUserAsync(User user);
        Task<Result> DeleteUserAsync(string userId);
        Task<bool> IsInRoleAsync(int userId, string role);

        //Task<TokenModel> RefreshToken(TokenModel model);
    }
}