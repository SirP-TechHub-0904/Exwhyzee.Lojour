
using Exwhyzee.Lojour.Core.TrainingAndWorkShop;
using Exwhyzee.Lojour.Data.Repository.TrainingAndWorkShop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.TrainingAndWorkShop
{

    public class TrainingAndWorkShopAppService : ITrainingAndWorkShopAppService
    {
        private ITrainingAndWorkShopRepository _TrainingAndWorkShopRepository;
        public TrainingAndWorkShopAppService(ITrainingAndWorkShopRepository TrainingAndWorkShopRepository)
        {
            _TrainingAndWorkShopRepository = TrainingAndWorkShopRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _TrainingAndWorkShopRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TrainingAndWorkShopModel> GetById(long Id)
        {
            try
            {
                return await _TrainingAndWorkShopRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(TrainingAndWorkShopModel entity)
        {

            return await _TrainingAndWorkShopRepository.Insert(entity);
        }


        public async Task<PagedList<TrainingAndWorkShopModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null)
        {
            List<TrainingAndWorkShopModel> data = new List<TrainingAndWorkShopModel>();
            var paggeddatas = await _TrainingAndWorkShopRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString, userProfileId);

            var paggedSource = paggeddatas;

            return new PagedList<TrainingAndWorkShopModel>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }

        public async Task Update(TrainingAndWorkShopModel entity)
        {
            try
            {



                await _TrainingAndWorkShopRepository.Update(entity);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
