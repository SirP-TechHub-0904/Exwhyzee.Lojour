using Exwhyzee.Lojour.Core.State;
using Exwhyzee.Lojour.Data.Repository.State;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.States
{
   public class StateAppService : IStateAppService
    {
        private IStateRepository _stateRepository;
        public StateAppService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _stateRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StateModel> GetById(long Id)
        {
            try
            {
                return await _stateRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         public async Task<long> Insert(StateModel entity)
        {
            var data = new StateModel
            {

                Name = entity.Name

            };

            return await _stateRepository.Insert(data);
        }


        public async Task<PagedList<StateModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null)
        {
            List<StateModel> data = new List<StateModel>();
            var paggeddatas = await _stateRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString);

            var paggedSource = paggeddatas;
            
            return new PagedList<StateModel>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }


    }
}
