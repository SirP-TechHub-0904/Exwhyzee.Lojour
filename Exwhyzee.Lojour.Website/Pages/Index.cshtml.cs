using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.Communities;
using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.EstateProperties.Dto;
using Exwhyzee.Lojour.Application.KindredApp;
using Exwhyzee.Lojour.Application.LGAs;
using Exwhyzee.Lojour.Application.Pages;
using Exwhyzee.Lojour.Application.PropertyImages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Exwhyzee.Lojour.Websitesite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPropertyAppService _propertyAppService;
        private readonly IPropertyImagesAppService _propertyImagesAppService;
        private readonly IHostingEnvironment _hostingEnv;
        private readonly ICommunityAppService _communityAppService;
        private readonly IKindredAppService _kindredAppService;
        private readonly ILGAsAppService _lgaAppService;
        private readonly IPageAppService _pageAppService;



        public IndexModel(IPropertyAppService propertyAppService, IHostingEnvironment env,
            IPropertyImagesAppService propertyImagesAppService, ICommunityAppService communityAppService,
            IKindredAppService kindredAppService, ILGAsAppService lgaAppService, IPageAppService pageAppService)
        {
            _propertyAppService = propertyAppService;
            _hostingEnv = env;
            _propertyImagesAppService = propertyImagesAppService;
            _communityAppService = communityAppService;
            _kindredAppService = kindredAppService;
            _lgaAppService = lgaAppService;
            _pageAppService = pageAppService;
        }

        public IList<EstatePropertyDto> MinnorMain { get; set; }
        public IList<EstatePropertyDto> LList { get; set; }
        public IList<EstatePropertyDto> MajorMain { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var entity = await _propertyAppService.GetAllProperty();



            //var result = entity.Source.Where(x => x.HomeLocation == Enums.HomeLocation.MinnorMain).Take(4).ToList();
            var result = entity.Source.Where(x => x.HomeLocation == Enums.HomeLocation.MinnorMain).OrderByDescending(x => x.SortOrder).Take(4).ToList();
            MinnorMain = result;

            var result2 = entity.Source.Where(x => x.HomeLocation == Enums.HomeLocation.List).OrderByDescending(x => x.SortOrder).Take(9).ToList();
            LList = result2;

            var items = entity.Source.Where(x => x.HomeLocation == Enums.HomeLocation.MajorMain).OrderByDescending(x => x.SortOrder).Take(2).ToList();
            MajorMain = items;


            return Page();
        }
    }
}
