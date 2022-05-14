using Exwhyzee.Lojour.Core.PropertyImage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.PropertyImages
{
    public interface IPropertyImagesRepository
    {
        Task<long> Insert(PropertyImage map);
        Task<PropertyImage> GetById(long Id);

        Task<IEnumerable<PropertyImage>> GetPropertyImages(long propertyId);
        Task Delete(long Id);
        Task Upate(PropertyImage mapping);

        Task<PagedList<PropertyImage>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long propertyId = 0);

    }
}
