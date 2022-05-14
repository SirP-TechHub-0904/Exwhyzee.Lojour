using Exwhyzee.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Exwhyzee.Lojour.Core.Authorization.Users
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            DateRegistered = DateTime.UtcNow.AddHours(1);
        }

       
        [PersonalData]
        public DateTime DateRegistered { get; set; }

        [PersonalData]
        public string CodeVerify { get; set; }


        [PersonalData]
        public string UniqueId { get; set; }

       
        public ICollection<ApplicationUserRole> UserRoles { get; set; }

        public string RoleString { get; set; }
       
        public UserVerification UserVerification { get; set; }

    }
}
