using Exwhyzee.Lojour.Core.EstateProperties;
using Exwhyzee.Lojour.Core.RequestProperties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.RequestProperties
{
    public interface IRequestPropertyRepository
    {
        Task<PagedList<RequestProperty>> GetAsync(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null);

        
        Task<RequestProperty> Get(long id);

        Task<long> Add(RequestProperty entity);

        Task Delete(long id);

        Task Update(RequestProperty entity);
    }
}
