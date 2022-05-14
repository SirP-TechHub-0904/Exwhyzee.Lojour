using Exwhyzee.Lojour.Core.EstateProperties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.EstateProperties
{
    public interface IPropertyRepository
    {
        Task<PagedList<EstateProperty>> GetAsync(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, string username = null, int? descriptiveStatus = null, int? propertyStatus = null);

        Task<PagedList<EstateProperty>> GetAsyncByUserId(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, string username = null);

        Task<PagedList<EstateProperty>> GetAsyncByRatingAndBidding(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null);

        Task<EstateProperty> Get(long id);

        Task<long> Add(EstateProperty entity);

        Task Delete(long id);

        Task Update(EstateProperty entity);
    }
}
