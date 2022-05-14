using Exwhyzee.Lojour.Core.PropertyFeatures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.PropertyFeatures
{
   public interface IPropertyFeaturesRepository
    {
        Task<long> Insert(PropertyFeature map);
        Task<PropertyFeature> GetById(long Id);
        Task Delete(long Id);
        Task<PagedList<PropertyFeature>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long propertyId = 0);

    }
}
