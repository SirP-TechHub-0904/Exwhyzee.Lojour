
using Exwhyzee.Lojour.Core.WorkHistory;
using Exwhyzee.Lojour.Data.Repository.WorkHistory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.WorkHistory
{

    public class WorkHistoryAppService : IWorkHistoryAppService
    {
        private IWorkHistoryRepository _workHistoryRepository;
        public WorkHistoryAppService(IWorkHistoryRepository workHistoryRepository)
        {
            _workHistoryRepository = workHistoryRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _workHistoryRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<WorkHistoryModel> GetById(long Id)
        {
            try
            {
                return await _workHistoryRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(WorkHistoryModel entity)
        {

            return await _workHistoryRepository.Insert(entity);
        }


        public async Task<PagedList<WorkHistoryModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null)
        {
            List<WorkHistoryModel> data = new List<WorkHistoryModel>();
            var paggeddatas = await _workHistoryRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString, userProfileId);

            var paggedSource = paggeddatas;

            return new PagedList<WorkHistoryModel>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }

        public async Task Update(WorkHistoryModel entity)
        {
            try
            {



                await _workHistoryRepository.Update(entity);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
