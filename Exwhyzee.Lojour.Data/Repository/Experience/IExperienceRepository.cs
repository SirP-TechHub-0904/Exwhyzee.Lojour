
using Exwhyzee.Lojour.Core.Experience;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.Experience
{
   public interface IExperienceRepository
    {
        Task<long> Insert(ExperienceModel map);
        Task<ExperienceModel> GetById(long Id);

        Task Delete(long Id);

        Task Update(ExperienceModel entity);


        Task<PagedList<ExperienceModel>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

    }
}
