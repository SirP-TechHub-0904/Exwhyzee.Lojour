
using Exwhyzee.Lojour.Core.PropertyFeatures;
using Exwhyzee.Lojour.Data.Repository.PropertyFeatures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.PropertyFeatures
{
   public class PropertyFeaturesAppService : IPropertyFeaturesAppService
    {
        private IPropertyFeaturesRepository _propertyFeaturesRepository;
        public PropertyFeaturesAppService(IPropertyFeaturesRepository propertyFeaturesRepository)
        {
            _propertyFeaturesRepository = propertyFeaturesRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _propertyFeaturesRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PropertyFeature> GetById(long Id)
        {
            try
            {
                return await _propertyFeaturesRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(PropertyFeature entity)
        {
            var data = new PropertyFeature
            {

                Name = entity.Name,
                PropertyId = entity.PropertyId
                

            };

            return await _propertyFeaturesRepository.Insert(data);
        }


        public async Task<PagedList<PropertyFeature>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long propertyId = 0)
        {
            List<PropertyFeature> data = new List<PropertyFeature>();
            var paggeddatas = await _propertyFeaturesRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString, propertyId);

            var paggedSource = paggeddatas;

            return new PagedList<PropertyFeature>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }


    }
}
