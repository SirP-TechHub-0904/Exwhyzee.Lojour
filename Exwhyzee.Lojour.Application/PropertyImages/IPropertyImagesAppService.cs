using Exwhyzee.Lojour.Application.PropertyImages.Dto;
using Exwhyzee.Lojour.Core.PropertyImage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.PropertyImages
{
    public interface IPropertyImagesAppService
    {
        Task<long> Insert(PropertyImage map);
        Task<PropertyImage> GetById(long Id);

        Task<PagedList<PropertyImage>> GetAllImages(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long propertyId = 0);

        Task Delete(long Id);
        Task Upate(PropertyImage mapping);
    }
}
