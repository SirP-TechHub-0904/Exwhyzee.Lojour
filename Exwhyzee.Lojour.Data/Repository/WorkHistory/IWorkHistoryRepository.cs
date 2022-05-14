
using Exwhyzee.Lojour.Core.WorkHistory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.WorkHistory
{
   public interface IWorkHistoryRepository
    {
        Task<long> Insert(WorkHistoryModel map);
        Task<WorkHistoryModel> GetById(long Id);

        Task Delete(long Id);

        Task Update(WorkHistoryModel entity);

        Task<PagedList<WorkHistoryModel>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

    }
}
