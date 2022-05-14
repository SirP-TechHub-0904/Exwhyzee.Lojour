using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exwhyzee.Lojour.Core.MeritCertificate
{
  public class MeritCertificateModel
    {
        public long Id { get; set; }

        public string Title { get; set; }

        [Display(Name = "Start Date")]
        public string StartDate { get; set; }

        public long UserProfileId { get; set; }

    }
}
