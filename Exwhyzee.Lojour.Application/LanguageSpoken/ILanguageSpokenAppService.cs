using Exwhyzee.Lojour.Core.LanguageSpoken;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.LanguageSpoken
{
   public interface ILanguageSpokenAppService
    {
        Task<long> Insert(LanguageSpokenModel map);
        Task<LanguageSpokenModel> GetById(long Id);

        Task<PagedList<LanguageSpokenModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

        Task Delete(long Id);

        Task Update(LanguageSpokenModel entity);

    }
}
