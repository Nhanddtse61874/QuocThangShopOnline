namespace LogicHandler.Identity
{
    public interface IClientApplicationUserService
    {
        Task SignOutAsync();

        Task ChangeAvatar(string username, string file);
        Task<bool> CreateAsync(string fullName, bool isEnterprise,
                               string userName, string email,
                               string phone, string taxCode,
                               string password);

        Task<bool> SignInAsync(string userName, string password);

        Task<bool> UpdateAsync(string userName, string currentPassword, string newPassword);

        Task ChangeInformationAsync(string userName, string newFullName,
                                    string newMail, string newPhone,
                                    string newTaxCode, string Description,
                                    string FacebookLink, string TwitterLink,
                                    string TelegramUserName);

        Task<ClientUser> GetUserByName(string name);
    }
    public class ClientUser
    {
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string TaxCode { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string UrlImage { get; set; }

        public bool IsEnterprise { get; set; }

        public string Description { get; set; }

        public string FacebookLink { get; set; }

        public string TwitterLink { get; set; }

        public string TelegramUserName { get; set; }
    }
}
