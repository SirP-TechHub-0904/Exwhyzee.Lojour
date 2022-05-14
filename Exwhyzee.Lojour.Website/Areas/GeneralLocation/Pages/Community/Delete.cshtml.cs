using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.Communities;
using Exwhyzee.Lojour.Core.CommunityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Website.Areas.GeneralLocation.Pages.Community
{
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class DeleteModel : PageModel
    {
        private readonly ICommunityAppService _communityAppService;

        public DeleteModel(ICommunityAppService communityAppService)
        {
            _communityAppService = communityAppService;
        }


        public CommunityData Data { get; set; }


        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(long id)
        {
            try
            {
                await _communityAppService.Delete(Id: id);

            }catch(Exception e)
            {

            }
            return Redirect("/GeneralLocation/Community/Index");
        }
    }
}