
using Exwhyzee.Lojour.Core.BarnerImage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.BarnerImages
{
    public interface IBarnerRepository: IDisposable
    {
        Task<long> Insert(BarnerFile map);
        Task<BarnerFile> GetById(long Id);

        Task<PagedList<BarnerFile>> GetAllBarner(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null);
        Task Delete(long Id);
        Task Upate(BarnerFile mapping);

    }
}
