using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.States;
using Exwhyzee.Lojour.Core.State;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Website.Areas.GeneralLocation.Pages.State
{
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class IndexModel : PageModel
    {
        private readonly IStateAppService _stateAppService;

        public IndexModel(IStateAppService stateAppService)
        {
            _stateAppService = stateAppService;
        }

        public PagedList<StateModel> Data { get; set; }
        List<StateModel> item = new List<StateModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            var paggedProperty = await _stateAppService.GetAll();
            var paggedSource = paggedProperty.Source.ToList();


            item.AddRange(paggedSource.Select(entity => new StateModel()
            {
               Name = entity.Name,
                Id = entity.Id

            }));

            Data = new PagedList<StateModel>(source: item, pageIndex: paggedProperty.PageIndex,
                                           pageSize: paggedProperty.PageSize, filteredCount: paggedProperty.FilteredCount, totalCount:
                                           paggedProperty.TotalCount);
            return Page();
        }
    }
}