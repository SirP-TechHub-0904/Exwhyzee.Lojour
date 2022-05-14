using Exwhyzee.Lojour.Core.KindredModel;
using Exwhyzee.Lojour.Data.Repository.Kindred;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.KindredApp
{
   public class KindredAppService: IKindredAppService
    {
        private IKindredRepository _kindredRepository;
        public KindredAppService(IKindredRepository kindredRepository)
        {
            _kindredRepository = kindredRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _kindredRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Kindreds> GetById(long Id)
        {
            try
            {
                return await _kindredRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(Kindreds entity)
        {
            var data = new Kindreds
            {

                Name = entity.Name,
                CommunityId = entity.CommunityId

            };

            return await _kindredRepository.Insert(data);
        }


        public async Task<PagedList<Kindreds>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null)
        {
            List<Kindreds> data = new List<Kindreds>();
            var paggeddatas = await _kindredRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString);

            var paggedSource = paggeddatas;

            return new PagedList<Kindreds>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }


    }
}
