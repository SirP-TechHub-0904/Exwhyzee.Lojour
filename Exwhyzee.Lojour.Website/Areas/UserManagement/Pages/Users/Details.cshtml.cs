using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Core.Authorization.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Website.Areas.UserManagement.Pages.Users
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class DetailsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUser Person { get; set; }


        public DetailsModel(UserManager<ApplicationUser> userManger)
        {
            _userManager = userManger;
            Person = new ApplicationUser();
        }
       
      

        public decimal Balance { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId)
        {
            Person = await _userManager.FindByIdAsync(userId);
          
            if (Person == null)
            {
                return RedirectToPage("/Index", new  { message= "Error User Not Found"});
            }
        
            return Page();
        }
    }
}