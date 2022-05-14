
using Exwhyzee.Lojour.Core.Referee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.Referee
{
   public interface IRefereeRepository
    {
        Task<long> Insert(RefereeModel map);
        Task<RefereeModel> GetById(long Id);

        Task Delete(long Id);

        Task Update(RefereeModel entity);


        Task<PagedList<RefereeModel>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

    }
}
