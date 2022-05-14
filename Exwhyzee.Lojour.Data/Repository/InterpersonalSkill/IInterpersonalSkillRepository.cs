
using Exwhyzee.Lojour.Core.InterpersonalSkill;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.InterpersonalSkill
{
   public interface IInterpersonalSkillRepository
    {
        Task<long> Insert(InterpersonalSkillModel map);
        Task<InterpersonalSkillModel> GetById(long Id);

        Task Delete(long Id);

        Task Update(InterpersonalSkillModel entity);


        Task<PagedList<InterpersonalSkillModel>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

    }
}
