
using Exwhyzee.Lojour.Core.MeritCertificateFeature;
using Exwhyzee.Lojour.Data.Repository.MeritCertificateFeature;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.MeritCertificateFeature
{

    public class MeritCertificateFeatureAppService : IMeritCertificateFeatureAppService
    {
        private IMeritCertificateFeatureRepository _meritCertificateFeatureRepository;
        public MeritCertificateFeatureAppService(IMeritCertificateFeatureRepository meritCertificateFeatureRepository)
        {
            _meritCertificateFeatureRepository = meritCertificateFeatureRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _meritCertificateFeatureRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MeritCertificateFeatureModel> GetById(long Id)
        {
            try
            {
                return await _meritCertificateFeatureRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(MeritCertificateFeatureModel entity)
        {

            return await _meritCertificateFeatureRepository.Insert(entity);
        }


        public async Task<PagedList<MeritCertificateFeatureModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null)
        {
            List<MeritCertificateFeatureModel> data = new List<MeritCertificateFeatureModel>();
            var paggeddatas = await _meritCertificateFeatureRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString, userProfileId);

            var paggedSource = paggeddatas;

            return new PagedList<MeritCertificateFeatureModel>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }

        public async Task Update(MeritCertificateFeatureModel entity)
        {
            try
            {



                await _meritCertificateFeatureRepository.Update(entity);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
