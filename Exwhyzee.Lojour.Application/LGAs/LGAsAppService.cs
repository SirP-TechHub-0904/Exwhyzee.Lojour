using Exwhyzee.Lojour.Core.LgaModel;
using Exwhyzee.Lojour.Data.Repository.LGA;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.LGAs
{
  
   public class LGAsAppService : ILGAsAppService
    {
        private ILgaRepository _lgaRepository;
        public LGAsAppService(ILgaRepository lgaRepository)
        {
            _lgaRepository = lgaRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _lgaRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Lga> GetById(long Id)
        {
            try
            {
                return await _lgaRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(Lga entity)
        {
            var data = new Lga
            {

                Name = entity.Name,
                StateId = entity.StateId
                
            };

            return await _lgaRepository.Insert(data);
        }


        public async Task<PagedList<Lga>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null)
        {
            List<Lga> data = new List<Lga>();
            var paggeddatas = await _lgaRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString);

            var paggedSource = paggeddatas;

            return new PagedList<Lga>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }


    }
}
