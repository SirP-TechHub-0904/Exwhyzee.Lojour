using Exwhyzee.Lojour.Core.MembershipOfLearneredSociety;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.MembershipOfLearneredSociety
{
   public interface IMembershipOfLearneredSocietyAppService
    {
        Task<long> Insert(MembershipOfLearneredSocietyModel map);
        Task<MembershipOfLearneredSocietyModel> GetById(long Id);

        Task<PagedList<MembershipOfLearneredSocietyModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

        Task Delete(long Id);

        Task Update(MembershipOfLearneredSocietyModel entity);

    }
}
