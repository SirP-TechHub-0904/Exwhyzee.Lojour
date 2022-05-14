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
    public class IndexModel : PageModel
    {
        private readonly IBarnerAppService _barnerAppService;
        private readonly IHostingEnvironment _hostingEnv;


        public IndexModel(IBarnerAppService barnerAppService, IHostingEnvironment env)
        {
            _barnerAppService = barnerAppService;
            _hostingEnv = env;
        }


        public PagedList<BarnerFile> Barners { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Barners = await _barnerAppService.GetBarnerFile();
            return Page();
        }
    }
}