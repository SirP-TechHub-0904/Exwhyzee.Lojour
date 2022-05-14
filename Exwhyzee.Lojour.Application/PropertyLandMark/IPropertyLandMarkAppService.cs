
using Exwhyzee.Lojour.Application.PropertyLandMark.Dto;
using Exwhyzee.Lojour.Core.PropertyFeatures;
using Exwhyzee.Lojour.Core.PropertyLandMarks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.PropertyLandMark
{
   public interface IPropertyLandMarkAppService
    {
        Task<long> Insert(PropertyLandMarks map);
        Task<PropertyLandMarks> GetById(long Id);

        Task<PagedList<PropertyLandMarks>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long propertyId = 0);

        Task Delete(long Id);
    }
}
