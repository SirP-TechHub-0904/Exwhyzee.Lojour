using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Core.Authorization.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Exwhyzee.Lojour.Web.Areas.UserManagement.Pages.Users
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;


        public IndexModel(
            UserManager<ApplicationUser> userManger, RoleManager<ApplicationRole> roleManager

            )
        {

            _userManager = userManger;
            _roleManager = roleManager;

        }
        public string Message { get; set; } = "Initial Request";

        public List<ApplicationUser> Users { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

         
            Users = await _userManager.Users.ToListAsync();
         

            return Page();
        }

    }
}