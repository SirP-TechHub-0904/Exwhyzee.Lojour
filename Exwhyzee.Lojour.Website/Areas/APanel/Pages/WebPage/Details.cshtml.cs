using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.Pages;
using Exwhyzee.Lojour.Application.Pages.Dto;
using Exwhyzee.Lojour.Core.Page;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Website.Areas.APanel.Pages.WebPage
{
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class DetailsModel : PageModel
    {

        private readonly IPageAppService _pageAppService;

        public DetailsModel(IPageAppService pageAppService)
        {
            _pageAppService = pageAppService;
        }


        [BindProperty]
        public PageDataDto Data { get; set; }
        public async Task OnGet(long id)
        {
            var entity = await _pageAppService.Get(id);

          

            if (entity == null)
            {
               // return NotFound($"Unable to load property with the ID '{id}'.");
            }


            Data = new PageDataDto
            {

                Title = entity.Title,
                PageStatus = entity.PageStatus,
                Content = entity.Content,
                PagePosition = entity.PagePosition,
                

            };


        }
    }
}