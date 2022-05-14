using Exwhyzee.Lojour.Core.MeritCertificate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.MeritCertificate
{
   public interface IMeritCertificateAppService
    {
        Task<long> Insert(MeritCertificateModel map);
        Task<MeritCertificateModel> GetById(long Id);

        Task<PagedList<MeritCertificateModel>> GetAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

        Task Delete(long Id);

        Task Update(MeritCertificateModel entity);

    }
}
