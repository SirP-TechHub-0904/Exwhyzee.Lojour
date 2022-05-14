using Exwhyzee.Lojour.Core.KindredModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.Kindred
{
   public interface IKindredRepository
    {
        Task<long> Insert(Kindreds map);
        Task<Kindreds> GetById(long Id);
        Task Delete(long Id);

        Task<PagedList<Kindreds>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null);

    }
}
