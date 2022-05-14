using Exwhyzee.Lojour.Core.TrainingAndWorkShop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.TrainingAndWorkShop
{
   public interface ITrainingAndWorkShopAppService
    {
        Task<long> Insert(TrainingAndWorkShopModel map);
        Task<TrainingAndWorkShopModel> GetById(long Id);

        Task<PagedList<TrainingAndWorkShopModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

        Task Delete(long Id);

        Task Update(TrainingAndWorkShopModel entity);

    }
}
