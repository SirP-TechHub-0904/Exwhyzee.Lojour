using Exwhyzee.Lojour.Core.LgaModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.LGA
{
   public interface ILgaRepository
    {
        Task<long> Insert(Lga map);
        Task<Lga> GetById(long Id);

        Task Delete(long Id);

        Task<PagedList<Lga>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null);

    }
}
