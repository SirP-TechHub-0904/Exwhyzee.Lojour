using Exwhyzee.Lojour.Core.PropertyLandMarks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.PropertyLandMark
{
   public interface IPropertyLandMarksRepository
    {
        Task<long> Insert(PropertyLandMarks map);
        Task<PropertyLandMarks> GetById(long Id);
        Task Delete(long Id);
        Task<PagedList<PropertyLandMarks>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long propertyId = 0);

    }
}
