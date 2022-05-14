using Exwhyzee.Lojour.Core.State;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.State
{
   public interface IStateRepository
    {
        Task<long> Insert(StateModel map);
        Task<StateModel> GetById(long Id);
        Task Delete(long Id);
        Task<PagedList<StateModel>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null);

    }
}
