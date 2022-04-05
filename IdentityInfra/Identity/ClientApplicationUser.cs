using Microsoft.AspNetCore.Identity;

namespace IdentityInfra.Identity
{
    public class ClientApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        public string TaxCode { get; set; }

        public string UrlImage { get; set; }

        public bool IsEnterprise { get; set; }

        public string Description { get; set; }

        public string FacebookLink { get; set; }

        public string TwitterLink { get; set; }

        public string TelegramUserName { get; set; }

        public virtual ICollection<ClientApplicationUserClaim> Claims { get; set; }

        public virtual ICollection<ClientApplicationUserLogin> Logins { get; set; }

        public virtual ICollection<ClientApplicationUserToken> Tokens { get; set; }

        public virtual ICollection<ClientApplicationUserRole> UserRoles { get; set; }
    }
}
