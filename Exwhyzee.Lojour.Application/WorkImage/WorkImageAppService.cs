
using Exwhyzee.Lojour.Core.WorkImage;
using Exwhyzee.Lojour.Data.Repository.WorkImage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.WorkImage
{

    public class WorkImageAppService : IWorkImageAppService
    {
        private IWorkImageRepository _workImageRepository;
        public WorkImageAppService(IWorkImageRepository workImageRepository)
        {
            _workImageRepository = workImageRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _workImageRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<WorkImageModel> GetById(long Id)
        {
            try
            {
                return await _workImageRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(WorkImageModel entity)
        {

            return await _workImageRepository.Insert(entity);
        }


        public async Task<PagedList<WorkImageModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null)
        {
            List<WorkImageModel> data = new List<WorkImageModel>();
            var paggeddatas = await _workImageRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString, userProfileId);

            var paggedSource = paggeddatas;

            return new PagedList<WorkImageModel>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }

        public async Task Update(WorkImageModel entity)
        {
            try
            {



                await _workImageRepository.Update(entity);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
