using Exwhyzee.Lojour.Core.CommunityModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.Communities
{
   public interface ICommunityAppService
    {
        Task<long> Insert(CommunityData map);
        Task<CommunityData> GetById(long Id);

        Task<PagedList<CommunityData>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null);

        Task Delete(long Id);
    }
}
