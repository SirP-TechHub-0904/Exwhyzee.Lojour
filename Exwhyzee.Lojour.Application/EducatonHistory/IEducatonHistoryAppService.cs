using Exwhyzee.Lojour.Core.EducationHistory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.EducationHistory
{
   public interface IEducationHistoryAppService
    {
        Task<long> Insert(EducationHistoryModel map);
        Task<EducationHistoryModel> GetById(long Id);

        Task<PagedList<EducationHistoryModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

        Task Delete(long Id);

        Task Update(EducationHistoryModel entity);

    }
}
