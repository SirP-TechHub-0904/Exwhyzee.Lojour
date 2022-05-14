using Exwhyzee.Lojour.Core.JobAnalysis;
using Exwhyzee.Lojour.Data.Repository.JobAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.JobAnalysis
{

    public class JobAnalysisAppService : IJobAnalysisAppService
    {
        private IJobAnalysisRepository _jobAnalysisRepository;
        public JobAnalysisAppService(IJobAnalysisRepository jobAnalysisRepository)
        {
            _jobAnalysisRepository = jobAnalysisRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _jobAnalysisRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<JobAnalysisModel> GetById(long Id)
        {
            try
            {
                return await _jobAnalysisRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(JobAnalysisModel entity)
        {

            return await _jobAnalysisRepository.Insert(entity);
        }


        public async Task<PagedList<JobAnalysisModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null)
        {
            List<JobAnalysisModel> data = new List<JobAnalysisModel>();
            var paggeddatas = await _jobAnalysisRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString, userProfileId);

            var paggedSource = paggeddatas;

            return new PagedList<JobAnalysisModel>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }

        public async Task Update(JobAnalysisModel entity)
        {
            try
            {



                await _jobAnalysisRepository.Update(entity);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}


