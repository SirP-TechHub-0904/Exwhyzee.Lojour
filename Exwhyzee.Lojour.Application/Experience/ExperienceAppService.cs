
using Exwhyzee.Lojour.Core.Experience;
using Exwhyzee.Lojour.Data.Repository.Experience;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.Experience
{
  
   public class ExperienceAppService : IExperienceAppService
    {
        private IExperienceRepository _experienceRepository;
        public ExperienceAppService(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _experienceRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ExperienceModel> GetById(long Id)
        {
            try
            {
                return await _experienceRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(ExperienceModel entity)
        {
           
            return await _experienceRepository.Insert(entity);
        }


        public async Task<PagedList<ExperienceModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null)
        {
            List<ExperienceModel> data = new List<ExperienceModel>();
            var paggeddatas = await _experienceRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString, userProfileId);

            var paggedSource = paggeddatas;

            return new PagedList<ExperienceModel>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }

        public async Task Update(ExperienceModel entity)
        {
            try
            {

               

                await _experienceRepository.Update(entity);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
