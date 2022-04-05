using Microsoft.AspNetCore.Identity;

namespace IdentityInfra.Identity
{
    public class ClientApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public virtual ClientApplicationRole Role { get; set; }
    }
}
