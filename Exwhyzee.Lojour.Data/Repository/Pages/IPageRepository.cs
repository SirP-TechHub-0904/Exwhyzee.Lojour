using Exwhyzee.Lojour.Core.Page;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.Pages
{
   public interface IPageRepository
    {
        Task<long> Insert(PageData map);
        Task<PageData> GetById(long Id);
        Task Delete(long Id);
        Task<PagedList<PageData>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null);
        Task Update(PageData entity);

    }
}
