using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.Tour;
using Exwhyzee.Lojour.Application.Tour.Dto;
using Exwhyzee.Lojour.Core.State;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Exwhyzee.Lojour.Web.Areas.APanel.Pages.Property
{
    [Authorize(Roles = "SuperAdmin,Agent,Admin")]


    public class EditTourModel : PageModel
    {

        private readonly ITourAppService _tourAppService;

        public EditTourModel(ITourAppService tourAppService)
        {
            _tourAppService = tourAppService;
        }



        [BindProperty]
        public TourModelDto Data { get; set; }
        

        public async Task<IActionResult> OnGetAsync(long id)
        {


            var entity = await _tourAppService.Get(id);

            string imageUrl = "";
            if (entity == null)
            {
                return NotFound($"Unable to load raffle with the ID '{id}'.");
            }


            Data = new TourModelDto
            {

                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                Date = entity.Date,
                Time = entity.Time,
                Payment = entity.Payment,
                FullName = entity.FullName

                
            };

            //state

           

            return Page();
        }


        public async Task<IActionResult> OnPostAsync(long id)
        {

            var property = await _tourAppService.Get(id);
            if (property == null)
            {
                return NotFound($"Unable to load Raffle with the ID '{id}'.");
            }
            
                property.PhoneNumber = Data.PhoneNumber;
                property.Email = Data.Email;
                property.Date = Data.Date;
                property.Time = Data.Time;
                property.Payment = Data.Payment;
                property.FullName = Data.FullName;

            await _tourAppService.Update(property);


            return RedirectToPage("./Request");
        }

    }
}