using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.EstateProperties.Dto;
using Exwhyzee.Lojour.Application.PropertyImages;
using Exwhyzee.Lojour.Core.PropertyImage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Web.Views.Shared.ViewComponents
{

    public class PropertyDashboardViewComponent : ViewComponent
    {
        private readonly IPropertyAppService _propertyAppService;
       

        public PropertyDashboardViewComponent(IPropertyAppService propertyAppService)
        {
            _propertyAppService = propertyAppService;

        }

        public async Task<IViewComponentResult> InvokeAsync(long propertyId)
        {
            var item = await GetItemAsync(propertyId);

            return View(item);
        }

        private async Task<List<EstatePropertyDto>> GetItemAsync(long propertyId)
        {
            var data = await _propertyAppService.GetAllProperty();


            return data.Source.ToList();
        }
    }
}
