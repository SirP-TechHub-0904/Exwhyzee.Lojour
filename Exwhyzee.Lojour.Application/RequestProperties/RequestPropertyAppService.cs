using Exwhyzee.Lojour.Application.RequestProperties.Dto;
using Exwhyzee.Lojour.Core.RequestProperties;
using Exwhyzee.Lojour.Data.Repository.RequestProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.RequestProperties
{
    public class RequestPropertyAppService: IRequestPropertyAppService
    {
        private readonly IRequestPropertyRepository _requestPropertyRepository;


        public RequestPropertyAppService(IRequestPropertyRepository requestPropertyRepository)
        {
            _requestPropertyRepository = requestPropertyRepository;
        }
        
      


        public async Task<long> Add(RequestPropertyDto entity)
        {
            var data = new RequestProperty
            {

                PropertyName = entity.PropertyName,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                ListType = entity.ListType,
                Category = entity.Category,
                Location = entity.Location,
                LandMark = entity.LandMark,
                Features = entity.Features,
                AmountRange = entity.AmountRange,
                AlertType = entity.AlertType,
                AlertDuration = entity.AlertDuration,
                DateCreated = entity.DateCreated
               
            };

            return await _requestPropertyRepository.Add(data);
        }

        public async Task Delete(long id)
        {
            await _requestPropertyRepository.Delete(id);
        }
       

        public async Task<RequestPropertyDto> Get(long id)
        {
            var entity = await _requestPropertyRepository.Get(id);

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

         
            var data = new RequestPropertyDto
            {
                Id = entity.Id,
                PropertyName = entity.PropertyName,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                ListType = entity.ListType,
                Category = entity.Category,
                Location = entity.Location,
                LandMark = entity.LandMark,
                Features = entity.Features,
                AmountRange = entity.AmountRange,
                AlertType = entity.AlertType,
                AlertDuration = entity.AlertDuration,
                DateCreated = entity.DateCreated,
                RequestId = entity.RequestId

            };

            
            return data;
        }

        public async Task<PagedList<RequestPropertyDto>> GetAll(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null)
        {
            List<RequestPropertyDto> dataitem = new List<RequestPropertyDto>();
            var paggedData = await _requestPropertyRepository.GetAsync(status, dateStart, dateEnd, startIndex, count, searchString);

            var paggedSource = paggedData.Source.ToList();


            dataitem.AddRange(paggedSource.Select(entity => new RequestPropertyDto()
            {
                Id = entity.Id,
                PropertyName = entity.PropertyName,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                ListType = entity.ListType,
                Category = entity.Category,
                Location = entity.Location,
                LandMark = entity.LandMark,
                Features = entity.Features,
                AmountRange = entity.AmountRange,
                AlertType = entity.AlertType,
                AlertDuration = entity.AlertDuration,
                DateCreated = entity.DateCreated


            }));

            return new PagedList<RequestPropertyDto>(source: dataitem, pageIndex: paggedData.PageIndex,
                                            pageSize: paggedData.PageSize, filteredCount: paggedData.FilteredCount, totalCount:
                                            paggedData.TotalCount);

        }

     
        public async Task Update(RequestPropertyDto entity)
        {
            try
            {

                var data = new RequestProperty
                {
                    Id = entity.Id,
                    PropertyName = entity.PropertyName,
                    PhoneNumber = entity.PhoneNumber,
                    Email = entity.Email,
                    ListType = entity.ListType,
                    Category = entity.Category,
                    Location = entity.Location,
                    LandMark = entity.LandMark,
                    Features = entity.Features,
                    AmountRange = entity.AmountRange,
                    AlertType = entity.AlertType,
                    AlertDuration = entity.AlertDuration,
                    DateCreated = entity.DateCreated


                };

                await _requestPropertyRepository.Update(data);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
