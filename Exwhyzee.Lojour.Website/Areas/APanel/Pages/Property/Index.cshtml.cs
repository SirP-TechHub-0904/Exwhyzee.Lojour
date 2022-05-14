using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.EstateProperties.Dto;
using Exwhyzee.Lojour.Core.Authorization.Users;
using Exwhyzee.Lojour.Core.EstateProperties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Website.Areas.APanel.Pages.Property
{
    [Authorize(Roles = "SuperAdmin,Agent,Admin")]

    public class IndexModel : PageModel
    {
        private readonly IPropertyAppService _propertyAppService;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(IPropertyAppService propertyAppService, UserManager<ApplicationUser> userManager)
        {
            _propertyAppService = propertyAppService;
            _userManager = userManager;
        }
        

        public PagedList<EstatePropertyDto> Property { get; set; }
        List<EstatePropertyDto> property = new List<EstatePropertyDto>();

        public async Task<IActionResult> OnGetAsync()
        {
            string n = _userManager.GetUserId(HttpContext.User);

            var user = await _userManager.FindByIdAsync(n);

            if (User.IsInRole("Admin") || User.IsInRole("SuperAdmin"))
            {
                var paggedProperty = await _propertyAppService.GetAllProperty();
                var paggedSource = paggedProperty.Source.ToList();
                if (user.UserVerification == Enums.UserVerification.Unverified)
                {
                    TempData["userstatus"] = "Not Verified";
                }

                property.AddRange(paggedSource.Select(entity => new EstatePropertyDto()
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
                    HomeLocation = entity.HomeLocation

                }));
                Property = new PagedList<EstatePropertyDto>(source: property, pageIndex: paggedProperty.PageIndex,
                                              pageSize: paggedProperty.PageSize, filteredCount: paggedProperty.FilteredCount, totalCount:
                                              paggedProperty.TotalCount);
            }
            else
            {
                var paggedProperty = await _propertyAppService.GetAllPropertyByUserId(username: user.UserName);
                var paggedSource = paggedProperty.Source.ToList();
                if (user.UserVerification == Enums.UserVerification.Unverified)
                {
                    TempData["userstatus"] = "Not Verified";
                }

                property.AddRange(paggedSource.Select(entity => new EstatePropertyDto()
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
                    Id = entity.Id

                }));

                Property = new PagedList<EstatePropertyDto>(source: property, pageIndex: paggedProperty.PageIndex,
                                               pageSize: paggedProperty.PageSize, filteredCount: paggedProperty.FilteredCount, totalCount:
                                               paggedProperty.TotalCount);
            }
            return Page();
        }
    }
}