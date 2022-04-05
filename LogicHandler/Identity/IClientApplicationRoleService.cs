namespace LogicHandler.Identity
{
    public interface IClientApplicationRoleService
    {
        Task CreateRoleAsync(string roleName);

        Task AddRoleAsync(string userName, string roleName);

        Task<bool> RoleExistsAsync(string roleName);
    }
}
