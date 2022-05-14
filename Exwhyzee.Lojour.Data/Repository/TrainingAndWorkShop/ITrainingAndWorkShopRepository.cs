
using Exwhyzee.Lojour.Core.TrainingAndWorkShop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.TrainingAndWorkShop
{
   public interface ITrainingAndWorkShopRepository
    {
        Task<long> Insert(TrainingAndWorkShopModel map);
        Task<TrainingAndWorkShopModel> GetById(long Id);

        Task Delete(long Id);

        Task Update(TrainingAndWorkShopModel entity);


        Task<PagedList<TrainingAndWorkShopModel>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

    }
}
