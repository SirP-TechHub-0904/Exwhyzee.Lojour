
using Exwhyzee.Lojour.Core.MembershipOfLearneredSociety;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.MembershipOfLearneredSociety
{
   public interface IMembershipOfLearneredSocietyRepository
    {
        Task<long> Insert(MembershipOfLearneredSocietyModel map);
        Task<MembershipOfLearneredSocietyModel> GetById(long Id);

        Task Delete(long Id);

        Task Update(MembershipOfLearneredSocietyModel entity);


        Task<PagedList<MembershipOfLearneredSocietyModel>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

    }
}
