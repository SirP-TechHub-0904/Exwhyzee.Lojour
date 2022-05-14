
using Exwhyzee.Lojour.Core.MeritCertificate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.MeritCertificate
{
   public interface IMeritCertificateRepository
    {
        Task<long> Insert(MeritCertificateModel map);
        Task<MeritCertificateModel> GetById(long Id);

        Task Delete(long Id);

        Task Update(MeritCertificateModel entity);


        Task<PagedList<MeritCertificateModel>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null);

    }
}
