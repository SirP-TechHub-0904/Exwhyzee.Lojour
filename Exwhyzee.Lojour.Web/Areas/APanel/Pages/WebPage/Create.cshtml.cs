using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Exwhyzee.Lojour.Core.State;
using Exwhyzee.Lojour.Application.States;
using Microsoft.AspNetCore.Identity;
using Exwhyzee.Lojour.Core.Authorization.Users;
using Microsoft.AspNetCore.Authorization;
using Exwhyzee.Lojour.Application.Pages;
using Exwhyzee.Lojour.Core.Page;

namespace Exwhyzee.Lojour.Web.Areas.APanel.Pages.WebPage
{
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class CreateModel : PageModel
    {
        //
        private readonly IPageAppService _pageAppService;

        public CreateModel(IPageAppService pageAppService)
        {
            _pageAppService = pageAppService;
        }

        public string LoggedInUser { get; set; }


        //
        [BindProperty]
        public PageData Data { get; set; }
        
        public async Task OnGet()
        {

         

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            try
            {
               
                if (ModelState.IsValid)
                {

                   

                    var item = new PageData
                    {
                        Title = Data.Title,
                        PageStatus = Data.PageStatus,
                        Content = Data.Content,
                        PagePosition = Data.PagePosition

                    };

                    var newpropertyId = await _pageAppService.Add(item);


                    return RedirectToPage("Index");
                }

                return Page();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

    }
}