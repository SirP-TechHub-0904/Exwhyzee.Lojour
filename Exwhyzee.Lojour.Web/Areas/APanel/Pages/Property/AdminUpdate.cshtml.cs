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
    public class AdminUpdateModel : PageModel
    {

        private readonly IPropertyAppService _propertyAppService;
        private readonly IStateAppService _stateAppService;


        public AdminUpdateModel(IPropertyAppService propertyAppService, IStateAppService stateAppService)
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

                PropertyName = item.PropertyName,
                Description = item.Description,
                AgentDetails = item.AgentDetails,
                Longitude = item.Longitude,
                Latitude = item.Latitude,
                Amount = item.Amount,
                PropertyProfile = item.PropertyProfile,
                PropertyType = item.PropertyType,
                PropertyAddress = item.PropertyAddress,
                State = item.State,
                LGA = item.LGA,
                Community = item.Community,
                Kindred = item.Kindred,
                SortOrder = item.SortOrder,
                HomeLocation = item.HomeLocation,
                Video = item.Video
            };

            //state

            var StateData = await _stateAppService.GetAll();
            var StateSource = StateData.Source.ToList();

            State = StateSource.ToList();

            return Page();
        }


        public async Task<IActionResult> OnPostAsync(long id)
        {

            var property = await _propertyAppService.Get(id);
            if (property == null)
            {
                return NotFound($"Unable to load Raffle with the ID '{id}'.");
            }




            property.PropertyName = Data.PropertyName;
            property.Description = Data.Description;
            property.AgentDetails = Data.AgentDetails;
            property.Longitude = Data.Longitude;
            property.Latitude = Data.Latitude;
            property.Amount = Data.Amount;
            property.PropertyProfile = Data.PropertyProfile;
            property.PropertyType = Data.PropertyType;
            property.PropertyStatus = Data.PropertyStatus;
            property.VerificationStatus = Data.VerificationStatus;
            property.DescriptiveStatus = Data.DescriptiveStatus;
            property.PropertyAddress = Data.PropertyAddress;
            property.State = Data.State;
            property.LGA = Data.LGA;
            property.Community = Data.Community;
            property.Kindred = Data.Kindred;
            property.SortOrder = Data.SortOrder;
            property.HomeLocation = Data.HomeLocation;
            property.Video = Data.Video;



            await _propertyAppService.Update(property);


            return RedirectToPage("./Index");
        }

    }
}