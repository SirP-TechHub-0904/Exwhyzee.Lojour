using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exwhyzee.Lojour.Core.Authorization.Users
{
    public class ApplicationRole: IdentityRole
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
