using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.EstateProperties.Dto;
using Exwhyzee.Lojour.Application.PropertyFeatures;
using Exwhyzee.Lojour.Application.PropertyImages;
using Exwhyzee.Lojour.Application.PropertyLandMark;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Web.Areas.APanel.Pages.Property
{
    [Authorize(Roles = "SuperAdmin,Agent,Admin")]

    public class DetailsModel : PageModel
    {
        private readonly IPropertyAppService _propertyAppService;
        private readonly IPropertyImagesAppService _propertyImagesAppService;
        private readonly IHostingEnvironment _hostingEnv;
        private readonly IPropertyFeaturesAppService _propertyFeaturesAppService;
        private readonly IPropertyLandMarkAppService _propertyLandMarkAppService;


        public DetailsModel(IPropertyAppService propertyAppService, IHostingEnvironment env, IPropertyLandMarkAppService propertyLandMarkAppService,
            IPropertyFeaturesAppService propertyFeaturesAppService,
            IPropertyImagesAppService propertyImagesAppService)
        {
            _propertyAppService = propertyAppService;
            _hostingEnv = env;
            _propertyImagesAppService = propertyImagesAppService;
            _propertyLandMarkAppService = propertyLandMarkAppService;
            _propertyFeaturesAppService = propertyFeaturesAppService;

        }
        [BindProperty]
        public EstatePropertyWithImages EstatePropertyDto { get; set; }
        public async Task OnGet(long id)
        {
            var entity = await _propertyAppService.Get(id);

            //get all images
            var img = await _propertyImagesAppService.GetAllImages(propertyId: entity.Id);
            //
            var DataFeatures = await _propertyFeaturesAppService.GetAll(propertyId: entity.Id);
           
            var DataLandMark = await _propertyLandMarkAppService.GetAll(propertyId: entity.Id);

            if (entity == null)
            {
                //return NotFound($"Unable to load property with the ID '{id}'.");
            }


            EstatePropertyDto = new EstatePropertyWithImages
            {

                PropertyName = entity.PropertyName,
                Description = entity.Description,
                AgentDetails = entity.AgentDetails,
                Longitude = entity.Longitude,
                Latitude = entity.Latitude,
                Amount = entity.Amount,
                PropertyProfile = entity.PropertyProfile,
                PropertyType = entity.PropertyType,
                PropertyStatus = entity.PropertyStatus,
                VerificationStatus = entity.VerificationStatus,
                DateCreated = entity.DateCreated,
                IdentificationNumber = entity.IdentificationNumber,
                State = entity.State,
                LGA = entity.LGA,
                Community = entity.Community,
                Kindred = entity.Kindred,
                SortOrder = entity.SortOrder,
                Id = entity.Id,
                RateFive = entity.RateFive,
                RateFour = entity.RateFour,
                RateOne = entity.RateOne,
                RateThree = entity.RateThree,
                RateTwo = entity.RateTwo,
                Video = entity.Video,
                PropertyImages = img.Source.ToList(),
                PropertyFeatures = DataFeatures.Source.ToList(),
                PropertyLandMarks = DataLandMark.Source.ToList()

            };


        }
    }
}