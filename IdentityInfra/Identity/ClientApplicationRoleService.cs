using LogicHandler.Identity;
using Microsoft.AspNetCore.Identity;

namespace IdentityInfra.Identity
{
    public class ClientApplicationRoleService : IClientApplicationRoleService
    {
        private readonly RoleManager<ClientApplicationRole> _roleManager;
        private readonly UserManager<ClientApplicationUser> _userManager;

        public ClientApplicationRoleService(RoleManager<ClientApplicationRole> roleManager,
                                            UserManager<ClientApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task AddRoleAsync(string userName, string roleName)
            => await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(userName), roleName);

        public async Task CreateRoleAsync(string roleName)
            => await _roleManager.CreateAsync(new ClientApplicationRole { Name = roleName });

        public async Task<bool> RoleExistsAsync(string roleName)
            => await _roleManager.RoleExistsAsync(roleName);
    }
}
