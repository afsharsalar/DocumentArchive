using DocumentArchive.Domain.UserAggregator;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using DocumentArchive.Application.Identity;

namespace DocumentArchive.Infrastructure.Persistence.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserClaimsPrincipalFactory<User> _userClaimsPrincipalFactory;
        private readonly IAuthorizationService _authorizationService;

        public IdentityService(
            UserManager<User> userManager,
            IUserClaimsPrincipalFactory<User> userClaimsPrincipalFactory,
            IAuthorizationService authorizationService
            )
        {
            _userManager = userManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _authorizationService = authorizationService;
        }


        public async Task<(Result Result, int UserId)> CreateUserAsync(string username, string password)
        {
            var user = new User { UserName = username, Email = username };
            var result = await _userManager.CreateAsync(user, password);
            return (result.ToApplicationResult(), user.Id);

        }

        public async Task<bool> IsInRoleAsync(int userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            return user != null && await _userManager.IsInRoleAsync(user, role);
        }

        public async Task<bool> AuthorizeAsync(int userId, string policyName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return false;
            }

            var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

            var result = await _authorizationService.AuthorizeAsync(principal, policyName);
      
            return result.Succeeded;
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user != null ? await DeleteUserAsync(user) : Result.Success();
        }

        public async Task<Result> DeleteUserAsync(User user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }


        //public async Task<Result> Login(string username,string password)
        //{
        //    //_userManager.PasswordValidators(username, password);
        //    return new Result(true,new);
        //}
    }
}
