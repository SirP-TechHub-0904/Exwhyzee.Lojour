using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.Tour;
using Exwhyzee.Lojour.Application.Tour.Dto;
using Exwhyzee.Lojour.Core.Authorization.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Website.Areas.APanel.Pages.Property
{
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class TourModel : PageModel
    {
        private readonly ITourAppService _tourAppService;
       
        public TourModel(ITourAppService tourAppService)
        {
            _tourAppService = tourAppService;
        }
        

        public PagedList<TourModelDto> Property { get; set; }
        List<TourModelDto> property = new List<TourModelDto>();

        public async Task<IActionResult> OnGetAsync()
        {
        
                var paggedProperty = await _tourAppService.GetAll();
                var paggedSource = paggedProperty.Source.ToList();
               

                property.AddRange(paggedSource.Select(entity => new TourModelDto()
                {
                    Id = entity.Id,
                    PhoneNumber = entity.PhoneNumber,
                    Email = entity.Email,
                    Date = entity.Date,
                    Time = entity.Time,
                    Payment = entity.Payment,
                    FullName = entity.FullName,
                    TourId = entity.TourId

                }));
                Property = new PagedList<TourModelDto>(source: property, pageIndex: paggedProperty.PageIndex,
                                              pageSize: paggedProperty.PageSize, filteredCount: paggedProperty.FilteredCount, totalCount:
                                              paggedProperty.TotalCount);
          
            return Page();
        }
    }
}