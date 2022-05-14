
using Exwhyzee.Lojour.Core.InterpersonalSkill;
using Exwhyzee.Lojour.Data.Repository.InterpersonalSkill;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.InterpersonalSkill
{
  
   public class InterpersonalSkillAppService : IInterpersonalSkillAppService
    {
        private IInterpersonalSkillRepository _interpersonalSkillRepository;
        public InterpersonalSkillAppService(IInterpersonalSkillRepository interpersonalSkillRepository)
        {
            _interpersonalSkillRepository = interpersonalSkillRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _interpersonalSkillRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<InterpersonalSkillModel> GetById(long Id)
        {
            try
            {
                return await _interpersonalSkillRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(InterpersonalSkillModel entity)
        {
           
            return await _interpersonalSkillRepository.Insert(entity);
        }


        public async Task<PagedList<InterpersonalSkillModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null)
        {
            List<InterpersonalSkillModel> data = new List<InterpersonalSkillModel>();
            var paggeddatas = await _interpersonalSkillRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString, userProfileId);

            var paggedSource = paggeddatas;

            return new PagedList<InterpersonalSkillModel>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }

        public async Task Update(InterpersonalSkillModel entity)
        {
            try
            {

               

                await _interpersonalSkillRepository.Update(entity);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
