using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.Communities;
using Exwhyzee.Lojour.Application.KindredApp;
using Exwhyzee.Lojour.Application.LGAs;
using Exwhyzee.Lojour.Core.CommunityModel;
using Exwhyzee.Lojour.Core.KindredModel;
using Exwhyzee.Lojour.Core.LgaModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Website.Areas.GeneralLocation.Pages.Kindred
{
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class IndexModel : PageModel
    {
        private readonly IKindredAppService _kindredAppService;

        public IndexModel(IKindredAppService kindredAppService)
        {
           
            _kindredAppService = kindredAppService;
        }

        public PagedList<Kindreds> Data { get; set; }
        List<Kindreds> item = new List<Kindreds>();

        public async Task<IActionResult> OnGetAsync()
        {
            var paggedData = await _kindredAppService.GetAll();
            var paggedSource = paggedData.Source.ToList();

            item.AddRange(paggedSource.Select(entity => new Kindreds()
            {
               Name = entity.Name,
               Community = entity.Community,
                Id = entity.Id

            }));

            Data = new PagedList<Kindreds>(source: item, pageIndex: paggedData.PageIndex,
                                           pageSize: paggedData.PageSize, filteredCount: paggedData.FilteredCount, totalCount:
                                           paggedData.TotalCount);
            return Page();
        }
    }
}