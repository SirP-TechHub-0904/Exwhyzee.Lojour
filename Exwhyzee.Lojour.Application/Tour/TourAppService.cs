
using Exwhyzee.Lojour.Application.Tour.Dto;
using Exwhyzee.Lojour.Core.Tour;
using Exwhyzee.Lojour.Data.Repository.Tour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.Tour
{
    public class TourAppService: ITourAppService
    {
        private readonly ITourRepository _tourRepository;


        public TourAppService(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }
        
      


        public async Task<long> Add(TourModelDto entity)
        {
            var data = new TourModel
            {

                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                Date = entity.Date,
                Time = entity.Time,
                Payment = entity.Payment,
                FullName = entity.FullName,
                TourId = entity.TourId

            };

            return await _tourRepository.Add(data);
        }

        public async Task Delete(long id)
        {
            await _tourRepository.Delete(id);
        }
       

        public async Task<TourModelDto> Get(long id)
        {
            var entity = await _tourRepository.Get(id);

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

         
            var data = new TourModelDto
            {
                Id = entity.Id,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                Date = entity.Date,
                Time = entity.Time,
                Payment = entity.Payment,
                FullName = entity.FullName,
                TourId = entity.TourId
            };

            
            return data;
        }

        public async Task<PagedList<TourModelDto>> GetAll(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null)
        {
            List<TourModelDto> dataitem = new List<TourModelDto>();
            var paggedData = await _tourRepository.GetAsync(status, dateStart, dateEnd, startIndex, count, searchString);

            var paggedSource = paggedData.Source.ToList();


            dataitem.AddRange(paggedSource.Select(entity => new TourModelDto()
            {
                Id = entity.Id,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                Date = entity.Date,
                Time = entity.Time,
                Payment = entity.Payment,
                FullName = entity.FullName,
                TourId = entity.TourId


            }));

            return new PagedList<TourModelDto>(source: dataitem, pageIndex: paggedData.PageIndex,
                                            pageSize: paggedData.PageSize, filteredCount: paggedData.FilteredCount, totalCount:
                                            paggedData.TotalCount);

        }

     
        public async Task Update(TourModelDto entity)
        {
            try
            {

                var data = new TourModel
                {
                    Id = entity.Id,
                    PhoneNumber = entity.PhoneNumber,
                    Email = entity.Email,
                    Date = entity.Date,
                    Time = entity.Time,
                    Payment = entity.Payment,
                    FullName = entity.FullName,
                    TourId = entity.TourId

                };

                await _tourRepository.Update(data);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
