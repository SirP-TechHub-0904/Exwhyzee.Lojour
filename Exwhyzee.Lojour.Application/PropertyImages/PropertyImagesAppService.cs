using Exwhyzee.Lojour.Application.PropertyImages.Dto;
using Exwhyzee.Lojour.Core.PropertyImage;
using Exwhyzee.Lojour.Data.Repository.PropertyImages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.PropertyImages
{
    public class PropertyImagesAppService: IPropertyImagesAppService
    {
        private IPropertyImagesRepository _propertyImageRepository;
        public PropertyImagesAppService(IPropertyImagesRepository propertyImageRepository)
        {
            _propertyImageRepository = propertyImageRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _propertyImageRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PropertyImage> GetById(long Id)
        {
            try
            {
                return await _propertyImageRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(PropertyImage image)
        {
            try
            {
                image.ImageExtension = image.ImageExtension.Substring(2);
                return await _propertyImageRepository.Insert(image);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Upate(PropertyImage image)
        {
            try
            {
                await _propertyImageRepository.Upate(image);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PagedList<PropertyImage>> GetAllImages(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long propertyId = 0)
        {
            List<PropertyImage> imageFile = new List<PropertyImage>();
            var paggedimages = await _propertyImageRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString, propertyId);

            var paggedSource = paggedimages;


            //imageFile.AddRange(paggedSource.Select(x => new Raffle()
            //{
            //    DeliveryType = x.DeliveryType,
            //    Description = x.Description,
            //    EndDate = x.EndDate,
            //    HostedBy = x.HostedBy,
            //    Id = x.Id,
            //    Name = x.Name,
            //    NumberOfTickets = x.NumberOfTickets,
            //    PricePerTicket = x.PricePerTicket,
            //    StartDate = x.StartDate,
            //    Status = x.Status,
            //    Username = x.Username,
            //    DateCreated = x.DateCreated,
            //    TotalSold = x.TotalSold,
            //    SortOrder = x.SortOrder,
            //    Archived = x.Archived,
            //    PaidOut = x.PaidOut,
            //    Location = x.Location

            //}));

            return new PagedList<PropertyImage>(source: paggedimages.Source, pageIndex: paggedimages.PageIndex,
                                            pageSize: paggedimages.PageSize, filteredCount: paggedimages.FilteredCount, totalCount:
                                            paggedimages.TotalCount);


        }


    }

}
