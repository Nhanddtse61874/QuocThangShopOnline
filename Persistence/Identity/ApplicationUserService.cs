using IdentityInfra.Identity;
using LogicHandler.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Identity
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly SignInManager<ClientApplicationUser> _signInManager;
        private readonly UserManager<ClientApplicationUser> _userManager;

        public ApplicationUserService(SignInManager<ClientApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = signInManager.UserManager;
        }
        
        public async Task<bool> SignInAsync(string userName, string password)
        {
            var target = await _userManager.FindByNameAsync(userName);

            if (target == null)
                return false;

            var validCredentials = await _userManager.CheckPasswordAsync(target, password);
            if (validCredentials)
            {
                //add claims when login
                await _userManager.AddClaimAsync(target, new System.Security.Claims.Claim("avatar", target.UrlImage));
                await _signInManager.SignInAsync(target, new AuthenticationProperties
                {
                    IsPersistent = true
                });

                return true;
            }
            return false;
        }

        public async Task SignOutAsync()
        {
            //Clear Claims when logout
            var contextUser = _signInManager.Context.User;
            var applicationUser = await _userManager.FindByNameAsync(contextUser.Identity.Name);
            await _userManager.RemoveClaimsAsync(applicationUser, contextUser.Claims);
            await _signInManager.SignOutAsync();
        }

        public async Task CreateAsync(string userName, string email, string password)
        {
            await _userManager.CreateAsync(new ClientApplicationUser
            {
                UserName = userName,
                Email = email
            }, password);
        }

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

        public async Task ChangeInformationAsync(string userName, string newMail, string phone, string urlImage)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var currentUser = await _userManager.FindByNameAsync(userName);
                if (!string.IsNullOrEmpty(newMail))
                {
                    currentUser.Email = newMail;
                }
                if (!string.IsNullOrEmpty(phone))
                {
                    currentUser.PhoneNumber = phone;
                }
                if (!string.IsNullOrEmpty(urlImage))
                {
                    currentUser.UrlImage = urlImage;
                }
                await _userManager.UpdateAsync(currentUser);
            }
            var contextUser = _signInManager.Context.User;
            var applicationUser = await _userManager.FindByNameAsync(contextUser.Identity.Name);
            await _userManager.RemoveClaimsAsync(applicationUser, contextUser.Claims);
            await _signInManager.SignOutAsync();
            var target = await _userManager.FindByNameAsync(userName);
            await _userManager.AddClaimAsync(target, new System.Security.Claims.Claim("avatar", urlImage));
            await _signInManager.SignInAsync(target, new AuthenticationProperties
            {
                IsPersistent = true
            });
        }

        public async Task<User> GetUserByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var currentUser = await _userManager.FindByNameAsync(name);
                return new User
                {
                    Email = currentUser.Email,
                    Phone = currentUser.PhoneNumber,
                    UrlImage = currentUser.UrlImage
                };
            }
            return null;
        }
    }
}
