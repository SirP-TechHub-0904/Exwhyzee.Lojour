using Exwhyzee.Lojour.Core.KindredModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.KindredApp
{
   public interface IKindredAppService
    {
        Task<long> Insert(Kindreds map);
        Task<Kindreds> GetById(long Id);

        Task<PagedList<Kindreds>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null);

        Task Delete(long Id);
    }
}
