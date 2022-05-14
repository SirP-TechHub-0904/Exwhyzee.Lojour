using Exwhyzee.Lojour.Core.Referee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.Referee
{
   public interface IRefereeAppService
    {
        Task<long> Insert(RefereeModel map);
        Task<RefereeModel> GetById(long Id);

        Task<PagedList<RefereeModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

        Task Delete(long Id);

        Task Update(RefereeModel entity);

    }
}
