using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Core.Authorization.Users;
using Exwhyzee.Lojour.Website.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Exwhyzee.Lojour.Website.Areas.Account.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IHostingEnvironment _hostingEnv;
     
        public ProfileModel(
            UserManager<ApplicationUser> userManager, IHostingEnvironment env,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
                        RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
            _hostingEnv = env;
        }


        [BindProperty]
        public ApplicationUser Data { get; set; }

        
        public async Task<IActionResult> OnGetAsync()
        {

            
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            Data = user;


            //state


            return Page();
        }
    }
}