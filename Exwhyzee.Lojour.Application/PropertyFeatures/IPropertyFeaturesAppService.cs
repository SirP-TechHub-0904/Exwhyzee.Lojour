
using Exwhyzee.Lojour.Application.PropertyFeatures.Dto;
using Exwhyzee.Lojour.Core.PropertyFeatures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.PropertyFeatures
{
   public interface IPropertyFeaturesAppService
    {
        Task<long> Insert(PropertyFeature map);
        Task<PropertyFeature> GetById(long Id);

        Task<PagedList<PropertyFeature>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long propertyId = 0);

        Task Delete(long Id);
    }
}
