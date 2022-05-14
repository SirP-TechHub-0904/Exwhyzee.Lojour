using System;
using System.Collections.Generic;
using System.Text;

namespace Exwhyzee.Lojour.Core.MeritCertificateFeature
{
  public class MeritCertificateFeatureModel
    {
        public long Id { get; set; }
        public string Feature { get; set; }

        public long MeritCertificateId { get; set; }

    }
}
