using Exwhyzee.Lojour.Core.RenderedService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.RenderedService
{
   public interface IRenderedServiceAppService
    {
        Task<long> Insert(RenderedServiceModel map);
        Task<RenderedServiceModel> GetById(long Id);

        Task<PagedList<RenderedServiceModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

        Task Delete(long Id);

        Task Update(RenderedServiceModel entity);

    }
}
