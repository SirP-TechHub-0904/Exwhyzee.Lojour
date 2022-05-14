using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.JobAnalysis;
using Exwhyzee.Lojour.Application.LanguageSpoken;
using Exwhyzee.Lojour.Application.States;
using Exwhyzee.Lojour.Application.UserProfile;
using Exwhyzee.Lojour.Application.WorkImage;
using Exwhyzee.Lojour.Core.Authorization.Users;
using Exwhyzee.Lojour.Core.JobAnalysis;
using Exwhyzee.Lojour.Core.LanguageSpoken;
using Exwhyzee.Lojour.Core.State;
using Exwhyzee.Lojour.Core.UserProfile;
using Exwhyzee.Lojour.Core.WorkImage;
using Exwhyzee.Lojour.Website.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Exwhyzee.Lojour.Website.Areas.Account.Pages
{
    public class UpdatePortfolioModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IHostingEnvironment _hostingEnv;
        private readonly IStateAppService _stateAppService;
        private IUserProfileAppService _userProfileAppService;
        private ILanguageSpokenAppService _languageSpokenAppService;
        private IWorkImageAppService _workImageAppService;
        private IJobAnalysisAppService _jobAnalysisAppService;

        #region Data Binding

        public UpdatePortfolioModel(
            UserManager<ApplicationUser> userManager, IHostingEnvironment env,
            SignInManager<ApplicationUser> signInManager, IStateAppService stateAppService,
            ILogger<RegisterModel> logger,
                 RoleManager<ApplicationRole> roleManager,
                 IUserProfileAppService userProfileAppService,
                ILanguageSpokenAppService languageSpokenAppService,
                IWorkImageAppService workImageAppService,
                IJobAnalysisAppService jobAnalysisAppService
               )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _stateAppService = stateAppService;
            _logger = logger;
            _hostingEnv = env;
            _userProfileAppService = userProfileAppService;
            _languageSpokenAppService = languageSpokenAppService;
            _workImageAppService = workImageAppService;
            _jobAnalysisAppService = jobAnalysisAppService;
        }


        #endregion

        #region Model
        [BindProperty]
        public ApplicationUser Data { get; set; }

        [BindProperty]
        public UserProfileModel userProfileModel { get; set; }

        [BindProperty]
        public WorkImageModel workImageModel { get; set; }

        [BindProperty]
        public long workImageModelId { get; set; }

        public List<WorkImageModel> ListWorkImageModel { get; set; }

        [BindProperty]
        public JobAnalysisModel jobAnalysisModel { get; set; }

        [BindProperty]
        public long jobAnalysisModelId { get; set; }

        public List<JobAnalysisModel> ListJobAnalysisModel { get; set; }



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


            //WorkImage
            var image = await _workImageAppService.GetAll(userProfileId: profile.Id);
            ListWorkImageModel = image.Source.ToList();

            //WorkImage
            var JobAnalysis = await _jobAnalysisAppService.GetAll(userProfileId: profile.Id);
            ListJobAnalysisModel = JobAnalysis.Source.ToList();


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
            return RedirectToPage("./UpdatePortfolio");
        }


        #endregion
        //

        #region WorkImage

        public async Task<IActionResult> OnPostWorkImageDelete(long id)
        {
            try
            {
                await _workImageAppService.Delete(Id: id);

            }
            catch (Exception e)
            {

            }
            return RedirectToPage("./UpdatePortfolio");

        }

        public async Task<IActionResult> OnPostWorkImage(long id)
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
                            var fileDbPathName = $"/Portfolio/".Trim();

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
                           
                            var item = new WorkImageModel
                            {
                                Url = $"{fileDbPathName}/{newFileName}",
                                Status = Enums.EntityStatus.Active,
                                UserProfileId = userProfileModel.Id,
                                Title = workImageModel.Title,
                                Address = workImageModel.Address


                            };
                            var newId = _workImageAppService.Insert(item);
                            #endregion

                            if (imgCount >= 20)
                                break;
                        }
                    }
                }
                #endregion
               
            }
            return RedirectToPage("./UpdatePortfolio", new
            {
                id = id
            });

        }

        #endregion

        #region Job Analysis

        public async Task<IActionResult> OnPostJobAnalysisDelete(long id)
        {
            try
            {
                await _jobAnalysisAppService.Delete(Id: id);

            }
            catch (Exception e)
            {

            }
            return RedirectToPage("./UpdatePortfolio");

        }

        public async Task<IActionResult> OnPostJobAnalysis(long id)
        {
            if (ModelState.IsValid)
            {
                var item = new JobAnalysisModel
                {
                    Title = jobAnalysisModel.Title,
                    Count = jobAnalysisModel.Count,
                    UserProfileId = userProfileModel.Id


                };
                var newId = await _jobAnalysisAppService.Insert(item);
            }
            return RedirectToPage("./UpdatePortfolio", new
            {
                id = id
            });

        }

        #endregion




    }
}