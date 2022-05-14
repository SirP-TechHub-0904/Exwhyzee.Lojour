using Exwhyzee.Lojour.Core.CommunityModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.Community
{
   public interface ICommunityRepository
    {
        Task<long> Insert(CommunityData map);
        Task<CommunityData> GetById(long Id);
        Task Delete(long Id);
        Task<PagedList<CommunityData>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null);

    }
}
