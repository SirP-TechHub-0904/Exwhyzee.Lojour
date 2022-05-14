using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using System.Linq;
using System.Net.Http.Headers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Exwhyzee.Lojour.Application.Communities;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Core.CommunityModel;
using Exwhyzee.Lojour.Core.LgaModel;
using Exwhyzee.Lojour.Application.LGAs;
using Microsoft.AspNetCore.Authorization;

namespace Exwhyzee.Lojour.Web.Areas.GeneralLocation.Pages.Community
{
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class NewCommunityModel : PageModel
    {
        private readonly ICommunityAppService _communityAppService;
        private readonly ILGAsAppService _lgaAppService;

        public NewCommunityModel(ICommunityAppService communityAppService, ILGAsAppService lgaAppService)
        {
            _communityAppService = communityAppService;
            _lgaAppService = lgaAppService;
        }


        //
        public PagedList<Lga> MainData { get; set; }
        [BindProperty]
        public CommunityData Data { get; set; }

       public List<Lga> item { get; set; }
        public async Task OnGet()
        {
           
            //LoggedInUser = _userManager.GetUserId(HttpContext.User);
             var paggedData = await _lgaAppService.GetAll();
            var paggedSource = paggedData.Source.ToList();


            //item.AddRange(paggedSource.Select(entity => new Lga()
            //{
            //   Name = entity.Name,
              
            //    Id = entity.Id

            //}));
            //MainData = new PagedList<Lga>(source: item, pageIndex: paggedData.PageIndex,
            //                                 pageSize: paggedData.PageSize, filteredCount: paggedData.FilteredCount, totalCount:
            //                                 paggedData.TotalCount);
            item = paggedSource.ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    var item = new CommunityData
                    {
                       Name = Data.Name,
                       LgaId = Data.LgaId

                    };

                    var newpropertyId = await _communityAppService.Insert(item);

                    

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