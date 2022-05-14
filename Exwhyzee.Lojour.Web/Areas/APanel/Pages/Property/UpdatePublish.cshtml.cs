using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.EstateProperties.Dto;
using Exwhyzee.Lojour.Application.States;
using Exwhyzee.Lojour.Core.State;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Exwhyzee.Lojour.Web.Areas.APanel.Pages.Property
{
    [Authorize(Roles = "SuperAdmin,Admin")]


    public class UpdatePublishModel : PageModel
    {

        private readonly IPropertyAppService _propertyAppService;
        private readonly IStateAppService _stateAppService;


        public UpdatePublishModel(IPropertyAppService propertyAppService, IStateAppService stateAppService)
        {
            _propertyAppService = propertyAppService;
            _stateAppService = stateAppService;

        }

        [BindProperty]
        public EstatePropertyDto Data { get; set; }


        public List<StateModel> State { get; set; }

        public async Task<IActionResult> OnGetAsync(long id)
        {


            var item = await _propertyAppService.Get(id);

            string imageUrl = "";
            if (item == null)
            {
                return NotFound($"Unable to load raffle with the ID '{id}'.");
            }


            Data = new EstatePropertyDto
            {
                PropertyStatus = item.PropertyStatus,
             VerificationStatus = item.VerificationStatus,
                SortOrder = item.SortOrder,
                HomeLocation = item.HomeLocation

            };

         
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(long id)
        {

            var property = await _propertyAppService.Get(id);
            if (property == null)
            {
                return NotFound($"Unable to load Raffle with the ID '{id}'.");
            }
            property.PropertyStatus = Data.PropertyStatus;
             property.VerificationStatus = Data.VerificationStatus;
                property.SortOrder = Data.SortOrder;
                property.HomeLocation = Data.HomeLocation;

            await _propertyAppService.Update(property);


            return RedirectToPage("./Index");
        }

    }
}