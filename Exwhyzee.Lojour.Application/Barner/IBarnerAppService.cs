
using Exwhyzee.Lojour.Core.BarnerImage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.Barner
{
    public interface IBarnerAppService
    {
        Task<long> Insert(BarnerFile map);
       
        Task<PagedList<BarnerFile>> GetBarnerFile(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null);

        Task Delete(long Id);

      

    }
}
