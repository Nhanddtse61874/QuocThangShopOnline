using System.Security.Claims;
using System.Security.Principal;

namespace Persistence.Identity
{
    public static class IdentityExtensions
    {
        public static string UrlImage(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("avatar");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}
