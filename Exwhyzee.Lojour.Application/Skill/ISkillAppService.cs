using Exwhyzee.Lojour.Core.Skill;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.Skill
{
   public interface ISkillAppService
    {
        Task<long> Insert(SkillModel map);
        Task<SkillModel> GetById(long Id);

        Task<PagedList<SkillModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

        Task Delete(long Id);

        Task Update(SkillModel entity);

    }
}
