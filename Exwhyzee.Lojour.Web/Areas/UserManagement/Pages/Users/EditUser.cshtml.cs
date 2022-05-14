using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Core.Authorization.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Exwhyzee.Wimbig.Web.Areas.UserManagement.Pages.Users
{
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class EditUserModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
      


        public EditUserModel(UserManager<ApplicationUser> userManager
            )
        {
            _userManager = userManager;
        }
        [TempData]
        public string StatusMessage { get; set; }

        [TempData]
        public string CityName { get; set; }

        [TempData]
        public string AreaCityName { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }


        public class InputModel
        {
            public string Id { get; set; }
            public string UserName { get; set; }
            public string NormalizedUserName { get; set; }
            public string Email { get; set; }
            public string NormalizedEmail { get; set; }
            public bool EmailConfirmed { get; set; }

            public string PhoneNumber { get; set; }
            public bool PhoneNumberConfirmed { get; set; }
            public bool TwoFactorEnabled { get; set; }
            public DateTimeOffset? LockoutEnd { get; set; }
            public bool LockoutEnabled { get; set; }
            public int AccessFailedCount { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string OtherNames { get; set; }
            public DateTime DateOfBirth { get; set; }
            [Display(Name = "Description")]
            public string UserDescription { get; set; }

            [Display(Name = "Reference")]
            public string ReferenceId { get; set; }

            [Display(Name = "Code Verify")]
            public string CodeVerify { get; set; }


            [Display(Name = "Area In Current City")]
            public string AreaInCurrentCity { get; set; }



            [Display(Name = "Current City")]
            public string CurrentCity { get; set; }
        }
        [BindProperty]
        public List<SelectListItem> CityDtoList { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound($"Unable to load user with the ID '{id}'.");
            }

          
            Input = new InputModel
            {


                Id = user.Id,
                UserName = user.UserName,
                NormalizedUserName = user.NormalizedUserName,
                Email = user.Email,
                NormalizedEmail = user.NormalizedEmail,
                EmailConfirmed = user.EmailConfirmed,

                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                LockoutEnd = user.LockoutEnd,
                LockoutEnabled = user.LockoutEnabled,
                AccessFailedCount = user.AccessFailedCount,
                CodeVerify = user.CodeVerify,
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByIdAsync(Input.Id);
            if (user == null)
            {
                return NotFound($"Unable to load user with the user");
            }


            user.NormalizedUserName = Input.NormalizedUserName;
            user.Email = Input.Email;
            user.NormalizedEmail = Input.NormalizedEmail;
            user.EmailConfirmed = Input.EmailConfirmed;

            user.PhoneNumber = Input.PhoneNumber;
            user.PhoneNumberConfirmed = Input.PhoneNumberConfirmed;
            user.TwoFactorEnabled = Input.TwoFactorEnabled;
            user.LockoutEnd = Input.LockoutEnd;
            user.LockoutEnabled = Input.LockoutEnabled;
            user.AccessFailedCount = Input.AccessFailedCount;
            user.CodeVerify = Input.CodeVerify;


            await _userManager.UpdateAsync(user);

            StatusMessage = "The Selected user has been updated";
            return RedirectToPage("./Index");
        }

    }
}