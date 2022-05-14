using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.DegreeObtained;
using Exwhyzee.Lojour.Application.EducationHistory;
using Exwhyzee.Lojour.Application.Experience;
using Exwhyzee.Lojour.Application.InterpersonalSkill;
using Exwhyzee.Lojour.Application.JobAnalysis;
using Exwhyzee.Lojour.Application.LanguageSpoken;
using Exwhyzee.Lojour.Application.MembershipOfLearneredSociety;
using Exwhyzee.Lojour.Application.MeritCertificate;
using Exwhyzee.Lojour.Application.Skill;
using Exwhyzee.Lojour.Application.States;
using Exwhyzee.Lojour.Application.TrainingAndWorkShop;
using Exwhyzee.Lojour.Application.UserProfile;
using Exwhyzee.Lojour.Application.WorkImage;
using Exwhyzee.Lojour.Core.Authorization.Users;
using Exwhyzee.Lojour.Core.EducationHistory;
using Exwhyzee.Lojour.Core.Experience;
using Exwhyzee.Lojour.Core.InterpersonalSkill;
using Exwhyzee.Lojour.Core.JobAnalysis;
using Exwhyzee.Lojour.Core.LanguageSpoken;
using Exwhyzee.Lojour.Core.MembershipOfLearneredSociety;
using Exwhyzee.Lojour.Core.MeritCertificate;
using Exwhyzee.Lojour.Core.Skill;
using Exwhyzee.Lojour.Core.State;
using Exwhyzee.Lojour.Core.TrainingAndWorkShop;
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
   
    public class MyCVModel : PageModel
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
        private IWorkImageAppService _workImageAppService;
        private IJobAnalysisAppService _jobAnalysisAppService;

        #region Data Binding

        public MyCVModel(
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
                ITrainingAndWorkShopAppService TrainingAndWorkShopAppService,
                 IWorkImageAppService workImageAppService,
                IJobAnalysisAppService jobAnalysisAppService)
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
        public ExperienceModel experienceModel { get; set; }

        [BindProperty]
        public long experienceModelId { get; set; }
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

        public List<StateModel> State { get; set; }

        #endregion

        #region OnGet 
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


            //WorkImage
            var image = await _workImageAppService.GetAll(userProfileId: profile.Id);
            ListWorkImageModel = image.Source.ToList();

            //WorkImage
            var JobAnalysis = await _jobAnalysisAppService.GetAll(userProfileId: profile.Id);
            ListJobAnalysisModel = JobAnalysis.Source.ToList();


            //
            //var DataExperienceModel = await _experienceAppService.GetAll(u: id);
            //ListFeatures = DataFeatures;
            return Page();
        }


        #endregion




    }

}
