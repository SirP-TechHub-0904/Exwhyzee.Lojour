using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.PropertyImages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Website.Areas.APanel.Pages.Property
{
    public class UserStatusModel : PageModel
    {
        private readonly IPropertyImagesAppService _propertyImagesAppService;
        private readonly IPropertyAppService _propertyAppService;
        public UserStatusModel(IPropertyImagesAppService propertyImagesAppService, IPropertyAppService propertyAppService)
        {
            _propertyImagesAppService = propertyImagesAppService;
            _propertyAppService = propertyAppService;
        }

        public async Task OnGet()
        {

           
        }

        public async Task<IActionResult> OnPostAsync(long id)
        {

            return RedirectToPage("./Index");
        }

    }
}