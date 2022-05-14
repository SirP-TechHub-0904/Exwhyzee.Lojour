
using Exwhyzee.Lojour.Core.EducationHistory;
using Exwhyzee.Lojour.Data.Repository.EducationHistory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.EducationHistory
{
  
   public class EducationHistoryAppService : IEducationHistoryAppService
    {
        private IEducationHistoryRepository _educationHistoryRepository;
        public EducationHistoryAppService(IEducationHistoryRepository educationHistoryRepository)
        {
            _educationHistoryRepository = educationHistoryRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _educationHistoryRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EducationHistoryModel> GetById(long Id)
        {
            try
            {
                return await _educationHistoryRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(EducationHistoryModel entity)
        {
            var data = new EducationHistoryModel
            {

                SchoolAttended = entity.SchoolAttended,
                Course = entity.Course,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Grade = entity.Grade,
                IsCurrent = entity.IsCurrent,
                UserProfileId = entity.UserProfileId

            };

            return await _educationHistoryRepository.Insert(data);
        }


        public async Task<PagedList<EducationHistoryModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null)
        {
            List<EducationHistoryModel> data = new List<EducationHistoryModel>();
            var paggeddatas = await _educationHistoryRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString, userProfileId);

            var paggedSource = paggeddatas;

            return new PagedList<EducationHistoryModel>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }

        public async Task Update(EducationHistoryModel entity)
        {
            try
            {

                var data = new EducationHistoryModel
                {
                    Id = entity.Id,
                    SchoolAttended = entity.SchoolAttended,
                    Course = entity.Course,
                    StartDate = entity.StartDate,
                    EndDate = entity.EndDate,
                    Grade = entity.Grade,
                    IsCurrent = entity.IsCurrent,
                    UserProfileId = entity.UserProfileId

                };

                await _educationHistoryRepository.Update(data);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
