using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.Tour;
using Exwhyzee.Lojour.Application.Tour.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Web.Areas.APanel.Pages.Property
{
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class DetailsTourModel : PageModel
    {
        private readonly ITourAppService _tourAppService;

        public DetailsTourModel(ITourAppService tourAppService)
        {
            _tourAppService = tourAppService;
        }


        [BindProperty]
        public TourModelDto Dto { get; set; }
        public async Task OnGet(long id)
        {
            var entity = await _tourAppService.Get(id);

          
            if (entity == null)
            {
                //return NotFound($"Unable to load property with the ID '{id}'.");
            }
            Dto = entity;

        }
    }
}