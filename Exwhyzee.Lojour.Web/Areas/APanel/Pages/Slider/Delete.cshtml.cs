using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.Barner;
using Exwhyzee.Lojour.Core.BarnerImage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Web.Areas.APanel.Pages.Slider
{
    public class DeleteModel : PageModel
    {
        private readonly IBarnerAppService _barnerAppService;
        private readonly IHostingEnvironment _hostingEnv;


        public DeleteModel(IBarnerAppService barnerAppService, IHostingEnvironment env)
        {
            _barnerAppService = barnerAppService;
            _hostingEnv = env;
        }


        public BarnerFile Barners { get; set; }
        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(long id)
        {
            try
            {
                await _barnerAppService.Delete(Id: id);

            }catch(Exception e)
            {

            }
            return Redirect("/Admin/Slider/Index");
        }
    }
}