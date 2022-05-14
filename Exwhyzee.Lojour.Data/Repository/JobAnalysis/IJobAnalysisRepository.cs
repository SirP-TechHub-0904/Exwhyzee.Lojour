
using Exwhyzee.Lojour.Core.JobAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.JobAnalysis
{
   public interface IJobAnalysisRepository
    {
        Task<long> Insert(JobAnalysisModel map);
        Task<JobAnalysisModel> GetById(long Id);

        Task Delete(long Id);

        Task Update(JobAnalysisModel entity);


        Task<PagedList<JobAnalysisModel>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

    }
}
