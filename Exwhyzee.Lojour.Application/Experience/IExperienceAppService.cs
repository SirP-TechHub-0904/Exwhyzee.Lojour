using Exwhyzee.Lojour.Core.Experience;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.Experience
{
   public interface IExperienceAppService
    {
        Task<long> Insert(ExperienceModel map);
        Task<ExperienceModel> GetById(long Id);

        Task<PagedList<ExperienceModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

        Task Delete(long Id);

        Task Update(ExperienceModel entity);

    }
}
