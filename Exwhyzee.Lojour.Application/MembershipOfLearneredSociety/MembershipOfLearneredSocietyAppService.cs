
using Exwhyzee.Lojour.Core.MembershipOfLearneredSociety;
using Exwhyzee.Lojour.Data.Repository.MembershipOfLearneredSociety;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.MembershipOfLearneredSociety
{

    public class MembershipOfLearneredSocietyAppService : IMembershipOfLearneredSocietyAppService
    {
        private IMembershipOfLearneredSocietyRepository _MembershipOfLearneredSocietyRepository;
        public MembershipOfLearneredSocietyAppService(IMembershipOfLearneredSocietyRepository MembershipOfLearneredSocietyRepository)
        {
            _MembershipOfLearneredSocietyRepository = MembershipOfLearneredSocietyRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _MembershipOfLearneredSocietyRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MembershipOfLearneredSocietyModel> GetById(long Id)
        {
            try
            {
                return await _MembershipOfLearneredSocietyRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(MembershipOfLearneredSocietyModel entity)
        {

            return await _MembershipOfLearneredSocietyRepository.Insert(entity);
        }


        public async Task<PagedList<MembershipOfLearneredSocietyModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null)
        {
            List<MembershipOfLearneredSocietyModel> data = new List<MembershipOfLearneredSocietyModel>();
            var paggeddatas = await _MembershipOfLearneredSocietyRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString, userProfileId);

            var paggedSource = paggeddatas;

            return new PagedList<MembershipOfLearneredSocietyModel>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }

        public async Task Update(MembershipOfLearneredSocietyModel entity)
        {
            try
            {



                await _MembershipOfLearneredSocietyRepository.Update(entity);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
