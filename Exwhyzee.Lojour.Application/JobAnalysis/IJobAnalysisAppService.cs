using Exwhyzee.Lojour.Core.JobAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.JobAnalysis
{
   public interface IJobAnalysisAppService
    {
        Task<long> Insert(JobAnalysisModel map);
        Task<JobAnalysisModel> GetById(long Id);

        Task<PagedList<JobAnalysisModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

        Task Delete(long Id);

        Task Update(JobAnalysisModel entity);

    }
}
