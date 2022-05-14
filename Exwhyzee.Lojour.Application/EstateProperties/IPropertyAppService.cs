using Exwhyzee.Lojour.Application.EstateProperties.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.EstateProperties
{
    public interface IPropertyAppService
    {
        Task<PagedList<EstatePropertyDto>> GetAllProperty(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, string username = null, int? descriptiveStatus = null, int? propertyStatus = null);

        Task<PagedList<EstatePropertyDto>> GetAllPropertyByUserId(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, string username = null);

        //Task<PagedList<EstatePropertyDto>> GetAllPropertyByRatingAndBidding(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null);

        Task<EstatePropertyDto> Get(long id);

        Task<long> Add(EstatePropertyDto entity);

        Task Delete(long id);

        Task Update(EstatePropertyDto entity);
    }
}
