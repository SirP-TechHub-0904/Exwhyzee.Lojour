
using Exwhyzee.Lojour.Core.MeritCertificate;
using Exwhyzee.Lojour.Data.Repository.MeritCertificate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.MeritCertificate
{

    public class MeritCertificateAppService : IMeritCertificateAppService
    {
        private IMeritCertificateRepository _meritCertificateRepository;
        public MeritCertificateAppService(IMeritCertificateRepository meritCertificateRepository)
        {
            _meritCertificateRepository = meritCertificateRepository;
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _meritCertificateRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MeritCertificateModel> GetById(long Id)
        {
            try
            {
                return await _meritCertificateRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(MeritCertificateModel entity)
        {

            return await _meritCertificateRepository.Insert(entity);
        }


        public async Task<PagedList<MeritCertificateModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null)
        {
            List<MeritCertificateModel> data = new List<MeritCertificateModel>();
            var paggeddatas = await _meritCertificateRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString, userProfileId);

            var paggedSource = paggeddatas;

            return new PagedList<MeritCertificateModel>(source: paggeddatas.Source, pageIndex: paggeddatas.PageIndex,
                                            pageSize: paggeddatas.PageSize, filteredCount: paggeddatas.FilteredCount, totalCount:
                                            paggeddatas.TotalCount);


        }

        public async Task Update(MeritCertificateModel entity)
        {
            try
            {



                await _meritCertificateRepository.Update(entity);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
