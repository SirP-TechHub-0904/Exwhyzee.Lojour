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
using Exwhyzee.Lojour.Application.KindredApp;
using Exwhyzee.Lojour.Core.KindredModel;
using Microsoft.AspNetCore.Authorization;

namespace Exwhyzee.Lojour.Website.Areas.GeneralLocation.Pages.Kindred
{
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class NewKindredModel : PageModel
    {
        private readonly ICommunityAppService _communityAppService;
        private readonly IKindredAppService _kindredAppService;

        public NewKindredModel(ICommunityAppService communityAppService, IKindredAppService kindredAppService)
        {
            _communityAppService = communityAppService;
            _kindredAppService = kindredAppService;
        }


        //
        public PagedList<Lga> MainData { get; set; }
        [BindProperty]
        public Kindreds Data { get; set; }

       public List<CommunityData> item { get; set; }
        public async Task OnGet()
        {
           
            //LoggedInUser = _userManager.GetUserId(HttpContext.User);
             var paggedData = await _communityAppService.GetAll();
            var paggedSource = paggedData.Source.ToList();

            
            item = paggedSource.ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    var item = new Kindreds
                    {
                       Name = Data.Name,
                       CommunityId = Data.CommunityId
                    };

                    var newpropertyId = await _kindredAppService.Insert(item);
                    
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