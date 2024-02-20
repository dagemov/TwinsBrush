using Microsoft.AspNetCore.Identity;
using Twins.Shared.Entities;

namespace Twins.Api.Helpers.Interfaces
{
    public interface IUserHelper
    {
        Task<IdentityResult> AddUserAsync(User user, string password);
        Task AddUserToRoleAsync(User user, string roleName);
        Task<bool> IsUserInRoleAsync(User user, string roleName);
        Task<User> GetUserAsync(string email);
        Task CheckRoleAsync(string roleName);
    }
}
