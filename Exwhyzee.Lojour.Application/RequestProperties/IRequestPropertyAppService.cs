using Exwhyzee.Lojour.Application.EstateProperties.Dto;
using Exwhyzee.Lojour.Application.RequestProperties.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.RequestProperties
{
    public interface IRequestPropertyAppService
    {
        Task<PagedList<RequestPropertyDto>> GetAll(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null);

       
        Task<RequestPropertyDto> Get(long id);

        Task<long> Add(RequestPropertyDto entity);

        Task Delete(long id);

        Task Update(RequestPropertyDto entity);
    }
}
