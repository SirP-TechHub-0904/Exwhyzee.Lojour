using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.Communities;
using Exwhyzee.Lojour.Application.LGAs;
using Exwhyzee.Lojour.Core.CommunityModel;
using Exwhyzee.Lojour.Core.LgaModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Website.Areas.GeneralLocation.Pages.Community
{
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class IndexModel : PageModel
    {
        private readonly ICommunityAppService _communityAppService;

        public IndexModel(ICommunityAppService communityAppService)
        {
            _communityAppService = communityAppService;
        }

        public PagedList<CommunityData> Data { get; set; }
        List<CommunityData> item = new List<CommunityData>();

        public async Task<IActionResult> OnGetAsync()
        {
            var paggedData = await _communityAppService.GetAll();
            var paggedSource = paggedData.Source.ToList();

            item.AddRange(paggedSource.Select(entity => new CommunityData()
            {
               Name = entity.Name,
               LGA = entity.LGA,
                Id = entity.Id

            }));

            Data = new PagedList<CommunityData>(source: item, pageIndex: paggedData.PageIndex,
                                           pageSize: paggedData.PageSize, filteredCount: paggedData.FilteredCount, totalCount:
                                           paggedData.TotalCount);
            return Page();
        }
    }
}