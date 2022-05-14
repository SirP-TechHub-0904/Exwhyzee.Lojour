using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Core.Authorization.Users;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Website.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ResendPasswordCodeModel : PageModel
    {

        private readonly SignInManager<ApplicationUser> _signInManager;


        private readonly UserManager<ApplicationUser> _userManager;

        public ResendPasswordCodeModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager

           )
        {

            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> OnGetAsync(string id)
        {

            var user = await _userManager.FindByIdAsync(id);
            System.Random randomInteger = new System.Random();
            int genNumber = randomInteger.Next(1000000);
            user.CodeVerify = genNumber.ToString();
            await _userManager.UpdateAsync(user);


            ///
            //var emailMessageBody = $"Please confirm your number is " + genNumber;

            //var emailMessage = string.Format("{0};??{1};??{2};??{3}", "Account Confirmation", "Confirm your email", "Thanks " + user.FullName, emailMessageBody);
            //var smsMessage = string.Format("{0}, Your Confirmation Number: {1}", user.FullName, genNumber);
            //await SendMessage(emailMessage, user.Email, MessageChannel.Email, MessageType.Activation);

            
            //    await SendMessage(smsMessage, user.PhoneNumber, MessageChannel.SMS, MessageType.Activation);



           
            return RedirectToPage("./ForgotPasswordConfirmation", new { area = "Identity", id = user.Id });


        }

     
    }
}