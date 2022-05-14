using Exwhyzee.Lojour.Core.WorkHistory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.WorkHistory
{
   public interface IWorkHistoryAppService
    {
        Task<long> Insert(WorkHistoryModel map);
        Task<WorkHistoryModel> GetById(long Id);

        Task<PagedList<WorkHistoryModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

        Task Delete(long Id);

        Task Update(WorkHistoryModel entity);

    }
}
