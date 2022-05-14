using Exwhyzee.Lojour.Application.PropertyImages;
using Exwhyzee.Lojour.Core.PropertyImage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Website.Views.Shared.ViewComponents
{

    public class OtherSmallFetcherViewComponent : ViewComponent
    {
        private readonly IPropertyImagesAppService _propertyImagesAppService;


        public OtherSmallFetcherViewComponent(IPropertyImagesAppService propertyImagesAppService)
        {

            _propertyImagesAppService = propertyImagesAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync(long propertyId)
        {
            var item = await GetItemAsync(propertyId);

            return View(item);
        }

        private async Task<List<PropertyImage>> GetItemAsync(long propertyId)
        {
            var images = await _propertyImagesAppService.GetAllImages(propertyId: propertyId);

           
            return images.Source.OrderBy(x => x.Id).Where(x=>x.IsDefault == false).ToList();
        }
    }
}
