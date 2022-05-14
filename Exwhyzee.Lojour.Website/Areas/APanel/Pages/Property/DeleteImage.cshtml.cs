using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.PropertyImages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Website.Areas.APanel.Pages.Property
{
    [Authorize(Roles = "SuperAdmin,Agent,Admin")]

    public class DeleteImageModel : PageModel
    {
        private readonly IPropertyImagesAppService _propertyImagesAppService;
        private readonly IPropertyAppService _propertyAppService;
        public DeleteImageModel(IPropertyImagesAppService propertyImagesAppService, IPropertyAppService propertyAppService)
        {
            _propertyImagesAppService = propertyImagesAppService;
            _propertyAppService = propertyAppService;
        }

        public async Task<IActionResult> OnGet(long id)
        {

            try
            {
                await _propertyImagesAppService.Delete(Id: id);

            }
            catch (Exception e)
            {

            }
            return Redirect("/APanel/Property/Index");
        }
    }
}