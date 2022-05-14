using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.RequestProperties;
using Exwhyzee.Lojour.Application.RequestProperties.Dto;
using Exwhyzee.Lojour.Core.State;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Exwhyzee.Lojour.Web.Areas.APanel.Pages.Property
{
    [Authorize(Roles = "SuperAdmin,Agent,Admin")]


    public class EditRequestModel : PageModel
    {

        private readonly IRequestPropertyAppService _requestPropertyAppService;

        public EditRequestModel(IRequestPropertyAppService requestPropertyAppService)
        {
            _requestPropertyAppService = requestPropertyAppService;
        }



        [BindProperty]
        public RequestPropertyDto Data { get; set; }
        

        public async Task<IActionResult> OnGetAsync(long id)
        {


            var entity = await _requestPropertyAppService.Get(id);

            string imageUrl = "";
            if (entity == null)
            {
                return NotFound($"Unable to load raffle with the ID '{id}'.");
            }


            Data = new RequestPropertyDto
            {
                PropertyName = entity.PropertyName,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                ListType = entity.ListType,
                Category = entity.Category,
                Location = entity.Location,
                LandMark = entity.LandMark,
                Features = entity.Features,
                AmountRange = entity.AmountRange,
                AlertType = entity.AlertType,
                AlertDuration = entity.AlertDuration

            };

            //state

           

            return Page();
        }


        public async Task<IActionResult> OnPostAsync(long id)
        {

            var property = await _requestPropertyAppService.Get(id);
            if (property == null)
            {
                return NotFound($"Unable to load Raffle with the ID '{id}'.");
            }
            
            property.PropertyName = Data.PropertyName;
                property.PhoneNumber = Data.PhoneNumber;
                property.Email = Data.Email;
                property.ListType = Data.ListType;
                property.Category = Data.Category;
                property.Location = Data.Location;
                property.LandMark = Data.LandMark;
                property.Features = Data.Features;
                property.AmountRange = Data.AmountRange;
                property.AlertType = Data.AlertType;
            property.AlertDuration = Data.AlertDuration;

            await _requestPropertyAppService.Update(property);


            return RedirectToPage("./Request");
        }

    }
}