using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.EstateProperties.Dto;
using Exwhyzee.Lojour.Application.Pages;
using Exwhyzee.Lojour.Application.Pages.Dto;
using Exwhyzee.Lojour.Application.States;
using Exwhyzee.Lojour.Core.Page;
using Exwhyzee.Lojour.Core.State;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Exwhyzee.Lojour.Web.Areas.APanel.Pages.WebPage
{
    [Authorize(Roles = "SuperAdmin,Admin")]


    public class EditModel : PageModel
    {

        private readonly IPageAppService _pageAppService;

        public EditModel(IPageAppService pageAppService)
        {
            _pageAppService = pageAppService;
        }

        [BindProperty]
        public PageDataDto Data { get; set; }

        

        public async Task<IActionResult> OnGetAsync(long id)
        {


            var item = await _pageAppService.Get(id);

            string imageUrl = "";
            if (item == null)
            {
                return NotFound($"Unable to load raffle with the ID '{id}'.");
            }


            Data = new PageDataDto
            {

                Title = item.Title,
                PageStatus = item.PageStatus,
                Content = item.Content,
                PagePosition = item.PagePosition
            };

            
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(long id)
        {

            var page = await _pageAppService.Get(id);
            if (page == null)
            {
                return NotFound($"Unable to load Raffle with the ID '{id}'.");
            }


            page.Title = Data.Title;
            page.PageStatus = Data.PageStatus;
            page.Content = Data.Content;
            page.PagePosition = Data.PagePosition;



            await _pageAppService.Update(page);


            return RedirectToPage("./Index");
        }

    }
}