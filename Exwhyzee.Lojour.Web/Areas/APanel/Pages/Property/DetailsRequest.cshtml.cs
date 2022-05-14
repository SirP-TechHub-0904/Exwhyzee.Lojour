using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.RequestProperties;
using Exwhyzee.Lojour.Application.RequestProperties.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Web.Areas.APanel.Pages.Property
{
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class DetailsRequestModel : PageModel
    {
        private readonly IRequestPropertyAppService _requestPropertyAppService;

        public DetailsRequestModel(IRequestPropertyAppService requestPropertyAppService)
        {
            _requestPropertyAppService = requestPropertyAppService;
        }


        [BindProperty]
        public RequestPropertyDto RequestPropertyDto { get; set; }
        public async Task OnGet(long id)
        {
            var entity = await _requestPropertyAppService.Get(id);

          
            if (entity == null)
            {
                //return NotFound($"Unable to load property with the ID '{id}'.");
            }
            RequestPropertyDto = entity;

        }
    }
}