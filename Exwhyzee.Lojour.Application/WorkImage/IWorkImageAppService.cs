using Exwhyzee.Lojour.Core.WorkImage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.WorkImage
{
   public interface IWorkImageAppService
    {
        Task<long> Insert(WorkImageModel map);
        Task<WorkImageModel> GetById(long Id);

        Task<PagedList<WorkImageModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

        Task Delete(long Id);

        Task Update(WorkImageModel entity);

    }
}
