namespace LogicHandler.Identity
{
    public interface IApplicationUserService
    {
        Task CreateAsync(string userName, string email, string password);

        Task<bool> SignInAsync(string userName, string password);

        Task SignOutAsync();

        Task<bool> UpdateAsync(string userName, string currentPassword, string newPassword);

        Task ChangeInformationAsync(string userName, string newMail, string phone, string urlImage);

        Task<User> GetUserByName(string name);
    }
    public class User
    {
        public string Phone { get; set; }

        public string Email { get; set; }

        public string UrlImage { get; set; }
    }
}
