using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Twins.Api.Data;
using Twins.Shared.Entities;

namespace Twins.Api.Helpers.Interfaces
{
    public class UserHelper : IUserHelper
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserHelper(DataContext context,UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user,password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
             await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name= roleName,
                });                
            }
        }

        public async Task<User> GetUserAsync(string email)
        {
            var user = await _context.Users
                .Include(c=>c.City)                
                .ThenInclude(s=>s.State)
                .ThenInclude(c=>c.Country)
                .FirstOrDefaultAsync(x=>x.Email==email);
            return user;
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
