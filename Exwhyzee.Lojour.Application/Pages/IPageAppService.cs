using Exwhyzee.Lojour.Application.Pages.Dto;
using Exwhyzee.Lojour.Core.Page;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.Pages
{
    public interface IPageAppService
    {
        Task<PagedList<PageData>> GetAllPages(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null);


        Task<PageDataDto> Get(long id);

        Task<long> Add(PageData entity);

        Task Delete(long id);

        Task Update(PageDataDto entity);
    }
}
