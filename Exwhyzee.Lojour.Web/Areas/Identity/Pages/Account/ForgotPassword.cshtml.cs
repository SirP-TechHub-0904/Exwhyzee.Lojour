using Exwhyzee.Lojour.Core.Authorization.Users;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ForgotPasswordModel> _logger;


        public ForgotPasswordModel(UserManager<ApplicationUser> userManager,
            ILogger<ForgotPasswordModel> logger)
        {
            _userManager = userManager;

            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string Username { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {

            return Page();


        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByNameAsync(Input.Username);
                    if (user == null)
                    {
                        // Don't reveal that the user does not exist or is not confirmed
                        // return RedirectToPage("./ForgotPasswordConfirmation");
                        ModelState.AddModelError(string.Empty, "user invalid");
                        return Page();
                    }
                    System.Random randomInteger = new System.Random();
                    int genNumber = randomInteger.Next(1000000);

                    // For more information on how to enable account confirmation and password reset please 
                    // visit https://go.microsoft.com/fwlink/?LinkID=532713
                    var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ResetPassword",
                        pageHandler: null,
                        values: new { code },
                        protocol: Request.Scheme);

                    ////update code verify
                    //user.CodeVerify = genNumber.ToString();
                    //await _userManager.UpdateAsync(user);
                    /////
                    //var emailMessageBody = $"Please confirm your number is " + genNumber.ToString();

                    //var emailMessage = string.Format("{0};??{1};??{2};??{3}", "Password Reset", "Confirm Code", "Welcome " + user.FullName, emailMessageBody);
                    //var smsMessage = string.Format("{0}, Your Password Reset Number: {1}", user.FullName, genNumber.ToString());
                    //_logger.LogInformation("Pusing Email To Store");
                    //await SendMessage(emailMessage, user.Email, MessageChannel.Email, MessageType.Activation);

                    //await SendMessage(smsMessage, user.PhoneNumber, MessageChannel.SMS, MessageType.Activation);



                    ///
                    _logger.LogInformation("Posting Email to Store");
                    return RedirectToPage("./ForgotPasswordConfirmation", new { id = user.Id });
                }
            }
            catch (Exception c)
            {
                ModelState.AddModelError(string.Empty, c.Message);

            }
            return Page();
        }

       
    }
}
