
using Exwhyzee.Lojour.Core.Referee;
using Exwhyzee.Lojour.Data.Repository.Referee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.Referee
{

    public class RefereeAppService : IRefereeAppService
    {
        private IRefereeRepository _RefereeRepository;
        public RefereeAppService(IRefereeRepository RefereeRepository)
        {
            _RefereeRepository = RefereeRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _RefereeRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RefereeModel> GetById(long Id)
        {
            try
            {
                return await _RefereeRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(RefereeModel entity)
        {

            return await _RefereeRepository.Insert(entity);
        }


        public async Task<PagedList<RefereeModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null)
        {
            List<RefereeModel> data = new List<RefereeModel>();
            var paggeddatas = await _RefereeRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString, userProfileId);

            var paggedSource = paggeddatas;

            return new PagedList<RefereeModel>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }

        public async Task Update(RefereeModel entity)
        {
            try
            {



                await _RefereeRepository.Update(entity);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
