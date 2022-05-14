using Exwhyzee.Lojour.Core.LanguageSpoken;
using Exwhyzee.Lojour.Data.Repository.LanguageSpoken;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.LanguageSpoken
{

    public class LanguageSpokenAppService : ILanguageSpokenAppService
    {
        private ILanguageSpokenRepository _languageSpokenRepository;
        public LanguageSpokenAppService(ILanguageSpokenRepository languageSpokenRepository)
        {
            _languageSpokenRepository = languageSpokenRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _languageSpokenRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LanguageSpokenModel> GetById(long Id)
        {
            try
            {
                return await _languageSpokenRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(LanguageSpokenModel entity)
        {

            return await _languageSpokenRepository.Insert(entity);
        }


        public async Task<PagedList<LanguageSpokenModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null)
        {
            List<LanguageSpokenModel> data = new List<LanguageSpokenModel>();
            var paggeddatas = await _languageSpokenRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString, userProfileId);

            var paggedSource = paggeddatas;

            return new PagedList<LanguageSpokenModel>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }

        public async Task Update(LanguageSpokenModel entity)
        {
            try
            {



                await _languageSpokenRepository.Update(entity);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}


