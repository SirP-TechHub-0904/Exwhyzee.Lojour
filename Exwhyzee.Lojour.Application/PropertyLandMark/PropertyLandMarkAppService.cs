
using Exwhyzee.Lojour.Application.PropertyLandMark;
using Exwhyzee.Lojour.Core.PropertyLandMarks;
using Exwhyzee.Lojour.Data.Repository.PropertyFeatures;
using Exwhyzee.Lojour.Data.Repository.PropertyLandMark;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.PropertyFeatures
{
   public class PropertyLandMarkAppService : IPropertyLandMarkAppService
    {
        private IPropertyLandMarksRepository _propertyLandMarksRepository;
        public PropertyLandMarkAppService(IPropertyLandMarksRepository propertyLandMarksRepository)
        {
            _propertyLandMarksRepository = propertyLandMarksRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _propertyLandMarksRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PropertyLandMarks> GetById(long Id)
        {
            try
            {
                return await _propertyLandMarksRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(PropertyLandMarks entity)
        {
            var data = new PropertyLandMarks
            {

                Name = entity.Name,
                Distance = entity.Distance,
                LandMarkType = entity.LandMarkType,
                PropertyId = entity.PropertyId
                

            };

            return await _propertyLandMarksRepository.Insert(data);
        }


        public async Task<PagedList<PropertyLandMarks>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long propertyId = 0)
        {
            List<PropertyLandMarks> data = new List<PropertyLandMarks>();
            var paggeddatas = await _propertyLandMarksRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString, propertyId);

            var paggedSource = paggeddatas;

            return new PagedList<PropertyLandMarks>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }


    }
}
