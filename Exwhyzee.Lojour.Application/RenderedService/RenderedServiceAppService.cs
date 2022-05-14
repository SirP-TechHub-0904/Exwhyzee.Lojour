
using Exwhyzee.Lojour.Core.RenderedService;
using Exwhyzee.Lojour.Data.Repository.RenderedService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.RenderedService
{

    public class RenderedServiceAppService : IRenderedServiceAppService
    {
        private IRenderedServiceRepository _renderedServiceRepository;
        public RenderedServiceAppService(IRenderedServiceRepository renderedServiceRepository)
        {
            _renderedServiceRepository = renderedServiceRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _renderedServiceRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RenderedServiceModel> GetById(long Id)
        {
            try
            {
                return await _renderedServiceRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(RenderedServiceModel entity)
        {

            return await _renderedServiceRepository.Insert(entity);
        }


        public async Task<PagedList<RenderedServiceModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null)
        {
            List<RenderedServiceModel> data = new List<RenderedServiceModel>();
            var paggeddatas = await _renderedServiceRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString, userProfileId);

            var paggedSource = paggeddatas;

            return new PagedList<RenderedServiceModel>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }

        public async Task Update(RenderedServiceModel entity)
        {
            try
            {



                await _renderedServiceRepository.Update(entity);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
