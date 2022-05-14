using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.KindredApp;
using Exwhyzee.Lojour.Core.KindredModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Web.Areas.GeneralLocation.Pages.Kindred
{
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class DeleteModel : PageModel
    {
        private readonly IKindredAppService _kindredAppService;

        public DeleteModel(IKindredAppService kindredAppService)
        {

            _kindredAppService = kindredAppService;
        }


        public Kindreds Data { get; set; }


        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(long id)
        {
            try
            {
                await _kindredAppService.Delete(Id: id);

            }catch(Exception e)
            {

            }
            return Redirect("/GeneralLocation/Kindred/Index");
        }
    }
}