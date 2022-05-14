
using Exwhyzee.Lojour.Core.Skill;
using Exwhyzee.Lojour.Data.Repository.Skill;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.Skill
{

    public class SkillAppService : ISkillAppService
    {
        private ISkillRepository _skillRepository;
        public SkillAppService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _skillRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SkillModel> GetById(long Id)
        {
            try
            {
                return await _skillRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(SkillModel entity)
        {

            return await _skillRepository.Insert(entity);
        }


        public async Task<PagedList<SkillModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null)
        {
            List<SkillModel> data = new List<SkillModel>();
            var paggeddatas = await _skillRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString, userProfileId);

            var paggedSource = paggeddatas;

            return new PagedList<SkillModel>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }

        public async Task Update(SkillModel entity)
        {
            try
            {



                await _skillRepository.Update(entity);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
