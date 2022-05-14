
using Exwhyzee.Lojour.Core.Skill;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.Skill
{
   public interface ISkillRepository
    {
        Task<long> Insert(SkillModel map);
        Task<SkillModel> GetById(long Id);

        Task Delete(long Id);

        Task Update(SkillModel entity);


        Task<PagedList<SkillModel>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

    }
}
