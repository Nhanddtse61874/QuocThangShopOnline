using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Persistence.Identity
{
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public AppClaimsPrincipalFactory(
        UserManager<ApplicationUser> userManager
        , IOptions<IdentityOptions> optionsAccessor)
    : base(userManager, optionsAccessor)
        { }

        protected async override Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("UrlImage", user.UrlImage));
            return identity;
        }
    }
}
