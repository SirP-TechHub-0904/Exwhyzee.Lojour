using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.DegreeObtained;
using Exwhyzee.Lojour.Application.EducationHistory;
using Exwhyzee.Lojour.Application.Experience;
using Exwhyzee.Lojour.Application.InterpersonalSkill;
using Exwhyzee.Lojour.Application.LanguageSpoken;
using Exwhyzee.Lojour.Application.MembershipOfLearneredSociety;
using Exwhyzee.Lojour.Application.MeritCertificate;
using Exwhyzee.Lojour.Application.Skill;
using Exwhyzee.Lojour.Application.States;
using Exwhyzee.Lojour.Application.TrainingAndWorkShop;
using Exwhyzee.Lojour.Application.UserProfile;
using Exwhyzee.Lojour.Core.Authorization.Users;
using Exwhyzee.Lojour.Core.DegreeObtained;
using Exwhyzee.Lojour.Core.EducationHistory;
using Exwhyzee.Lojour.Core.Experience;
using Exwhyzee.Lojour.Core.InterpersonalSkill;
using Exwhyzee.Lojour.Core.LanguageSpoken;
using Exwhyzee.Lojour.Core.MembershipOfLearneredSociety;
using Exwhyzee.Lojour.Core.MeritCertificate;
using Exwhyzee.Lojour.Core.Skill;
using Exwhyzee.Lojour.Core.State;
using Exwhyzee.Lojour.Core.TrainingAndWorkShop;
using Exwhyzee.Lojour.Core.UserProfile;
using Exwhyzee.Lojour.Website.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Exwhyzee.Lojour.Website.Areas.Account.Pages
{
    public class UpdateProfileModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IHostingEnvironment _hostingEnv;
        private readonly IStateAppService _stateAppService;
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

        #region Data Binding

        public UpdateProfileModel(
            UserManager<ApplicationUser> userManager, IHostingEnvironment env,
            SignInManager<ApplicationUser> signInManager, IStateAppService stateAppService,
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
            _stateAppService = stateAppService;
            _logger = logger;
            _hostingEnv = env;
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


        #endregion

        #region Model
        [BindProperty]
        public ApplicationUser Data { get; set; }

        [BindProperty]
        public UserProfileModel userProfileModel { get; set; }
        [BindProperty]
        public ExperienceModel experienceModel { get; set; }

        [BindProperty]
        public long experienceModelId { get; set; }

        [BindProperty]
        public string PhotoUrlLink { get; set; }
        [BindProperty]
        public EducationHistoryModel EducationModel { get; set; }

        [BindProperty]
        public long educationModelId { get; set; }
        [BindProperty]
        public SkillModel skillModel { get; set; }

        [BindProperty]
        public long skillModelId { get; set; }

        [BindProperty]
        public LanguageSpokenModel languageSpokenModel { get; set; }

        [BindProperty]
        public long langaugeModelId { get; set; }
        [BindProperty]
        public MembershipOfLearneredSocietyModel membershipOfLearneredSocietyModel { get; set; }
        [BindProperty]
        public MeritCertificateModel meritCertificateModel { get; set; }
        [BindProperty]
        public long meritCertificateModelId { get; set; }
        [BindProperty]
        public TrainingAndWorkShopModel trainingAndWorkShopModel { get; set; }

        [BindProperty]
        public long trainingAndWorkShoModelId { get; set; }

        public List<ExperienceModel> ListExperienceModel { get; set; }
        public List<EducationHistoryModel> ListEducationHistoryModel { get; set; }
        public List<SkillModel> ListSkillModel { get; set; }
        public PagedList<InterpersonalSkillModel> ListInterpersonalSkillModel { get; set; }
        public List<LanguageSpokenModel> ListLanguageSpokenModel { get; set; }
        public List<MembershipOfLearneredSocietyModel> ListMembershipOfLearneredSocietyModel { get; set; }
        public List<MeritCertificateModel> ListMeritCertificateModel { get; set; }
        public List<TrainingAndWorkShopModel> ListTrainingAndWorkShopModel { get; set; }


        public List<StateModel> State { get; set; }

        #endregion

        #region OnGet / onpost
        public async Task<IActionResult> OnGetAsync()
        {


           
            string imageUrl = "";
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            Data = user;

            //profile
            var profile = await _userProfileAppService.GetByUserId(user.Id);
            userProfileModel = profile;

            //experiences
            var experience = await _experienceAppService.GetAll(userProfileId: profile.Id);
            ListExperienceModel = experience.Source.ToList();

            //education
            var education = await _educationHistoryAppService.GetAll(userProfileId: profile.Id);
            ListEducationHistoryModel = education.Source.ToList();

            //Skill
            var skill = await _skillAppService.GetAll(userProfileId: profile.Id);
            ListSkillModel = skill.Source.ToList();

            //Language
            var language = await _languageSpokenAppService.GetAll(userProfileId: profile.Id);
            ListLanguageSpokenModel = language.Source.ToList();

            //Merit Certificate
            var cert = await _meritCertificateAppService.GetAll(userProfileId: profile.Id);
            ListMeritCertificateModel = cert.Source.ToList();

            //MembershipOfLearneredSociety
            var MembershipOfLearneredSociety = await _membershipOfLearneredSocietyAppService.GetAll(userProfileId: profile.Id);
            ListMembershipOfLearneredSocietyModel = MembershipOfLearneredSociety.Source.ToList();


            //TrainingAndWorkShop
            var TrainingAndWorkShop = await _TrainingAndWorkShopAppService.GetAll(userProfileId: profile.Id);
            ListTrainingAndWorkShopModel = TrainingAndWorkShop.Source.ToList();
            //state

            var StateData = await _stateAppService.GetAll();
            var StateSource = StateData.Source.ToList();

            State = StateSource.ToList();

            //
            //var DataExperienceModel = await _experienceAppService.GetAll(u: id);
            //ListFeatures = DataFeatures;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(long id)
        {


            var UserData = await _userManager.GetUserAsync(User);
            if (UserData == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

          
            ///
            //upload image

           

            await _userManager.UpdateAsync(UserData);

            //
           
            //StatusMessage = "The Selected Raffle has been updated";
            return RedirectToPage("./Profile");
        }


        #endregion
        //
        #region Experience

        public async Task<IActionResult> OnPostExperienceDelete(long id)
        {
            try
            {
                await _experienceAppService.Delete(Id: id);

            }
            catch (Exception e)
            {

            }
            return RedirectToPage("./UpdateProfile");


        }

        public async Task<IActionResult> OnPostExperience(long id)
        {
            if (ModelState.IsValid)
            {
                var item = new ExperienceModel
                {
                    UserProfileId = userProfileModel.Id,
                    Title = experienceModel.Title,
                    Address = experienceModel.Address,
                    Description = experienceModel.Description,
                    EndDate = experienceModel.EndDate,
                    IsCurrent = experienceModel.IsCurrent,
                    StartDate = experienceModel.StartDate,
                  

                };
                var newId = _experienceAppService.Insert(item);
                            }
            return RedirectToPage("./UpdateProfile", new
            {
                id = id
            });

        }

        #endregion

        #region Education

        public async Task<IActionResult> OnPostEducationDelete(long id)
        {
            try
            {
                await _educationHistoryAppService.Delete(Id: id);

            }
            catch (Exception e)
            {

            }
            return RedirectToPage("./UpdateProfile");
            
        }

        public async Task<IActionResult> OnPostEducation(long id)
        {
            if (ModelState.IsValid)
            {
                var item = new EducationHistoryModel
                {
                    SchoolAttended = EducationModel.SchoolAttended,
                    Course = EducationModel.Course,
                    StartDate = EducationModel.StartDate,
                    EndDate = EducationModel.EndDate,
                    Grade = EducationModel.Grade,
                    IsCurrent = EducationModel.IsCurrent,
                    UserProfileId = userProfileModel.Id


                };
                var newId = _educationHistoryAppService.Insert(item);
            }
            return RedirectToPage("./UpdateProfile", new
            {
                id = id
            });

        }

        #endregion

        #region Skills

        public async Task<IActionResult> OnPostSkillDelete(long id)
        {
            try
            {
                await _skillAppService.Delete(Id: id);

            }
            catch (Exception e)
            {

            }
            return RedirectToPage("./UpdateProfile");

        }

        public async Task<IActionResult> OnPostSkill(long id)
        {
            if (ModelState.IsValid)
            {
                var item = new SkillModel
                {
                    Title = skillModel.Title,
                    UserProfileId = userProfileModel.Id


                };
                var newId = _skillAppService.Insert(item);
            }
            return RedirectToPage("./UpdateProfile", new
            {
                id = id
            });

        }

        #endregion

        #region Language

        public async Task<IActionResult> OnPostLanguageDelete(long id)
        {
            try
            {
                await _languageSpokenAppService.Delete(Id: id);

            }
            catch (Exception e)
            {

            }
            return RedirectToPage("./UpdateProfile");

        }

        public async Task<IActionResult> OnPostLanguage(long id)
        {
            if (ModelState.IsValid)
            {
                var item = new LanguageSpokenModel
                {
                    Title = languageSpokenModel.Title,
                    UserProfileId = userProfileModel.Id


                };
                var newId = _languageSpokenAppService.Insert(item);
            }
            return RedirectToPage("./UpdateProfile", new
            {
                id = id
            });

        }

        #endregion

        #region Certificate

        public async Task<IActionResult> OnPostMeritCertificateDelete(long id)
        {
            try
            {
                await _meritCertificateAppService.Delete(Id: id);

            }
            catch (Exception e)
            {

            }
            return RedirectToPage("./UpdateProfile");

        }

        public async Task<IActionResult> OnPostMeritCertificate(long id)
        {
            if (ModelState.IsValid)
            {
                var item = new MeritCertificateModel
                {
                    Title = meritCertificateModel.Title,
                    StartDate = meritCertificateModel.StartDate,
                    UserProfileId = userProfileModel.Id


                };
                var newId = _meritCertificateAppService.Insert(item);
            }
            return RedirectToPage("./UpdateProfile", new
            {
                id = id
            });

        }

        #endregion

        #region membershipOfLearneredSociety

        public async Task<IActionResult> OnPostMembershipOfLearneredSocietyDelete(long id)
        {
            try
            {
                await _membershipOfLearneredSocietyAppService.Delete(Id: id);

            }
            catch (Exception e)
            {

            }
            return RedirectToPage("./UpdateProfile");

        }

        public async Task<IActionResult> OnPostMembershipOfLearneredSociety(long id)
        {
            if (ModelState.IsValid)
            {
                var item = new MembershipOfLearneredSocietyModel
                {
                    Title = membershipOfLearneredSocietyModel.Title,
                    Abbr = membershipOfLearneredSocietyModel.Abbr,
                    UserProfileId = userProfileModel.Id


                };
                var newId = _membershipOfLearneredSocietyAppService.Insert(item);
            }
            return RedirectToPage("./UpdateProfile", new
            {
                id = id
            });

        }

        #endregion


        #region TrainingAndWorkShop

        public async Task<IActionResult> OnPostTrainingAndWorkShopDelete(long id)
        {
            try
            {
                await _TrainingAndWorkShopAppService.Delete(Id: id);

            }
            catch (Exception e)
            {

            }
            return RedirectToPage("./UpdateProfile");

        }

        public async Task<IActionResult> OnPostTrainingAndWorkShop(long id)
        {
            if (ModelState.IsValid)
            {
                var item = new TrainingAndWorkShopModel
                {
                    Title = trainingAndWorkShopModel.Title,
                    Location = trainingAndWorkShopModel.Location,
                    Date = trainingAndWorkShopModel.Date,
                    UserProfileId = userProfileModel.Id


                };
                var newId = _TrainingAndWorkShopAppService.Insert(item);
            }
            return RedirectToPage("./UpdateProfile", new
            {
                id = id
            });

        }

        #endregion

        #region Profile Update
        ////userprofile
        public async Task<IActionResult> OnPostUserProfile(long id)
        {
            if (ModelState.IsValid)
            {
                #region portfolio Image(s)
                int imgCount = 0;
                if (HttpContext.Request.Form.Files != null && HttpContext.Request.Form.Files.Count > 0)
                {
                    var newFileName = string.Empty;
                    var filePath = string.Empty;
                    string pathdb = string.Empty;
                    var files = HttpContext.Request.Form.Files;
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            filePath = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                            imgCount++;
                            var now = DateTime.Now;
                            var uniqueFileName = $"{now.Year}{now.Month}{now.Day}_{now.Hour}{now.Minute}{now.Second}{now.Millisecond}".Trim();




                            var fileExtension = Path.GetExtension(filePath);

                            newFileName = uniqueFileName + fileExtension;

                            // if you wish to save file path to db use this filepath variable + newFileName
                            var fileDbPathName = $"/Profile/".Trim();

                            filePath = $"{_hostingEnv.WebRootPath}{fileDbPathName}".Trim();

                            if (!(Directory.Exists(filePath)))
                                Directory.CreateDirectory(filePath);

                            var fileName = "";
                            fileName = filePath + $"/{newFileName}".Trim();

                            //Bitmap image = ResizeImage(file.OpenReadStream.file, 400, 800);
                            // copy the file to the desired location from the tempMemoryLocation of IFile and flush temp memory
                            using (FileStream fs = System.IO.File.Create(fileName))
                            {
                                file.CopyTo(fs);
                                fs.Flush();
                            }

                            #region Save Image Propertie to Db


                            PhotoUrlLink = $"{fileDbPathName}/{newFileName}";
                              
                            #endregion

                            if (imgCount >= 20)
                                break;
                        }
                    }
                }
                #endregion

                var item = new UserProfileModel
                {
                    Id = userProfileModel.Id,
                    Title = userProfileModel.Title,
                    SurName = userProfileModel.SurName,
                    FirstName = userProfileModel.FirstName,
                    LastName = userProfileModel.LastName,
                    Description = userProfileModel.Description,
                    ContactAddress = userProfileModel.ContactAddress,
                    Country = userProfileModel.Country,
                    DateOfBirth = userProfileModel.DateOfBirth,
                    DateRegistered = userProfileModel.DateRegistered,
                    UserId = userProfileModel.UserId,
                    FacebookLink = userProfileModel.FacebookLink,
                    TwitterLink = userProfileModel.TwitterLink,
                    LinkedinLink = userProfileModel.LinkedinLink,
                    PhotoUrl = PhotoUrlLink,
                  ComplementryCardKeywords = userProfileModel.ComplementryCardKeywords,
                  Gender = userProfileModel.Gender,
                  MaritalStatus = userProfileModel.MaritalStatus


                };
        var newId = _userProfileAppService.Update(item);
    }
            return RedirectToPage("./UpdateProfile", new { id = id
});

        }


        #endregion


    }
}