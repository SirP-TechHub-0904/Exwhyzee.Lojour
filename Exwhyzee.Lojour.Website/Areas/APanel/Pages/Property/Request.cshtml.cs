using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.RequestProperties;
using Exwhyzee.Lojour.Application.RequestProperties.Dto;
using Exwhyzee.Lojour.Core.Authorization.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Website.Areas.APanel.Pages.Property
{
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class RequestModel : PageModel
    {
        private readonly IRequestPropertyAppService _requestPropertyAppService;
       
        public RequestModel(IRequestPropertyAppService requestPropertyAppService)
        {
            _requestPropertyAppService = requestPropertyAppService;
        }
        

        public PagedList<RequestPropertyDto> Property { get; set; }
        List<RequestPropertyDto> property = new List<RequestPropertyDto>();

        public async Task<IActionResult> OnGetAsync()
        {
        
                var paggedProperty = await _requestPropertyAppService.GetAll();
                var paggedSource = paggedProperty.Source.ToList();
               

                property.AddRange(paggedSource.Select(entity => new RequestPropertyDto()
                {
                    Id = entity.Id,
                    PropertyName = entity.PropertyName,
                    PhoneNumber = entity.PhoneNumber,
                    Email = entity.Email,
                    ListType = entity.ListType,
                    Category = entity.Category,
                    Location = entity.Location,
                    LandMark = entity.LandMark,
                    Features = entity.Features,
                    AmountRange = entity.AmountRange,
                    AlertType = entity.AlertType,
                    AlertDuration = entity.AlertDuration,
                    DateCreated = entity.DateCreated

                }));
                Property = new PagedList<RequestPropertyDto>(source: property, pageIndex: paggedProperty.PageIndex,
                                              pageSize: paggedProperty.PageSize, filteredCount: paggedProperty.FilteredCount, totalCount:
                                              paggedProperty.TotalCount);
          
            return Page();
        }
    }
}