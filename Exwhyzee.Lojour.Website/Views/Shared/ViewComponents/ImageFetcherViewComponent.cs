using Exwhyzee.Lojour.Application.PropertyImages;
using Exwhyzee.Lojour.Core.PropertyImage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Website.Views.Shared.ViewComponents
{

    public class ImageFetcherViewComponent : ViewComponent
    {
        private readonly IPropertyImagesAppService _propertyImagesAppService;


        public ImageFetcherViewComponent(IPropertyImagesAppService propertyImagesAppService)
        {

            _propertyImagesAppService = propertyImagesAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync(long propertyId)
        {
            var item = await GetItemAsync(propertyId);

            return View(item);
        }

        private async Task<PropertyImage> GetItemAsync(long propertyId)
        {
            var images = await _propertyImagesAppService.GetAllImages(propertyId: propertyId);

            if (images.Source.Count() < 1)
            {
                
                return new PropertyImage
                {
                    DateCreated = DateTime.Now,
                    ImageExtension = ".png",
                    PropertyId = propertyId,
                    Id = 0,
                   
                    Url = $"/main/wimbig/wimbig_drum_2.png"
                };
                //return null;
            }
            return images.Source.OrderBy(x => x.Id).FirstOrDefault(x=>x.IsDefault == true);
        }
    }
}
