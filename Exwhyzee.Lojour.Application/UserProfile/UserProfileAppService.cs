
using Exwhyzee.Lojour.Core.UserProfile;
using Exwhyzee.Lojour.Data.Repository.DegreeObtained;
using Exwhyzee.Lojour.Data.Repository.EducationHistory;
using Exwhyzee.Lojour.Data.Repository.Experience;
using Exwhyzee.Lojour.Data.Repository.InterpersonalSkill;
using Exwhyzee.Lojour.Data.Repository.LanguageSpoken;
using Exwhyzee.Lojour.Data.Repository.MembershipOfLearneredSociety;
using Exwhyzee.Lojour.Data.Repository.MeritCertificate;
using Exwhyzee.Lojour.Data.Repository.Skill;
using Exwhyzee.Lojour.Data.Repository.TrainingAndWorkShop;
using Exwhyzee.Lojour.Data.Repository.UserProfile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.UserProfile
{

    public class UserProfileAppService : IUserProfileAppService
    {
        private IUserProfileRepository _userProfileRepository;
        private IExperienceRepository _experienceRepository;
        private IEducationHistoryRepository _educationHistoryRepository;
        private ISkillRepository _skillRepository;
        private IDegreeObtainedRepository _DegreeObtainedRepository;
private IInterpersonalSkillRepository _interpersonalSkillRepository;
        private ILanguageSpokenRepository _languageSpokenRepository;
        private IMembershipOfLearneredSocietyRepository _MembershipOfLearneredSocietyRepository;
        private IMeritCertificateRepository _meritCertificateRepository;
        private ITrainingAndWorkShopRepository _TrainingAndWorkShopRepository;


        public UserProfileAppService(IUserProfileRepository userProfileRepository,
            IExperienceRepository experienceRepository,
            IEducationHistoryRepository educationHistoryRepository,
            ISkillRepository skillRepository,
            IDegreeObtainedRepository DegreeObtainedRepository,
            IInterpersonalSkillRepository interpersonalSkillRepository,
            ILanguageSpokenRepository languageSpokenRepository,
            IMembershipOfLearneredSocietyRepository MembershipOfLearneredSocietyRepository,
            IMeritCertificateRepository meritCertificateRepository,
            ITrainingAndWorkShopRepository TrainingAndWorkShopRepository)
        {
            _userProfileRepository = userProfileRepository;
            _experienceRepository = experienceRepository;
            _educationHistoryRepository = educationHistoryRepository;
            _skillRepository = skillRepository;
 _DegreeObtainedRepository = DegreeObtainedRepository;
 _interpersonalSkillRepository = interpersonalSkillRepository;
            _languageSpokenRepository = languageSpokenRepository;
            _MembershipOfLearneredSocietyRepository = MembershipOfLearneredSocietyRepository;
            _meritCertificateRepository = meritCertificateRepository;
            _TrainingAndWorkShopRepository = TrainingAndWorkShopRepository;

        }

      


        public async Task Delete(long Id)
        {
            try
            {
                await _userProfileRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserProfileModel> GetById(long Id)
        {
            try
            {
                return await _userProfileRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(UserProfileModel entity)
        {
          //  var experince = await _experienceRepository.Insert()

            return await _userProfileRepository.Insert(entity);
        }


        public async Task<PagedList<UserProfileModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null)
        {
            List<UserProfileModel> data = new List<UserProfileModel>();
            var paggeddatas = await _userProfileRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString);

            var paggedSource = paggeddatas;

            return new PagedList<UserProfileModel>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }

        public async Task Update(UserProfileModel entity)
        {
            try
            {



                await _userProfileRepository.Update(entity);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserProfileModel> GetByUserId(string UserId)
        {
            try
            {
                return await _userProfileRepository.GetByUserId(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
