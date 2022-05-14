using Exwhyzee.Lojour.Core.LgaModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.LGAs
{
   public interface ILGAsAppService
    {
        Task<long> Insert(Lga map);
        Task<Lga> GetById(long Id);

        Task<PagedList<Lga>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null);

        Task Delete(long Id);

    }
}
