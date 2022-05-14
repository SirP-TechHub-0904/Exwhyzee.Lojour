using Exwhyzee.Lojour.Core.DegreeObtained;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.DegreeObtained
{
   public interface IDegreeObtainedAppService
    {
        Task<long> Insert(DegreeObtainedModel map);
        Task<DegreeObtainedModel> GetById(long Id);

        Task<PagedList<DegreeObtainedModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

        Task Delete(long Id);

        Task Update(DegreeObtainedModel entity);

    }
}
