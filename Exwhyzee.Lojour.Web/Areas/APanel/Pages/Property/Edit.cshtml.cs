using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.EstateProperties.Dto;
using Exwhyzee.Lojour.Application.PropertyFeatures;
using Exwhyzee.Lojour.Application.PropertyImages;
using Exwhyzee.Lojour.Application.PropertyLandMark;
using Exwhyzee.Lojour.Application.States;
using Exwhyzee.Lojour.Core.State;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Exwhyzee.Lojour.Web.Areas.APanel.Pages.Property
{
    [Authorize(Roles = "SuperAdmin,Agent,Admin")]


    public class EditModel : PageModel
    {

        private readonly IPropertyAppService _propertyAppService;
        private readonly IStateAppService _stateAppService;
        private readonly IPropertyImagesAppService _propertyImagesAppService;
        private readonly IPropertyFeaturesAppService _propertyFeaturesAppService;
        private readonly IPropertyLandMarkAppService _propertyLandMarkAppService;


        public EditModel(IPropertyAppService propertyAppService, IStateAppService stateAppService, IPropertyLandMarkAppService propertyLandMarkAppService,
            IPropertyFeaturesAppService propertyFeaturesAppService,
            IPropertyImagesAppService propertyImagesAppService)
        {
            _propertyAppService = propertyAppService;
            _stateAppService = stateAppService;
            _propertyImagesAppService = propertyImagesAppService;
            _propertyLandMarkAppService = propertyLandMarkAppService;
            _propertyFeaturesAppService = propertyFeaturesAppService;
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
            var img = await _propertyImagesAppService.GetAllImages(propertyId: id);
            //
            var DataFeatures = await _propertyFeaturesAppService.GetAll(propertyId: id);

            var DataLandMark = await _propertyLandMarkAppService.GetAll(propertyId: id);
            Data = new EstatePropertyDto
            {
                DescriptiveStatus = item.DescriptiveStatus,
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
                Video = item.Video,
                MapLink = item.MapLink,
                PropertyImagesList = img.Source.ToList(),
            PropertyFeaturesList = DataFeatures.Source.ToList(),
            PropertyLandMarksList = DataLandMark.Source.ToList()

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
            property.DescriptiveStatus = Data.DescriptiveStatus;
            property.PropertyAddress = Data.PropertyAddress;
            if (Data.State != null)
            {
                property.State = Data.State;
            }
            if (Data.LGA != null)
            {
                property.LGA = Data.LGA;
            }
            property.Community = Data.Community;
            property.Kindred = Data.Kindred;
            property.Video = Data.Video;
            property.MapLink = Data.MapLink;




            await _propertyAppService.Update(property);


            return RedirectToPage("./Index");
        }

    }
}