using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.EstateProperties.Dto;
using Exwhyzee.Lojour.Application.PropertyImages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Exwhyzee.Lojour.Website.Areas.APanel.Pages.Property
{
    [Authorize(Roles = "SuperAdmin,Agent,Admin")]

    public class MakeDefaultImageModel : PageModel
    {

        private readonly IPropertyImagesAppService _propertyImagesAppService;
        private readonly IPropertyAppService _propertyAppService;
        private readonly IHostingEnvironment _hostingEnv;

        public MakeDefaultImageModel(IPropertyImagesAppService propertyImagesAppService,
            IHostingEnvironment env, IPropertyAppService propertyAppService)
        {
            _propertyImagesAppService = propertyImagesAppService;
            _propertyAppService = propertyAppService;
            _hostingEnv = env;
        }
        [BindProperty]
        public EstatePropertyDto Data { get; set; }

       

        public async Task<IActionResult> OnGetAsync(long id)
        {

           
                var item = await _propertyImagesAppService.GetById(id);
 try
            {
                var alliamges = await _propertyImagesAppService.GetAllImages(propertyId: item.PropertyId);
                var defaultP = alliamges.Source.Where(x => x.IsDefault == true).ToList();
                foreach (var i in defaultP)
                {
                    var propertyimagechange = await _propertyImagesAppService.GetById(i.Id);
                    propertyimagechange.IsDefault = false;
                    await _propertyImagesAppService.Upate(propertyimagechange);
                }

                item.IsDefault = true;
                await _propertyImagesAppService.Upate(item);

            }catch(Exception c)
            {

            }

            return Redirect("/APanel/Property/ListImages/"+item.PropertyId);
        }


        public async Task<IActionResult> OnPostAsync(long id)
        {
         

            //long cityId = Convert.ToInt64(CityInfo);
            //long AreacityId = Convert.ToInt64(AreaInCity);
            //var cityData = await _cityAppService.Get(cityId);
            //var AreacityData = await _cityAppService.GetAreaInCity(AreacityId);


            //var raffle = await _raffleAppService.GetById(id);
            //if (raffle == null)
            //{
            //    return NotFound($"Unable to load Raffle with the ID '{id}'.");
            //}

            
            //raffle.Description = Raffle.Description;
            //raffle.SortOrder = Raffle.SortOrder;
            //raffle.PaidOut = Raffle.PaidOut;
            //raffle.Archived = Raffle.Archived;

            //raffle.DeliveryType = Raffle.DeliveryType;
           
            //raffle.Name = Raffle.Name;
            //raffle.NumberOfTickets = Raffle.NumberOfTickets;
            //raffle.PricePerTicket = Raffle.PricePerTicket;
            //raffle.Location = cityData.Name;
            //raffle.AreaInCity = AreacityData.Name;
           

            //await _raffleAppService.Update(raffle);

            //StatusMessage = "The Selected Raffle has been updated";
            return RedirectToPage("./Index");
        }

    }
}