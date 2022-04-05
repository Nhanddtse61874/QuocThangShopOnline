using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityInfra.Identity
{
    public class ClientApplicationUserToken : IdentityUserToken<string>
    {
        public virtual ClientApplicationUser User { get; set; }
    }
}
