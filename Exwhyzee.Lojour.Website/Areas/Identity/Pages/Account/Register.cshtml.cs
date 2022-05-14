using Exwhyzee.Core.Mvc.ValidationAttributes;
using Exwhyzee.Lojour.Core.Authorization.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Exwhyzee.Lojour.Application.UserProfile;
using Exwhyzee.Lojour.Application.Experience;
using Exwhyzee.Lojour.Application.EducationHistory;
using Exwhyzee.Lojour.Application.Skill;
using Exwhyzee.Lojour.Application.DegreeObtained;
using Exwhyzee.Lojour.Application.InterpersonalSkill;
using Exwhyzee.Lojour.Application.LanguageSpoken;
using Exwhyzee.Lojour.Application.MembershipOfLearneredSociety;
using Exwhyzee.Lojour.Application.MeritCertificate;
using Exwhyzee.Lojour.Application.TrainingAndWorkShop;
using Exwhyzee.Lojour.Core.Experience;
using Exwhyzee.Lojour.Core.UserProfile;
using Exwhyzee.Lojour.Core.EducationHistory;
using Exwhyzee.Lojour.Core.Skill;
using Exwhyzee.Lojour.Core.DegreeObtained;
using Exwhyzee.Lojour.Core.InterpersonalSkill;
using Exwhyzee.Lojour.Core.LanguageSpoken;
using Exwhyzee.Lojour.Core.MembershipOfLearneredSociety;
using Exwhyzee.Lojour.Core.MeritCertificate;
using Exwhyzee.Lojour.Core.TrainingAndWorkShop;

