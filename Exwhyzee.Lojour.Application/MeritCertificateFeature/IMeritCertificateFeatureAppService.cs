using Exwhyzee.Lojour.Core.MeritCertificateFeature;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.MeritCertificateFeature
{
   public interface IMeritCertificateFeatureAppService
    {
        Task<long> Insert(MeritCertificateFeatureModel map);
        Task<MeritCertificateFeatureModel> GetById(long Id);

        Task<PagedList<MeritCertificateFeatureModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

        Task Delete(long Id);

        Task Update(MeritCertificateFeatureModel entity);

    }
}
