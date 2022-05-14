using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.LGAs;
using Exwhyzee.Lojour.Core.LgaModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Website.Areas.GeneralLocation.Pages.LGA
{
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class IndexModel : PageModel
    {
        private readonly ILGAsAppService _lgaAppService;

        public IndexModel(ILGAsAppService lgaAppService)
        {
            _lgaAppService = lgaAppService;
        }

        public PagedList<Lga> Data { get; set; }
        List<Lga> item = new List<Lga>();

        public async Task<IActionResult> OnGetAsync()
        {
            var paggedProperty = await _lgaAppService.GetAll();
            var paggedSource = paggedProperty.Source.ToList();


            item.AddRange(paggedSource.Select(entity => new Lga()
            {
               Name = entity.Name,
               StateName = entity.StateName,
                Id = entity.Id

            }));

            Data = new PagedList<Lga>(source: item, pageIndex: paggedProperty.PageIndex,
                                           pageSize: paggedProperty.PageSize, filteredCount: paggedProperty.FilteredCount, totalCount:
                                           paggedProperty.TotalCount);
            return Page();
        }
    }
}