namespace Exwhyzee.Lojour.Website.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly RoleManager<ApplicationRole> _roleManager;

        private IUserProfileAppService _userProfileAppService;
        private IExperienceAppService _experienceAppService;
        private IEducationHistoryAppService _educationHistoryAppService;
        private ISkillAppService _skillAppService;
        private IDegreeObtainedAppService _degreeObtainedAppService;
        private IInterpersonalSkillAppService _interpersonalSkillAppService;
        private ILanguageSpokenAppService _languageSpokenAppService;
        private IMembershipOfLearneredSocietyAppService _membershipOfLearneredSocietyAppService;
        private IMeritCertificateAppService _meritCertificateAppService;
        private ITrainingAndWorkShopAppService _TrainingAndWorkShopAppService;




        public RegisterModel(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ILogger<RegisterModel> logger,
                    RoleManager<ApplicationRole> roleManager,
                    IUserProfileAppService userProfileAppService,
            IExperienceAppService experienceAppService,
            IEducationHistoryAppService educationHistoryAppService,
            ISkillAppService skillAppService,
            IDegreeObtainedAppService degreeObtainedAppService,
            IInterpersonalSkillAppService interpersonalSkillAppService,
            ILanguageSpokenAppService languageSpokenAppService,
            IMembershipOfLearneredSocietyAppService membershipOfLearneredSocietyAppService,
            IMeritCertificateAppService meritCertificateAppService,
            ITrainingAndWorkShopAppService TrainingAndWorkShopAppService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

            _logger = logger;
            _userProfileAppService = userProfileAppService;
            _experienceAppService = experienceAppService;
            _educationHistoryAppService = educationHistoryAppService;
            _skillAppService = skillAppService;
            _degreeObtainedAppService = degreeObtainedAppService;
            _interpersonalSkillAppService = interpersonalSkillAppService;
            _languageSpokenAppService = languageSpokenAppService;
            _membershipOfLearneredSocietyAppService = membershipOfLearneredSocietyAppService;
            _meritCertificateAppService = meritCertificateAppService;
            _TrainingAndWorkShopAppService = TrainingAndWorkShopAppService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string StatusMessage { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }



            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }


            [Required]
            [Display(Name = "Phone Number"), RegularExpression(@"^[0]\d{10}$", ErrorMessage = "Error! Invalid Phone Number")]

            public string PhoneNumber { get; set; }



            public DateTime DateRegistered { get; set; }

            public string CodeVerify { get; set; }

            public string UniqueId { get; set; }

            public string ContactAddress { get; set; }
            public string RoleString { get; set; }
            public string State { get; set; }
            public string LGA { get; set; }
            public string Community { get; set; }
            public string Kindred { get; set; }
            public string IdentificationMode { get; set; }
            public string VerificationStatus { get; set; }
            public string IdentificationNumber { get; set; }
            public string BVN { get; set; }
            public string NextOfKinName { get; set; }
            public string NextOfKinEmail { get; set; }
            public string NextOfKinPhoneNumber { get; set; }
            public string RefereeName { get; set; }
            public string RefereePhone { get; set; }
            public string RefereeEmail { get; set; }

        }

        [BindProperty]
        public List<SelectListItem> Roles { get; set; }

        public UserProfileModel userProfileModel = new UserProfileModel();
        public ExperienceModel experienceModel = new ExperienceModel();
        public EducationHistoryModel EducationModel = new EducationHistoryModel();
        public SkillModel skillModel = new SkillModel();
        public DegreeObtainedModel degreeObtainedModel = new DegreeObtainedModel();
        public InterpersonalSkillModel interpersonalSkillModel = new InterpersonalSkillModel();
        public LanguageSpokenModel languageSpokenModel = new LanguageSpokenModel();
        public MembershipOfLearneredSocietyModel membershipOfLearneredSocietyModel = new MembershipOfLearneredSocietyModel();

        public MeritCertificateModel meritCertificateModel = new MeritCertificateModel();
        public TrainingAndWorkShopModel trainingAndWorkShopModel = new TrainingAndWorkShopModel();

        public async Task OnGet(string returnUrl = null)
        {
            var roles = _roleManager.Roles.Where(x => !x.Name.Contains("Admin")).ToList();
            Roles = roles.Select(a => new SelectListItem
            {
                Value = a.Name.ToString(),
                Text = a.Name
            }).ToList();

        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            var roles = _roleManager.Roles.Where(x => !x.Name.Contains("Admin")).ToList();

            returnUrl = returnUrl ?? Url.Content("~/");
            var check = _userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                var unqiueId = check.OrderByDescending(x => x.UniqueId).FirstOrDefault();
                var verificationCode = Exwhyzee.Core.Helpers.CommonHelper.GenerateRandomInteger(8);

                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    PhoneNumber = Input.PhoneNumber,
                    CodeVerify = "",
                    DateRegistered = DateTime.UtcNow.AddHours(1),
                    UniqueId = "id",
                    RoleString = Input.RoleString,
                    UserVerification = Enums.UserVerification.Unverified,
                    EmailConfirmed = true

                };
                //

                if (check.Select(x => x.Email).Contains(Input.Email))
                {
                    TempData["error"] = "Email already taken";
                    Roles = roles.Select(a => new SelectListItem
                    {
                        Value = a.Name.ToString(),
                        Text = a.Name
                    }).ToList();
                    return Page();
                }

                if (check.Select(x => x.PhoneNumber).Contains(Input.PhoneNumber))
                {
                    TempData["error"] = "phone number already taken";
                    Roles = roles.Select(a => new SelectListItem
                    {
                        Value = a.Name.ToString(),
                        Text = a.Name
                    }).ToList();
                    return Page();
                }

                //age

                try
                {


                    var result = await _userManager.CreateAsync(user, Input.Password);
                    if (result.Succeeded)
                    {

                        await _userManager.AddToRoleAsync(user, Input.RoleString);
                        userProfileModel.UserId = user.Id;
                        userProfileModel.DateOfBirth = DateTime.UtcNow.AddHours(1);
                        userProfileModel.DateRegistered = DateTime.UtcNow.AddHours(1);
                        userProfileModel.MaritalStatus = "";


                        var uId = await _userProfileAppService.Insert(userProfileModel);

                        userProfileModel.LojourId = "LJ/"+ userProfileModel.Id.ToString("00000");
                        var newId = _userProfileAppService.Update(userProfileModel);


                        _logger.LogInformation("User created a new account with password.");

                        //update rolestring
                        string rolename = "";
                        var userRole = await _userManager.FindByIdAsync(user.Id);
                        var roleRole = await _userManager.GetRolesAsync(userRole);
                        if (roleRole != null)
                        {
                            rolename = string.Join("; ", roleRole);
                        }
                        userRole.RoleString = rolename;
                        await _userManager.UpdateAsync(userRole);

                        var emailCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        //var callbackUrl = Url.Page(
                        //    "/Account/ConfirmEmail",
                        //    pageHandler: null,
                        //    values: new { userId = user.Id, code = emailCode },
                        //    protocol: Request.Scheme);

                        //var emailMessageBody = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";
                        //var emailMessageBody = $"Please confirm your number is " + verificationCode.ToString();

                        //var emailMessage = string.Format("{0};??{1};??{2};??{3}", "Successful", "Your registration was successful", "Welcome " + user.FullName, ".");
                        //var smsMessage = string.Format("{0}, Your registration was successful. Play Small WinBig @ https://www.Lojour.com/", user.FullName);
                        //_logger.LogInformation("Pusing Email To Store");
                        //await SendMessage(emailMessage, user.Email, MessageChannel.Email, MessageType.Activation);

                        //var validePhoneNumber = Exwhyzee.Core.Helpers.CommonHelper.IsValidPhoneNumber(user.PhoneNumber);
                        //if (validePhoneNumber)
                        //{
                        //    _logger.LogInformation("Pusing SMS To Store");
                        //    await SendMessage(smsMessage, user.PhoneNumber, MessageChannel.SMS, MessageType.Activation);
                        //}


                        await _signInManager.SignInAsync(user, isPersistent: false);

                        if (await _signInManager.UserManager.IsInRoleAsync(user, "Admin"))
                        {
                            return RedirectToPage("Index", "Users", "UserManagement");

                        }
                        else if (await _signInManager.UserManager.IsInRoleAsync(user, "SuperAdmin"))
                        {
                            return RedirectToPage("Index", "Dashboard", "SuperAdmin");
                        }
                        else if (await _signInManager.UserManager.IsInRoleAsync(user, "Agent") || await _signInManager.UserManager.IsInRoleAsync(user, "Saller") || await _signInManager.UserManager.IsInRoleAsync(user, "Buyer"))
                        {

                            return RedirectToPage("/Profile", new { area = "Account" });
                        }
                        return LocalRedirect(returnUrl);

                        // return RedirectToPage("./Manage/Verify", new { id = user.Id });
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                catch (Exception e)
                {
                    TempData["error"] = e;


                }
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                                       .Where(y => y.Count > 0)
                                       .ToList();
            }
            Roles = roles.Select(a => new SelectListItem
            {
                Value = a.Name.ToString(),
                Text = a.Name
            }).ToList();
            return Page();
        }

    }
}
