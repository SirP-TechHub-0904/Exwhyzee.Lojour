using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.EstateProperties.Dto;
using Exwhyzee.Lojour.Application.Pages;
using Exwhyzee.Lojour.Core.Authorization.Users;
using Exwhyzee.Lojour.Core.EstateProperties;
using Exwhyzee.Lojour.Core.Page;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Web.Areas.APanel.Pages.WebPage
{
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class IndexModel : PageModel
    {
        private readonly IPageAppService _pageAppService;

        public IndexModel(IPageAppService pageAppService)
        {
            _pageAppService = pageAppService;
        }


        public PagedList<PageData> PagesItem { get; set; }
        List<PageData> paged = new List<PageData>();

        public async Task<IActionResult> OnGetAsync()
        {

            var paggedProperty = await _pageAppService.GetAllPages();
            var paggedSource = paggedProperty.Source.ToList();


            paged.AddRange(paggedSource.Select(entity => new PageData()
            {
               Title = entity.Title,
               PageStatus = entity.PageStatus,
               Content = entity.Content,
               PagePosition = entity.PagePosition,
               Id = entity.Id

            }));

            PagesItem = new PagedList<PageData>(source: paged, pageIndex: paggedProperty.PageIndex,
                                           pageSize: paggedProperty.PageSize, filteredCount: paggedProperty.FilteredCount, totalCount:
                                           paggedProperty.TotalCount);
            return Page();
        }
    }
}