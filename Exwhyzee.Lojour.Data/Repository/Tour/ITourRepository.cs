
using Exwhyzee.Lojour.Core.Tour;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.Tour
{
    public interface ITourRepository
    {
        Task<PagedList<TourModel>> GetAsync(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null);

        
        Task<TourModel> Get(long id);

        Task<long> Add(TourModel entity);

        Task Delete(long id);

        Task Update(TourModel entity);
    }
}
