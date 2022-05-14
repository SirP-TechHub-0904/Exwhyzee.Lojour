using Exwhyzee.Lojour.Application.EstateProperties.Dto;
using Exwhyzee.Lojour.Core.EstateProperties;
using Exwhyzee.Lojour.Core.PropertyFeatures;
using Exwhyzee.Lojour.Core.PropertyLandMarks;
using Exwhyzee.Lojour.Data.Repository.EstateProperties;
using Exwhyzee.Lojour.Data.Repository.PropertyFeatures;
using Exwhyzee.Lojour.Data.Repository.PropertyImages;
using Exwhyzee.Lojour.Data.Repository.PropertyLandMark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.EstateProperties
{
    public class PropertyAppService : IPropertyAppService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IPropertyFeaturesRepository _propertyFeaturesRepository;
        private readonly IPropertyLandMarksRepository _propertyLandMarksRepository;
        private IPropertyImagesRepository _propertyImageRepository;

        public PropertyAppService(IPropertyRepository propertyRepository, IPropertyFeaturesRepository propertyFeaturesRepository,

            IPropertyLandMarksRepository propertyLandMarksRepository, IPropertyImagesRepository propertyImageRepository)
        {
            _propertyRepository = propertyRepository;
            _propertyFeaturesRepository = propertyFeaturesRepository;
            _propertyLandMarksRepository = propertyLandMarksRepository;
            _propertyImageRepository = propertyImageRepository;
        }




        public async Task<long> Add(EstatePropertyDto entity)
        {
            var data = new EstateProperty
            {

                PropertyName = entity.PropertyName,
                Description = entity.Description,
                AgentDetails = entity.AgentDetails,
                Longitude = entity.Longitude,
                Latitude = entity.Latitude,
                Amount = entity.Amount,
                PropertyProfile = entity.PropertyProfile,
                PropertyType = entity.PropertyType,
                PropertyStatus = entity.PropertyStatus,
                VerificationStatus = entity.VerificationStatus,
                DescriptiveStatus = entity.DescriptiveStatus,
                PropertyAddress = entity.PropertyAddress,
                DateCreated = entity.DateCreated,
                IdentificationNumber = entity.IdentificationNumber,
                State = entity.State,
                LGA = entity.LGA,
                Community = entity.Community,
                Kindred = entity.Kindred,
                SortOrder = entity.SortOrder,
                HomeLocation = entity.HomeLocation,
                Username = entity.Username,
                Video = entity.Video,
                MapLink = entity.MapLink

            };

            return await _propertyRepository.Add(data);
        }

        public async Task Delete(long id)
        {
            await _propertyRepository.Delete(id);
        }
        public PagedList<PropertyFeature> ListFeatures { get; set; }


        public PagedList<PropertyLandMarks> ListLandMarks { get; set; }


        public async Task<EstatePropertyDto> Get(long id)
        {
            var entity = await _propertyRepository.Get(id);

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var DataFeatures = await _propertyFeaturesRepository.GetAsyncAll(propertyId: id);
            ListFeatures = DataFeatures;

            //

            var DataLandMark = await _propertyLandMarksRepository.GetAsyncAll(propertyId: id);
            ListLandMarks = DataLandMark;

            ///

            var images = await _propertyImageRepository.GetAsyncAll(propertyId: id);

            var data = new EstatePropertyDto
            {
                Id = entity.Id,
                PropertyName = entity.PropertyName,
                Amount = entity.Amount,
                PropertyStatus = entity.PropertyStatus,
                DescriptiveStatus = entity.DescriptiveStatus,
                FullName = entity.FullName,
                PropertyAddress = entity.PropertyAddress,
                VerificationStatus = entity.VerificationStatus,
                Username = entity.Username,
                IdentificationNumber = entity.IdentificationNumber,
                RateOne = entity.RateOne,
                RateTwo = entity.RateTwo,
                RateThree = entity.RateThree,
                RateFour = entity.RateFour,
                RateFive = entity.RateFive,
                SortOrder = entity.SortOrder,
                Description = entity.Description,
                AgentDetails = entity.AgentDetails,
                Longitude = entity.Longitude,
                Latitude = entity.Latitude,
                PropertyProfile = entity.PropertyProfile,
                PropertyType = entity.PropertyType,
                DateCreated = entity.DateCreated,
                State = entity.State,
                LGA = entity.LGA,
                Community = entity.Community,
                Video = entity.Video,
                Kindred = entity.Kindred,
                PropertyLevel = entity.PropertyLevel,
                MapLink = entity.MapLink,
                HomeLocation = entity.HomeLocation,
                Position = entity.Position,
                PropertyLandMarksList = ListLandMarks.Source.ToList(),
                PropertyFeaturesList = ListFeatures.Source.ToList(),
                PropertyImagesList = images.Source.ToList(),


            };


            return data;
        }

        public async Task<PagedList<EstatePropertyDto>> GetAllProperty(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, string username = null, int? descriptiveStatus = null, int? propertyStatus = null)
        {
            List<EstatePropertyDto> dataitem = new List<EstatePropertyDto>();
            var paggedData = await _propertyRepository.GetAsync(status, dateStart, dateEnd, startIndex, count, searchString, username, descriptiveStatus, propertyStatus);

            var paggedSource = paggedData.Source.ToList();


            dataitem.AddRange(paggedSource.Select(entity => new EstatePropertyDto()
            {
                PropertyName = entity.PropertyName,
                Description = entity.Description,
                AgentDetails = entity.AgentDetails,
                Longitude = entity.Longitude,
                Latitude = entity.Latitude,
                Amount = entity.Amount,
                PropertyProfile = entity.PropertyProfile,
                PropertyType = entity.PropertyType,
                PropertyStatus = entity.PropertyStatus,
                VerificationStatus = entity.VerificationStatus,
                DescriptiveStatus = entity.DescriptiveStatus,
                PropertyAddress = entity.PropertyAddress,
                DateCreated = entity.DateCreated,
                IdentificationNumber = entity.IdentificationNumber,
                State = entity.State,
                LGA = entity.LGA,
                Community = entity.Community,
                Kindred = entity.Kindred,
                SortOrder = entity.SortOrder,
                Id = entity.Id,
                HomeLocation = entity.HomeLocation,
                FullName = entity.FullName,
                Video = entity.Video,
                MapLink = entity.MapLink


            }));

            return new PagedList<EstatePropertyDto>(source: dataitem, pageIndex: paggedData.PageIndex,
                                            pageSize: paggedData.PageSize, filteredCount: paggedData.FilteredCount, totalCount:
                                            paggedData.TotalCount);

        }

        public async Task<PagedList<EstatePropertyDto>> GetAllPropertyByUserId(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, string username = null)
        {
            List<EstatePropertyDto> dataitem = new List<EstatePropertyDto>();
            var paggedData = await _propertyRepository.GetAsyncByUserId(status, dateStart, dateEnd, startIndex, count, searchString, username);

            var paggedSource = paggedData.Source.ToList();


            dataitem.AddRange(paggedSource.Select(entity => new EstatePropertyDto()
            {
                PropertyName = entity.PropertyName,
                Description = entity.Description,
                AgentDetails = entity.AgentDetails,
                Longitude = entity.Longitude,
                Latitude = entity.Latitude,
                Amount = entity.Amount,
                PropertyProfile = entity.PropertyProfile,
                PropertyType = entity.PropertyType,
                PropertyStatus = entity.PropertyStatus,
                VerificationStatus = entity.VerificationStatus,
                DescriptiveStatus = entity.DescriptiveStatus,
                PropertyAddress = entity.PropertyAddress,
                DateCreated = entity.DateCreated,
                IdentificationNumber = entity.IdentificationNumber,
                State = entity.State,
                LGA = entity.LGA,
                Community = entity.Community,
                Kindred = entity.Kindred,
                SortOrder = entity.SortOrder,
                Id = entity.Id,
                HomeLocation = entity.HomeLocation,
                FullName = entity.FullName,
                MapLink = entity.MapLink


            }));

            return new PagedList<EstatePropertyDto>(source: dataitem, pageIndex: paggedData.PageIndex,
                                            pageSize: paggedData.PageSize, filteredCount: paggedData.FilteredCount, totalCount:
                                            paggedData.TotalCount);

        }


        public async Task Update(EstatePropertyDto entity)
        {
            try
            {

                var data = new EstateProperty
                {
                    Id = entity.Id,
                    PropertyName = entity.PropertyName,
                    Description = entity.Description,
                    AgentDetails = entity.AgentDetails,
                    Longitude = entity.Longitude,
                    Latitude = entity.Latitude,
                    Amount = entity.Amount,
                    PropertyProfile = entity.PropertyProfile,
                    PropertyType = entity.PropertyType,
                    PropertyStatus = entity.PropertyStatus,
                    VerificationStatus = entity.VerificationStatus,
                    DescriptiveStatus = entity.DescriptiveStatus,
                    PropertyAddress = entity.PropertyAddress,
                    DateCreated = entity.DateCreated,
                    IdentificationNumber = entity.IdentificationNumber,
                    State = entity.State,
                    LGA = entity.LGA,
                    Community = entity.Community,
                    Kindred = entity.Kindred,
                    SortOrder = entity.SortOrder,
                    HomeLocation = entity.HomeLocation,
                    Username = entity.Username,
                    Video = entity.Video,
                    MapLink = entity.MapLink

                };

                await _propertyRepository.Update(data);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
