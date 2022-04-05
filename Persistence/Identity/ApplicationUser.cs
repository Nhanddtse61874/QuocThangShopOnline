using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Identity
{
    public class ApplicationUser : Microsoft.AspNet.Identity.EntityFramework.IdentityUser
    {
        [PersonalData]
        public string UrlImage { get; set; }

        [PersonalData]
        public int? ShopId { get; set; }
    }
}
