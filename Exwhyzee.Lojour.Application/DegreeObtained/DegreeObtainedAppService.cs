
using Exwhyzee.Lojour.Core.DegreeObtained;
using Exwhyzee.Lojour.Data.Repository.DegreeObtained;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.DegreeObtained
{

    public class DegreeObtainedAppService : IDegreeObtainedAppService
    {
        private IDegreeObtainedRepository _DegreeObtainedRepository;
        public DegreeObtainedAppService(IDegreeObtainedRepository DegreeObtainedRepository)
        {
            _DegreeObtainedRepository = DegreeObtainedRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _DegreeObtainedRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DegreeObtainedModel> GetById(long Id)
        {
            try
            {
                return await _DegreeObtainedRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(DegreeObtainedModel entity)
        {

            return await _DegreeObtainedRepository.Insert(entity);
        }


        public async Task<PagedList<DegreeObtainedModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null)
        {
            List<DegreeObtainedModel> data = new List<DegreeObtainedModel>();
            var paggeddatas = await _DegreeObtainedRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString, userProfileId);

            var paggedSource = paggeddatas;

            return new PagedList<DegreeObtainedModel>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }

        public async Task Update(DegreeObtainedModel entity)
        {
            try
            {



                await _DegreeObtainedRepository.Update(entity);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
