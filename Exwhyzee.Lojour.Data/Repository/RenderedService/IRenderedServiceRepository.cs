
using Exwhyzee.Lojour.Core.RenderedService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.RenderedService
{
   public interface IRenderedServiceRepository
    {
        Task<long> Insert(RenderedServiceModel map);
        Task<RenderedServiceModel> GetById(long Id);

        Task Delete(long Id);

        Task Update(RenderedServiceModel entity);


        Task<PagedList<RenderedServiceModel>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId =  null);

    }
}
