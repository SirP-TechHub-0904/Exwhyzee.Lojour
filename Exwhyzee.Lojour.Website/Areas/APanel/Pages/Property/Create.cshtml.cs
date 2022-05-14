using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.EstateProperties.Dto;
using Exwhyzee.Lojour.Application.PropertyImages;
using Exwhyzee.Lojour.Core.EstateProperties;
using Exwhyzee.Lojour.Core.PropertyImage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Exwhyzee.Lojour.Core.State;
using Exwhyzee.Lojour.Application.States;
using Microsoft.AspNetCore.Identity;
using Exwhyzee.Lojour.Core.Authorization.Users;
using Microsoft.AspNetCore.Authorization;

namespace Exwhyzee.Lojour.Website.Areas.APanel.Pages.Property
{
    [Authorize(Roles = "SuperAdmin,Agent,Admin")]

    public class CreateModel : PageModel
    {
        //
        private readonly IPropertyAppService _propertyAppService;
        private readonly IPropertyImagesAppService _propertyImagesAppService;
        private readonly IHostingEnvironment _hostingEnv;
        private readonly IStateAppService _stateAppService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(IPropertyAppService propertyAppService, UserManager<ApplicationUser> userManager, IHostingEnvironment env,
            IPropertyImagesAppService propertyImagesAppService, IStateAppService stateAppService)
        {
            _propertyAppService = propertyAppService;
            _hostingEnv = env;
            _propertyImagesAppService = propertyImagesAppService;
            _stateAppService = stateAppService;
            _userManager = userManager;
        }

        public string LoggedInUser { get; set; }


        //
        [BindProperty]
        public EstatePropertyDto EstatePropertyDto { get; set; }

        public List<StateModel> item { get; set; }
        public async Task OnGet()
        {

            string n = _userManager.GetUserId(HttpContext.User);

            var user = await _userManager.FindByIdAsync(n);

            //if(user.UserVerification == Enums.UserVerification.Unverified)
            //{
            //    return RedirectToPage("./Index");
            //}

            LoggedInUser = user.UserName;


        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            try
            {
               
                if (ModelState.IsValid)
                {

                   

                    var item = new EstatePropertyDto
                    {
                        PropertyName = "",
                        Description = "",
                        AgentDetails = "",
                        Longitude = "",
                        Latitude = "",
                        Amount = 0,
                        PropertyProfile = "",
                        PropertyType = EstatePropertyDto.PropertyType,
                        PropertyStatus = 0,
                        VerificationStatus = 0,
                        DescriptiveStatus = EstatePropertyDto.DescriptiveStatus,
                        PropertyAddress = "",
                        DateCreated = DateTime.UtcNow.AddHours(1),
                        IdentificationNumber = "LJ/",
                        State = "",
                        LGA = "",
                        Community = "",
                        Kindred = "",
                        SortOrder = 1,
                        HomeLocation = 0,
                        Username = EstatePropertyDto.Username

                    };

                    var newpropertyId = await _propertyAppService.Add(item);


                    return RedirectToPage("Form", new { id = newpropertyId });
                }

                return Page();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

    }
}