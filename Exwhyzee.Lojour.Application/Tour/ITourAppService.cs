
using Exwhyzee.Lojour.Application.Tour.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.Tour
{
    public interface ITourAppService
    {
        Task<PagedList<TourModelDto>> GetAll(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null);

       
        Task<TourModelDto> Get(long id);

        Task<long> Add(TourModelDto entity);

        Task Delete(long id);

        Task Update(TourModelDto entity);
    }
}
