using Exwhyzee.Lojour.Application.PropertyImages;
using Exwhyzee.Lojour.Core.Authorization.Users;
using Exwhyzee.Lojour.Core.PropertyImage;
using Exwhyzee.Lojour.Website.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Website.Views.Shared.ViewComponents
{

    public class HeaderUserViewComponent : ViewComponent
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly RoleManager<ApplicationRole> _roleManager;




        public HeaderUserViewComponent(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
                        RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

            _logger = logger;
        }
        [BindProperty]
        public ApplicationUser Data { get; set; }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var item = await GetItemAsync();

            return View(item);
        }

        private async Task<ApplicationUser> GetItemAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return null;
            }
            Data = user;
            return Data;
        }
    }
}
