using Microsoft.AspNetCore.Identity;

namespace IdentityInfra.Identity
{
    public class ClientApplicationUserClaim : IdentityUserClaim<string>
    {
        public virtual ClientApplicationUser User { get; set; }
    }
}
