
using Exwhyzee.Lojour.Core.MeritCertificateFeature;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.MeritCertificateFeature
{
   public interface IMeritCertificateFeatureRepository
    {
        Task<long> Insert(MeritCertificateFeatureModel map);
        Task<MeritCertificateFeatureModel> GetById(long Id);

        Task Delete(long Id);

        Task Update(MeritCertificateFeatureModel entity);


        Task<PagedList<MeritCertificateFeatureModel>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? meritCertificateId = null);

    }
}
