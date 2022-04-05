using LogicHandler.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace IdentityInfra.Identity
{
    public class ClientApplicationUserService : IClientApplicationUserService
    {
        private readonly SignInManager<ClientApplicationUser> _signInManager;
        private readonly UserManager<ClientApplicationUser> _userManager;
        private readonly RoleManager<ClientApplicationRole> _roleManager;

        public ClientApplicationUserService(SignInManager<ClientApplicationUser> signInManager,
            RoleManager<ClientApplicationRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = signInManager.UserManager;
            _roleManager = roleManager;
        }

        public async Task ChangeInformationAsync(string userName, string newFullName,
                                                 string newMail, string newPhone,
                                                 string newTaxCode, string Description,
                                                 string FacebookLink, string TwitterLink,
                                                 string TelegramUserName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var currenUser = await _userManager.FindByNameAsync(userName);
                if (!string.IsNullOrEmpty(newFullName))
                {
                    currenUser.FullName = newFullName;
                }
                if (!string.IsNullOrEmpty(newMail))
                {
                    currenUser.Email = newMail;
                }
                if (!string.IsNullOrEmpty(newPhone))
                {
                    currenUser.PhoneNumber = newPhone;
                }
                if (!string.IsNullOrEmpty(newTaxCode))
                {
                    currenUser.TaxCode = newTaxCode;
                }
                if (!string.IsNullOrEmpty(Description))
                {
                    currenUser.Description = Description;
                }
                if (!string.IsNullOrEmpty(FacebookLink))
                {
                    currenUser.FacebookLink = FacebookLink;
                }
                if (!string.IsNullOrEmpty(TwitterLink))
                {
                    currenUser.TwitterLink = TwitterLink;
                }
                if (!string.IsNullOrEmpty(TelegramUserName))
                {
                    currenUser.TelegramUserName = TelegramUserName;
                }
                await _userManager.UpdateAsync(currenUser);
            }
        }

        public async Task<bool> CreateAsync(string fullName, bool isEnterprise,
                                            string userName, string email,
                                            string phone, string taxCode,
                                            string password)
        {
            var res = await _userManager.CreateAsync(new ClientApplicationUser
            {
                PhoneNumber = phone,
                IsEnterprise = isEnterprise,
                TaxCode = taxCode,
                FullName = fullName,
                UserName = userName,
                Email = email,
            }, password);
            return res.Succeeded;
        }

        public async Task<ClientUser> GetUserByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var currentUser = await _userManager.FindByNameAsync(name);
                if (currentUser == null)
                {
                    return null;
                }
                return new ClientUser
                {
                    UserName = currentUser.UserName,
                    Email = currentUser.Email,
                    Phone = currentUser.PhoneNumber,
                    UrlImage = currentUser.UrlImage,
                    FullName = currentUser.FullName,
                    TaxCode = currentUser.TaxCode,
                    Description = currentUser.Description,
                    FacebookLink = currentUser.FacebookLink,
                    TwitterLink = currentUser.TwitterLink,
                    TelegramUserName = currentUser.TelegramUserName,
                    IsEnterprise = currentUser.IsEnterprise,
                };
            }
            return null;
        }

        public async Task<bool> SignInAsync(string userName, string password)
        {
            var target = await _userManager.FindByNameAsync(userName);

            if (target == null)
                return false;

            var validCredentials = await _userManager.CheckPasswordAsync(target, password);
            if (validCredentials)
            {
                await _signInManager.SignInAsync(target, new AuthenticationProperties
                {
                    IsPersistent = true
                });

                return true;
            }
            return false;
        }

        public async Task SignOutAsync() => await _signInManager.SignOutAsync();

        public async Task<bool> UpdateAsync(string userName, string currentPassword, string newPassword)
        {
            var currentUser = await _userManager.FindByNameAsync(userName);
            var result = await _userManager.CheckPasswordAsync(currentUser, currentPassword);
            if (result)
            {
                await _userManager.ChangePasswordAsync(currentUser, currentPassword, newPassword);
            }
            return result;
        }

        public async Task ChangeAvatar(string username, string file)
        {
            var currenUser = await _userManager.FindByNameAsync(username);
            currenUser.UrlImage = file;
            await _userManager.UpdateAsync(currenUser);
        }
    }
}
