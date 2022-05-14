
using Exwhyzee.Lojour.Core.BarnerImage;
using Exwhyzee.Lojour.Data.Repository.BarnerImages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.Barner
{
    public class BarnerAppService : IBarnerAppService
    {
        private IBarnerRepository _barnerRepository;
        public BarnerAppService(IBarnerRepository barnerRepository)
        {
            _barnerRepository = barnerRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
               await _barnerRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
        public async Task<PagedList<BarnerFile>> GetBarnerFile(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null)
        {
            List<BarnerFile> raffles = new List<BarnerFile>();
            var paggedBarner = await _barnerRepository.GetAllBarner(dateStart, dateEnd, startIndex, count, searchString);
            var paggedSource = paggedBarner.Source;

            
            return new PagedList<BarnerFile>(source: paggedSource, pageIndex: paggedBarner.PageIndex,
                                            pageSize: paggedBarner.PageSize, filteredCount: paggedBarner.FilteredCount, totalCount:
                                            paggedBarner.TotalCount);
        }

      
        public Task<BarnerFile> GetById(long Id)
        {
            throw new NotImplementedException();
        }

     

        public async Task<long> Insert(BarnerFile image)
        {
            try
            {
                image.Extension = image.Extension.Substring(2);
                return await _barnerRepository.Insert(image);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
