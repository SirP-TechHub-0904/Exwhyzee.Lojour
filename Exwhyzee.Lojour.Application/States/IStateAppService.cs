using Exwhyzee.Lojour.Core.State;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.States
{
   public interface IStateAppService
    {
        Task<long> Insert(StateModel map);
        Task<StateModel> GetById(long Id);

        Task<PagedList<StateModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null);

        Task Delete(long Id);
    }
}
