using Exwhyzee.Lojour.Core.CommunityModel;
using Exwhyzee.Lojour.Data.Repository.Community;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.Communities
{
   public class CommunityAppService : ICommunityAppService
    {
        private ICommunityRepository _communityRepository;
        public CommunityAppService(ICommunityRepository communityRepository)
        {
            _communityRepository = communityRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _communityRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CommunityData> GetById(long Id)
        {
            try
            {
                return await _communityRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(CommunityData entity)
        {
            var data = new CommunityData
            {

                Name = entity.Name,
                LgaId = entity.LgaId

            };

            return await _communityRepository.Insert(data);
        }


        public async Task<PagedList<CommunityData>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null)
        {
            List<CommunityData> data = new List<CommunityData>();
            var paggeddatas = await _communityRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString);

            var paggedSource = paggeddatas;

            return new PagedList<CommunityData>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }


    }
}
