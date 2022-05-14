
using Exwhyzee.Lojour.Core.DegreeObtained;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.DegreeObtained
{
   public interface IDegreeObtainedRepository
    {
        Task<long> Insert(DegreeObtainedModel map);
        Task<DegreeObtainedModel> GetById(long Id);

        Task Delete(long Id);

        Task Update(DegreeObtainedModel entity);


        Task<PagedList<DegreeObtainedModel>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

    }
}
